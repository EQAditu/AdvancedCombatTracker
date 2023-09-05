using System;
using System.Text;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.IO;
using System.Reflection;
using System.Xml;

[assembly: AssemblyTitle("Encounter Trim Silence")]
[assembly: AssemblyDescription("A sample plugin that will trim the duration in the middle of encounters when no combat(silence) is encountered.  Requires an idle combat end timer longer than the silence limit.")]
[assembly: AssemblyCompany("EQAditu")]
[assembly: AssemblyVersion("1.0.0.1")]

namespace ACT_Plugin
{
	public class EncTrimSilence : UserControl, IActPluginV1
	{
		#region Designer Created Code (Avoid editing)
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
			this.rtbLog = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.nudSilenceLimit = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.nudSilenceLimit)).BeginInit();
			this.SuspendLayout();
			// 
			// rtbLog
			// 
			this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.rtbLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbLog.Location = new System.Drawing.Point(3, 74);
			this.rtbLog.Name = "rtbLog";
			this.rtbLog.ReadOnly = true;
			this.rtbLog.Size = new System.Drawing.Size(680, 307);
			this.rtbLog.TabIndex = 0;
			this.rtbLog.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(314, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Number of seconds to count before trimming silence (0 to disable)";
			// 
			// nudSilenceLimit
			// 
			this.nudSilenceLimit.Location = new System.Drawing.Point(377, 9);
			this.nudSilenceLimit.Name = "nudSilenceLimit";
			this.nudSilenceLimit.Size = new System.Drawing.Size(64, 20);
			this.nudSilenceLimit.TabIndex = 2;
			this.nudSilenceLimit.Value = new decimal(new int[] {
			15,
			0,
			0,
			0});
			this.nudSilenceLimit.ValueChanged += new System.EventHandler(this.nudSilenceLimit_ValueChanged);
			// 
			// EncTrimSilence
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.nudSilenceLimit);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.rtbLog);
			this.Name = "EncTrimSilence";
			this.Size = new System.Drawing.Size(686, 384);
			((System.ComponentModel.ISupportInitialize)(this.nudSilenceLimit)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		#endregion
		public EncTrimSilence()
		{
			InitializeComponent();
		}

		Label lblStatus;    // The status label that appears in ACT's Plugin tab
		string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\EncTrimSilence.config.xml");
		private RichTextBox rtbLog;
		private Label label1;
		private NumericUpDown nudSilenceLimit;
		SettingsSerializer xmlSettings;
		int silenceLimit = 15;
		DateTime lastHostile = DateTime.MinValue;

		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			lblStatus = pluginStatusText;   // Hand the status label's reference to our local var
			pluginScreenSpace.Controls.Add(this);   // Add this UserControl to the tab ACT provides
			this.Dock = DockStyle.Fill; // Expand the UserControl to fill the tab's client space
			xmlSettings = new SettingsSerializer(this); // Create a new settings serializer and pass it this instance
			LoadSettings();

			// Create some sort of parsing event handler.  After the "+=" hit TAB twice and the code will be generated for you.
			ActGlobals.oFormActMain.BeforeCombatAction += FormActMain_BeforeCombatAction;
			ActGlobals.oFormActMain.OnCombatStart += FormActMain_OnCombatStart;
			ActGlobals.oFormActMain.OnCombatEnd += FormActMain_OnCombatEnd;

			lblStatus.Text = "Plugin Started";
		}

		public void DeInitPlugin()
		{
			// Unsubscribe from any events you listen to when exiting!
			ActGlobals.oFormActMain.BeforeCombatAction -= FormActMain_BeforeCombatAction;
			ActGlobals.oFormActMain.OnCombatStart -= FormActMain_OnCombatStart;
			ActGlobals.oFormActMain.OnCombatEnd -= FormActMain_OnCombatEnd;

			SaveSettings();
			lblStatus.Text = "Plugin Exited";
		}

		private void FormActMain_BeforeCombatAction(bool isImport, CombatActionEventArgs actionInfo)
		{
			if (silenceLimit == 0 || actionInfo.cancelAction)
				return;

			if (CombatantData.DamageSwingTypes.Contains(actionInfo.swingType))
			{
				if ((actionInfo.time - lastHostile).TotalSeconds > silenceLimit)
				{
					ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.EndTimes.Add(ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.EndTime);
					ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.StartTimes.Add(actionInfo.time);
					if (ActGlobals.oFormActMain.ActiveZone.PopulateAll)
					{
						ActGlobals.oFormActMain.ActiveZone.Items[0].EndTimes.Add(ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.EndTime);
						ActGlobals.oFormActMain.ActiveZone.Items[0].StartTimes.Add(actionInfo.time);
					}
				}
				lastHostile = actionInfo.time;
			}
		}
		private void FormActMain_OnCombatStart(bool isImport, CombatToggleEventArgs encounterInfo)
		{
			Log("Combat started. " + ActGlobals.oFormActMain.LastKnownTime.ToLongTimeString());
			lastHostile = ActGlobals.oFormActMain.LastKnownTime;
		}
		private void FormActMain_OnCombatEnd(bool isImport, CombatToggleEventArgs encounterInfo)
		{
			StringBuilder sb = new StringBuilder();
			foreach (DateTime start in encounterInfo.encounter.StartTimes)
				sb.Append(start.ToLongTimeString() + ", ");
			sb.Length = sb.Length - 2;
			Log("\t\tStarts: " + sb);
			sb.Clear();
			foreach (DateTime end in encounterInfo.encounter.EndTimes)
				sb.Append(end.ToLongTimeString() + ", ");
			sb.Length = sb.Length - 2;
			Log("\t\tEnds:   " + sb);

			double oldDuration;
			if (encounterInfo.encounter.EndTime == DateTime.MinValue || encounterInfo.encounter.StartTime == DateTime.MaxValue)
				oldDuration = 0;
			else
				oldDuration = (encounterInfo.encounter.EndTime - encounterInfo.encounter.StartTime).TotalSeconds;
			Log(String.Format("Combat ended.   {1} \tTrim: {2:0} -> {3:0}s ({0})",
				encounterInfo.encounter.Title, encounterInfo.encounter.EndTime.ToLongTimeString(), oldDuration, encounterInfo.encounter.Duration.TotalSeconds));
		}

		void LoadSettings()
		{
			// Add any controls you want to save the state of
			xmlSettings.AddControlSetting(nudSilenceLimit.Name, nudSilenceLimit);

			if (File.Exists(settingsFile))
			{
				using (FileStream fs = new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (XmlTextReader xReader = new XmlTextReader(fs))
				{
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
				}
			}
		}
		void SaveSettings()
		{
			using (MemoryStream ms = new MemoryStream())
			using (XmlTextWriter xWriter = new XmlTextWriter(ms, Encoding.UTF8))
			{
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
				xWriter.Flush();    // Flush the buffer (useless for memory streams?)
				ActGlobals.oFormActMain.UncachedFileSave(new FileInfo(settingsFile), ms);   // I don't trust OS write caching :(
			}
		}

		private void nudSilenceLimit_ValueChanged(object sender, EventArgs e)
		{
			silenceLimit = (int)nudSilenceLimit.Value;
		}
		void Log(string LogText)
		{
			ThreadInvokes.RichTextBoxAppendDateTimeLine(ActGlobals.oFormActMain, rtbLog, LogText);
		}
	}
}
