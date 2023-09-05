/////////////////////////////////////////////////////////////////////////////////////////////////
// Talking DPS Plugin for ACT
//
// Speaks current raid/group or personal encounter DPS information using Text-to-Speech.
//
// Original idea and first coded November 2008
// Version 1.0.0.0 Released November 7, 2008
// Version 1.0.0.1 Released November 7, 2008
//	- Fixed bug with speaking DPS while importing incounters.
// Version 1.0.0.2 Released December 23, 2008
//      - Corrected speaking grammer.  ie:  1 second instead of seconds (plural vs singular)
// Version 1.0.0.3 Released March 20, 2008
//	- Fixed exception bug if the combatant didn't exist when trying to calculate dps.
//
// Anap of Archon, Crushbone Server
/////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text;
using Advanced_Combat_Tracker;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.IO;
[assembly: AssemblyTitle("Talking DPS")]
[assembly: AssemblyDescription("Speaks current raid/group or personal encounter DPS information using Text-to-Speech.  See plugin configuration for options.")]
[assembly: AssemblyCompany("Anap of Archon, Crushbone Server")]
[assembly: AssemblyVersion("1.0.0.3")]
namespace Some_ACT_Plugin
{
	public class Talking_DPS : IActPluginV1
	{
		Label statusLabel;
		TabPage screenSpace;
		Timer tmrTick;

		string xmlFileName = Application.StartupPath + "\\Config\\Talking DPS.config.xml";

		#region Interface
		private System.Windows.Forms.GroupBox groupBox;
		private System.Windows.Forms.NumericUpDown nudInCombatInterval;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton rbReportRaidDPS;
		private System.Windows.Forms.RadioButton rbReportPersonalDPS;
		private System.Windows.Forms.CheckBox cbSpeakDuringEncounter;
		private System.Windows.Forms.CheckBox cbSpeakEndEncounter;
		private System.Windows.Forms.CheckBox cbSpeakEncounterName;
		private System.Windows.Forms.CheckBox cbSpeakEncounterDuration;
		private System.Windows.Forms.CheckBox cbSpeakNumDeaths;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnLoad;

		// setup config ui
		private void InitUI()
		{
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.nudInCombatInterval = new System.Windows.Forms.NumericUpDown();
			this.rbReportRaidDPS = new System.Windows.Forms.RadioButton();
			this.rbReportPersonalDPS = new System.Windows.Forms.RadioButton();
			this.cbSpeakDuringEncounter = new System.Windows.Forms.CheckBox();
			this.cbSpeakEndEncounter = new System.Windows.Forms.CheckBox();
			this.cbSpeakEncounterName = new System.Windows.Forms.CheckBox();
			this.cbSpeakEncounterDuration = new System.Windows.Forms.CheckBox();
			this.cbSpeakNumDeaths = new System.Windows.Forms.CheckBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnLoad = new System.Windows.Forms.Button();

			this.groupBox.SuspendLayout();

			((System.ComponentModel.ISupportInitialize)(this.nudInCombatInterval)).BeginInit();

			this.groupBox.Controls.Add(this.label1);
			this.groupBox.Controls.Add(this.label2);
			this.groupBox.Controls.Add(this.label3);
			this.groupBox.Controls.Add(this.nudInCombatInterval);
			this.groupBox.Controls.Add(this.rbReportRaidDPS);
			this.groupBox.Controls.Add(this.rbReportPersonalDPS);
			this.groupBox.Controls.Add(this.cbSpeakDuringEncounter);
			this.groupBox.Controls.Add(this.cbSpeakEndEncounter);
			this.groupBox.Controls.Add(this.cbSpeakEncounterName);
			this.groupBox.Controls.Add(this.cbSpeakEncounterDuration);
			this.groupBox.Controls.Add(this.cbSpeakNumDeaths);
			this.groupBox.Controls.Add(this.btnSave);
			this.groupBox.Controls.Add(this.btnLoad);

			this.groupBox.Location = new System.Drawing.Point(10, 15);
			this.groupBox.Size = new System.Drawing.Size(400, 350); // w, h
			this.groupBox.Text = "Talking DPS Configuration";

			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 25);
			this.label1.Text = "Reporting mode:";

			this.rbReportRaidDPS.AutoSize = true;
			this.rbReportRaidDPS.Location = new System.Drawing.Point(110, 24);
			this.rbReportRaidDPS.Name = "rbReportRaidDPS";
			this.rbReportRaidDPS.Size = new System.Drawing.Size(90, 17);
			this.rbReportRaidDPS.Checked = true;
			this.rbReportRaidDPS.Text = "Raid/Group DPS";
			//this.rbReportRaidDPS.CheckedChanged += new System.EventHandler(this.ReportModeChange);

			this.rbReportPersonalDPS.AutoSize = true;
			this.rbReportPersonalDPS.Location = new System.Drawing.Point(230, 24);
			this.rbReportPersonalDPS.Name = "rbReportPersonalDPS";
			this.rbReportPersonalDPS.Size = new System.Drawing.Size(90, 17);
			this.rbReportPersonalDPS.Text = "Personal DPS";
			//this.rbReportPersonalDPS.CheckedChanged += new System.EventHandler(this.ReportModeChange);

			this.cbSpeakDuringEncounter.AutoSize = true;
			this.cbSpeakDuringEncounter.Location = new System.Drawing.Point(10, 55);
			this.cbSpeakDuringEncounter.Checked = true;
			this.cbSpeakDuringEncounter.Name = "cbSpeakDuringEncounter";
			this.cbSpeakDuringEncounter.Text = "Speak DPS every";
			//this.cbSpeakDuringEncounter.CheckedChanged += new System.EventHandler(this.SpeakDuringEncounterChange);

			this.nudInCombatInterval.Location = new System.Drawing.Point(120, 53);
			this.nudInCombatInterval.Size = new System.Drawing.Size(50, 20);
			this.nudInCombatInterval.Maximum = 600;
			this.nudInCombatInterval.Minimum = 1;
			this.nudInCombatInterval.Value = 10;
			this.nudInCombatInterval.ValueChanged += new System.EventHandler(this.nudInCombatInterval_ValueChanged);

			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(173, 57);
			this.label2.Text = "seconds during an encounter";

			this.cbSpeakEndEncounter.AutoSize = true;
			this.cbSpeakEndEncounter.Location = new System.Drawing.Point(10, 80);
			this.cbSpeakEndEncounter.Checked = true;
			this.cbSpeakEndEncounter.Name = "cbSpeakEndEncounter";
			this.cbSpeakEndEncounter.Text = "Speak DPS when the encounter ends";

			this.cbSpeakEncounterName.AutoSize = true;
			this.cbSpeakEncounterName.Location = new System.Drawing.Point(45, 100);
			this.cbSpeakEncounterName.Checked = true;
			this.cbSpeakEncounterName.Name = "cbSpeakEncounterName";
			this.cbSpeakEncounterName.Text = "Include encounter name";

			this.cbSpeakEncounterDuration.AutoSize = true;
			this.cbSpeakEncounterDuration.Location = new System.Drawing.Point(45, 120);
			this.cbSpeakEncounterDuration.Checked = true;
			this.cbSpeakEncounterDuration.Name = "cbSpeakEncounterDuration";
			this.cbSpeakEncounterDuration.Text = "Include encounter duration";

			this.cbSpeakNumDeaths.AutoSize = true;
			this.cbSpeakNumDeaths.Location = new System.Drawing.Point(45, 140);
			this.cbSpeakNumDeaths.Checked = true;
			this.cbSpeakNumDeaths.Name = "cbSpeakNumDeaths";
			this.cbSpeakNumDeaths.Text = "Include number of allied deaths (includes pets)";

			this.btnSave.AutoSize = true;
			this.btnSave.Location = new System.Drawing.Point(10, 250);
			this.btnSave.Text = "Save Configuration";
			this.btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += new EventHandler(btnSave_Click);

			this.btnLoad.AutoSize = true;
			this.btnLoad.Location = new System.Drawing.Point(140, 250);
			this.btnLoad.Text = "Load Configuration";
			this.btnLoad.UseVisualStyleBackColor = true;
			btnLoad.Click += new EventHandler(btnLoad_Click);

			this.label3.AutoSize = false;
			this.label3.Location = new System.Drawing.Point(10, 280);
			this.label3.Size = new System.Drawing.Size(360, 50);
			this.label3.Text = "Configuration settings will automatically save when you disable this plugin or when you exit ACT.  You can manually save or load configuration settings by using the buttons above.";


			screenSpace.Controls.Add(this.groupBox);
			this.groupBox.ResumeLayout(false);
			this.groupBox.PerformLayout();

			((System.ComponentModel.ISupportInitialize)(this.nudInCombatInterval)).EndInit();
		}
		#endregion

		// Save button was clicked
		void btnSave_Click(object sender, EventArgs e)
		{
			SaveXmlSettings();
		}

		// Load button was clicked
		void btnLoad_Click(object sender, EventArgs e)
		{
			LoadXmlSettings();
		}

		// In combat timer changed
		private void nudInCombatInterval_ValueChanged(object sender, EventArgs e)
		{
			if (tmrTick.Enabled)
				tmrTick.Interval = (int)this.nudInCombatInterval.Value * 1000;
		}

		// Speak during an encounter changed
		private void SpeakDuringEncounterChange(object sender, EventArgs e)
		{
			if (cbSpeakDuringEncounter.Checked)
				StartEncounterTimer();
			else
				StopEncounterTimer();
		}

		// Report mode changed
		private void ReportModeChange(object sender, EventArgs e)
		{
			RadioButton button = (RadioButton)sender;
			if (button.Checked && button.Text == "Personal DPS")
				ActGlobals.oFormActMain.TTS("Reporting Personal D P S");
			if (button.Checked && button.Text == "Raid/Group DPS")
				ActGlobals.oFormActMain.TTS("Reporting Raid or group D P S");
		}


		#region IActPluginV1 Members
		// Plugin Stopped
		public void DeInitPlugin()
		{
			StopEncounterTimer();
			ActGlobals.oFormActMain.OnCombatEnd -= oFormActMain_OnCombatEnd;
			SaveXmlSettings();
			statusLabel.Text = "Plugin Stopped";
		}

		// Plugin Started
		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			screenSpace = pluginScreenSpace;
			statusLabel = pluginStatusText;
			InitUI();
			statusLabel.Text = "Plugin Started";
			ActGlobals.oFormActMain.OnCombatEnd += new CombatToggleEventDelegate(oFormActMain_OnCombatEnd);
			StartEncounterTimer();
			LoadXmlSettings();
		}
		#endregion


		// Combat End
		void oFormActMain_OnCombatEnd(bool isImport, CombatToggleEventArgs encounterInfo)
		{
			if (isImport)
				return;

			double dCurrDPS = myGetDPS();

			if (dCurrDPS > 0 && cbSpeakEndEncounter.Checked)
			{
				string sDPS = dCurrDPS.ToString("0.0") + " K";
				string sDuration = "";
				string sTitle = "";
				string sDeaths = "";
				string sPluralMins = "s";
				string sPluralSecs = "s";

				if (cbSpeakEncounterName.Checked)
					sTitle = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.Title;

				if (cbSpeakEncounterDuration.Checked)
				{
					DateTime startTime = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.StartTime;
					DateTime endTime = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.ShortEndTime;
					TimeSpan duration = endTime.Subtract(startTime);

					if (duration.Minutes == 1)
						sPluralMins = "";

					if (duration.Seconds == 1)
						sPluralSecs = "";

					if (duration.Minutes > 0)
						sDuration = " took " + duration.Minutes + " minute" + sPluralMins + " " + duration.Seconds + " second" + sPluralSecs + " at ";
					else
						sDuration = " took " + duration.Seconds + " second" + sPluralSecs + " at ";
				}

				if (cbSpeakNumDeaths.Checked)
					sDeaths = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.AlliedDeaths.ToString("0") + " deaths. ";

				ActGlobals.oFormActMain.TTS(sTitle + sDuration + sDPS + sDeaths);
			}
		}

		// Start a new timer for during encounter dps
		void StartEncounterTimer()
		{
			tmrTick = new Timer();
			tmrTick.Interval = (int)this.nudInCombatInterval.Value * 1000;
			tmrTick.Tick += new EventHandler(tmr_Tick);
			tmrTick.Enabled = true;
		}

		// Stop current encounter dps timer
		void StopEncounterTimer()
		{
			tmrTick.Enabled = false;
			tmrTick.Tick -= tmr_Tick;
		}

		// Current encounter dps timer tick
		void tmr_Tick(object sender, EventArgs e)
		{
			if (ActGlobals.oFormActMain.InCombat)
			{
				double dCurrDPS = myGetDPS();

				string sDPSTTS = dCurrDPS.ToString("0.0") + " K";

				string sCustom = "{DPS} K";

				sDPSTTS = sCustom.ToUpper().Replace("{DPS}", dCurrDPS.ToString("0.0"));

				// If in combat and dps is above 0, speak it
				// note: the above 0 check is to get around "infinity" problems
				if (ActGlobals.oFormActMain.InCombat && cbSpeakDuringEncounter.Checked && dCurrDPS > 0)
					ActGlobals.oFormActMain.TTS(sDPSTTS);
			}
		}

		// Get current encounter DPS
		private double myGetDPS()
		{
			double dDPS = 0;

			if (ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.GetCombatant(ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.CharName) == null)
				return 0;

			// Get raid/group dps
			if (rbReportRaidDPS.Checked)
				dDPS = (int)ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.DPS;
			// Get personal DPS
			else if (rbReportPersonalDPS.Checked)
				dDPS = (int)ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.GetCombatant(ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.CharName).ExtDPS;

			dDPS /= 1000;

			return dDPS;
		}

		// Save settings to XML file
		private void SaveXmlSettings()
		{
			using (XmlTextWriter xml = new XmlTextWriter(xmlFileName, System.Text.Encoding.UTF8))
			{
				xml.Formatting = Formatting.Indented;
				xml.Indentation = 4;
				xml.Namespaces = false;

				xml.WriteStartDocument();

				xml.WriteStartElement("", "Config", "");

				xml.WriteStartElement("", "InCombatInterval", "");
				xml.WriteString(nudInCombatInterval.Value.ToString());
				xml.WriteEndElement();

				xml.WriteStartElement("", "ReportRaidDPS", "");
				xml.WriteString(rbReportRaidDPS.Checked.ToString());
				xml.WriteEndElement();

				xml.WriteStartElement("", "ReportPersonalDPS", "");
				xml.WriteString(rbReportPersonalDPS.Checked.ToString());
				xml.WriteEndElement();

				xml.WriteStartElement("", "SpeakDuringEncounter", "");
				xml.WriteString(cbSpeakDuringEncounter.Checked.ToString());
				xml.WriteEndElement();

				xml.WriteStartElement("", "SpeakEndEncounter", "");
				xml.WriteString(cbSpeakEndEncounter.Checked.ToString());
				xml.WriteEndElement();

				xml.WriteStartElement("", "SpeakEncounterName", "");
				xml.WriteString(cbSpeakEncounterName.Checked.ToString());
				xml.WriteEndElement();

				xml.WriteStartElement("", "SpeakEncounterDuration", "");
				xml.WriteString(cbSpeakEncounterDuration.Checked.ToString());
				xml.WriteEndElement();

				xml.WriteStartElement("", "SpeakNumDeaths", "");
				xml.WriteString(cbSpeakNumDeaths.Checked.ToString());
				xml.WriteEndElement();

				xml.WriteEndElement();  //Config

				xml.WriteEndDocument();
			}
		}

		// Load settings from XML file
		private void LoadXmlSettings()
		{
			FileInfo file = new FileInfo(xmlFileName);
			if (file.Exists == false)
				return;

			using (XmlTextReader xml = new XmlTextReader(xmlFileName))
			{
				try
				{
					while (xml.Read())
					{
						if (xml.NodeType == XmlNodeType.Element)
						{
							try
							{
								if (xml.LocalName == "InCombatInterval")
									nudInCombatInterval.Value = Convert.ToDecimal(xml.ReadString());
								if (xml.LocalName == "ReportRaidDPS")
									rbReportRaidDPS.Checked = Convert.ToBoolean(xml.ReadString());
								if (xml.LocalName == "ReportPersonalDPS")
									rbReportPersonalDPS.Checked = Convert.ToBoolean(xml.ReadString());
								if (xml.LocalName == "SpeakDuringEncounter")
									cbSpeakDuringEncounter.Checked = Convert.ToBoolean(xml.ReadString());
								if (xml.LocalName == "SpeakEndEncounter")
									cbSpeakEndEncounter.Checked = Convert.ToBoolean(xml.ReadString());
								if (xml.LocalName == "SpeakEncounterName")
									cbSpeakEncounterName.Checked = Convert.ToBoolean(xml.ReadString());
								if (xml.LocalName == "SpeakEncounterDuration")
									cbSpeakEncounterDuration.Checked = Convert.ToBoolean(xml.ReadString());
								if (xml.LocalName == "SpeakNumDeaths")
									cbSpeakNumDeaths.Checked = Convert.ToBoolean(xml.ReadString());

							}
							catch (System.Exception ex)
							{
								string error = String.Format("Error while parsing XML settings: Line #{0} ({1})\n{2}", xml.LineNumber, xml.LocalName, ex.Message);
								MessageBox.Show(error + "\n\n Attempting default settings!", "Talking DPS Plugin - XML Preferences Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								ActGlobals.oFormActMain.WriteExceptionLog(ex, error);
								continue;
							}
						}
					}
				}
				catch (System.Exception ex)
				{
					string error = "The XML settings file may be corrupt or unusable.  Loading defaults where applicable.";
					MessageBox.Show(error, "Talking DPS Plugin - XML Preferences Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					ActGlobals.oFormActMain.WriteExceptionLog(ex, error);
				}
			}
		}
	
	
	
	
	// end public class
    }
// end namespace
}
// EOF
