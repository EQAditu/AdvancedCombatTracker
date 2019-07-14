using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

[assembly: AssemblyTitle("German Parsing Engine")]
[assembly: AssemblyDescription("Plugin based parsing engine for German EQ2 servers")]
[assembly: AssemblyCompany("Aditu of Skyfire")]
[assembly: AssemblyVersion("1.1.0.6")]

// TODO: Needs QuickFail implementation

namespace ACT_Plugin
{
	public class ACT_German_Parser : UserControl, IActPluginV1
	{
		#region Designer Created Code (Avoid editing)
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private CheckBox cbGermanMergeNames;
		private CheckBox cbSwarmIsMaster;
		private CheckBox cbMultiDamageIsOne;
		private CheckBox cbSParseConsider;
		private CheckBox cbIncludeInterceptFocus;
		private CheckBox cbRecalcWardedHits;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cbGermanMergeNames = new System.Windows.Forms.CheckBox();
			this.cbSwarmIsMaster = new System.Windows.Forms.CheckBox();
			this.cbRecalcWardedHits = new System.Windows.Forms.CheckBox();
			this.cbMultiDamageIsOne = new System.Windows.Forms.CheckBox();
			this.cbSParseConsider = new System.Windows.Forms.CheckBox();
			this.cbIncludeInterceptFocus = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// cbGermanMergeNames
			// 
			this.cbGermanMergeNames.AutoSize = true;
			this.cbGermanMergeNames.Checked = true;
			this.cbGermanMergeNames.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbGermanMergeNames.Location = new System.Drawing.Point(14, 17);
			this.cbGermanMergeNames.Name = "cbGermanMergeNames";
			this.cbGermanMergeNames.Size = new System.Drawing.Size(286, 17);
			this.cbGermanMergeNames.TabIndex = 0;
			this.cbGermanMergeNames.Text = "Merge combatants with similar names.  (Not retroactive)";
			this.cbGermanMergeNames.UseVisualStyleBackColor = true;
			this.cbGermanMergeNames.MouseHover += new System.EventHandler(this.cbGermanMergeNames_MouseHover);
			// 
			// cbSwarmIsMaster
			// 
			this.cbSwarmIsMaster.AutoSize = true;
			this.cbSwarmIsMaster.Checked = true;
			this.cbSwarmIsMaster.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSwarmIsMaster.Location = new System.Drawing.Point(14, 38);
			this.cbSwarmIsMaster.Name = "cbSwarmIsMaster";
			this.cbSwarmIsMaster.Size = new System.Drawing.Size(305, 17);
			this.cbSwarmIsMaster.TabIndex = 1;
			this.cbSwarmIsMaster.Text = "Merge pet attacks into their master\'s data.  (Not retroactive)";
			this.cbSwarmIsMaster.UseVisualStyleBackColor = true;
			this.cbSwarmIsMaster.MouseHover += new System.EventHandler(this.cbSwarmIsMaster_MouseHover);
			// 
			// cbRecalcWardedHits
			// 
			this.cbRecalcWardedHits.AutoSize = true;
			this.cbRecalcWardedHits.Checked = true;
			this.cbRecalcWardedHits.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbRecalcWardedHits.Location = new System.Drawing.Point(14, 59);
			this.cbRecalcWardedHits.Name = "cbRecalcWardedHits";
			this.cbRecalcWardedHits.Size = new System.Drawing.Size(287, 17);
			this.cbRecalcWardedHits.TabIndex = 2;
			this.cbRecalcWardedHits.Text = "Recalc warded hits to their true value.  (Not retroactive)";
			this.cbRecalcWardedHits.UseVisualStyleBackColor = true;
			this.cbRecalcWardedHits.MouseHover += new System.EventHandler(this.cbRecalcWardedHits_MouseHover);
			// 
			// cbMultiDamageIsOne
			// 
			this.cbMultiDamageIsOne.AutoSize = true;
			this.cbMultiDamageIsOne.Checked = true;
			this.cbMultiDamageIsOne.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbMultiDamageIsOne.Location = new System.Drawing.Point(14, 80);
			this.cbMultiDamageIsOne.Name = "cbMultiDamageIsOne";
			this.cbMultiDamageIsOne.Size = new System.Drawing.Size(414, 17);
			this.cbMultiDamageIsOne.TabIndex = 3;
			this.cbMultiDamageIsOne.Text = "Record a single log line with multiple damage types as a single hit. (Not retroac" +
	"tive)";
			this.cbMultiDamageIsOne.UseVisualStyleBackColor = true;
			this.cbMultiDamageIsOne.MouseHover += new System.EventHandler(this.cbMultiDamageIsOne_MouseHover);
			// 
			// cbSParseConsider
			// 
			this.cbSParseConsider.AutoSize = true;
			this.cbSParseConsider.Checked = true;
			this.cbSParseConsider.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSParseConsider.Location = new System.Drawing.Point(14, 101);
			this.cbSParseConsider.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.cbSParseConsider.Name = "cbSParseConsider";
			this.cbSParseConsider.Size = new System.Drawing.Size(479, 17);
			this.cbSParseConsider.TabIndex = 9;
			this.cbSParseConsider.Text = "Add characters marked by the /con, /whogroup, /whoraid command to the Selective P" +
	"arsing list";
			this.cbSParseConsider.MouseHover += new System.EventHandler(this.cbSParseConsider_MouseHover);
			// 
			// cbIncludeInterceptFocus
			// 
			this.cbIncludeInterceptFocus.AutoSize = true;
			this.cbIncludeInterceptFocus.Location = new System.Drawing.Point(14, 122);
			this.cbIncludeInterceptFocus.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.cbIncludeInterceptFocus.Name = "cbIncludeInterceptFocus";
			this.cbIncludeInterceptFocus.Size = new System.Drawing.Size(466, 17);
			this.cbIncludeInterceptFocus.TabIndex = 19;
			this.cbIncludeInterceptFocus.Text = "Parse focus damage done to channeler pets. (Skews attacker DPS/ToHit%, Not Retroa" +
	"ctive)";
			this.cbIncludeInterceptFocus.MouseHover += new System.EventHandler(this.cbIncludeInterceptFocus_MouseHover);
			// 
			// ACT_German_Parser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cbIncludeInterceptFocus);
			this.Controls.Add(this.cbSParseConsider);
			this.Controls.Add(this.cbMultiDamageIsOne);
			this.Controls.Add(this.cbRecalcWardedHits);
			this.Controls.Add(this.cbSwarmIsMaster);
			this.Controls.Add(this.cbGermanMergeNames);
			this.Name = "ACT_German_Parser";
			this.Size = new System.Drawing.Size(546, 179);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion


		#endregion
		public ACT_German_Parser()
		{
			InitializeComponent();
		}

		Label lblStatus;    // The status label that appears in ACT's Plugin tab
		string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\ACT_German_Parser.config.xml");
		SettingsSerializer xmlSettings;
		TreeNode optionsNode = null;

		#region IActPluginV1 Members
		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			lblStatus = pluginStatusText;   // Hand the status label's reference to our local var
			pluginScreenSpace.Controls.Add(this);
			this.Dock = DockStyle.Fill;

			int dcIndex = -1;   // Find the Data Correction node in the Options tab
			for (int i = 0; i < ActGlobals.oFormActMain.OptionsTreeView.Nodes.Count; i++)
			{
				if (ActGlobals.oFormActMain.OptionsTreeView.Nodes[i].Text == "Data Correction")
					dcIndex = i;
			}
			if (dcIndex != -1)
			{
				// Add our own node to the Data Correction node
				optionsNode = ActGlobals.oFormActMain.OptionsTreeView.Nodes[dcIndex].Nodes.Add("EQ2 German Settings");
				// Register our user control(this) to our newly create node path.  All controls added to the list will be laid out left to right, top to bottom
				ActGlobals.oFormActMain.OptionsControlSets.Add(@"Data Correction\EQ2 German Settings", new List<Control> { this });
				Label lblConfig = new Label();
				lblConfig.AutoSize = true;
				lblConfig.Text = "Find the applicable options in the Options tab, Data Correction section.";
				pluginScreenSpace.Controls.Add(lblConfig);
			}

			xmlSettings = new SettingsSerializer(this); // Create a new settings serializer and pass it this instance
			LoadSettings();

			PopulateRegexArray();
			SetupEQ2EnglishEnvironment();
			ActGlobals.oFormActMain.BeforeLogLineRead += new LogLineEventDelegate(oFormActMain_BeforeLogLineRead);
			ActGlobals.oFormActMain.BeforeCombatAction += new CombatActionDelegate(oFormActMain_BeforeCombatAction);
			ActGlobals.oFormActMain.AfterCombatAction += new CombatActionDelegate(oFormActMain_AfterCombatAction);
			ActGlobals.oFormActMain.UpdateCheckClicked += new FormActMain.NullDelegate(oFormActMain_UpdateCheckClicked);
			ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(oFormActMain_OnLogLineRead);
			if (ActGlobals.oFormActMain.GetAutomaticUpdatesAllowed())   // If ACT is set to automatically check for updates, check for updates to the plugin
				new Thread(new ThreadStart(oFormActMain_UpdateCheckClicked)).Start();   // If we don't put this on a separate thread, web latency will delay the plugin init phase
			lblStatus.Text = "Plugin Started";
		}

		public void DeInitPlugin()
		{
			ActGlobals.oFormActMain.BeforeLogLineRead -= oFormActMain_BeforeLogLineRead;
			ActGlobals.oFormActMain.BeforeCombatAction -= oFormActMain_BeforeCombatAction;
			ActGlobals.oFormActMain.AfterCombatAction -= oFormActMain_AfterCombatAction;
			ActGlobals.oFormActMain.UpdateCheckClicked -= oFormActMain_UpdateCheckClicked;
			ActGlobals.oFormActMain.OnLogLineRead -= oFormActMain_OnLogLineRead;

			if (optionsNode != null)    // If we added our user control to the Options tab, remove it
			{
				optionsNode.Remove();
				ActGlobals.oFormActMain.OptionsControlSets.Remove(@"Data Correction\EQ2 German Settings");
			}

			SaveSettings();
			lblStatus.Text = "Plugin Exited";
		}
		#endregion
		void oFormActMain_UpdateCheckClicked()
		{
			int pluginId = 54;
			try
			{
				DateTime localDate = ActGlobals.oFormActMain.PluginGetSelfDateUtc(this);
				DateTime remoteDate = ActGlobals.oFormActMain.PluginGetRemoteDateUtc(pluginId);
				if (localDate.AddHours(2) < remoteDate)
				{
					DialogResult result = MessageBox.Show("There is an updated version of the EQ2 German Parsing Plugin.  Update it now?\n\n(If there is an update to ACT, you should click No and update ACT first.)", "New Version", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (result == DialogResult.Yes)
					{
						FileInfo updatedFile = ActGlobals.oFormActMain.PluginDownload(pluginId);
						ActPluginData pluginData = ActGlobals.oFormActMain.PluginGetSelfData(this);
						pluginData.pluginFile.Delete();
						updatedFile.MoveTo(pluginData.pluginFile.FullName);
						ThreadInvokes.CheckboxSetChecked(ActGlobals.oFormActMain, pluginData.cbEnabled, false);
						Application.DoEvents();
						ThreadInvokes.CheckboxSetChecked(ActGlobals.oFormActMain, pluginData.cbEnabled, true);
					}
				}
			}
			catch (Exception ex)
			{
				ActGlobals.oFormActMain.WriteExceptionLog(ex, "Plugin Update Check");
			}
		}

		#region Parsing
		Regex[] regexArray;
		const string logTimeStampRegexStr = @"\(\d{10}\)\[.{24}\] ";
		SortedDictionary<string, string> germanShortToLong = new SortedDictionary<string, string>();
		SortedDictionary<string, string> germanLongToShort = new SortedDictionary<string, string>();
		DateTime lastWardTime = DateTime.MinValue;
		long lastWardAmount = 0;
		string lastWardedTarget = string.Empty;
		DateTime lastInterceptTime = DateTime.MinValue;
		long lastInterceptAmount = 0;
		string lastInterceptTarget = string.Empty;
		string lastIntercepter = string.Empty;
		Regex mobLocSplit = new Regex("(?<mob>.+?) in .+", RegexOptions.Compiled);
		Regex regexWhogroup = new Regex(logTimeStampRegexStr + @"(?<name>[^ ]+) Lvl \d+ .+", RegexOptions.Compiled);
		Regex regexWhoraid = new Regex(logTimeStampRegexStr + @"\[\d+ [^\]]+\] (?<name>[^ ]+) \([^\)]+\)", RegexOptions.Compiled);
		Regex regexConsider = new Regex(logTimeStampRegexStr + @".+?Ihr visiert folgendes Ziel an: (?<player>.+?) \.\.\..+", RegexOptions.Compiled);
		CombatActionEventArgs lastDamage = null;


		private void PopulateRegexArray()
		{
			regexArray = new Regex[14];
			regexArray[0] = new Regex(logTimeStampRegexStr + @"(?<victim>.+?) wird von EUCH getroffen und nimmt (?<damageAndType>.+?)-Schaden\. \((?<special>.+)\)", RegexOptions.Compiled);
			regexArray[1] = new Regex(logTimeStampRegexStr + @"(?<attacker>.+?) (?:versucht )?versucht ?(?:, )?(?<victimAndSkill>.+?) ?zu (?<attackType>[^.]+?), (?<why>.+)\.(?: \((?<special>.+)\))?", RegexOptions.Compiled);
			regexArray[2] = new Regex(logTimeStampRegexStr + @"(?:Der Zauber ""(?<attackType>.+?)"" von (?<healer>.+?)|(?:\\Des\()?(?<healer>.+?)(?:\))? (?:Zauber )?""(?<attackType>.+?)"") (?:ermutigt|heilt) (?:\\den\()?(?<victim>.+?)(?:\))? ?(?<crit>kritisch )?(?:f.r|mit) (?<damage>\d+) Trefferpunkt(?: \((?<critStr>.+)\))?\..*", RegexOptions.Compiled);
			regexArray[3] = new Regex(logTimeStampRegexStr + @"(?<healer>.+?) (?:Zauber )?""(?<healType>.+?)"" absorbiert (?<damage>\d+) Schadens Punkte? ?, der (?<victim>.+?) zugef.gt wurde\.", RegexOptions.Compiled);
			regexArray[4] = new Regex(logTimeStampRegexStr + @"(?:Der Zauber ""(?<attacktype>.+?)"" von (?<attacker>.+?)|(?<attacker>\w+) ZAUBER ""(?<attacktype>.+?)"") trifft (?<victim>.+?) und entzieht (?<damage>\d+) Punkte? Kraft\.(?: ?\((?<crit>.+)\))?", RegexOptions.Compiled);
			regexArray[5] = new Regex(logTimeStampRegexStr + @"(?<attacker>.+?) hat (?<victim>.+) get.?tet\.", RegexOptions.Compiled);
			regexArray[6] = new Regex(logTimeStampRegexStr + "Nutzerbefehl: \"act (.+)\"", RegexOptions.Compiled);
			regexArray[7] = new Regex(logTimeStampRegexStr + @"You have entered (?::.+?:)?(?<zone>.+)\.", RegexOptions.Compiled);
			regexArray[8] = new Regex(logTimeStampRegexStr + @"(?:(?<attacker>.+?) Zauber ""(?<skilltype>.+?)""|Der Zauber ""(?<skilltype>.+?)"" von (?<attacker>.+?)|(?<attacker>.+?) ZAUBER ""(?<skilltype>.+?)""|(?<attacker>.+?)) trifft (?<victim>.+?) und verursacht (?<damageAndType>.+?)-Schaden\.(?: \((?<special>.+)\))?", RegexOptions.Compiled);
			regexArray[9] = new Regex(logTimeStampRegexStr + @"(?<victim>.+?) wird vom Zauber ""(?<skillType>.+?)"" getroffen und nimmt (?<damageAndType>.+?)-Schaden\.(?: \((?<special>.+)\))?", RegexOptions.Compiled);
			regexArray[10] = new Regex(logTimeStampRegexStr + @"(?:Der Zauber ""(?<skillType>.+?)"" von (?<healer>.+?)|(?:\\Des\()?(?<healer>.+?)(?:\))? (?:Zauber )?""(?<skillType>.+?)"") erfrischt (?:\\den\()?(?<victim>.+?)(?:\))? ?(?<crit>kritisch )?(?:f.r|mit:?) (?<damage>\d+) Manapunkte?(?: (?:""(?<critStr2>.+?)"" )?\((?<critStr>.+)\))?\.", RegexOptions.Compiled);
			regexArray[11] = new Regex(logTimeStampRegexStr + @"(?<healer>.+?) Zauber ""(?<skillType>[^""]+)""(?: von (?<healer2>.+?))? befreit (?<victim>.+?) von ""(?<effect>.+)""\..*", RegexOptions.Compiled);
			regexArray[12] = new Regex(logTimeStampRegexStr + @"(?:(?<attacker>EUER) ""(?<skilltype>[^""]+)"" (?<direction>erhöht|steigert kritisch|verringert|senkt kritisch) EUREN? (?:Hass|Hassposition) bei|""(?<skilltype>[^""]+)"" von (?<attacker>.+?) (?<direction>erhöht|steigert kritisch|verringert|senkt kritisch) (?:den|die) eigenen? (?:Hass|Hassposition) bei) (?<victim>.+?)(?: um |\.mit )(?<damage>\d+) (?<dirtype>.+?)(?: \((?<critStr>.+)\))?\.", RegexOptions.Compiled);
			regexArray[13] = new Regex(logTimeStampRegexStr + @"(?<healer>.+?) reduziert? den Schaden von (?<attacker>.+?) gegen (?<victim>.+?) um (?<damage>\d+)\.", RegexOptions.Compiled);
		}
		void oFormActMain_BeforeLogLineRead(bool isImport, LogLineEventArgs logInfo)
		{
			for (int i = 0; i < regexArray.Length; i++)
			{
				Match reMatch = regexArray[i].Match(logInfo.logLine);
				if (reMatch.Success)
				{
					switch (i)
					{
						case 0:
						case 8:
						case 9:
							logInfo.detectedType = Color.Red.ToArgb();
							break;
						case 1:
							logInfo.detectedType = Color.DarkRed.ToArgb();
							break;
						case 2:
							logInfo.detectedType = Color.Blue.ToArgb();
							break;
						case 3:
						case 13:
							logInfo.detectedType = Color.DodgerBlue.ToArgb();
							break;
						case 4:
							logInfo.detectedType = Color.DarkOrchid.ToArgb();
							break;
						default:
							logInfo.detectedType = Color.Black.ToArgb();
							break;
					}
					LogExeGerman(reMatch, i + 1, logInfo.logLine, isImport);
					break;
				}
			}
		}
		void oFormActMain_BeforeCombatAction(bool isImport, CombatActionEventArgs actionInfo)
		{
			// Divine Light
			if (lastDamage != null && lastDamage.victim == actionInfo.attacker && lastDamage.theAttackType == "Divine Light" && lastDamage.theDamageType.Contains("focus"))
			{
				//
			}
			// Riposte/kontert/отвечает & Relect/отражает
			if (lastDamage != null && lastDamage.time == actionInfo.time)
			{
				if ((long)lastDamage.damage == (long)Dnum.Unknown && lastDamage.damage.DamageString.Contains("kontert"))
				{
					if (actionInfo.swingType == (int)SwingTypeEnum.Melee && actionInfo.victim == lastDamage.attacker)
					{
						actionInfo.special = "kontert";
						lastDamage.damage.DamageString2 = String.Format("({0} returned)", actionInfo.damage.ToString());
					}
				}
				if ((long)actionInfo.damage == (long)Dnum.Unknown && actionInfo.damage.DamageString.Contains("reflect"))
				{
					if (actionInfo.theAttackType == lastDamage.theAttackType && actionInfo.victim == lastDamage.attacker)
					{
						//lastDamage.special = "reflect";  // Too late to take effect
						actionInfo.damage.DamageString2 = String.Format(" ({0} returned)", lastDamage.damage.ToString());
					}
				}
			}
		}
		void oFormActMain_AfterCombatAction(bool isImport, CombatActionEventArgs actionInfo)
		{
			if (actionInfo.swingType == (int)SwingTypeEnum.Melee || actionInfo.swingType == (int)SwingTypeEnum.NonMelee)
				lastDamage = actionInfo;
		}
		bool captureWhoraid = false;
		void oFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
		{
			if (cbSParseConsider.Checked)
			{
				if (logInfo.logLine.Contains("/whoraid search results"))
					captureWhoraid = true;
				if (logInfo.logLine.EndsWith("players found"))
					captureWhoraid = false;
				if (captureWhoraid && regexWhoraid.IsMatch(logInfo.logLine))
				{
					string outputName = regexWhoraid.Replace(logInfo.logLine, "$1");
					ActGlobals.oFormActMain.SelectiveListAdd(outputName);
				}
				if (regexWhogroup.IsMatch(logInfo.logLine))
				{
					string outputName = regexWhogroup.Replace(logInfo.logLine, "$1");
					ActGlobals.oFormActMain.SelectiveListAdd(outputName);
				}
				if (regexConsider.IsMatch(logInfo.logLine))
				{
					string outputName = regexConsider.Replace(logInfo.logLine, "$1");
					if (outputName.StartsWith("{f}"))
						outputName = outputName.Substring(3);
					ActGlobals.oFormActMain.SelectiveListAdd(outputName);
					if (!isImport)
						System.Media.SystemSounds.Beep.Play();
				}
			}
		}

		string[] criticalWords = new string[] { "Legendär Kritischer", "Sagenumwoben Kritischer", "Mythisch Kritischer", "kritisch", "Kritischer" };
		string[] criticalWords2 = new string[] { "Legendär", "Sagenumwoben", "Mythisch" };

		private void LogExeGerman(Match reMatch, int logMatched, string logLine, bool isImport)
		{
			logLine = logLine.Replace("\t", string.Empty);

			string attacker, attackType, victim, damage, skillType, why, crit, special, direction;
			string critStr, critStr2;
			bool critical;
			int skillIndex, swarmIndex;
			List<DamageAndType> damageAndTypeArr;
            MasterSwing ms;

			DateTime time = ActGlobals.oFormActMain.LastKnownTime;

			Dnum failType;
			int gts = ActGlobals.oFormActMain.GlobalTimeSorter;

			switch (logMatched)
			{
				#region Case 1 [YOUR melee]
				case 1:
					victim = reMatch.Groups[1].Value;   // Contains the attacker and skillType
					damage = reMatch.Groups[2].Value;
					special = reMatch.Groups[3].Value;

                    critical = false;
                    critStr = "None";
                    foreach (string s in criticalWords)
                    {
                        if (special.Contains(s))
                        {
                            critical = true;
                            special = special.Replace(s, string.Empty);
                            critStr = s;
                            break;
                        }
                    }

                    attacker = ActGlobals.charName;
					victim = GermanPersonaReplace(victim);

					damageAndTypeArr = GerGetDamageAndTypeArr(damage);

					special = special.Trim();
					special = String.IsNullOrEmpty(special) ? "None" : special;
					special = GerGetTrimSpecial(special);

					if (cbGermanMergeNames.Checked)
					{
						victim = FindGermanCombatant(victim);
					}

					if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim))
						AddDamageAttack(attacker, victim, string.Empty, (int)SwingTypeEnum.Melee, critical, critStr, special, damageAndTypeArr, time, gts);
					break;
				#endregion
				#region Case 2 [misses]
				case 2:
					attacker = reMatch.Groups[1].Value;
					victim = reMatch.Groups[2].Value;
					attackType = "melee";
					why = reMatch.Groups[4].Value;
					special = reMatch.Groups[5].Value;
					failType = Dnum.Unknown;
					skillType = string.Empty;

					attacker = GermanPersonaReplace(attacker);

					skillIndex = victim.IndexOf(" mit \"");
					if (skillIndex > -1)
					{
						skillType = victim.Substring(skillIndex + 6, victim.Length - (skillIndex + 7));
						victim = victim.Substring(0, skillIndex);
						attackType = "non-melee";
					}

					victim = GermanPersonaReplace(victim);

					SetFailTypeSpecialGerman(victim, why, ref failType, ref special);
					if (String.IsNullOrEmpty(failType.ToString()))
						failType = new Dnum(Dnum.Unknown, "Unknown Avoid");

					if (String.IsNullOrEmpty(skillType))
					{
						if (cbSwarmIsMaster.Checked)
						{
							swarmIndex = attacker.IndexOf(" des ");
							if (swarmIndex == -1)
								swarmIndex = attacker.IndexOf(" von ");
							if (swarmIndex > -1)
							{
								skillType = GerGetPetSkilltypeString(attacker, skillType, swarmIndex);
								attacker = GerGetPetAttackerString(attacker, swarmIndex);
							}
							if (cbGermanMergeNames.Checked)
							{
								attacker = FindGermanCombatant(attacker);
								victim = FindGermanCombatant(victim);
							}
							if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim))
							{
								if (swarmIndex > -1)
								{
									ActGlobals.oFormActMain.AddCombatAction((int)SwingTypeEnum.NonMelee, false, special, attacker, skillType, failType, time, gts, victim, attackType);
								}
								else
								{
									ActGlobals.oFormActMain.AddCombatAction((int)SwingTypeEnum.Melee, false, special, attacker, attackType, failType, time, gts, victim, attackType);
								}
							}
							break;
						}
						if (cbGermanMergeNames.Checked)
						{
							attacker = FindGermanCombatant(attacker);
							victim = FindGermanCombatant(victim);
						}
						if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim))
						{
							ActGlobals.oFormActMain.AddCombatAction((int)SwingTypeEnum.Melee, false, special, attacker, attackType, failType, time, gts, victim, attackType);
						}
					}
					else
					{
						if (cbSwarmIsMaster.Checked)
						{
							swarmIndex = attacker.IndexOf(" des ");
							if (swarmIndex == -1)
								swarmIndex = attacker.IndexOf(" von ");
							if (swarmIndex > -1)
							{
								skillType = GerGetPetSkilltypeString(attacker, skillType, swarmIndex);
								attacker = GerGetPetAttackerString(attacker, swarmIndex);
							}
						}
						if (cbGermanMergeNames.Checked)
						{
							attacker = FindGermanCombatant(attacker);
							victim = FindGermanCombatant(victim);
						}
						if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim))
						{
							ActGlobals.oFormActMain.AddCombatAction((int)SwingTypeEnum.NonMelee, false, special, attacker, skillType, failType, time, gts, victim, attackType);
						}
					}
					break;
				#endregion
				#region Case 3 [healing]
				case 3:
					if (!ActGlobals.oFormActMain.InCombat)
						break;
					skillType = reMatch.Groups[1].Value;
					attacker = reMatch.Groups[2].Value;
					victim = reMatch.Groups[3].Value;
					crit = reMatch.Groups[4].Value;
					damage = reMatch.Groups[5].Value;
					special = reMatch.Groups[6].Value;


					if (crit.StartsWith("krit"))
						critical = true;
					else
						critical = false;

                    critStr = "None";
                    foreach (string s in criticalWords)
                    {
                        if (special.Contains(s))
                        {
                            critical = true;
                            special = special.Replace(s, string.Empty);
                            critStr = s;
                            break;
                        }
                    }


                    //if (attacker != "EUER")
                    //    attacker = attacker.Substring(0, attacker.Length - 1);

                    victim = GermanPersonaReplace(victim);
					attacker = GermanPersonaReplace(attacker);
					if (cbSwarmIsMaster.Checked)
					{
						swarmIndex = attacker.IndexOf(" des ");
						if (swarmIndex == -1)
							swarmIndex = attacker.IndexOf(" von ");
						if (swarmIndex > -1)
						{
							skillType = GerGetPetSkilltypeString(attacker, skillType, swarmIndex);
							attacker = GerGetPetAttackerString(attacker, swarmIndex);
						}
					}

					attacker = GermanRemoveS(attacker, victim, critical);

					if (cbGermanMergeNames.Checked)
					{
						attacker = FindGermanCombatant(attacker);
						victim = FindGermanCombatant(victim);
					}
                    ms = new MasterSwing((int)SwingTypeEnum.Healing, critical, "None", Int64.Parse(damage), time, gts, skillType, attacker, "Hitpoints", victim);
                    ms.Tags["CriticalStr"] = critStr;
                    ActGlobals.oFormActMain.AddCombatAction(ms);
                    break;
				#endregion
				#region Case 4 [ward absorbtion]
				case 4:
					if (!ActGlobals.oFormActMain.InCombat)
						break;
					attacker = reMatch.Groups[1].Value;
					skillType = reMatch.Groups[2].Value;
					damage = reMatch.Groups[3].Value;
					victim = reMatch.Groups[4].Value;

					attacker = GermanPersonaReplace(attacker);
					victim = GermanPersonaReplace(victim);
					if (cbSwarmIsMaster.Checked)
					{
						swarmIndex = attacker.IndexOf(" des ");
						if (swarmIndex == -1)
							swarmIndex = attacker.IndexOf(" von ");
						if (swarmIndex > -1)
						{
							skillType = GerGetPetSkilltypeString(attacker, skillType, swarmIndex);
							attacker = GerGetPetAttackerString(attacker, swarmIndex);
						}
					}
					if (cbGermanMergeNames.Checked)
					{
						attacker = FindGermanCombatant(attacker);
						victim = FindGermanCombatant(victim);
					}
					ActGlobals.oFormActMain.AddCombatAction((int)SwingTypeEnum.Healing, false, "None", attacker, skillType, Int64.Parse(damage), time, gts, victim, "Absorption");
					if (CheckWardedHit(victim, time))
						lastWardAmount += Int64.Parse(damage);
					else
						lastWardAmount = Int64.Parse(damage);
					lastWardedTarget = victim;
					lastWardTime = time;
					break;
				#endregion
				#region Case 5 [power drain]
				case 5:
					skillType = reMatch.Groups[1].Value;
					attacker = reMatch.Groups[2].Value;
					victim = reMatch.Groups[3].Value;
					damage = reMatch.Groups[4].Value;
					crit = reMatch.Groups[5].Value;

					critical = crit.Contains("Kritischer");

					if (attacker[attacker.Length - 1] == 's')
						attacker = attacker.Substring(0, attacker.Length - 1);

					attacker = GermanPersonaReplace(attacker);
					victim = GermanPersonaReplace(victim);
					if (cbSwarmIsMaster.Checked)
					{
						swarmIndex = attacker.IndexOf(" des ");
						if (swarmIndex == -1)
							swarmIndex = attacker.IndexOf(" von ");
						if (swarmIndex > -1)
						{
							skillType = GerGetPetSkilltypeString(attacker, skillType, swarmIndex);
							attacker = GerGetPetAttackerString(attacker, swarmIndex);
						}
					}
					if (cbGermanMergeNames.Checked)
					{
						attacker = FindGermanCombatant(attacker);
						victim = FindGermanCombatant(victim);
					}
					if (attacker == victim)
						break;      // You don't get credit for attacking yourself or your own pet
					if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim))
					{
						if (CheckWardedHit(victim, time))
						{
							Dnum complexWardedHit = new Dnum(Int64.Parse(damage) + lastWardAmount, String.Format("{0}/{1}", lastWardAmount, damage.ToString()));
							ActGlobals.oFormActMain.AddCombatAction((int)SwingTypeEnum.PowerDrain, critical, "None", attacker, skillType, complexWardedHit, time, gts, victim, "warded/non-melee");
							lastWardAmount = 0;
						}
						else
							ActGlobals.oFormActMain.AddCombatAction((int)SwingTypeEnum.PowerDrain, critical, "None", attacker, skillType, Int64.Parse(damage), time, gts, victim, "non-melee");
					}
					break;
				#endregion
				#region Case 6 [kills]
				case 6:
					if (!ActGlobals.oFormActMain.InCombat)
						break;
					attacker = reMatch.Groups[1].Value;
					victim = reMatch.Groups[2].Value;

					attacker = GermanPersonaReplace(attacker);
					victim = GermanPersonaReplace(victim);

					if (mobLocSplit.IsMatch(victim))
						victim = mobLocSplit.Replace(victim, "$1");
					if (cbGermanMergeNames.Checked)
					{
						attacker = FindGermanCombatant(attacker);
						victim = FindGermanCombatant(victim);
					}
					ActGlobals.oFormSpellTimers.RemoveTimerMods(victim);
					ActGlobals.oFormActMain.AddCombatAction((int)SwingTypeEnum.NonMelee, false, "None", attacker, "Killing", Dnum.Death, time, gts, victim, "Death");
					break;
				#endregion
				#region Case 7 [act commands]
				case 7:
					ActGlobals.oFormActMain.ActCommands(reMatch.Groups[1].Value);
					break;
				#endregion
				#region Case 8 [zone change]
				case 8:
					if (logLine.Contains(" combat by "))
						break;
					ActGlobals.oFormActMain.ChangeZone(reMatch.Groups[1].Value.Trim());
					break;
				#endregion
				#region Case 9 [successful attacks]
				case 9:
					attacker = reMatch.Groups[1].Value;
					skillType = reMatch.Groups[2].Value;
					victim = reMatch.Groups[3].Value;
					damage = reMatch.Groups[4].Value;
					special = reMatch.Groups[5].Value;

                    critical = false;
                    critStr = "None";
                    foreach (string s in criticalWords)
                    {
                        if (special.Contains(s))
                        {
                            critical = true;
                            special = special.Replace(s, string.Empty);
                            critStr = s;
                            break;
                        }
                    }

                    special = special.Trim();
					special = String.IsNullOrEmpty(special) ? "None" : special;
					special = GerGetTrimSpecial(special);

					damageAndTypeArr = GerGetDamageAndTypeArr(damage);

					if (!String.IsNullOrEmpty(skillType))
					{
						attacker = GermanPersonaReplace(attacker);
						victim = GermanPersonaReplace(victim);
						if (cbSwarmIsMaster.Checked)
						{
							swarmIndex = attacker.IndexOf(" des ");
							if (swarmIndex == -1)
								swarmIndex = attacker.IndexOf(" von ");
							if (swarmIndex > -1)
							{
								skillType = GerGetPetSkilltypeString(attacker, skillType, swarmIndex);
								attacker = GerGetPetAttackerString(attacker, swarmIndex);
							}
						}

						if (cbGermanMergeNames.Checked)
						{
							attacker = FindGermanCombatant(attacker);
							victim = FindGermanCombatant(victim);
						}
						// Skilltype defined
						if (attacker == victim)
							break;
						if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim))
						{
							AddDamageAttack(attacker, victim, skillType, (int)SwingTypeEnum.NonMelee, critical, critStr, special, damageAndTypeArr, time, gts);
						}
					}
					else
					{
						if (cbSwarmIsMaster.Checked)
						{
							attacker = GermanPersonaReplace(attacker);
							victim = GermanPersonaReplace(victim);
							swarmIndex = attacker.IndexOf(" des ");
							if (swarmIndex == -1)
								swarmIndex = attacker.IndexOf(" von ");
							if (swarmIndex > -1)
							{
								skillType = GerGetPetSkilltypeString(attacker, skillType, swarmIndex);
								attacker = GerGetPetAttackerString(attacker, swarmIndex);

								if (cbGermanMergeNames.Checked)
								{
									attacker = FindGermanCombatant(attacker);
									victim = FindGermanCombatant(victim);
								}
								// Swarm Pet Melee
								if (attacker == victim)
									break;
								if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim))
								{
									AddDamageAttack(attacker, victim, skillType, (int)SwingTypeEnum.NonMelee, critical, critStr, special, damageAndTypeArr, time, gts);
								}
								break;
							}
						}

						attacker = GermanPersonaReplace(attacker);
						victim = GermanPersonaReplace(victim);
						if (cbGermanMergeNames.Checked)
						{
							attacker = FindGermanCombatant(attacker);
							victim = FindGermanCombatant(victim);
						}
						// Player melee
						if (attacker == victim)
							break;
						if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim))
						{
							AddDamageAttack(attacker, victim, skillType, (int)SwingTypeEnum.Melee, critical, critStr, special, damageAndTypeArr, time, gts);
						}
					}
					break;
				#endregion
				#region Case 10 [unsourced skills]
				case 10:
					attacker = "Unknown";
					victim = reMatch.Groups[1].Value;
					skillType = reMatch.Groups[2].Value;
					damage = reMatch.Groups[3].Value;
					special = reMatch.Groups[4].Value;

                    critical = false;
                    critStr = "None";
                    foreach (string s in criticalWords)
                    {
                        if (special.Contains(s))
                        {
                            critical = true;
                            special = special.Replace(s, string.Empty);
                            critStr = s;
                            break;
                        }
                    }

                    if (!String.IsNullOrEmpty(skillType))
					{
						if (attacker[attacker.Length - 1] == 's')
							attacker = attacker.Substring(0, attacker.Length - 1);
					}

					special = special.Trim();
					special = String.IsNullOrEmpty(special) ? "None" : special;
					special = GerGetTrimSpecial(special);

					damageAndTypeArr = GerGetDamageAndTypeArr(damage);

					victim = GermanPersonaReplace(victim);
					if (cbGermanMergeNames.Checked)
					{
						victim = FindGermanCombatant(victim);
					}

					if (ActGlobals.oFormActMain.InCombat)
						AddDamageAttack(attacker, victim, skillType, (int)SwingTypeEnum.NonMelee, critical, critStr, special, damageAndTypeArr, time, gts);
					else
						if (!isImport)
						ActGlobals.oFormSpellTimers.NotifySpell(attacker, skillType, victim == ActGlobals.charName, victim, true);
					break;
				#endregion
				#region Case 11 [power healing]
				case 11:
					if (!ActGlobals.oFormActMain.InCombat)
						break;
					skillType = reMatch.Groups[1].Value;
					attacker = reMatch.Groups[2].Value;
					victim = reMatch.Groups[3].Value;
					crit = reMatch.Groups[4].Value;
					damage = reMatch.Groups[5].Value;
					critStr2 = reMatch.Groups[6].Value;
					critStr = reMatch.Groups[7].Value;

					if (crit.StartsWith("krit"))
						critical = true;
					else
						critical = false;
					if (String.IsNullOrEmpty(critStr))
						critStr = "None";
					else
					{
						if (critStr.Contains("kritisch"))
							critical = true;
					}

                    foreach (string s in criticalWords2)
                    {
                        if (critStr2.Contains(s))
                        {
                            critical = true;
                            critStr = s;
                            break;
                        }
                    }



                    victim = GermanPersonaReplace(victim);
					attacker = GermanPersonaReplace(attacker);
					if (cbSwarmIsMaster.Checked)
					{
						swarmIndex = attacker.IndexOf(" des ");
						if (swarmIndex == -1)
							swarmIndex = attacker.IndexOf(" von ");
						if (swarmIndex > -1)
						{
							skillType = GerGetPetSkilltypeString(attacker, skillType, swarmIndex);
							attacker = GerGetPetAttackerString(attacker, swarmIndex);
						}
					}

					attacker = GermanRemoveS(attacker, victim, critical);

					if (cbGermanMergeNames.Checked)
					{
						attacker = FindGermanCombatant(attacker);
						victim = FindGermanCombatant(victim);
					}
                    ms = new MasterSwing((int)SwingTypeEnum.PowerHealing, critical, "None", Int64.Parse(damage), time, gts, skillType, attacker, "Manapunkt", victim);
                    ms.Tags["CriticalStr"] = critStr;
                    ActGlobals.oFormActMain.AddCombatAction(ms);

                    break;
				#endregion
				#region Case 12 [dispell/cure]
				case 12:
					string temp = reMatch.Groups[1].Value;
					skillType = reMatch.Groups[2].Value;
					attacker = reMatch.Groups[3].Value;
					victim = reMatch.Groups[4].Value;
					attackType = reMatch.Groups[5].Value;

					if (temp == "EUER")
						attacker = ActGlobals.charName;

					attacker = GermanPersonaReplace(attacker);
					victim = GermanPersonaReplace(victim);

					if (cbGermanMergeNames.Checked)
					{
						attacker = FindGermanCombatant(attacker);
						victim = FindGermanCombatant(victim);
					}

					if (attackType == "Traumatischer Greifer")
						ActGlobals.oFormSpellTimers.DispellTimerMods(victim);

					if (ActGlobals.oFormActMain.InCombat)
						ActGlobals.oFormActMain.AddCombatAction((int)SwingTypeEnum.CureDispel, false, attackType, attacker, skillType, 1, time, gts, victim, "befreit");
					break;
				#endregion
				#region Case 13 [threat]
				case 13:
					attacker = reMatch.Groups[1].Value;
					skillType = reMatch.Groups[2].Value;
					direction = reMatch.Groups[3].Value;
					victim = reMatch.Groups[4].Value;
					damage = reMatch.Groups[5].Value;
					crit = reMatch.Groups[6].Value; //dirtype
					special = reMatch.Groups[7].Value;

					attacker = GermanPersonaReplace(attacker);
					victim = GermanPersonaReplace(victim);

					if (victim.StartsWith("der "))
						victim = victim.Substring(4);
					if (victim.StartsWith("\\dat("))
						victim = victim.Substring(5, victim.Length - 6);

					bool increase = (direction == "erhöht") || (direction == "steigert kritisch");
					bool positionChange = !crit.Contains("Bedrohungen");
					critical = direction.EndsWith("kritisch");
                    critStr = "None";
                    foreach (string s in criticalWords2)
                    {
                        if (crit.Contains(s))
                        {
                            critical = true;
                            crit = crit.Replace(s, string.Empty);
                            critStr = s;
                            break;
                        }
                    }

					Dnum dDamage;
					if (positionChange)
						dDamage = new Dnum(Dnum.ThreatPosition, String.Format("{0} Positions", Int64.Parse(damage)));
					else
						dDamage = new Dnum(Int64.Parse(damage));
					direction = increase ? "Increase" : "Decrease";

					if (cbGermanMergeNames.Checked)
					{
						attacker = FindGermanCombatant(attacker);
						victim = FindGermanCombatant(victim);
					}

					if (attacker == victim)
						break;      // You don't get credit for attacking yourself or your own pet
					if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim))
					{
						//ActGlobals.oFormActMain.AddCombatAction((int)SwingTypeEnum.Threat, critical, "None", attacker, skillType, dDamage, time, gts, victim, direction);
                        ms = new MasterSwing((int)SwingTypeEnum.Threat, critical, "None", dDamage, time, gts, skillType, attacker, direction, victim);
                        ms.Tags["CriticalStr"] = critStr;
                        ActGlobals.oFormActMain.AddCombatAction(ms);
                    }
					break;
				#endregion
				#region Case 14 [damage interception]
				case 14:
					if (!ActGlobals.oFormActMain.InCombat)
						break;
					attacker = reMatch.Groups[1].Value; // Inteceptor
					special = reMatch.Groups[2].Value;  // Attacker
					victim = reMatch.Groups[3].Value;   // Target
					damage = reMatch.Groups[4].Value;   // Amount

					attacker = GermanPersonaReplace(attacker);
					victim = GermanPersonaReplace(victim);
					if (cbGermanMergeNames.Checked)
					{
						attacker = FindGermanCombatant(attacker);
						victim = FindGermanCombatant(victim);
					}

					ActGlobals.oFormActMain.AddCombatAction((int)SwingTypeEnum.Healing, false, special, attacker, "Channeler Pet", Int64.Parse(damage), time, gts, victim, "Interception");
					if (CheckInterceptedHit(victim, time))
						lastInterceptAmount += Int64.Parse(damage);
					else
						lastInterceptAmount = Int64.Parse(damage);
					lastInterceptTarget = victim;
					lastInterceptTime = time;
					lastIntercepter = attacker;
					break;
				#endregion

				default:
					break;
			}
		}
		private bool CheckWardedHit(string victim, DateTime time)
		{
			return cbRecalcWardedHits.Checked && lastWardTime == time && lastWardedTarget == victim && lastWardAmount > 0;
		}
		private bool CheckInterceptedFocus(string victim, DateTime time, List<DamageAndType> damageAndTypeArr)
		{
			if (cbRecalcWardedHits.Checked && lastInterceptTime == time && lastIntercepter == victim && lastInterceptAmount > 0)
			{
				if (damageAndTypeArr.Count == 1)
				{
					if (damageAndTypeArr[0].Type == "focus")
						return true;
				}
			}
			return false;
		}
		private bool CheckInterceptedHit(string victim, DateTime time)
		{
			return cbRecalcWardedHits.Checked && lastInterceptTime == time && lastInterceptTarget == victim && lastInterceptAmount > 0;
		}

		private string GermanTrimGrammar(string combatant)
		{
			combatant = GermanTrimPrefix(combatant);

			string oldName;
			do
			{
				oldName = combatant;

				if (combatant.EndsWith("em"))
					combatant = combatant.Substring(0, combatant.Length - 2);
				if (combatant.EndsWith("en"))
					combatant = combatant.Substring(0, combatant.Length - 2);
				if (combatant.EndsWith("er"))
					combatant = combatant.Substring(0, combatant.Length - 2);
				if (combatant.EndsWith("e"))
					combatant = combatant.Substring(0, combatant.Length - 1);
				if (combatant.EndsWith("s"))
					combatant = combatant.Substring(0, combatant.Length - 1);
				if (combatant.EndsWith("'"))
					combatant = combatant.Substring(0, combatant.Length - 1);
				if (combatant.EndsWith(" "))
					combatant = combatant.Substring(0, combatant.Length - 1);

				combatant = combatant.Replace(" dem ", " ");
				combatant = combatant.Replace(" den ", " ");
				combatant = combatant.Replace(" des ", " ");
				combatant = combatant.Replace(" der ", " ");

				combatant = combatant.Replace("em ", " ");
				combatant = combatant.Replace("en ", " ");
				combatant = combatant.Replace("er ", " ");
				combatant = combatant.Replace("e ", " ");
				combatant = combatant.Replace("s ", " ");
				combatant = combatant.Replace("  ", " ");
			} while (combatant != oldName);

			return combatant.Trim();
		}
		private static string GermanTrimPrefix(string combatant)
		{
			if (combatant.ToLower().StartsWith("der "))
				combatant = combatant.Substring(4);
			if (combatant.ToLower().StartsWith("des "))
				combatant = combatant.Substring(4);
			if (combatant.ToLower().StartsWith("das "))
				combatant = combatant.Substring(4);
			if (combatant.ToLower().StartsWith("dem "))
				combatant = combatant.Substring(4);
			if (combatant.ToLower().StartsWith("den "))
				combatant = combatant.Substring(4);
			if (combatant.ToLower().StartsWith("die "))
				combatant = combatant.Substring(4);

			if (combatant.ToLower().StartsWith("der "))
				combatant = combatant.Substring(4);
			if (combatant.ToLower().StartsWith("des "))
				combatant = combatant.Substring(4);
			if (combatant.ToLower().StartsWith("das "))
				combatant = combatant.Substring(4);
			if (combatant.ToLower().StartsWith("dem "))
				combatant = combatant.Substring(4);
			if (combatant.ToLower().StartsWith("den "))
				combatant = combatant.Substring(4);
			if (combatant.ToLower().StartsWith("die "))
				combatant = combatant.Substring(4);
			combatant = combatant.Trim();
			return combatant;
		}
		private string FindGermanCombatant(string input)
		{
			if (germanLongToShort.ContainsKey(input))
				return germanShortToLong[germanLongToShort[input]];
			else
			{
				string noPrefix = GermanTrimPrefix(input);
				string trimmed = GermanTrimGrammar(noPrefix);

				if (germanShortToLong.ContainsKey(trimmed))
				{
					return germanShortToLong[trimmed];
				}

				germanLongToShort.Add(input, trimmed);
				if (!germanShortToLong.ContainsKey(trimmed))
					germanShortToLong.Add(trimmed, noPrefix);

				return noPrefix;
			}
		}
		private string GermanRemoveS(string attacker, string victim, bool critical)
		{
			if (attacker == ActGlobals.charName)
				return attacker;
			if ((victim == ActGlobals.charName || !critical) && attacker[attacker.Length - 1] == 's')
				attacker = attacker.Substring(0, attacker.Length - 1);
			if (attacker.Substring(0, attacker.Length - 1) == victim)
				attacker = victim;
			return attacker;
		}
		private void SetFailTypeSpecialGerman(string victim, string why, ref Dnum failType, ref string special)
		{
			#region Misses
			if (why.Contains("verfehlt aber"))
			{
				failType = Dnum.Miss;
				if (String.IsNullOrEmpty(special))
					special = "None";
				else
					special = GerGetTrimSpecial(special);
				return;
			}
			#endregion
			int index;
			string avoid = string.Empty;
			string spec = string.Empty;
			GerSortAvoidSpecial(special, ref avoid, ref spec);
			avoid = GerGetTrimAvoid(avoid);
			special = GerGetTrimSpecial(special);
			special = String.IsNullOrEmpty(spec) ? "None" : special;
			#region Your avoidance
			if (why == "aber IHR weicht aus")
			{
				string avoider = GermanPersonaReplace(victim);
				if (ActGlobals.charName != avoider)
				{
					avoid = avoider + " " + avoid;
				}
				failType = new Dnum(Dnum.Unknown, avoid);
				return;
			}
			#endregion
			#region Special named avoidance
			index = why.IndexOf("greift ein");
			if (index != -1)
			{
				string avoider = GermanPersonaReplace(why.Substring(5, why.Length - 16));
				if (victim != avoider)
				{
					avoid = avoider + " " + avoid;
				}
				failType = new Dnum(Dnum.Unknown, avoid);
				return;
			}
			#endregion
		}
		private void GerSortAvoidSpecial(string input, ref string avoid, ref string spec)
		{
			string[] specialAttacks = new string[] { "Doppelangriff", "aoe attack", "aoe", "double attack", "double", "the flurry attack", "flurry", "Wirbel" };
			for (int j = 0; j < specialAttacks.Length; j++)
			{
				if (input.Contains(specialAttacks[j]))
				{
					spec = specialAttacks[j];
					avoid = input.Replace(specialAttacks[j], string.Empty).Trim();
					break;
				}
			}
			if (avoid == string.Empty)
				avoid = input;
		}
		private static List<DamageAndType> GerGetDamageAndTypeArr(string damageAndType)
		{
			damageAndType = damageAndType.Replace("\"", "");
			damageAndType = damageAndType.Replace(" und ", ", ");
			damageAndType = damageAndType.Replace("-Schaden", "");
			List<string> results = new List<string>(damageAndType.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
			for (int i = results.Count - 1; i >= 0; i--)
			{
				if (Char.IsLetter(results[i], 0))
					results.RemoveAt(i);
			}
			List<DamageAndType> outList = new List<DamageAndType>();
			for (int i = 0; i < results.Count; i++)
			{
				outList.Add(new DamageAndType(results[i]));
			}
			return outList;
		}
		private static string GerGetPetAttackerString(string attacker, int parIndex)
		{
			return attacker.Substring(parIndex + 5, attacker.Length - parIndex - 5).TrimEnd(new char[] { '.', ' ' });
		}
		private static string GerGetPetSkilltypeString(string attacker, string skillType, int parIndex)
		{
			if (String.IsNullOrEmpty(skillType))
			{
				return String.Format("({0})", attacker.Substring(0, parIndex));
			}
			else
			{
				return String.Format("({0}) - {1}", attacker.Substring(0, parIndex), skillType);
			}
		}
		private string GerGetTrimSpecial(string input)
		{
			if (input.Contains("Wirbel")) return "flurry";
			if (input.Contains("flurry")) return "flurry";
			if (input.Contains("aoe attack")) return "aoe";
			if (input.Contains("WB-Angriff")) return "aoe";
			if (input.Contains("AOE attack")) return "aoe";
			if (input.Contains("Doppelangriff")) return "double";
			if (input.Contains("double")) return "double";
			if (input.Contains("Treffer")) return "None";
			if (input.Contains("Kritischer Treffer")) return "None";
			if (input.Contains("None")) return "None";
			return input;
		}
		private string GerGetTrimAvoid(string input)
		{
			if (input.Contains("blocken")) return "blocks";
			if (input.Contains("blockt")) return "blocks";
			if (input.Contains("block")) return "blocks";
			if (input.Contains("blockss")) return "blocks";

			if (input.Contains("parierener")) return "parries";
			if (input.Contains("wehrt")) return "parries";
			if (input.Contains("parry")) return "parries";
			if (input.Contains("pariert")) return "parries";
			if (input.Contains("Parriert")) return "parries";

			if (input.Contains("riposte")) return "ripostes";
			if (input.Contains("ripostess")) return "ripostes";
			if (input.Contains("kontert")) return "ripostes";
			if (input.Contains("konterner")) return "ripostes";
			if (input.Contains("Gegenschlag")) return "ripostes";

			if (input.Contains("deflect")) return "deflects";
			if (input.Contains("deflectss")) return "deflects";
			if (input.Contains("weichen aus")) return "deflects";
			if (input.Contains("weicht aus")) return "deflects";
			if (input.Contains("verhindert")) return "deflects";

			if (input.Contains("ausweichen")) return "dodges";
			if (input.Contains("weicht")) return "dodges";

			if (input.Contains("widersteht")) return "resists";

			if (input.Contains("reflektiert")) return "reflects";

			return input;
		}
		private string GermanPersonaReplace(string input)
		{
			input = input.Trim();
			if ((input.StartsWith(@"\Der(") || input.StartsWith(@"\Des(") || input.StartsWith(@"\der(") || input.StartsWith(@"\den("))
				&& input.EndsWith(")"))
			{
				input = input.Substring(5, input.Length - 6);
			}
			if ((input.StartsWith(@"Der ")))
			{
				input = input.Substring(4);
			}
			if ((input.StartsWith(@"Des ")))
			{
				input = input.Substring(4);
			}
			if (input == "YOU")
				return ActGlobals.charName;
			if (input == "YOUR")
				return ActGlobals.charName;
			if (input == "YOURSELF")
				return ActGlobals.charName;
			if (input.ToUpper() == "EUCH")
				return ActGlobals.charName;
			if (input == "EUER")
				return ActGlobals.charName;
			if (input.ToUpper() == "IHR")
				return ActGlobals.charName;
			if (input == "EUCH SELBST")
				return ActGlobals.charName;
			if (input.ToUpper() == "EUER ZAUBER")
				return ActGlobals.charName;
			return input;
		}
		private class DamageAndType
		{
			long damage;
			string type;
			/// <summary>
			/// Data class for a single type of damage and the amount
			/// </summary>
			/// <param name="Damage">The positive integer amount of damage</param>
			/// <param name="Type">The type of damage to display it as</param>
			public DamageAndType(long Damage, string Type)
			{
				this.damage = Damage;
				this.type = Type;
			}
			/// <summary>
			/// Data class for a single type of damage and the amount
			/// </summary>
			/// <param name="UnsplitSource">An input string such as "123 crushing" to be split by the constructor</param>
			public DamageAndType(string UnsplitSource)
			{
				int spacePos = UnsplitSource.IndexOf(' ');
				if (spacePos == -1)
					throw new ArgumentException("The input string did not contain a space, thus cannot be split");
				damage = Int64.Parse(UnsplitSource.Substring(0, spacePos));
				type = UnsplitSource.Substring(spacePos + 1);
			}
			public long Damage
			{
				get { return damage; }
				set { damage = value; }
			}
			public string Type
			{
				get { return type; }
				set { type = value; }
			}
		}
		private void AddDamageAttack(string attacker, string victim, string skillType, int swingType, bool critical, string criticalStr, string special, List<DamageAndType> damageAndTypeArr, DateTime time, int gts)
		{
			long damageTotal = 0;
			if (cbMultiDamageIsOne.Checked)
			{
				string damageStr = string.Empty;
				string typeStr = string.Empty;
				if (CheckInterceptedFocus(victim, time, damageAndTypeArr))
				{
					if (!cbIncludeInterceptFocus.Checked)
						return;
				}
				if (CheckInterceptedHit(victim, time))
				{
					damageTotal = lastInterceptAmount;
					damageStr += String.Format("{0}/", damageTotal.ToString(GetIntCommas()));
					typeStr += String.Format("{0}/", "intercepted");
					lastInterceptAmount = 0;
				}
				if (CheckWardedHit(victim, time))
				{
					damageTotal = lastWardAmount;
					damageStr += String.Format("{0}/", damageTotal.ToString(GetIntCommas()));
					typeStr += String.Format("{0}/", "warded");
					lastWardAmount = 0;
				}
				for (int i = 0; i < damageAndTypeArr.Count; i++)
				{
					damageTotal += damageAndTypeArr[i].Damage;
					damageStr += String.Format("{0}/", damageAndTypeArr[i].Damage.ToString(GetIntCommas()));
					typeStr += String.Format("{0}/", damageAndTypeArr[i].Type);
				}
				damageStr = damageStr.TrimEnd(new char[] { '/' });
				typeStr = typeStr.TrimEnd(new char[] { '/' });
				if (String.IsNullOrEmpty(skillType))
					skillType = typeStr;
                MasterSwing ms = new MasterSwing(swingType, critical, special, new Dnum(damageTotal, damageStr), time, gts, skillType, attacker, typeStr, victim);
                ms.Tags["CriticalStr"] = criticalStr;
                ActGlobals.oFormActMain.AddCombatAction(ms);
            }
            else
			{
				bool nullSkillType = false;
				if (String.IsNullOrEmpty(skillType))
					nullSkillType = true;
				for (int i = 0; i < damageAndTypeArr.Count; i++)
				{
					damageTotal += damageAndTypeArr[i].Damage;
                    string damageStr = damageAndTypeArr[i].Damage.ToString(GetIntCommas());
                    if (nullSkillType)
						skillType = damageAndTypeArr[i].Type;
					if (i == damageAndTypeArr.Count - 1 && CheckWardedHit(victim, time))
					{
						damageTotal += lastWardAmount;
						lastWardAmount = 0;
					}
                    MasterSwing ms = new MasterSwing(swingType, critical, special, new Dnum(damageTotal, damageStr), time, gts, skillType, attacker, damageAndTypeArr[i].Type, victim);
                    ms.Tags["CriticalStr"] = criticalStr;
                    ActGlobals.oFormActMain.AddCombatAction(ms);
                }
            }
		}
		#endregion
		void LoadSettings()
		{
			// Add items to the xmlSettings object here...
			xmlSettings.AddControlSetting(cbGermanMergeNames.Name, cbGermanMergeNames);
			xmlSettings.AddControlSetting(cbMultiDamageIsOne.Name, cbMultiDamageIsOne);
			xmlSettings.AddControlSetting(cbRecalcWardedHits.Name, cbRecalcWardedHits);
			xmlSettings.AddControlSetting(cbSwarmIsMaster.Name, cbSwarmIsMaster);
			xmlSettings.AddControlSetting(cbSParseConsider.Name, cbSParseConsider);
			xmlSettings.AddControlSetting(cbIncludeInterceptFocus.Name, cbIncludeInterceptFocus);

			if (File.Exists(settingsFile))
			{
				FileStream fs = new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				XmlTextReader xReader = new XmlTextReader(fs);

				try
				{
					while (xReader.Read())
					{
						if (xReader.NodeType == XmlNodeType.Element)
						{
							if (xReader.LocalName == "SettingsSerializer")
							{
								xmlSettings.ImportFromXml(xReader);
							}
						}
					}
				}
				catch (Exception ex)
				{
					lblStatus.Text = "Error loading settings: " + ex.Message;
				}
				xReader.Close();
			}
		}
		void SaveSettings()
		{
			FileStream fs = new FileStream(settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
			XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8);
			xWriter.Formatting = Formatting.Indented;
			xWriter.Indentation = 1;
			xWriter.IndentChar = '\t';
			xWriter.WriteStartDocument(true);
			xWriter.WriteStartElement("Config");    // <Config>
			xWriter.WriteStartElement("SettingsSerializer");    // <Config><SettingsSerializer>
			xmlSettings.ExportToXml(xWriter);   // Fill the SettingsSerializer XML
			xWriter.WriteEndElement();  // </SettingsSerializer>
			xWriter.WriteEndElement();  // </Config>
			xWriter.WriteEndDocument(); // Tie up loose ends (shouldn't be any)
			xWriter.Flush();    // Flush the file buffer to disk
			xWriter.Close();
		}

		private void cbGermanMergeNames_MouseHover(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.SetOptionsHelpText("If enabled, combatants with grammatical changes such as: ruhiger Wachposten, ruhigen Wachpostens s, ruhigen Wachposten, ruhige Wachposten, ruhigen Wachposten en; will all show up as the same combatant.  (Which ever showed up first in an ACT session)");
		}
		private void cbSwarmIsMaster_MouseHover(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.SetOptionsHelpText("When enabled, \"Wässrige Horde des Character\" and other similarly named pets will have their attack damage added to their master instead of as their own named entry.  Incoming attacks will *not* be redirected to their master's data.");
		}
		private void cbRecalcWardedHits_MouseHover(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.SetOptionsHelpText("If enabled, no-damage hits or reduced damage hits immediately following a ward absorbtion will be increased by the absorption amount.  Stoneskin's no-damage hits cannot be recalculated.");
		}
		private void cbMultiDamageIsOne_MouseHover(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.SetOptionsHelpText("When enabled, an attack that has multiple damage types, such as \"300 crushing, 5 poison and 5 disease damage\" will show up as one total attack: 300/5/5 crushing/poison/disease, internally seen as 310.  If disabled, each damage type will show up as an individual swing, IE three attacks: 300 crushing; 5 poison; 5 disease.  Having a single attack show up as multiple will have consequences when calculating ToHit%.");
		}
		private void cbSParseConsider_MouseHover(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.SetOptionsHelpText("The /con command simply adds some text to the log about your target's con-level.  The /whogroup and /whoraid commands will list the members of your group/raid respectively.  Using this option will allow you to quickly add players to the Selective Parsing list.");
		}
		private void cbIncludeInterceptFocus_MouseHover(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.SetOptionsHelpText("When a channeler per intercepts damage, it receives an attack as focus damage.  Normally this focus damage is ignored and instead parsed as a heal for the channeler.  Enabling this option will also parse the damage done to the pet.");
		}
		private string GetIntCommas()
		{
			return ActGlobals.mainTableShowCommas ? "#,0" : "0";
		}
		private string GetFloatCommas()
		{
			return ActGlobals.mainTableShowCommas ? "#,0.00" : "0.00";
		}
		private void SetupEQ2EnglishEnvironment()
		{
			CultureInfo usCulture = new CultureInfo("en-US");   // This is for SQL syntax; do not change


			if (!CombatantData.ColumnDefs.ContainsKey("CritTypes"))
				CombatantData.ColumnDefs.Add("CritTypes", new CombatantData.ColumnDef("CritTypes", true, "VARCHAR(32)", "CritTypes", CombatantDataGetCritTypes, CombatantDataGetCritTypes, (Left, Right) => { return CombatantDataGetCritTypes(Left).CompareTo(CombatantDataGetCritTypes(Right)); }));
			if (!CombatantData.ExportVariables.ContainsKey("crittypes"))
				CombatantData.ExportVariables.Add("crittypes", new CombatantData.TextExportFormatter("crittypes", "Critical Types", "Distribution of Critical Types  (Normal|Legendary|Fabled|Mythical)", (Data, Extra) => { return CombatantDataGetCritTypes(Data); }));

			if (!DamageTypeData.ColumnDefs.ContainsKey("CritTypes"))
				DamageTypeData.ColumnDefs.Add("CritTypes", new DamageTypeData.ColumnDef("CritTypes", true, "VARCHAR(32)", "CritTypes", DamageTypeDataGetCritTypes, DamageTypeDataGetCritTypes));

			if (!AttackType.ColumnDefs.ContainsKey("CritTypes"))
				AttackType.ColumnDefs.Add("CritTypes", new AttackType.ColumnDef("CritTypes", true, "VARCHAR(32)", "CritTypes", AttackTypeGetCritTypes, AttackTypeGetCritTypes, (Left, Right) => { return AttackTypeGetCritTypes(Left).CompareTo(AttackTypeGetCritTypes(Right)); }));

			if (!MasterSwing.ColumnDefs.ContainsKey("CriticalStr"))
				MasterSwing.ColumnDefs.Add("CriticalStr", new MasterSwing.ColumnDef("CriticalStr", true, "VARCHAR(32)", "CriticalStr", (Data) =>
				{
					if (Data.Tags.ContainsKey("CriticalStr"))
						return (string)Data.Tags["CriticalStr"];
					else
						return "None";
				}, (Data) =>
				{
					if (Data.Tags.ContainsKey("CriticalStr"))
						return (string)Data.Tags["CriticalStr"];
					else
						return "None";
				}, (Left, Right) =>
				{
					string left = Left.Tags.ContainsKey("CriticalStr") ? (string)Left.Tags["CriticalStr"] : "None";
					string right = Right.Tags.ContainsKey("CriticalStr") ? (string)Right.Tags["CriticalStr"] : "None";
					return left.CompareTo(right);
				}));

			foreach (KeyValuePair<string, MasterSwing.ColumnDef> pair in MasterSwing.ColumnDefs)
				pair.Value.GetCellForeColor = (Data) => { return GetSwingTypeColor(Data.SwingType); };

			ActGlobals.oFormActMain.ValidateLists();
			ActGlobals.oFormActMain.ValidateTableSetup();
		}
		private string CombatantDataGetCritTypes(CombatantData Data)
		{
			AttackType at;
			if (Data.AllOut.TryGetValue(ActGlobals.ActLocalization.LocalizationStrings["attackTypeTerm-all"].DisplayedText, out at))
			{
				return AttackTypeGetCritTypes(at);
			}
			else
				return "-";
		}
		private string DamageTypeDataGetCritTypes(DamageTypeData Data)
		{
			AttackType at;
			if (Data.Items.TryGetValue(ActGlobals.ActLocalization.LocalizationStrings["attackTypeTerm-all"].DisplayedText, out at))
			{
				return AttackTypeGetCritTypes(at);
			}
			else
				return "-";
		}
		private string AttackTypeGetCritTypes(AttackType Data)
		{
			int crit = 0;
			int lCrit = 0;
			int fCrit = 0;
			int mCrit = 0;
			for (int i = 0; i < Data.Items.Count; i++)
			{
				MasterSwing ms = Data.Items[i];
				if (ms.Critical)
				{
					crit++;
					if (!ms.Tags.ContainsKey("CriticalStr"))
						continue;
					if (((string)ms.Tags["CriticalStr"]).Contains("Legendär"))
					{
						lCrit++;
						continue;
					}
					if (((string)ms.Tags["CriticalStr"]).Contains("Sagenumwoben"))
					{
						fCrit++;
						continue;
					}
					if (((string)ms.Tags["CriticalStr"]).Contains("Mythisch"))
					{
						mCrit++;
						continue;
					}
				}
			}
			float lCritPerc = ((float)lCrit / (float)crit) * 100f;
			float fCritPerc = ((float)fCrit / (float)crit) * 100f;
			float mCritPerc = ((float)mCrit / (float)crit) * 100f;
			if (crit == 0)
				return "-";
			return String.Format("{0:0.0}%L - {1:0.0}%F - {2:0.0}%M", lCritPerc, fCritPerc, mCritPerc);
		}
		private Color GetSwingTypeColor(int SwingType)
		{
			switch (SwingType)
			{
				case 1:
				case 2:
					return Color.Crimson;
				case 3:
					return Color.Blue;
				case 4:
					return Color.DarkRed;
				case 5:
					return Color.DarkOrange;
				case 8:
					return Color.DarkOrchid;
				case 9:
					return Color.DodgerBlue;
				default:
					return Color.Black;
			}
		}
	}
}