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

[assembly: AssemblyTitle("English-Japan(EN-JP) Parsing Engine")]
[assembly: AssemblyDescription("Plugin based parsing engine for Japanese EQ2 servers running the English client")]
[assembly: AssemblyCompany("Aditu of Skyfire")]
[assembly: AssemblyVersion("1.2.0.10")]

namespace ACT_Plugin
{
	public class ACT_EnJp_Parser : UserControl, IActPluginV1
	{
		#region Designer generated code (Avoid editing)
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
			this.cbMultiDamageIsOne = new System.Windows.Forms.CheckBox();
			this.cbRecalcWardedHits = new System.Windows.Forms.CheckBox();
			this.cbKatakana = new System.Windows.Forms.CheckBox();
			this.cbSParseConsider = new System.Windows.Forms.CheckBox();
			this.cbIncludeInterceptFocus = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// cbMultiDamageIsOne
			// 
			this.cbMultiDamageIsOne.AutoSize = true;
			this.cbMultiDamageIsOne.Checked = true;
			this.cbMultiDamageIsOne.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbMultiDamageIsOne.Location = new System.Drawing.Point(13, 14);
			this.cbMultiDamageIsOne.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.cbMultiDamageIsOne.Name = "cbMultiDamageIsOne";
			this.cbMultiDamageIsOne.Size = new System.Drawing.Size(362, 17);
			this.cbMultiDamageIsOne.TabIndex = 5;
			this.cbMultiDamageIsOne.Text = "Record a hit with multiple damage types as a single hit. (Not retroactive)";
			this.cbMultiDamageIsOne.MouseHover += new System.EventHandler(this.cbMultiDamageIsOne_MouseHover);
			// 
			// cbRecalcWardedHits
			// 
			this.cbRecalcWardedHits.AutoSize = true;
			this.cbRecalcWardedHits.Checked = true;
			this.cbRecalcWardedHits.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbRecalcWardedHits.Location = new System.Drawing.Point(13, 52);
			this.cbRecalcWardedHits.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.cbRecalcWardedHits.Name = "cbRecalcWardedHits";
			this.cbRecalcWardedHits.Size = new System.Drawing.Size(368, 17);
			this.cbRecalcWardedHits.TabIndex = 7;
			this.cbRecalcWardedHits.Text = "Recalculate warded/intercepted hits to their true value.  (Not retroactive)";
			this.cbRecalcWardedHits.MouseHover += new System.EventHandler(this.cbRecalcWardedHits_MouseHover);
			// 
			// cbKatakana
			// 
			this.cbKatakana.AutoSize = true;
			this.cbKatakana.Checked = true;
			this.cbKatakana.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbKatakana.Location = new System.Drawing.Point(13, 33);
			this.cbKatakana.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.cbKatakana.Name = "cbKatakana";
			this.cbKatakana.Size = new System.Drawing.Size(403, 17);
			this.cbKatakana.TabIndex = 9;
			this.cbKatakana.Text = "When displaying skill names, display katakana when available.  (Not retroactive)";
			this.cbKatakana.MouseHover += new System.EventHandler(this.cbKatakana_MouseHover);
			// 
			// cbSParseConsider
			// 
			this.cbSParseConsider.AutoSize = true;
			this.cbSParseConsider.Checked = true;
			this.cbSParseConsider.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSParseConsider.Location = new System.Drawing.Point(13, 71);
			this.cbSParseConsider.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.cbSParseConsider.Name = "cbSParseConsider";
			this.cbSParseConsider.Size = new System.Drawing.Size(479, 17);
			this.cbSParseConsider.TabIndex = 7;
			this.cbSParseConsider.Text = "Add characters marked by the /con, /whogroup, /whoraid command to the Selective P" +
	"arsing list";
			this.cbSParseConsider.MouseHover += new System.EventHandler(this.cbSParseConsider_MouseHover);
			// 
			// cbIncludeInterceptFocus
			// 
			this.cbIncludeInterceptFocus.AutoSize = true;
			this.cbIncludeInterceptFocus.Location = new System.Drawing.Point(13, 90);
			this.cbIncludeInterceptFocus.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.cbIncludeInterceptFocus.Name = "cbIncludeInterceptFocus";
			this.cbIncludeInterceptFocus.Size = new System.Drawing.Size(466, 17);
			this.cbIncludeInterceptFocus.TabIndex = 19;
			this.cbIncludeInterceptFocus.Text = "Parse focus damage done to channeler pets. (Skews attacker DPS/ToHit%, Not Retroa" +
	"ctive)";
			// 
			// ACT_EnJp_Parser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.cbIncludeInterceptFocus);
			this.Controls.Add(this.cbKatakana);
			this.Controls.Add(this.cbMultiDamageIsOne);
			this.Controls.Add(this.cbSParseConsider);
			this.Controls.Add(this.cbRecalcWardedHits);
			this.Name = "ACT_EnJp_Parser";
			this.Size = new System.Drawing.Size(495, 108);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		#endregion
		public ACT_EnJp_Parser()
		{
			InitializeComponent();
		}

		Label lblStatus;	// The status label that appears in ACT's Plugin tab
		string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\ACT_EnJp_Parser.config.xml");
		private CheckBox cbMultiDamageIsOne;
		private CheckBox cbRecalcWardedHits;
		private CheckBox cbKatakana;
		SettingsSerializer xmlSettings;
		private CheckBox cbSParseConsider;
		private CheckBox cbIncludeInterceptFocus;
		TreeNode optionsNode = null;

		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			lblStatus = pluginStatusText;	// Hand the status label's reference to our local var
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
				optionsNode = ActGlobals.oFormActMain.OptionsTreeView.Nodes[dcIndex].Nodes.Add("EQ2 EN-JP Settings");
				// Register our user control(this) to our newly create node path.  All controls added to the list will be laid out left to right, top to bottom
				ActGlobals.oFormActMain.OptionsControlSets.Add(@"Data Correction\EQ2 EN-JP Settings", new List<Control> { this });
				Label lblConfig = new Label();
				lblConfig.AutoSize = true;
				lblConfig.Text = "Find the applicable options in the Options tab, Data Correction - EQ2 EN-JP Settings";
				pluginScreenSpace.Controls.Add(lblConfig);
			}

			xmlSettings = new SettingsSerializer(this);	// Create a new settings serializer and pass it this instance
			LoadSettings();

			PopulateRegexArray();

			SetupEQ2EnglishEnvironment();

			ActGlobals.oFormActMain.BeforeLogLineRead += new LogLineEventDelegate(oFormActMain_BeforeLogLineRead);
			ActGlobals.oFormActMain.BeforeCombatAction += new CombatActionDelegate(oFormActMain_BeforeCombatAction);
			ActGlobals.oFormActMain.AfterCombatAction += new CombatActionDelegate(oFormActMain_AfterCombatAction);
			ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(oFormActMain_OnLogLineRead);
			ActGlobals.oFormActMain.UpdateCheckClicked += new FormActMain.NullDelegate(oFormActMain_UpdateCheckClicked);
			if (ActGlobals.oFormActMain.GetAutomaticUpdatesAllowed())   // If ACT is set to automatically check for updates, check for updates to the plugin
				new Thread(new ThreadStart(oFormActMain_UpdateCheckClicked)).Start();	// If we don't put this on a separate thread, web latency will delay the plugin init phase
			lblStatus.Text = "Plugin Started";
		}

		public void DeInitPlugin()
		{
			ActGlobals.oFormActMain.BeforeLogLineRead -= oFormActMain_BeforeLogLineRead;
			ActGlobals.oFormActMain.BeforeCombatAction -= oFormActMain_BeforeCombatAction;
			ActGlobals.oFormActMain.AfterCombatAction -= oFormActMain_AfterCombatAction;
			ActGlobals.oFormActMain.OnLogLineRead -= oFormActMain_OnLogLineRead;
			ActGlobals.oFormActMain.UpdateCheckClicked -= oFormActMain_UpdateCheckClicked;

			if (optionsNode != null)    // If we added our user control to the Options tab, remove it
			{
				optionsNode.Remove();
				ActGlobals.oFormActMain.OptionsControlSets.Remove(@"Data Correction\EQ2 EN-JP Settings");
			}

			SaveSettings();
			lblStatus.Text = "Plugin Exited";
		}
		void oFormActMain_UpdateCheckClicked()
		{
			int pluginId = 55;
			try
			{
				DateTime localDate = ActGlobals.oFormActMain.PluginGetSelfDateUtc(this);
				DateTime remoteDate = ActGlobals.oFormActMain.PluginGetRemoteDateUtc(pluginId);
				if (localDate.AddHours(2) < remoteDate)
				{
					DialogResult result = MessageBox.Show("There is an updated version of the EQ2 EN-JP Parsing Plugin.  Update it now?\n\n(If there is an update to ACT, you should click No and update ACT first.)", "New Version", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
		DateTime lastWardTime = DateTime.MinValue;
		long lastWardAmount = 0;
		string lastWardedTarget = string.Empty;
		DateTime lastInterceptTime = DateTime.MinValue;
		long lastInterceptAmount = 0;
		string lastInterceptTarget = string.Empty;
		string lastIntercepter = string.Empty;
		Regex petSplit = new Regex(@"(?<petName>\w* ?)<(?<attacker>\w+)['의の](?<s>s?) (?<petClass>.+)>", RegexOptions.Compiled);
		Regex engKillSplit = new Regex("(?<mob>.+?) in .+", RegexOptions.Compiled);
		Regex romanjiSplit = new Regex(@"\\r\w:(?<katakana>.+?)\\:(?<romanji>.+)\\/r", RegexOptions.Compiled);
		Regex regexConsider = new Regex(logTimeStampRegexStr + @".+?You consider (?<player>.+?)\.\.\. .+", RegexOptions.Compiled);
		Regex regexWhogroup = new Regex(logTimeStampRegexStr + @"(?<name>[^ ]+) Lvl \d+ .+", RegexOptions.Compiled);
		Regex regexWhoraid = new Regex(logTimeStampRegexStr + @"\[\d+ [^\]]+\] (?<name>[^ ]+) \([^\)]+\)", RegexOptions.Compiled);
		CombatActionEventArgs lastDamage = null;

		private void PopulateRegexArray()
		{
			regexArray = new Regex[13];
			regexArray[0] = new Regex(logTimeStampRegexStr + @"(?<victim>.+?) +(?:is|are) hit by (?<skillType>.+?) for (?<damageAndType>.+) damage\.(?: \((?<special>.+)\))?", RegexOptions.Compiled);
			regexArray[1] = new Regex(logTimeStampRegexStr + @"(?<attacker>.+?) +hits? (?<victim>.+?) +for (?<damageAndAttackType>.+?) damage\.(?: \((?<special>.+)\))?", RegexOptions.Compiled);
			regexArray[2] = new Regex(logTimeStampRegexStr + @"(?<healerAndSkill>.+?) +(?<oldcrit>critically heals|heals) (?<victim>.+?) +for (?<crit>a .*?critical of )?(?<damage>\d+) hit points?\.", RegexOptions.Compiled);
			regexArray[3] = new Regex(logTimeStampRegexStr + @"(?<attacker>.+?) +(?:tries|try) to damage (?<victimAndSkill>.+?) *, but (?<why>.+?)\.(?: \((?<special>.+)\))?", RegexOptions.Compiled);
			regexArray[4] = new Regex(logTimeStampRegexStr + @"(?<attacker>.+?) +(?:has|have) killed (?<victim>.+?) *\.", RegexOptions.Compiled);
			regexArray[5] = new Regex(logTimeStampRegexStr + @"Unknown command: 'act (.+)'", RegexOptions.Compiled);
			regexArray[6] = new Regex(logTimeStampRegexStr + @"(?<attackerAndSkill>.+?) +hits (?<victim>.+?) +draining (?<damage>\d+) points? of power\.(?: \((?<special>.+)\))?", RegexOptions.Compiled);
			regexArray[7] = new Regex(logTimeStampRegexStr + @"(?<attacker>YOUR|.+?['의の]s?) ?(?<skillType>.+?) absorbs (?<damage>\d+) points? of damage from being done to (?<victim>.+)\.", RegexOptions.Compiled);
			regexArray[8] = new Regex(logTimeStampRegexStr + @"You have entered (?::.+?:)?(?<zone>.+)\.", RegexOptions.Compiled);
			regexArray[9] = new Regex(logTimeStampRegexStr + @"(?<healerAndSkill>.+?) +(?<oldcrit>(?:critically )?refreshes) (?<victim>.+?) +for (?<crit>a .*?critical of )?(?<damage>\d+) mana points?\.", RegexOptions.Compiled);
			regexArray[10] = new Regex(logTimeStampRegexStr + @"(?:(?<owner>YOUR)|(?<owner>.+?)(?:['의の]s?)) (?<skillType>.+?) (?<oldcrit>critically )?(?<direction>increases|reduces) (?<attacker>.+?) hate (?:position )?with (?<victim>.+?) (?:by|for) (?<crit>a .*?critical of )?(?<damage>\d+) (?<dirType>threat|positions?)\.", RegexOptions.Compiled);
			regexArray[11] = new Regex(logTimeStampRegexStr + @"(?<attacker>.+?['의の]s?|YOUR) (?<skillType>.+?) (?<action>dispels?|relieves?) (?:(?<victim>YOU) of (?<affliction>.+?)|(?<affliction>.+?) from (?<victim>.+))\.", RegexOptions.Compiled);
			regexArray[12] = new Regex(logTimeStampRegexStr + @"(?<healer>[^""]+?) reduces? the damage from (?<attacker>.+?) to (?<victim>.+) by (?<damage>\d+)\.", RegexOptions.Compiled);
		}
		void oFormActMain_BeforeLogLineRead(bool isImport, LogLineEventArgs logInfo)
		{
			if (NotQuickFail(logInfo))
			{
				for (int i = 0; i < regexArray.Length; i++)
				{
					Match reMatch = regexArray[i].Match(logInfo.logLine);
					if (reMatch.Success)
					{
						switch (i)
						{
							case 0:
							case 1:
								logInfo.detectedType = Color.Red.ToArgb();
								break;
							case 2:
								logInfo.detectedType = Color.Blue.ToArgb();
								break;
							case 3:
								logInfo.detectedType = Color.DarkRed.ToArgb();
								break;
							case 6:
								logInfo.detectedType = Color.DarkOrchid.ToArgb();
								break;
							case 7:
								logInfo.detectedType = Color.DodgerBlue.ToArgb();
								break;
							default:
								logInfo.detectedType = Color.Black.ToArgb();
								break;
						}
						LogExeEnJp(reMatch, i + 1, logInfo.logLine, isImport);
						break;
					}
				}
			}
		}
		void oFormActMain_BeforeCombatAction(bool isImport, CombatActionEventArgs actionInfo)
		{
			// Riposte/kontert/отвечает & Relect/отражает
			if (lastDamage != null && lastDamage.time == actionInfo.time)
			{
				if ((int)lastDamage.damage == (int)Dnum.Unknown && lastDamage.damage.DamageString.Contains("riposte"))
				{
					if (actionInfo.swingType == (int)SwingTypeEnum.Melee && actionInfo.victim == lastDamage.attacker)
					{
						actionInfo.special = "riposte";
						lastDamage.damage.DamageString2 = String.Format("({0} returned)", actionInfo.damage.ToString());
					}
				}
				if ((int)actionInfo.damage == (int)Dnum.Unknown && actionInfo.damage.DamageString.Contains("reflect"))
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

		string[] matchKeywords = new string[] { "damage", "point", ", but", "killed", "command", "entered", "hate", "dispel", "relieve", "reduces" };
		private bool NotQuickFail(LogLineEventArgs logInfo)
		{
			for (int i = 0; i < matchKeywords.Length; i++)
			{
				if (logInfo.logLine.Contains(matchKeywords[i]))
					return true;
			}

			return false;
		}
		string[] criticalWords = new string[] { "Legendary critical", "Fabled critical", "Mythical critical", "critical" };

		private void LogExeEnJp(Match reMatch, int logMatched, string logLine, bool isImport)
		{
			string attacker, victim, damage, skillType, why, crit, special, attackType;
			string critStr;
			List<string> attackingTypes = new List<string>();
			List<string> damages = new List<string>();
			Regex rE = regexArray[logMatched - 1];
			SwingTypeEnum swingType;
			bool critical;
			string[] attackerSkillSplit;
			List<DamageAndType> damageAndTypeArr;

			DateTime time = ActGlobals.oFormActMain.LastKnownTime;

			Dnum failType;
			int gts = ActGlobals.oFormActMain.GlobalTimeSorter;

			switch (logMatched)
			{
				#region Case 1 [unsourced skill attacks]
				case 1:
					victim = reMatch.Groups[1].Value;
					skillType = reMatch.Groups[2].Value;
					damage = reMatch.Groups[3].Value;
					special = reMatch.Groups[4].Value;
					special = String.IsNullOrEmpty(special) ? "None" : special;
					attacker = "Unknown";	// Unsourced melee hits show as "Unknown" attacking, so we do the same
					if (!ActGlobals.oFormActMain.InCombat && !isImport)
					{
						ActGlobals.oFormSpellTimers.NotifySpell(attacker.ToLower(), skillType, victim == "YOU", victim.ToLower(), true);
						break;
					}
					damageAndTypeArr = EngGetDamageAndTypeArr(damage);

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

					if (victim == "YOU")
						victim = ActGlobals.charName;
					AddDamageAttack(attacker, victim, skillType, (int)SwingTypeEnum.NonMelee, critical, critStr, special, damageAndTypeArr, time, gts);
					break;
				#endregion
				#region Case 2 [melee/non-melee attacks]
				case 2:
					attacker = reMatch.Groups[1].Value;	// Contains the attacker and possibly skillType
					victim = reMatch.Groups[2].Value;
					damage = reMatch.Groups[3].Value;
					special = reMatch.Groups[4].Value;
					skillType = string.Empty;

					if (damage.Contains("pain and suffering"))
						break;
					damageAndTypeArr = EngGetDamageAndTypeArr(damage);

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

					special = special.Replace("attack", string.Empty).Trim();
					special = special.Replace("hit", string.Empty).Trim();
					special = String.IsNullOrEmpty(special) ? "None" : special;

					victim = EnglishPersonaReplace(victim);
					if (attacker == "YOU")	// You performing melee
					{
						attacker = ActGlobals.charName;
						if (attacker == victim)
							break;		// You don't get credit for attacking yourself or your own pet
						if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim))
						{
							AddDamageAttack(attacker, victim, string.Empty, (int)SwingTypeEnum.Melee, critical, critStr, special, damageAndTypeArr, time, gts);
						}
						break;
					}
					if (attacker.StartsWith("YOUR"))		// You attacking with a skill
					{
						skillType = attacker.Substring(5);
						attacker = ActGlobals.charName;
						if (attacker == victim || attacker == petSplit.Replace(victim, "$2"))
							break;		// You don't get credit for attacking yourself or your own pet
						// Traumatic Swipe / トラウマティック・スワイプ
						if (skillType == "Traumatic Swipe" || skillType == "トラウマティック・スワイプ" || skillType == "\\ra:トラウマティック・スワイプ\\:Traumatic Swipe\\/r")
							ActGlobals.oFormSpellTimers.ApplyTimerMod(attacker, victim, skillType, 0.5F, 30);
						if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim))
						{
							AddDamageAttack(attacker, victim, skillType, (int)SwingTypeEnum.NonMelee, critical, critStr, special, damageAndTypeArr, time, gts);
						}
						//NotifySpell(attacker, skillType, true, victim, true);
						break;
					}

					attacker = attacker.Replace("の\\r", "の \\r");
					attackerSkillSplit = attacker.Split(new string[] { "の", "'s " }, StringSplitOptions.RemoveEmptyEntries);
					if (attackerSkillSplit.Length > 1)
					{
						JPAttackerSkillTypeResort(ref attacker, ref skillType, attackerSkillSplit);

						if (String.IsNullOrEmpty(skillType))	// If a skillType was not found, treat as melee
						{
							if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim))
							{
								AddDamageAttack(attacker, victim, string.Empty, (int)SwingTypeEnum.Melee, critical, critStr, special, damageAndTypeArr, time, gts);
							}
						}
						else
						{
							if (attacker == victim || attacker == petSplit.Replace(victim, "$2"))
								break;		// You don't get credit for attacking yourself or your own pet
							if (skillType == "Traumatic Swipe" || skillType == "トラウマティック・スワイプ" || skillType == "\\ra:トラウマティック・スワイプ\\:Traumatic Swipe\\/r")
								ActGlobals.oFormSpellTimers.ApplyTimerMod(attacker, victim, skillType, 0.5F, 30);
							if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim))
							{
								AddDamageAttack(attacker, victim, skillType, (int)SwingTypeEnum.NonMelee, critical, critStr, special, damageAndTypeArr, time, gts);
							}
						}
						break;
					}
					// If its down to here, it was a normal melee attack with no special naming tricks
					if (attacker == victim)
						break;		// You don't get credit for attacking yourself or your own pet
					if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim))
					{
						AddDamageAttack(attacker, victim, string.Empty, (int)SwingTypeEnum.Melee, critical, critStr, special, damageAndTypeArr, time, gts);
					}
					break;
				#endregion
				#region Case 3 [healing]
				case 3:
					if (!ActGlobals.oFormActMain.InCombat)
						break;
					attacker = reMatch.Groups[1].Value;	// Contains the healer and skillType
					crit = reMatch.Groups[2].Value;
					victim = reMatch.Groups[3].Value;
					critStr = reMatch.Groups[4].Value;
					damage = reMatch.Groups[5].Value;
					skillType = string.Empty;

					if (crit[0] == 'c')		// Check for critical hits
						critical = true;
					else
						critical = false;

					if (!String.IsNullOrWhiteSpace(critStr))
					{
						critical = true;
						critStr = critStr.Substring(2);	// "a "
						critStr = critStr.Substring(0, critStr.Length - 4);	// " of "
					}
					else
					{
						critStr = "None";
					}

					victim = EnglishPersonaReplace(victim);
					if (attacker.StartsWith("YOUR"))		// You healing
					{
						skillType = attacker.Substring(5);
						attacker = ActGlobals.charName;
						MasterSwing ms = new MasterSwing((int)SwingTypeEnum.Healing, critical, "None", Int64.Parse(damage), time, gts, skillType, attacker, "Hitpoints", victim);
						ms.Tags["CriticalStr"] = critStr;
						ActGlobals.oFormActMain.AddCombatAction(ms);
						break;
					}

					attacker = attacker.Replace("の\\r", "の \\r");
					attackerSkillSplit = attacker.Split(new string[] { "の", "'s " }, StringSplitOptions.RemoveEmptyEntries);
					if (attackerSkillSplit.Length > 1)
					{
						JPAttackerSkillTypeResort(ref attacker, ref skillType, attackerSkillSplit);
						MasterSwing ms = new MasterSwing((int)SwingTypeEnum.Healing, critical, "None", Int64.Parse(damage), time, gts, skillType, attacker, "Hitpoints", victim);
						ms.Tags["CriticalStr"] = critStr;
						ActGlobals.oFormActMain.AddCombatAction(ms);
					}
					break;
				#endregion
				#region Case 4 [misses]
				case 4:
					attacker = reMatch.Groups[1].Value;
					victim = reMatch.Groups[2].Value;		// Contains Victim and possibly skillType
					why = reMatch.Groups[3].Value;
					special = reMatch.Groups[4].Value;
					skillType = string.Empty;

					attacker = EnglishPersonaReplace(attacker);
					swingType = SwingTypeEnum.Melee;
					int skillSplitPos = victim.IndexOf(" with ");	// If this contains "with", we know there's a skillType
					if (skillSplitPos > -1)
					{
						skillType = victim.Substring(skillSplitPos + 6);
						victim = victim.Substring(0, skillSplitPos).Trim();
						swingType = SwingTypeEnum.NonMelee;
					}

					if (victim == "YOU" || victim == "YOUR")
						victim = ActGlobals.charName;
					why = why.Replace("interferes", string.Empty);
					why = why.Replace(victim, string.Empty);

					bool isSpecial = false;
					if (special.Contains(" aoe "))
					{
						why += special.Replace("the aoe attack", string.Empty).Trim();
						special = "aoe";
						isSpecial = true;
					}
					if (special.Contains(" double "))
					{
						why += special.Replace("the double attack", string.Empty).Trim();
						special = "double";
						isSpecial = true;
					}
					if (special.Contains(" flurry "))
					{
						why += special.Replace("the flurry attack", string.Empty).Trim();
						special = "flurry";
						isSpecial = true;
					}
					if (why == "misses" || why == "miss")
						failType = Dnum.Miss;
					else
					{
						if (!isSpecial)
							why = why.Trim() + " " + special;
						failType = new Dnum(Dnum.Unknown, why.Trim());
					}
					if (!isSpecial)
						special = "None";

					attacker = attacker.Replace("の\\r", "の \\r");
					attackerSkillSplit = attacker.Split(new string[] { "の", "'s " }, StringSplitOptions.RemoveEmptyEntries);
					if (attackerSkillSplit.Length > 1)
						JPAttackerSkillTypeResort(ref attacker, ref skillType, attackerSkillSplit);

					if (String.IsNullOrEmpty(skillType))	// If a skillType was not found, treat as melee
					{
						if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim))
						{
							AddCombatAction((int)SwingTypeEnum.Melee, false, special, attacker, "melee", failType, time, gts, victim, "melee");
						}
					}
					else
					{
						if (attacker == victim || attacker == petSplit.Replace(victim, "$2"))
							break;		// You don't get credit for attacking yourself or your own pet
						if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim))
						{
							AddCombatAction((int)SwingTypeEnum.NonMelee, false, special, attacker, skillType, failType, time, gts, victim, "non-melee");
						}
					}
					break;
				#endregion
				#region Case 5 [killing]
				case 5:
					attacker = reMatch.Groups[1].Value;
					victim = reMatch.Groups[2].Value;
					if (victim.ToUpper() == "YOU")
						victim = ActGlobals.charName;
					if (attacker.ToUpper() == "YOU")
						attacker = ActGlobals.charName;

					swingType = SwingTypeEnum.NonMelee;
					//if(ActGlobals.petIsMaster)
					//{
					//    if(petSplit.IsMatch(attacker))
					//    {
					//        attacker = petSplit.Replace(attacker,"$2");
					//        swingType = 5;
					//        if(petSplit.Replace(attacker,"$1").Length < 3)
					//            swingType = 8;
					//    }
					//}
					if (engKillSplit.IsMatch(victim))
					{
						victim = engKillSplit.Replace(victim, "$1");
					}
					ActGlobals.oFormSpellTimers.RemoveTimerMods(victim);
					ActGlobals.oFormSpellTimers.DispellTimerMods(victim);
					if (ActGlobals.oFormActMain.InCombat)
					{
						AddCombatAction((int)swingType, false, "None", attacker, "Killing", Dnum.Death, time, gts, victim, "Death");

						//if (cbKillEnd.Checked && ActiveZone.ActiveEncounter.GetAllies().IndexOf(new CombatantData(attacker, null)) > -1)
						//{
						//    EndCombat(true);
						//}
					}
					break;
				#endregion
				#region Case 6 [act commands]
				case 6:
					ActGlobals.oFormActMain.ActCommands(rE.Replace(logLine, "$1"));
					break;
				#endregion
				#region Case 7 [power drain]
				case 7:
					attacker = reMatch.Groups[1].Value;
					skillType = string.Empty;
					victim = reMatch.Groups[2].Value;
					damage = reMatch.Groups[3].Value;
					special = reMatch.Groups[4].Value;

					victim = EnglishPersonaReplace(victim);
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

					if (attacker.StartsWith("YOUR"))		// You attacking with a skill
					{
						skillType = attacker.Substring(5);
						attacker = ActGlobals.charName;
					}
					else
					{
						attacker = attacker.Replace("の\\r", "の \\r");
						attackerSkillSplit = attacker.Split(new string[] { "の", "'s " }, StringSplitOptions.RemoveEmptyEntries);
						if (attackerSkillSplit.Length > 1)
							JPAttackerSkillTypeResort(ref attacker, ref skillType, attackerSkillSplit);
					}
					if (attacker == victim || attacker == petSplit.Replace(victim, "$2"))
						break;		// You don't get credit for attacking yourself or your own pet
					if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim))
					{
						if (CheckWardedHit(victim, time))
						{
							Dnum complexWardedHit = new Dnum(Int64.Parse(damage) + lastWardAmount, String.Format("{0}/{1}", lastWardAmount.ToString(GetIntCommas()), Int64.Parse(damage).ToString(GetIntCommas())));
							//AddCombatAction((int)SwingTypeEnum.PowerDrain, false, "None", attacker, skillType, complexWardedHit, time, gts, victim, "warded/non-melee");
							MasterSwing ms = new MasterSwing((int)SwingTypeEnum.PowerDrain, critical, "None", Int64.Parse(damage), time, gts, skillType, attacker, "non-melee", victim);
							ms.Tags["CriticalStr"] = critStr;
							ActGlobals.oFormActMain.AddCombatAction(ms);
							lastWardAmount = 0;
						}
						else
						{
							//AddCombatAction((int)SwingTypeEnum.PowerDrain, false, "None", attacker, skillType, Int32.Parse(damage), time, gts, victim, "non-melee");
							MasterSwing ms = new MasterSwing((int)SwingTypeEnum.PowerDrain, critical, "None", Int64.Parse(damage), time, gts, skillType, attacker, "non-melee", victim);
							ms.Tags["CriticalStr"] = critStr;
							ActGlobals.oFormActMain.AddCombatAction(ms);
						}
					}
					break;
				#endregion
				#region Case 8 [ward absorbtion]
				case 8:
					if (!ActGlobals.oFormActMain.InCombat)
						break;
					attacker = reMatch.Groups[1].Value;
					skillType = reMatch.Groups[2].Value;
					damage = reMatch.Groups[3].Value;
					victim = reMatch.Groups[4].Value;

					attacker = EnglishPersonaReplace(attacker);
					victim = EnglishPersonaReplace(victim);
					if (attacker.EndsWith("'s"))
						attacker = attacker.Substring(0, attacker.Length - 2);
					if (attacker.EndsWith("'"))
						attacker = attacker.Substring(0, attacker.Length - 1);
					if (attacker.EndsWith("의"))
						attacker = attacker.Substring(0, attacker.Length - 1);
					if (attacker.EndsWith("の"))
						attacker = attacker.Substring(0, attacker.Length - 1);

					AddCombatAction((int)SwingTypeEnum.Healing, false, "None", attacker, skillType, Int64.Parse(damage), time, gts, victim, "Absorption");
					if (CheckWardedHit(victim, time))
						lastWardAmount += Int64.Parse(damage);
					else
						lastWardAmount = Int64.Parse(damage);
					lastWardedTarget = victim;
					lastWardTime = time;
					break;
				#endregion
				#region Case 9 [zone change]
				case 9:
					if (logLine.Contains(" combat by "))
						break;
					ActGlobals.oFormActMain.ChangeZone(rE.Replace(logLine, "$1").Trim());
					break;
				#endregion
				#region Case 10 [power healing]
				case 10:
					if (!ActGlobals.oFormActMain.InCombat)
						break;
					attacker = reMatch.Groups[1].Value;	// Contains the healer and skillType
					crit = reMatch.Groups[2].Value;
					victim = reMatch.Groups[3].Value;
					critStr = reMatch.Groups[4].Value;
					damage = reMatch.Groups[5].Value;
					skillType = string.Empty;

					if (crit[0] == 'c')		// Check for critical hits
						critical = true;
					else
						critical = false;

					if (!String.IsNullOrWhiteSpace(critStr))
					{
						critical = true;
						critStr = critStr.Substring(2);	// "a "
						critStr = critStr.Substring(0, critStr.Length - 4);	// " of "
					}
					else
					{
						critStr = "None";
					}


					victim = EnglishPersonaReplace(victim);
					if (attacker.StartsWith("YOUR"))		// You healing
					{
						skillType = attacker.Substring(5);
						attacker = ActGlobals.charName;
						MasterSwing ms = new MasterSwing((int)SwingTypeEnum.PowerHealing, critical, "None", Int64.Parse(damage), time, gts, skillType, attacker, "Power", victim);
						ms.Tags["CriticalStr"] = critStr;
						ActGlobals.oFormActMain.AddCombatAction(ms);
						break;
					}
					attacker = attacker.Replace("の\\r", "の \\r");
					attackerSkillSplit = attacker.Split(new string[] { "の", "'s " }, StringSplitOptions.RemoveEmptyEntries);
					if (attackerSkillSplit.Length > 1)
					{
						JPAttackerSkillTypeResort(ref attacker, ref skillType, attackerSkillSplit);
						MasterSwing ms = new MasterSwing((int)SwingTypeEnum.PowerHealing, critical, "None", Int64.Parse(damage), time, gts, skillType, attacker, "Power", victim);
						ms.Tags["CriticalStr"] = critStr;
						ActGlobals.oFormActMain.AddCombatAction(ms);
					}
					break;
				#endregion
				#region Case 11 [threat]
				case 11:
					string owner = reMatch.Groups[1].Value;
					skillType = reMatch.Groups[2].Value;
					crit = reMatch.Groups[3].Value;
					string direction = reMatch.Groups[4].Value;
					attacker = reMatch.Groups[5].Value;
					victim = reMatch.Groups[6].Value;
					critStr = reMatch.Groups[7].Value;
					damage = reMatch.Groups[8].Value;
					string position = reMatch.Groups[9].Value;

					attacker = EnglishPersonaReplace(attacker);
					owner = EnglishPersonaReplace(owner);
					victim = EnglishPersonaReplace(victim);
					if (attacker == "THEIR")
						attacker = owner;
					bool increase = direction == "increases";
					bool positionChange = !(position == "threat");
					critical = crit.StartsWith("crit");

					if (!String.IsNullOrWhiteSpace(critStr))
					{
						critical = true;
						critStr = critStr.Substring(2);	// "a "
						critStr = critStr.Substring(0, critStr.Length - 4);	// " of "
					}
					else
					{
						critStr = "None";
					}

					if (attacker.EndsWith("'s"))
						attacker = attacker.Substring(0, attacker.Length - 2);
					if (attacker.EndsWith("'"))
						attacker = attacker.Substring(0, attacker.Length - 1);
					if (attacker.EndsWith("의"))
						attacker = attacker.Substring(0, attacker.Length - 1);
					if (attacker.EndsWith("の"))
						attacker = attacker.Substring(0, attacker.Length - 1);

					Dnum dDamage;
					if (positionChange)
						dDamage = new Dnum(Dnum.ThreatPosition, String.Format("{0} Positions", Int64.Parse(damage)));
					else
						dDamage = new Dnum(Int64.Parse(damage));
					direction = increase ? "Increase" : "Decrease";

					if (attacker == victim || attacker == petSplit.Replace(victim, "$2"))
						break;		// You don't get credit for attacking yourself or your own pet
					if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim) || ActGlobals.oFormActMain.SetEncounter(time, owner, victim))
					{
						MasterSwing ms = new MasterSwing((int)SwingTypeEnum.Threat, critical, "None", dDamage, time, gts, skillType, attacker, direction, victim);
						ms.Tags["CriticalStr"] = critStr;
						ActGlobals.oFormActMain.AddCombatAction(ms);
					}
					break;
				#endregion
				#region Case 12 [dispell/cure]
				case 12:
					attacker = reMatch.Groups[1].Value;
					skillType = reMatch.Groups[2].Value;
					direction = reMatch.Groups[3].Value;
					victim = reMatch.Groups[4].Value;
					attackType = reMatch.Groups[5].Value;

					attacker = EnglishPersonaReplace(attacker);
					victim = EnglishPersonaReplace(victim);

					if (attackType == "Traumatic Swipe" || attackType == "トラウマティック・スワイプ" || attackType == "\\ra:トラウマティック・スワイプ\\:Traumatic Swipe\\/r")
						ActGlobals.oFormSpellTimers.DispellTimerMods(victim);

					if (attacker.EndsWith("'s"))
						attacker = attacker.Substring(0, attacker.Length - 2);
					if (attacker.EndsWith("'"))
						attacker = attacker.Substring(0, attacker.Length - 1);
					if (attacker.EndsWith("의"))
						attacker = attacker.Substring(0, attacker.Length - 1);
					if (attacker.EndsWith("の"))
						attacker = attacker.Substring(0, attacker.Length - 1);

					bool cont = false;
					if (direction[0] == 'r')
						cont = ActGlobals.oFormActMain.InCombat;
					else
						cont = ActGlobals.oFormActMain.SetEncounter(time, attacker, victim);
					if (cont)
						AddCombatAction((int)SwingTypeEnum.CureDispel, false, attackType, attacker, skillType, 1, time, gts, victim, direction);
					break;
				#endregion
				#region Case 13 [damage interception]
				case 13:
					if (!ActGlobals.oFormActMain.InCombat)
						break;
					attacker = reMatch.Groups[1].Value;	// Inteceptor
					special = reMatch.Groups[2].Value;	// Attacker
					victim = reMatch.Groups[3].Value;	// Target
					damage = reMatch.Groups[4].Value;	// Amount

					attacker = EnglishPersonaReplace(attacker);
					victim = EnglishPersonaReplace(victim);

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
		private bool CheckWardedHit(string victim, DateTime time)
		{
			return cbRecalcWardedHits.Checked && lastWardTime == time && lastWardedTarget == victim && lastWardAmount > 0;
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
				bool nullSkillType = String.IsNullOrEmpty(skillType);

				for (int i = 0; i < damageAndTypeArr.Count; i++)
				{
					damageTotal = damageAndTypeArr[i].Damage;
					string damageStr = damageAndTypeArr[i].Damage.ToString(GetIntCommas());
					if (nullSkillType)
						skillType = damageAndTypeArr[i].Type;

					if (CheckInterceptedFocus(victim, time, damageAndTypeArr))
					{
						if (!cbIncludeInterceptFocus.Checked)
							continue;
					}

					if (i == damageAndTypeArr.Count - 1 && (CheckWardedHit(victim, time) || CheckInterceptedHit(victim, time)))
					{
						damageTotal += lastInterceptAmount;
						damageTotal += lastWardAmount;
						lastInterceptAmount = 0;
						lastWardAmount = 0;
					}
					MasterSwing ms = new MasterSwing(swingType, critical, special, new Dnum(damageTotal, damageStr), time, gts, skillType, attacker, damageAndTypeArr[i].Type, victim);
					ms.Tags["CriticalStr"] = criticalStr;
					ActGlobals.oFormActMain.AddCombatAction(ms);
				}
			}
		}
		public void AddCombatAction(int SwingType, bool Critical, string Special, string Attacker, string theAttackType, Dnum Damage, DateTime Time, int TimeSorter, string Victim, string theDamageType)
		{
			if (romanjiSplit.IsMatch(theAttackType))
			{
				if (cbKatakana.Checked)
					theAttackType = romanjiSplit.Replace(theAttackType, "$1");
				else
					theAttackType = romanjiSplit.Replace(theAttackType, "$2");
			}
			if (romanjiSplit.IsMatch(Attacker))
			{
				if (cbKatakana.Checked)
					Attacker = romanjiSplit.Replace(Attacker, "$1");
				else
					Attacker = romanjiSplit.Replace(Attacker, "$2");
			}
			if (romanjiSplit.IsMatch(Victim))
			{
				if (cbKatakana.Checked)
					Victim = romanjiSplit.Replace(Victim, "$1");
				else
					Victim = romanjiSplit.Replace(Victim, "$2");
			}

			ActGlobals.oFormActMain.AddCombatAction(SwingType, Critical, Special, Attacker, theAttackType, Damage, Time, TimeSorter, Victim, theDamageType);
		}
		private static void JPAttackerSkillTypeResort(ref string attacker, ref string skillType, string[] attackerSkillSplit)
		{
			attacker = attackerSkillSplit[0].Trim();
			skillType = string.Empty;
			for (int i = 1; i < attackerSkillSplit.Length; i++)
			{
				skillType += attackerSkillSplit[i].Trim() + " の ";
			}
			skillType = skillType.Remove(skillType.Length - 3);
		}
		private string EnglishPersonaReplace(string input)
		{
			if (input == "YOU")
				return ActGlobals.charName;
			if (input == "YOUR")
				return ActGlobals.charName;
			if (input == "YOURSELF")
				return ActGlobals.charName;
			return input;
		}
		private List<DamageAndType> EngGetDamageAndTypeArr(string damageAndType)
		{
			List<DamageAndType> outList = new List<DamageAndType>();
			damageAndType = damageAndType.Replace(" and ", ", ");
			damageAndType = damageAndType.Replace("points of ", "");
			string[] entries = damageAndType.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

			for (int i = 0; i < entries.Length; i++)
			{
				outList.Add(new DamageAndType(entries[i]));
			}
			return outList;
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
		#endregion
		void LoadSettings()
		{
			// Add items to the xmlSettings object here...
			xmlSettings.AddControlSetting(cbMultiDamageIsOne.Name, cbMultiDamageIsOne);
			xmlSettings.AddControlSetting(cbRecalcWardedHits.Name, cbRecalcWardedHits);
			xmlSettings.AddControlSetting(cbKatakana.Name, cbKatakana);
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
			xWriter.WriteStartElement("Config");	// <Config>
			xWriter.WriteStartElement("SettingsSerializer");	// <Config><SettingsSerializer>
			xmlSettings.ExportToXml(xWriter);	// Fill the SettingsSerializer XML
			xWriter.WriteEndElement();	// </SettingsSerializer>
			xWriter.WriteEndElement();	// </Config>
			xWriter.WriteEndDocument();	// Tie up loose ends (shouldn't be any)
			xWriter.Flush();	// Flush the file buffer to disk
			xWriter.Close();
		}

		private void cbRecalcWardedHits_MouseHover(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.SetOptionsHelpText("If enabled, no-damage hits or reduced damage hits immediately following a ward absorbtion will be increased by the absorption amount.  Stoneskin's no-damage hits cannot be recalculated.");
		}
		private void cbMultiDamageIsOne_MouseHover(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.SetOptionsHelpText("When enabled, an attack that has multiple damage types, such as \"300 crushing, 5 poison and 5 disease damage\" will show up as one total attack: 300/5/5 crushing/poison/disease, internally seen as 310.  If disabled, each damage type will show up as an individual swing, IE three attacks: 300 crushing; 5 poison; 5 disease.  Having a single attack show up as multiple will have consequences when calculating ToHit%.");
		}
		private void cbKatakana_MouseHover(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.SetOptionsHelpText(string.Empty);
		}
		private void cbSParseConsider_MouseHover(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.SetOptionsHelpText("The /con command simply adds some text to the log about your target's con-level.  The /whogroup and /whoraid commands will list the members of your group/raid respectively.  Using this option will allow you to quickly add players to the Selective Parsing list.");
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
			CultureInfo usCulture = new CultureInfo("en-US");	// This is for SQL syntax; do not change


			if (!CombatantData.ColumnDefs.ContainsKey("CritTypes"))
				CombatantData.ColumnDefs.Add("CritTypes", new CombatantData.ColumnDef("CritTypes", true, "VARCHAR(32)", "CritTypes", CombatantDataGetCritTypes, CombatantDataGetCritTypes, (Left, Right) => { return CombatantDataGetCritTypes(Left).CompareTo(CombatantDataGetCritTypes(Right)); }));
			if (!CombatantData.ExportVariables.ContainsKey("crittypes"))
				CombatantData.ExportVariables.Add("crittypes", new CombatantData.TextExportFormatter("crittypes", "Critical Types", "Distribution of Critical Types  (Normal|Legendary|Fabled|Mythical)", (Data, Extra) => { return CombatantFormatSwitch(Data, "crittypes", Extra); }));

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
					if (((string)ms.Tags["CriticalStr"]).Contains("Legendary"))
					{
						lCrit++;
						continue;
					}
					if (((string)ms.Tags["CriticalStr"]).Contains("Fabled"))
					{
						fCrit++;
						continue;
					}
					if (((string)ms.Tags["CriticalStr"]).Contains("Mythical"))
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
		private string EncounterFormatSwitch(EncounterData Data, List<CombatantData> SelectiveAllies, string VarName, string Extra)
		{
			long damage = 0;
			long healed = 0;
			int swings = 0;
			int hits = 0;
			int crits = 0;
			int heals = 0;
			int critheals = 0;
			int cures = 0;
			int misses = 0;
			int hitfail = 0;
			float tohit = 0;
			double dps = 0;
			double hps = 0;
			long healstaken = 0;
			long damagetaken = 0;
			long powerdrain = 0;
			long powerheal = 0;
			int kills = 0;
			int deaths = 0;

			switch (VarName)
			{
				case "maxheal":
					return Data.GetMaxHeal(true, false);
				case "MAXHEAL":
					return Data.GetMaxHeal(false, false);
				case "maxhealward":
					return Data.GetMaxHeal(true, true);
				case "MAXHEALWARD":
					return Data.GetMaxHeal(false, true);
				case "maxhit":
					return Data.GetMaxHit(true);
				case "MAXHIT":
					return Data.GetMaxHit(false);
				case "duration":
					return Data.DurationS;
				case "DURATION":
					return Data.Duration.TotalSeconds.ToString("0");
				case "damage":
					foreach (CombatantData cd in SelectiveAllies)
						damage += cd.Damage;
					return damage.ToString();
				case "damage-m":
					foreach (CombatantData cd in SelectiveAllies)
						damage += cd.Damage;
					return (damage / 1000000.0).ToString("0.00");
				case "DAMAGE-k":
					foreach (CombatantData cd in SelectiveAllies)
						damage += cd.Damage;
					return (damage / 1000.0).ToString("0");
				case "DAMAGE-m":
					foreach (CombatantData cd in SelectiveAllies)
						damage += cd.Damage;
					return (damage / 1000000.0).ToString("0");
				case "healed":
					foreach (CombatantData cd in SelectiveAllies)
						healed += cd.Healed;
					return healed.ToString();
				case "swings":
					foreach (CombatantData cd in SelectiveAllies)
						swings += cd.Swings;
					return swings.ToString();
				case "hits":
					foreach (CombatantData cd in SelectiveAllies)
						hits += cd.Hits;
					return hits.ToString();
				case "crithits":
					foreach (CombatantData cd in SelectiveAllies)
						crits += cd.CritHits;
					return crits.ToString();
				case "crithit%":
					foreach (CombatantData cd in SelectiveAllies)
						crits += cd.CritHits;
					foreach (CombatantData cd in SelectiveAllies)
						hits += cd.Hits;
					float crithitperc = (float)crits / (float)hits;
					return crithitperc.ToString("0'%");
				case "heals":
					foreach (CombatantData cd in SelectiveAllies)
						heals += cd.Heals;
					return heals.ToString();
				case "critheals":
					foreach (CombatantData cd in SelectiveAllies)
						critheals += cd.CritHits;
					return critheals.ToString();
				case "critheal%":
					foreach (CombatantData cd in SelectiveAllies)
						critheals += cd.CritHeals;
					foreach (CombatantData cd in SelectiveAllies)
						heals += cd.Heals;
					float crithealperc = (float)critheals / (float)heals;
					return crithealperc.ToString("0'%");
				case "cures":
					foreach (CombatantData cd in SelectiveAllies)
						cures += cd.CureDispels;
					return cures.ToString();
				case "misses":
					foreach (CombatantData cd in SelectiveAllies)
						misses += cd.Misses;
					return misses.ToString();
				case "hitfailed":
					foreach (CombatantData cd in SelectiveAllies)
						hitfail += cd.Blocked;
					return hitfail.ToString();
				case "TOHIT":
					foreach (CombatantData cd in SelectiveAllies)
						tohit += cd.ToHit;
					tohit /= SelectiveAllies.Count;
					return tohit.ToString("0");
				case "DPS":
				case "ENCDPS":
					foreach (CombatantData cd in SelectiveAllies)
						damage += cd.Damage;
					dps = damage / Data.Duration.TotalSeconds;
					return dps.ToString("0");
				case "DPS-k":
				case "ENCDPS-k":
					foreach (CombatantData cd in SelectiveAllies)
						damage += cd.Damage;
					dps = damage / Data.Duration.TotalSeconds;
					return (dps / 1000.0).ToString("0");
				case "ENCHPS":
					foreach (CombatantData cd in SelectiveAllies)
						healed += cd.Healed;
					hps = healed / Data.Duration.TotalSeconds;
					return hps.ToString("0");
				case "ENCHPS-k":
					foreach (CombatantData cd in SelectiveAllies)
						healed += cd.Healed;
					hps = healed / Data.Duration.TotalSeconds;
					return (hps / 1000.0).ToString("0");
				case "tohit":
					foreach (CombatantData cd in SelectiveAllies)
						tohit += cd.ToHit;
					tohit /= SelectiveAllies.Count;
					return tohit.ToString("F");
				case "dps":
				case "encdps":
					foreach (CombatantData cd in SelectiveAllies)
						damage += cd.Damage;
					dps = damage / Data.Duration.TotalSeconds;
					return dps.ToString("F");
				case "dps-k":
				case "encdps-k":
					foreach (CombatantData cd in SelectiveAllies)
						damage += cd.Damage;
					dps = damage / Data.Duration.TotalSeconds;
					return (dps / 1000.0).ToString("F");
				case "enchps":
					foreach (CombatantData cd in SelectiveAllies)
						healed += cd.Healed;
					hps = healed / Data.Duration.TotalSeconds;
					return hps.ToString("F");
				case "enchps-k":
					foreach (CombatantData cd in SelectiveAllies)
						healed += cd.Healed;
					hps = healed / Data.Duration.TotalSeconds;
					return (hps / 1000.0).ToString("F");
				case "healstaken":
					foreach (CombatantData cd in SelectiveAllies)
						healstaken += cd.HealsTaken;
					return healstaken.ToString();
				case "damagetaken":
					foreach (CombatantData cd in SelectiveAllies)
						damagetaken += cd.DamageTaken;
					return damagetaken.ToString();
				case "powerdrain":
					foreach (CombatantData cd in SelectiveAllies)
						powerdrain += cd.PowerDamage;
					return powerdrain.ToString();
				case "powerheal":
					foreach (CombatantData cd in SelectiveAllies)
						powerheal += cd.PowerReplenish;
					return powerheal.ToString();
				case "kills":
					foreach (CombatantData cd in SelectiveAllies)
						kills += cd.Kills;
					return kills.ToString();
				case "deaths":
					foreach (CombatantData cd in SelectiveAllies)
						deaths += cd.Deaths;
					return deaths.ToString();
				case "title":
					return Data.Title;

				default:
					return VarName;
			}
		}
		private string CombatantFormatSwitch(CombatantData Data, string VarName, string Extra)
		{
			int len = 0;
			switch (VarName)
			{
				case "name":
					return Data.Name;
				case "NAME":
					len = Int32.Parse(Extra);
					return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
				case "NAME3":
					len = 3;
					return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
				case "NAME4":
					len = 4;
					return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
				case "NAME5":
					len = 5;
					return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
				case "NAME6":
					len = 6;
					return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
				case "NAME7":
					len = 7;
					return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
				case "NAME8":
					len = 8;
					return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
				case "NAME9":
					len = 9;
					return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
				case "NAME10":
					len = 10;
					return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
				case "NAME11":
					len = 11;
					return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
				case "NAME12":
					len = 12;
					return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
				case "NAME13":
					len = 13;
					return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
				case "NAME14":
					len = 14;
					return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
				case "NAME15":
					len = 15;
					return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
				case "DURATION":
					return Data.Duration.TotalSeconds.ToString("0");
				case "duration":
					return Data.DurationS;
				case "maxhit":
					return Data.GetMaxHit(true);
				case "MAXHIT":
					return Data.GetMaxHit(false);
				case "maxheal":
					return Data.GetMaxHeal(true, false);
				case "MAXHEAL":
					return Data.GetMaxHeal(false, false);
				case "maxhealward":
					return Data.GetMaxHeal(true, true);
				case "MAXHEALWARD":
					return Data.GetMaxHeal(false, true);
				case "damage":
					return Data.Damage.ToString();
				case "damage-k":
					return (Data.Damage / 1000.0).ToString("0.00");
				case "damage-m":
					return (Data.Damage / 1000000.0).ToString("0.00");
				case "DAMAGE-k":
					return (Data.Damage / 1000.0).ToString("0");
				case "DAMAGE-m":
					return (Data.Damage / 1000000.0).ToString("0");
				case "healed":
					return Data.Healed.ToString();
				case "swings":
					return Data.Swings.ToString();
				case "hits":
					return Data.Hits.ToString();
				case "crithits":
					return Data.CritHits.ToString();
				case "critheals":
					return Data.CritHeals.ToString();
				case "crittypes":
					return CombatantDataGetCritTypes(Data);
				case "crithit%":
					return Data.CritDamPerc.ToString("0'%");
				case "critheal%":
					return Data.CritHealPerc.ToString("0'%");
				case "heals":
					return Data.Heals.ToString();
				case "cures":
					return Data.CureDispels.ToString();
				case "misses":
					return Data.Misses.ToString();
				case "hitfailed":
					return Data.Blocked.ToString();
				case "TOHIT":
					return Data.ToHit.ToString("0");
				case "DPS":
					return Data.DPS.ToString("0");
				case "DPS-k":
					return (Data.DPS / 1000.0).ToString("0");
				case "ENCDPS":
					return Data.EncDPS.ToString("0");
				case "ENCDPS-k":
					return (Data.EncDPS / 1000.0).ToString("0");
				case "ENCHPS":
					return Data.EncHPS.ToString("0");
				case "ENCHPS-k":
					return (Data.EncHPS / 1000.0).ToString("0");
				case "tohit":
					return Data.ToHit.ToString("F");
				case "dps":
					return Data.DPS.ToString("F");
				case "dps-k":
					return (Data.DPS / 1000.0).ToString("F");
				case "encdps":
					return Data.EncDPS.ToString("F");
				case "encdps-k":
					return (Data.EncDPS / 1000.0).ToString("F");
				case "enchps":
					return Data.EncHPS.ToString("F");
				case "enchps-k":
					return (Data.EncHPS / 1000.0).ToString("F");
				case "healstaken":
					return Data.HealsTaken.ToString();
				case "damagetaken":
					return Data.DamageTaken.ToString();
				case "powerdrain":
					return Data.PowerDamage.ToString();
				case "powerheal":
					return Data.PowerReplenish.ToString();
				case "kills":
					return Data.Kills.ToString();
				case "deaths":
					return Data.Deaths.ToString();
				case "damage%":
					return Data.DamagePercent;
				case "healed%":
					return Data.HealedPercent;
				case "threatstr":
					return Data.GetThreatStr("Threat (Out)");
				case "threatdelta":
					return Data.GetThreatDelta("Threat (Out)").ToString();
				case "n":
					return "\n";
				case "t":
					return "\t";

				default:
					return VarName;
			}
		}
		private string GetAttackTypeSwingType(AttackType Data)
		{
			int swingType = 100;
			List<int> swingTypes = new List<int>();
			List<MasterSwing> cachedItems = new List<MasterSwing>(Data.Items);
			for (int i = 0; i < cachedItems.Count; i++)
			{
				MasterSwing s = cachedItems[i];
				if (swingTypes.Contains(s.SwingType) == false)
					swingTypes.Add(s.SwingType);
			}
			if (swingTypes.Count == 1)
				swingType = swingTypes[0];

			return swingType.ToString();
		}
		private string GetDamageTypeGrouping(DamageTypeData Data)
		{
			string grouping = string.Empty;

			int swingTypeIndex = 0;
			if (Data.Outgoing)
			{
				grouping += "attacker=" + Data.Parent.Name;
				foreach (KeyValuePair<int, List<string>> links in CombatantData.SwingTypeToDamageTypeDataLinksOutgoing)
				{
					foreach (string damageTypeLabel in links.Value)
					{
						if (Data.Type == damageTypeLabel)
						{
							grouping += String.Format("&swingtype{0}={1}", swingTypeIndex++ == 0 ? string.Empty : swingTypeIndex.ToString(), links.Key);
						}
					}
				}
			}
			else
			{
				grouping += "victim=" + Data.Parent.Name;
				foreach (KeyValuePair<int, List<string>> links in CombatantData.SwingTypeToDamageTypeDataLinksIncoming)
				{
					foreach (string damageTypeLabel in links.Value)
					{
						if (Data.Type == damageTypeLabel)
						{
							grouping += String.Format("&swingtype{0}={1}", swingTypeIndex++ == 0 ? string.Empty : swingTypeIndex.ToString(), links.Key);
						}
					}
				}
			}

			return grouping;
		}
	}
}
