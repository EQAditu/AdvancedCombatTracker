using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

[assembly: AssemblyTitle("Damage Taken Per Second")]
[assembly: AssemblyDescription("Creates incremental and on-demand calculations of damage taken per second (in the last XX seconds)")]
[assembly: AssemblyCompany("EQAditu")]
[assembly: AssemblyVersion("1.0.0.2")]

namespace ACT_Plugin
{
	public class DTakenPSCalcs : IActPluginV1
	{
		Label lblStatus;    // The status label that appears in ACT's Plugin tab
		List<int> incDamageTypes = new List<int>();
		const string tagName = "DamageTakenPerSecond";

		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			lblStatus = pluginStatusText;   // Hand the status label's reference to our local var

			#region Incremental setup
			// Gather all swingtypes that can be sorted into Incoming Damage
			foreach (KeyValuePair<int, List<string>> pair in CombatantData.SwingTypeToDamageTypeDataLinksIncoming)
			{
				foreach (string damageTypeLabel in pair.Value)
				{
					if (damageTypeLabel == CombatantData.DamageTypeDataIncomingDamage)
					{
						if (!incDamageTypes.Contains(pair.Key))
							incDamageTypes.Add(pair.Key);
					}
				}
			}
			ActGlobals.oFormActMain.AfterCombatAction += new CombatActionDelegate(oFormActMain_AfterCombatAction);
			#endregion
			CreateDTakenPSIncrementalColumns();

			CreateDTakenPSOnDemandColumns();

			lblStatus.Text = "Plugin Started";
		}

		public void DeInitPlugin()
		{
			// Unsubscribe from any events you listen to when exiting!
			ActGlobals.oFormActMain.AfterCombatAction -= oFormActMain_AfterCombatAction;

			lblStatus.Text = "Plugin Exited";
		}
		private string GetFloatCommas()
		{
			return ActGlobals.mainTableShowCommas ? "#,0.00" : "0.00";
		}

		#region Incremental data columns
		void oFormActMain_AfterCombatAction(bool isImport, CombatActionEventArgs actionInfo)
		{
			if (incDamageTypes.Contains(actionInfo.swingType) == false) return;
			if (actionInfo.damage <= 0) return;
			EncounterData activeEncounter = ActGlobals.oFormActMain.ActiveZone.Items[ActGlobals.oFormActMain.ActiveZone.Items.Count - 1];
			CombatantData combatant = activeEncounter.GetCombatant(actionInfo.victim);

			SortedList<DateTime, long> damagePerSecond;
			if (combatant.Tags.ContainsKey(tagName))
			{
				damagePerSecond = (SortedList<DateTime, long>)combatant.Tags[tagName];
			}
			else
			{
				damagePerSecond = new SortedList<DateTime, long>();
				combatant.Tags.Add(tagName, damagePerSecond);
			}

			if (damagePerSecond.ContainsKey(actionInfo.time))
			{
				damagePerSecond[actionInfo.time] += actionInfo.damage;
			}
			else
			{
				damagePerSecond.Add(actionInfo.time, actionInfo.damage);
			}
		}
		private void CreateDTakenPSIncrementalColumns()
		{
			CultureInfo usCulture = new CultureInfo("en-US");   // This is for SQL syntax; do not change
			CombatantData.ColumnDef encounterDamageTakenPerSecond = new CombatantData.ColumnDef("EncDTakenPS", false, // Default not visible
				"BIGINT", "EncDTakenPS",                                                                        // SQL Exporting Stuff
				(Data) => (Data.DamageTaken / Data.Parent.Duration.TotalSeconds).ToString(GetFloatCommas()),    // Main Table Cell Data
				(Data) => (Data.DamageTaken / Data.Parent.Duration.TotalSeconds).ToString(usCulture),           // SQL Compatible Data
				(Left, Right) => Left.DamageTaken.CompareTo(Right.DamageTaken))                                 // Sorting comparison
			{
				GetCellForeColor = (Data) => Color.DarkOrange                   // Always color the text this color regardless of Data
			};

			CombatantData.ColumnDef encounterDamageTakenPerSecondLast60 = new CombatantData.ColumnDef("EncDTakenPS-60", false, // Default not visible
				"BIGINT", "EncDTakenPSL60",                                                // SQL Exporting Stuff
				(Data) => DTakenPSIncremental(Data, 60).ToString(GetFloatCommas()),     // Main Table Cell Data
				(Data) => DTakenPSIncremental(Data, 60).ToString(usCulture),            // SQL Compatible Data
				(Left, Right) => Left.DamageTaken.CompareTo(Right.DamageTaken))             // Sorting comparison
			{
				GetCellForeColor = (Data) => Color.DarkOrange                               // Always color the text this color regardless of Data
			};
			CombatantData.ColumnDef encounterDamageTakenPerSecondLast10 = new CombatantData.ColumnDef("EncDTakenPS-10", false, // Default not visible
				"BIGINT", "EncDTakenPSL10",                                                // SQL Exporting Stuff
				(Data) => DTakenPSIncremental(Data, 10).ToString(GetFloatCommas()),     // Main Table Cell Data
				(Data) => DTakenPSIncremental(Data, 10).ToString(usCulture),            // SQL Compatible Data
				(Left, Right) => Left.DamageTaken.CompareTo(Right.DamageTaken))             // Sorting comparison
			{
				GetCellForeColor = (Data) => Color.DarkOrange                               // Always color the text this color regardless of Data
			};

			CombatantData.ColumnDefs.Add("EncDTakenPS", encounterDamageTakenPerSecond);
			CombatantData.ColumnDefs.Add("EncDTakenPS-60", encounterDamageTakenPerSecondLast60);
			CombatantData.ColumnDefs.Add("EncDTakenPS-10", encounterDamageTakenPerSecondLast10);
		}
		/// <summary>
		/// Gets the sum of damage taken in the last XX seconds of an encounter and returns a DPS value
		/// </summary>
		/// <param name="Data">Combatant receiving damage</param>
		/// <param name="Seconds">The number of seconds to include from the end.  Or zero(0) to include all.</param>
		/// <returns>Encounter Damage Taken Per Second in the last Seconds for a Combatant</returns>
		private double DTakenPSIncremental(CombatantData Data, int Seconds)
		{
			double rSecs = (Seconds > Data.Parent.Duration.TotalSeconds) ? Data.Parent.Duration.TotalSeconds : Seconds;   // If the encounter duration is less than (Seconds), use that duration instead
			DateTime cutoff = Data.Parent.EndTime - TimeSpan.FromSeconds(rSecs);
			long totalDamage = 0;
			if (Data.Tags.ContainsKey(tagName))
			{
				SortedList<DateTime, long> dps = (SortedList<DateTime, long>)Data.Tags[tagName];
				for (int i = dps.Count - 1; i >= 0; i--)
				{
					if (dps.Keys[i] >= cutoff)
					{
						totalDamage += dps.Values[i];
					}
					else
						break;
				}
			}

			double encDTakenPS = totalDamage / rSecs;
			return encDTakenPS;
		}
		#endregion

		#region On-demand method columns
		private void CreateDTakenPSOnDemandColumns()
		{
			CultureInfo usCulture = new CultureInfo("en-US");   // This is for SQL syntax; do not change

			CombatantData.ColumnDef encounterDamageTakenPerSecondLast60 = new CombatantData.ColumnDef("ODEncDTakenPS-60", false, // Default not visible
				"BIGINT", "ODEncDTakenPSL60",                                                                     // SQL Exporting Stuff
				(Data) => DTakenPSOnDemand(Data, 60).ToString(GetFloatCommas()),                     // Main Table Cell Data
				(Data) => DTakenPSOnDemand(Data, 60).ToString(usCulture),                            // SQL Compatible Data
				(Left, Right) => Left.DamageTaken.CompareTo(Right.DamageTaken))                                 // Sorting comparison
			{
				GetCellForeColor = (Data) => Color.DarkOrange                   // Always color the text this color regardless of Data
			};
			CombatantData.ColumnDef encounterDamageTakenPerSecondLast10 = new CombatantData.ColumnDef("ODEncDTakenPS-10", false, // Default not visible
				"BIGINT", "ODEncDTakenPSL10",                                                                     // SQL Exporting Stuff
				(Data) => DTakenPSOnDemand(Data, 10).ToString(GetFloatCommas()),                     // Main Table Cell Data
				(Data) => DTakenPSOnDemand(Data, 10).ToString(usCulture),                            // SQL Compatible Data
				(Left, Right) => Left.DamageTaken.CompareTo(Right.DamageTaken))                                 // Sorting comparison
			{
				GetCellForeColor = (Data) => Color.DarkOrange                   // Always color the text this color regardless of Data
			};

			CombatantData.ColumnDefs.Add("ODEncDTakenPS-60", encounterDamageTakenPerSecondLast60);
			CombatantData.ColumnDefs.Add("ODEncDTakenPS-10", encounterDamageTakenPerSecondLast10);
		}
		/// <summary>
		/// Gets the sum of damage taken in the last XX seconds of an encounter and returns a DPS value
		/// </summary>
		/// <param name="Data">Combatant receiving damage</param>
		/// <param name="Seconds">The number of seconds to include from the end.  Or zero(0) to include all.</param>
		/// <returns>Encounter Damage Taken Per Second in the last Seconds for a Combatant</returns>
		private double DTakenPSOnDemand(CombatantData Data, int Seconds)
		{
			AttackType at;
			if (Data.Items[CombatantData.DamageTypeDataIncomingDamage].Items.TryGetValue(ActGlobals.ActLocalization.LocalizationStrings["attackTypeTerm-all"].DisplayedText, out at))
			{
				if (Data.Tags.ContainsKey("DTakenCount|Duration"))  // Check if ever cached
				{
					if ((string)Data.Tags["DTakenCount|Duration"] == $"{at.Items.Count}|{Data.Parent.DurationS}")   // Check if the cached value matches current totals
					{
						if (Data.Tags.ContainsKey($"DamageTakenPSInLast|{Seconds}"))    // Check if there is a cached version for last XX seconds
							return (double)Data.Tags[$"DamageTakenPSInLast|{Seconds}"];
					}
				}

				Stopwatch sw = new Stopwatch();
				sw.Start();

				double rSecs = (Seconds > Data.Parent.Duration.TotalSeconds) ? Data.Parent.Duration.TotalSeconds : Seconds;   // If the encounter duration is less than (Seconds), use that duration instead
				TimeSpan tsSecs = TimeSpan.FromSeconds(rSecs);
				long totalDamage = 0;
				foreach (MasterSwing ms in at.Items)
				{
					if (ms.Time >= Data.Parent.EndTime - tsSecs || Seconds == 0)    // if the MasterSwing's time falls in the timeframe of the end-(Seconds)
					{
						totalDamage += ms.Damage;
					}
				}
				double encDTakenPS = totalDamage / rSecs;

				ActGlobals.oFormActMain.WriteDebugLog($"DamageTakenPSInLast {Data.Name} {sw.ElapsedMilliseconds}");

				// Create our cache entries
				if (Data.Tags.ContainsKey("DTakenCount|Duration"))
				{
					Data.Tags["DTakenCount|Duration"] = $"{at.Items.Count}|{Data.Parent.DurationS}";
					Data.Tags[$"DamageTakenPSInLast|{Seconds}"] = encDTakenPS;
				}
				else
				{
					Data.Tags.Add("DTakenCount|Duration", $"{at.Items.Count}|{Data.Parent.DurationS}");
					Data.Tags.Add($"DamageTakenPSInLast|{Seconds}", encDTakenPS);
				}
				return encDTakenPS;
			}
			else
				return 0;
		}
		#endregion
	}
}
