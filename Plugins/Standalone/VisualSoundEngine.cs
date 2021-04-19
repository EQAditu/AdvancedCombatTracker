using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Advanced_Combat_Tracker;
using Transitions;

[assembly: AssemblyTitle("Visual Sound Engine")]
[assembly: AssemblyDescription("Captures TTS/WAV being sent through ACT and displays a descriptive visual alert in addition")]
[assembly: AssemblyCopyright("EQAditu <aditu@advancedcombattracker.com>")]
[assembly: AssemblyVersion("1.0.1.2")]

namespace ACT_Plugin
{
	public class VisualSoundEngine : UserControl, IActPluginV1
	{
		#region Designer Code
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
			this.cbTopMost = new System.Windows.Forms.CheckBox();
			this.nudEventDuration = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.cbShowWindow = new System.Windows.Forms.CheckBox();
			this.cbClickThrough = new System.Windows.Forms.CheckBox();
			this.nudOpacity = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.cbWindowTransLocked = new System.Windows.Forms.CheckBox();
			this.cbEventTransLocked = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ccFormBg = new Advanced_Combat_Tracker.ColorControl();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.fccEventColors = new Advanced_Combat_Tracker.FontColorControl();
			((System.ComponentModel.ISupportInitialize)(this.nudEventDuration)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudOpacity)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbTopMost
			// 
			this.cbTopMost.AutoSize = true;
			this.cbTopMost.Checked = true;
			this.cbTopMost.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbTopMost.Location = new System.Drawing.Point(6, 42);
			this.cbTopMost.Name = "cbTopMost";
			this.cbTopMost.Size = new System.Drawing.Size(92, 17);
			this.cbTopMost.TabIndex = 1;
			this.cbTopMost.Text = "Always on top";
			this.cbTopMost.UseVisualStyleBackColor = true;
			this.cbTopMost.CheckedChanged += new System.EventHandler(this.cbTopMost_CheckedChanged);
			// 
			// nudEventDuration
			// 
			this.nudEventDuration.Location = new System.Drawing.Point(6, 19);
			this.nudEventDuration.Maximum = new decimal(new int[] {
			120,
			0,
			0,
			0});
			this.nudEventDuration.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.nudEventDuration.Name = "nudEventDuration";
			this.nudEventDuration.Size = new System.Drawing.Size(66, 20);
			this.nudEventDuration.TabIndex = 2;
			this.nudEventDuration.Value = new decimal(new int[] {
			10,
			0,
			0,
			0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(78, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(115, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Event Display Duration";
			// 
			// cbShowWindow
			// 
			this.cbShowWindow.AutoSize = true;
			this.cbShowWindow.Checked = true;
			this.cbShowWindow.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbShowWindow.Location = new System.Drawing.Point(6, 19);
			this.cbShowWindow.Name = "cbShowWindow";
			this.cbShowWindow.Size = new System.Drawing.Size(95, 17);
			this.cbShowWindow.TabIndex = 4;
			this.cbShowWindow.Text = "Show Window";
			this.cbShowWindow.UseVisualStyleBackColor = true;
			this.cbShowWindow.CheckedChanged += new System.EventHandler(this.cbShowWindow_CheckedChanged);
			// 
			// cbClickThrough
			// 
			this.cbClickThrough.AutoSize = true;
			this.cbClickThrough.Location = new System.Drawing.Point(6, 65);
			this.cbClickThrough.Name = "cbClickThrough";
			this.cbClickThrough.Size = new System.Drawing.Size(118, 17);
			this.cbClickThrough.TabIndex = 6;
			this.cbClickThrough.Text = "ClickThrough/Lock";
			this.cbClickThrough.UseVisualStyleBackColor = true;
			this.cbClickThrough.CheckedChanged += new System.EventHandler(this.cbClickThrough_CheckedChanged);
			// 
			// nudOpacity
			// 
			this.nudOpacity.DecimalPlaces = 2;
			this.nudOpacity.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.nudOpacity.Location = new System.Drawing.Point(6, 147);
			this.nudOpacity.Maximum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.nudOpacity.Name = "nudOpacity";
			this.nudOpacity.Size = new System.Drawing.Size(66, 20);
			this.nudOpacity.TabIndex = 2;
			this.nudOpacity.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.nudOpacity.ValueChanged += new System.EventHandler(this.nudOpacity_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(78, 149);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(177, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Window/Alert Opacity (0.00 to 1.00)";
			// 
			// cbWindowTransLocked
			// 
			this.cbWindowTransLocked.AutoSize = true;
			this.cbWindowTransLocked.Checked = true;
			this.cbWindowTransLocked.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbWindowTransLocked.Location = new System.Drawing.Point(6, 88);
			this.cbWindowTransLocked.Name = "cbWindowTransLocked";
			this.cbWindowTransLocked.Size = new System.Drawing.Size(303, 17);
			this.cbWindowTransLocked.TabIndex = 7;
			this.cbWindowTransLocked.Text = "Window becomes transparent when ClickThrough/Locked";
			this.cbWindowTransLocked.UseVisualStyleBackColor = true;
			this.cbWindowTransLocked.CheckedChanged += new System.EventHandler(this.cbWindowTransLocked_CheckedChanged);
			// 
			// cbEventTransLocked
			// 
			this.cbEventTransLocked.AutoSize = true;
			this.cbEventTransLocked.Location = new System.Drawing.Point(6, 101);
			this.cbEventTransLocked.Name = "cbEventTransLocked";
			this.cbEventTransLocked.Size = new System.Drawing.Size(322, 17);
			this.cbEventTransLocked.TabIndex = 4;
			this.cbEventTransLocked.Text = "Background becomes transparent when ClickThrough/Locked";
			this.cbEventTransLocked.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ccFormBg);
			this.groupBox1.Controls.Add(this.cbWindowTransLocked);
			this.groupBox1.Controls.Add(this.cbShowWindow);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cbClickThrough);
			this.groupBox1.Controls.Add(this.cbTopMost);
			this.groupBox1.Controls.Add(this.nudOpacity);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(397, 179);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Window Options";
			// 
			// ccFormBg
			// 
			this.ccFormBg.AutoSize = true;
			this.ccFormBg.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ccFormBg.ForeColorSetting = System.Drawing.SystemColors.Control;
			this.ccFormBg.Location = new System.Drawing.Point(6, 111);
			this.ccFormBg.Name = "ccFormBg";
			this.ccFormBg.Size = new System.Drawing.Size(282, 30);
			this.ccFormBg.TabIndex = 5;
			this.ccFormBg.Text = "Window Background Color  (when not transparent)";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cbEventTransLocked);
			this.groupBox2.Controls.Add(this.nudEventDuration);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.fccEventColors);
			this.groupBox2.Location = new System.Drawing.Point(3, 188);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(397, 126);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Event Options";
			// 
			// fccEventColors
			// 
			this.fccEventColors.AutoSize = true;
			this.fccEventColors.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.fccEventColors.BackColorSetting = System.Drawing.Color.Black;
			this.fccEventColors.FontChangable = true;
			this.fccEventColors.FontSetting = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fccEventColors.ForeColorSetting = System.Drawing.Color.Crimson;
			this.fccEventColors.Location = new System.Drawing.Point(6, 45);
			this.fccEventColors.Name = "fccEventColors";
			this.fccEventColors.Size = new System.Drawing.Size(337, 50);
			this.fccEventColors.TabIndex = 0;
			this.fccEventColors.Text = "Event Alert Colors";
			// 
			// VisualSoundEngine
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "VisualSoundEngine";
			this.Size = new System.Drawing.Size(1026, 625);
			((System.ComponentModel.ISupportInitialize)(this.nudEventDuration)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudOpacity)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private Advanced_Combat_Tracker.FontColorControl fccEventColors;
		private System.Windows.Forms.CheckBox cbTopMost;
		private System.Windows.Forms.NumericUpDown nudEventDuration;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox cbShowWindow;
		#endregion

		Label lblStatus;
		string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\VisualSoundEngine.config.xml");
		SettingsSerializer xmlSettings;
		Form eventWindow;
		FlowLayoutPanel eventPanel;
		FormActMain.PlaySoundDelegate oldSoundEngine;
		private ColorControl ccFormBg;
		private CheckBox cbClickThrough;
		private NumericUpDown nudOpacity;
		private Label label2;
		private CheckBox cbWindowTransLocked;
		private CheckBox cbEventTransLocked;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		FormActMain.PlayTtsDelegate oldTtsEngine;
		CheckBox cbbShowWindow;
		Color transparentKey = Color.FromArgb(11, 22, 33);

		public VisualSoundEngine()
		{
			InitializeComponent();
			eventWindow = new Form();
			eventWindow.Name = "eventWindow";
			eventWindow.Text = "Visual Sound Engine";
			eventWindow.TopMost = true;
			eventWindow.Size = new Size(800, 200);
			eventWindow.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			eventPanel = new FlowLayoutPanel();
			eventPanel.FlowDirection = FlowDirection.TopDown;
			eventWindow.Controls.Add(eventPanel);
			eventPanel.Dock = DockStyle.Fill;
			eventWindow.FormClosing += new FormClosingEventHandler(eventWindow_FormClosing);
			eventWindow.StartPosition = FormStartPosition.Manual;
			eventWindow.TransparencyKey = transparentKey;
			cbbShowWindow = new CheckBox();
			cbbShowWindow.AutoSize = true;
			cbbShowWindow.Text = "VisualSound";
			cbbShowWindow.Appearance = Appearance.Button;
			cbbShowWindow.TextAlign = ContentAlignment.MiddleCenter;
			cbbShowWindow.CheckedChanged += CbbShowWindow_CheckedChanged;
			cbbShowWindow.MouseUp += CbbShowWindow_MouseUp;
		}

		private void CbbShowWindow_MouseUp(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{
				cbClickThrough.Checked = !cbClickThrough.Checked;
			}
		}

		private void CbbShowWindow_CheckedChanged(object sender, EventArgs e)
		{
			cbShowWindow.Checked = cbbShowWindow.Checked;
		}

		void eventWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.WindowsShutDown)
			{
				ActGlobals.oFormActMain.Close();
			}
			else
			{
				e.Cancel = true;
				cbShowWindow.Checked = false;
			}
		}

		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			lblStatus = pluginStatusText;
			lblStatus.Text = "Starting...";
			pluginScreenSpace.Controls.Add(this);
			this.Dock = DockStyle.Fill;
			oldSoundEngine = ActGlobals.oFormActMain.PlaySoundMethod;
			oldTtsEngine = ActGlobals.oFormActMain.PlayTtsMethod;
			ActGlobals.oFormActMain.PlaySoundMethod = ShowSoundEvent;
			ActGlobals.oFormActMain.PlayTtsMethod = ShowTtsEvent;
			ccFormBg.ForeColorSettingChanged += (newColor) =>
			{
				if (!cbClickThrough.Checked) eventWindow.BackColor = newColor;
			};
			xmlSettings = new SettingsSerializer(this);
			LoadSettings();
			if (cbShowWindow.Checked)
			{
				eventWindow.Show();
				cbbShowWindow.Checked = true;
			}
			ActGlobals.oFormActMain.CornerControlAdd(cbbShowWindow);
			lblStatus.Text = "Plugin started...";
		}


		public void DeInitPlugin()
		{
			ActGlobals.oFormActMain.PlaySoundMethod = oldSoundEngine;
			ActGlobals.oFormActMain.PlayTtsMethod = oldTtsEngine;
			SaveSettings();
			eventWindow.Dispose();
			ActGlobals.oFormActMain.CornerControlRemove(cbbShowWindow);
		}
		void LoadSettings()
		{
			xmlSettings.AddControlSetting(cbTopMost.Name, cbTopMost);
			xmlSettings.AddControlSetting(cbShowWindow.Name, cbShowWindow);
			xmlSettings.AddControlSetting(fccEventColors.Name, fccEventColors);
			xmlSettings.AddControlSetting(ccFormBg.Name, ccFormBg);
			xmlSettings.AddControlSetting(nudEventDuration.Name, nudEventDuration);
			xmlSettings.AddControlSetting(eventWindow.Name, eventWindow);
			xmlSettings.AddControlSetting(cbClickThrough.Name, cbClickThrough);
			xmlSettings.AddControlSetting(cbEventTransLocked.Name, cbEventTransLocked);
			xmlSettings.AddControlSetting(cbWindowTransLocked.Name, cbWindowTransLocked);

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

		private void ShowTtsEvent(string TtsString)
		{
			AddEventLabel(TtsString);
			oldTtsEngine(TtsString);
		}
		private void ShowSoundEvent(string Sound, int Volume)
		{
			oldSoundEngine(Sound, Volume);
			if (Sound.EndsWith("sapi.wav"))
				return;

			Sound = Path.GetFileName(Sound);

			AddEventLabel(Sound);
		}

		private void AddEventLabel(string Text)
		{
			Label eventLabel = new Label();
			eventLabel.Text = Text;
			eventLabel.AutoSize = true;
			eventLabel.Font = fccEventColors.FontSetting;
			eventLabel.ForeColor = fccEventColors.ForeColorSetting;
			if (cbClickThrough.Checked && cbWindowTransLocked.Checked && cbEventTransLocked.Checked)
				eventLabel.BackColor = transparentKey;
			else
				eventLabel.BackColor = fccEventColors.BackColorSetting;
			Transition colorFade = new Transition(new TransitionType_Acceleration((int)nudEventDuration.Value * 1000));
			colorFade.add(eventLabel, "ForeColor", eventLabel.BackColor);
			colorFade.TransitionCompletedEvent += (sender, args) => { eventPanel.Controls.Remove(eventLabel); eventLabel.Dispose(); };
			eventPanel.SuspendLayout();
			eventPanel.Controls.Add(eventLabel);
			eventPanel.Controls.SetChildIndex(eventLabel, 0);
			eventPanel.ResumeLayout();
			colorFade.run();
		}
		private void cbShowWindow_CheckedChanged(object sender, EventArgs e)
		{
			eventWindow.Visible = cbShowWindow.Checked;
			cbbShowWindow.Checked = cbShowWindow.Checked;
		}
		private void cbTopMost_CheckedChanged(object sender, EventArgs e)
		{
			eventWindow.TopMost = cbTopMost.Checked;
		}

		private void cbClickThrough_CheckedChanged(object sender, EventArgs e)
		{
			SetClickThrough(cbClickThrough.Checked);
		}

		private void nudOpacity_ValueChanged(object sender, EventArgs e)
		{
			eventWindow.Opacity = (double)nudOpacity.Value;
			SetClickThrough(cbClickThrough.Checked);
		}
		private void cbWindowTransLocked_CheckedChanged(object sender, EventArgs e)
		{
			SetClickThrough(cbClickThrough.Checked);
		}


		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetWindowLong(IntPtr Handle, int nIndex);
		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int SetWindowLong(IntPtr Handle, int nIndex, int dwNewLong);
		const int WS_EX_TRANSPARENT = 0x00000020;

		void SetClickThrough(bool enable)
		{
			if (enable)
			{
				if (cbWindowTransLocked.Checked)
					eventWindow.BackColor = transparentKey;
				else
					eventWindow.BackColor = ccFormBg.ForeColorSetting;

				if (eventWindow.Opacity == 1)
					eventWindow.Opacity = 0.99;
				eventWindow.FormBorderStyle = FormBorderStyle.None;
				int windowFlags = GetWindowLong(eventWindow.Handle, -20);
				windowFlags |= WS_EX_TRANSPARENT;
				int swlReturn = SetWindowLong(eventWindow.Handle, -20, windowFlags);
			}
			else
			{
				eventWindow.BackColor = ccFormBg.ForeColorSetting;

				if (eventWindow.Opacity == 0.99)
					eventWindow.Opacity = 1;
				int windowFlags = GetWindowLong(eventWindow.Handle, -20);
				windowFlags ^= WS_EX_TRANSPARENT;
				int swlReturn = SetWindowLong(eventWindow.Handle, -20, windowFlags);
				eventWindow.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			}
		}

	}
}
