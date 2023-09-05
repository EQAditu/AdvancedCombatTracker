using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.Reflection;
using System.IO;
using System.Xml;

[assembly: AssemblyTitle("Auto Attack")]
[assembly: AssemblyDescription("Autoattack notification and tracking")]
[assembly: AssemblyVersion("2.0.0.8")]

namespace ACT_Plugin
{
	public class Auto_Attack : UserControl, IActPluginV1
	{
		#region IDE Generated Code (Do not edit directly)
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
			this.gbDetectedAttacks = new System.Windows.Forms.GroupBox();
			this.lvAttacks = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.gbSoundAlerts = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lbSoundAlerts = new System.Windows.Forms.ListBox();
			this.btnSoundAdd = new System.Windows.Forms.Button();
			this.btnSoundRemove = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.rbAlertTts = new System.Windows.Forms.RadioButton();
			this.rbAlertWav = new System.Windows.Forms.RadioButton();
			this.rbAlertQuestion = new System.Windows.Forms.RadioButton();
			this.rbAlertError = new System.Windows.Forms.RadioButton();
			this.rbAlertExclamation = new System.Windows.Forms.RadioButton();
			this.rbAlertAsterisk = new System.Windows.Forms.RadioButton();
			this.btnTtsPlay = new System.Windows.Forms.Button();
			this.rbAlertBeep = new System.Windows.Forms.RadioButton();
			this.btnWavPlay = new System.Windows.Forms.Button();
			this.tbAlertTts = new System.Windows.Forms.TextBox();
			this.btnWavBrowse = new System.Windows.Forms.Button();
			this.tbAlertWav = new System.Windows.Forms.TextBox();
			this.tbAlertType = new System.Windows.Forms.TextBox();
			this.btnReset = new System.Windows.Forms.Button();
			this.gbDetectedAttacks.SuspendLayout();
			this.gbSoundAlerts.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbDetectedAttacks
			// 
			this.gbDetectedAttacks.Controls.Add(this.lvAttacks);
			this.gbDetectedAttacks.Location = new System.Drawing.Point(3, 3);
			this.gbDetectedAttacks.Name = "gbDetectedAttacks";
			this.gbDetectedAttacks.Size = new System.Drawing.Size(708, 173);
			this.gbDetectedAttacks.TabIndex = 0;
			this.gbDetectedAttacks.TabStop = false;
			this.gbDetectedAttacks.Text = "Detected Attacks";
			// 
			// lvAttacks
			// 
			this.lvAttacks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lvAttacks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
			this.lvAttacks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvAttacks.FullRowSelect = true;
			this.lvAttacks.Location = new System.Drawing.Point(6, 19);
			this.lvAttacks.Name = "lvAttacks";
			this.lvAttacks.Size = new System.Drawing.Size(696, 148);
			this.lvAttacks.TabIndex = 0;
			this.lvAttacks.UseCompatibleStateImageBehavior = false;
			this.lvAttacks.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Special Type";
			this.columnHeader1.Width = 123;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Proc Count";
			this.columnHeader2.Width = 123;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Extra Attacks";
			this.columnHeader3.Width = 123;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Proc Chance";
			this.columnHeader4.Width = 123;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Extra to Normal";
			this.columnHeader5.Width = 123;
			// 
			// gbSoundAlerts
			// 
			this.gbSoundAlerts.Controls.Add(this.tableLayoutPanel1);
			this.gbSoundAlerts.Controls.Add(this.label1);
			this.gbSoundAlerts.Controls.Add(this.rbAlertTts);
			this.gbSoundAlerts.Controls.Add(this.rbAlertWav);
			this.gbSoundAlerts.Controls.Add(this.rbAlertQuestion);
			this.gbSoundAlerts.Controls.Add(this.rbAlertError);
			this.gbSoundAlerts.Controls.Add(this.rbAlertExclamation);
			this.gbSoundAlerts.Controls.Add(this.rbAlertAsterisk);
			this.gbSoundAlerts.Controls.Add(this.btnTtsPlay);
			this.gbSoundAlerts.Controls.Add(this.rbAlertBeep);
			this.gbSoundAlerts.Controls.Add(this.btnWavPlay);
			this.gbSoundAlerts.Controls.Add(this.tbAlertTts);
			this.gbSoundAlerts.Controls.Add(this.btnWavBrowse);
			this.gbSoundAlerts.Controls.Add(this.tbAlertWav);
			this.gbSoundAlerts.Controls.Add(this.tbAlertType);
			this.gbSoundAlerts.Location = new System.Drawing.Point(3, 182);
			this.gbSoundAlerts.Name = "gbSoundAlerts";
			this.gbSoundAlerts.Size = new System.Drawing.Size(708, 174);
			this.gbSoundAlerts.TabIndex = 2;
			this.gbSoundAlerts.TabStop = false;
			this.gbSoundAlerts.Text = "Sound Alerts";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.lbSoundAlerts, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnSoundAdd, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnSoundRemove, 1, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(522, 19);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.8792F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.12081F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(180, 149);
			this.tableLayoutPanel1.TabIndex = 14;
			// 
			// lbSoundAlerts
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.lbSoundAlerts, 2);
			this.lbSoundAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbSoundAlerts.FormattingEnabled = true;
			this.lbSoundAlerts.IntegralHeight = false;
			this.lbSoundAlerts.Location = new System.Drawing.Point(3, 3);
			this.lbSoundAlerts.Name = "lbSoundAlerts";
			this.lbSoundAlerts.Size = new System.Drawing.Size(174, 115);
			this.lbSoundAlerts.Sorted = true;
			this.lbSoundAlerts.TabIndex = 0;
			this.lbSoundAlerts.SelectedIndexChanged += new System.EventHandler(this.lbSoundAlerts_SelectedIndexChanged);
			// 
			// btnSoundAdd
			// 
			this.btnSoundAdd.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnSoundAdd.Location = new System.Drawing.Point(3, 124);
			this.btnSoundAdd.Name = "btnSoundAdd";
			this.btnSoundAdd.Size = new System.Drawing.Size(84, 22);
			this.btnSoundAdd.TabIndex = 1;
			this.btnSoundAdd.Text = "Add/Edit";
			this.btnSoundAdd.UseVisualStyleBackColor = true;
			this.btnSoundAdd.Click += new System.EventHandler(this.btnSoundAdd_Click);
			// 
			// btnSoundRemove
			// 
			this.btnSoundRemove.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnSoundRemove.Location = new System.Drawing.Point(93, 124);
			this.btnSoundRemove.Name = "btnSoundRemove";
			this.btnSoundRemove.Size = new System.Drawing.Size(84, 22);
			this.btnSoundRemove.TabIndex = 2;
			this.btnSoundRemove.Text = "Remove";
			this.btnSoundRemove.UseVisualStyleBackColor = true;
			this.btnSoundRemove.Click += new System.EventHandler(this.btnSoundRemove_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Special Type";
			// 
			// rbAlertTts
			// 
			this.rbAlertTts.AutoSize = true;
			this.rbAlertTts.Location = new System.Drawing.Point(9, 147);
			this.rbAlertTts.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.rbAlertTts.Name = "rbAlertTts";
			this.rbAlertTts.Size = new System.Drawing.Size(98, 17);
			this.rbAlertTts.TabIndex = 11;
			this.rbAlertTts.Text = "Text to Speech";
			this.rbAlertTts.UseVisualStyleBackColor = true;
			this.rbAlertTts.CheckedChanged += new System.EventHandler(this.rbAlertTts_CheckedChanged);
			// 
			// rbAlertWav
			// 
			this.rbAlertWav.AutoSize = true;
			this.rbAlertWav.Location = new System.Drawing.Point(9, 130);
			this.rbAlertWav.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.rbAlertWav.Name = "rbAlertWav";
			this.rbAlertWav.Size = new System.Drawing.Size(88, 17);
			this.rbAlertWav.TabIndex = 7;
			this.rbAlertWav.Text = "Custom WAV";
			this.rbAlertWav.UseVisualStyleBackColor = true;
			this.rbAlertWav.CheckedChanged += new System.EventHandler(this.rbAlertWav_CheckedChanged);
			// 
			// rbAlertQuestion
			// 
			this.rbAlertQuestion.AutoSize = true;
			this.rbAlertQuestion.Location = new System.Drawing.Point(9, 113);
			this.rbAlertQuestion.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.rbAlertQuestion.Name = "rbAlertQuestion";
			this.rbAlertQuestion.Size = new System.Drawing.Size(67, 17);
			this.rbAlertQuestion.TabIndex = 6;
			this.rbAlertQuestion.Text = "Question";
			this.rbAlertQuestion.UseVisualStyleBackColor = true;
			// 
			// rbAlertError
			// 
			this.rbAlertError.AutoSize = true;
			this.rbAlertError.Location = new System.Drawing.Point(9, 96);
			this.rbAlertError.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.rbAlertError.Name = "rbAlertError";
			this.rbAlertError.Size = new System.Drawing.Size(47, 17);
			this.rbAlertError.TabIndex = 5;
			this.rbAlertError.Text = "Error";
			this.rbAlertError.UseVisualStyleBackColor = true;
			// 
			// rbAlertExclamation
			// 
			this.rbAlertExclamation.AutoSize = true;
			this.rbAlertExclamation.Location = new System.Drawing.Point(9, 79);
			this.rbAlertExclamation.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.rbAlertExclamation.Name = "rbAlertExclamation";
			this.rbAlertExclamation.Size = new System.Drawing.Size(82, 17);
			this.rbAlertExclamation.TabIndex = 4;
			this.rbAlertExclamation.Text = "Exclamation";
			this.rbAlertExclamation.UseVisualStyleBackColor = true;
			// 
			// rbAlertAsterisk
			// 
			this.rbAlertAsterisk.AutoSize = true;
			this.rbAlertAsterisk.Location = new System.Drawing.Point(9, 62);
			this.rbAlertAsterisk.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.rbAlertAsterisk.Name = "rbAlertAsterisk";
			this.rbAlertAsterisk.Size = new System.Drawing.Size(62, 17);
			this.rbAlertAsterisk.TabIndex = 3;
			this.rbAlertAsterisk.Text = "Asterisk";
			this.rbAlertAsterisk.UseVisualStyleBackColor = true;
			// 
			// btnTtsPlay
			// 
			this.btnTtsPlay.Location = new System.Drawing.Point(489, 146);
			this.btnTtsPlay.Name = "btnTtsPlay";
			this.btnTtsPlay.Size = new System.Drawing.Size(27, 20);
			this.btnTtsPlay.TabIndex = 13;
			this.btnTtsPlay.Text = "|>";
			this.btnTtsPlay.UseVisualStyleBackColor = true;
			this.btnTtsPlay.Click += new System.EventHandler(this.btnTtsPlay_Click);
			// 
			// rbAlertBeep
			// 
			this.rbAlertBeep.AutoSize = true;
			this.rbAlertBeep.Checked = true;
			this.rbAlertBeep.Location = new System.Drawing.Point(9, 45);
			this.rbAlertBeep.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.rbAlertBeep.Name = "rbAlertBeep";
			this.rbAlertBeep.Size = new System.Drawing.Size(50, 17);
			this.rbAlertBeep.TabIndex = 2;
			this.rbAlertBeep.TabStop = true;
			this.rbAlertBeep.Text = "Beep";
			this.rbAlertBeep.UseVisualStyleBackColor = true;
			// 
			// btnWavPlay
			// 
			this.btnWavPlay.Location = new System.Drawing.Point(489, 126);
			this.btnWavPlay.Name = "btnWavPlay";
			this.btnWavPlay.Size = new System.Drawing.Size(27, 20);
			this.btnWavPlay.TabIndex = 10;
			this.btnWavPlay.Text = "|>";
			this.btnWavPlay.UseVisualStyleBackColor = true;
			this.btnWavPlay.Click += new System.EventHandler(this.btnWavPlay_Click);
			// 
			// tbAlertTts
			// 
			this.tbAlertTts.Enabled = false;
			this.tbAlertTts.Location = new System.Drawing.Point(113, 146);
			this.tbAlertTts.Name = "tbAlertTts";
			this.tbAlertTts.Size = new System.Drawing.Size(373, 20);
			this.tbAlertTts.TabIndex = 12;
			// 
			// btnWavBrowse
			// 
			this.btnWavBrowse.Location = new System.Drawing.Point(462, 126);
			this.btnWavBrowse.Name = "btnWavBrowse";
			this.btnWavBrowse.Size = new System.Drawing.Size(27, 20);
			this.btnWavBrowse.TabIndex = 9;
			this.btnWavBrowse.Text = "...";
			this.btnWavBrowse.UseVisualStyleBackColor = true;
			this.btnWavBrowse.Click += new System.EventHandler(this.btnWavBrowse_Click);
			// 
			// tbAlertWav
			// 
			this.tbAlertWav.Enabled = false;
			this.tbAlertWav.Location = new System.Drawing.Point(103, 126);
			this.tbAlertWav.Name = "tbAlertWav";
			this.tbAlertWav.Size = new System.Drawing.Size(357, 20);
			this.tbAlertWav.TabIndex = 8;
			// 
			// tbAlertType
			// 
			this.tbAlertType.Location = new System.Drawing.Point(81, 19);
			this.tbAlertType.Name = "tbAlertType";
			this.tbAlertType.Size = new System.Drawing.Size(182, 20);
			this.tbAlertType.TabIndex = 1;
			this.tbAlertType.Text = "None";
			// 
			// btnReset
			// 
			this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnReset.ForeColor = System.Drawing.Color.DarkRed;
			this.btnReset.Location = new System.Drawing.Point(627, 24);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(75, 18);
			this.btnReset.TabIndex = 1;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// Auto_Attack
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.gbSoundAlerts);
			this.Controls.Add(this.gbDetectedAttacks);
			this.Name = "Auto_Attack";
			this.Size = new System.Drawing.Size(714, 417);
			this.gbDetectedAttacks.ResumeLayout(false);
			this.gbSoundAlerts.ResumeLayout(false);
			this.gbSoundAlerts.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbDetectedAttacks;
		private System.Windows.Forms.ListView lvAttacks;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.GroupBox gbSoundAlerts;
		private System.Windows.Forms.Button btnWavBrowse;
		private System.Windows.Forms.TextBox tbAlertType;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton rbAlertBeep;
		private System.Windows.Forms.RadioButton rbAlertAsterisk;
		private System.Windows.Forms.RadioButton rbAlertWav;
		private System.Windows.Forms.RadioButton rbAlertQuestion;
		private System.Windows.Forms.RadioButton rbAlertError;
		private System.Windows.Forms.RadioButton rbAlertExclamation;
		private System.Windows.Forms.Button btnWavPlay;
		private System.Windows.Forms.TextBox tbAlertWav;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ListBox lbSoundAlerts;
		private System.Windows.Forms.Button btnSoundAdd;
		private RadioButton rbAlertTts;
		private Button btnTtsPlay;
		private TextBox tbAlertTts;
		private Button btnReset;
		private System.Windows.Forms.Button btnSoundRemove;

		#endregion
		public Auto_Attack()
		{
			InitializeComponent();
		}
		Label lblPlugin;
		string xmlFileName = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, @"Config\Auto_Attack.config.xml");
		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			pluginScreenSpace.Controls.Add(this);
			this.Dock = DockStyle.Fill;
			ActGlobals.oFormActMain.AfterCombatAction += new CombatActionDelegate(oFormActMain_AfterCombatAction);
			LoadXmlSettings();
			lblPlugin = pluginStatusText;
			lblPlugin.Text = "Plugin Started.";
		}
		string[] aSentryStrings = new string[] { "Ancestral Sentry", "Ahnenwachtposten" };
		float totalSwings = 0;
		SortedDictionary<string, float> specialExtra = new SortedDictionary<string, float>();
		SortedDictionary<string, float> specialProc = new SortedDictionary<string, float>();
		SortedDictionary<string, bool> usedSpecials = new SortedDictionary<string, bool>();
		void oFormActMain_AfterCombatAction(bool isImport, CombatActionEventArgs actionInfo)
		{
			if (isImport)
				return;
			if (actionInfo.attacker == ActGlobals.charName && actionInfo.swingType == (int)SwingTypeEnum.Melee)
				if (!ActGlobals.oFormActMain.LastLogLine.Substring(ActGlobals.oFormActMain.TimeStampLen).StartsWith(ActGlobals.charName))
					if (!InputContains(actionInfo.victim, aSentryStrings))
					{
						string key = actionInfo.special.ToLower();
						if (key == "none")
						{
							usedSpecials.Clear();
							totalSwings++;
						}
						else
						{
							if (!usedSpecials.ContainsKey(key))
							{
								usedSpecials.Add(key, true);
								if (specialProc.ContainsKey(key))
									specialProc[key] += 1F;
								else
									specialProc.Add(key, 1F);
							}
							if (specialExtra.ContainsKey(key))
								specialExtra[key] += 1F;
							else
								specialExtra.Add(key, 1F);
						}

						if (soundSettings.ContainsKey(key))
						{
							try
							{
								soundSettings[key].PlayAlert();
							}
							catch (Exception ex)
							{
								ActGlobals.oFormActMain.WriteExceptionLog(ex, actionInfo.special);
							}
						}
						UpdateListView();
					}
		}
		private void UpdateListView()
		{
			gbDetectedAttacks.Text = "Detected Attacks (" + totalSwings + " total)";
			lvAttacks.BeginUpdate();
			lvAttacks.Items.Clear();
			foreach (KeyValuePair<string, float> pair in specialExtra)
			{
				ListViewItem lvi = new ListViewItem();
				lvi.Text = UppercaseFirst(pair.Key);
				lvi.SubItems.Add(specialProc[pair.Key].ToString());
				lvi.SubItems.Add(pair.Value.ToString());
				lvi.SubItems.Add(String.Format("{0:0.00%}", specialProc[pair.Key] / totalSwings));
				lvi.SubItems.Add(String.Format("{0:0.00%}", pair.Value / totalSwings));
				lvAttacks.Items.Add(lvi);
			}
			lvAttacks.EndUpdate();
		}
		static string UppercaseFirst(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return string.Empty;
			}
			char[] a = s.ToCharArray();
			a[0] = char.ToUpper(a[0]);
			return new string(a);
		}
		bool InputContains(string input, string[] terms)
		{
			for (int i = 0; i < terms.Length; i++)
			{
				if (input.Contains(terms[i]))
					return true;
			}
			return false;
		}
		public void DeInitPlugin()
		{
			ActGlobals.oFormActMain.AfterCombatAction -= oFormActMain_AfterCombatAction;
			SaveXmlSettings();
			lblPlugin.Text = "Plugin exited.";
		}
		private void LoadXmlSettings()
		{
			FileInfo file = new FileInfo(xmlFileName);
			if (!file.Exists)
			{
				// Add default beep for "None" special type
				SoundSetting setting = new SoundSetting();
				setting.special = "None";
				setting.soundType = SoundSettingTypeEnum.Beep;
				AddSoundSetting(setting);

				return;
			}
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
								if (xml.LocalName == "SoundSettings")
								{
									while (xml.Read())
									{
										if (xml.NodeType == XmlNodeType.Element)
										{
											if (xml.LocalName == "SoundSetting")
											{
												SoundSetting setting = new SoundSetting();
												setting.special = xml.GetAttribute("Special");
												int type = 0;
												try { type = Int32.Parse(xml.GetAttribute("SoundType")); }
												catch { }
												setting.soundType = (SoundSettingTypeEnum)type;
												setting.soundData = xml.GetAttribute("SoundData");

												AddSoundSetting(setting);
											}
											else
												break;
										}
									}
								}
							}
							catch (System.Exception ex)
							{
								string error = String.Format("Error while parsing XML settings: Line #{0} ({1})\n{2}",
									xml.LineNumber, xml.LocalName, ex.Message);
								MessageBox.Show(error + "\n\n Attempting default setting", "XML Preferences Error",
									MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								ActGlobals.oFormActMain.WriteExceptionLog(ex, error);
								continue;
							}
						}
					}
				}
				catch (System.Exception ex)
				{
					string error = "The XML settings file may be corrupt or unusable.  Loading defaults where applicable.";
					MessageBox.Show(error, "XML Preferences Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					ActGlobals.oFormActMain.WriteExceptionLog(ex, error);
				}
			}
		}
		private void AddSoundSetting(SoundSetting setting)
		{
			string key = setting.ToString().ToLower();
			if (soundSettings.ContainsKey(key))
				soundSettings[key] = setting;
			else
			{
				soundSettings.Add(key, setting);
				lbSoundAlerts.Items.Add(UppercaseFirst(setting.ToString()));
			}
		}
		private void SaveXmlSettings()
		{
			using (XmlTextWriter xml = new XmlTextWriter(xmlFileName, System.Text.Encoding.UTF8))
			{
				xml.Formatting = Formatting.Indented;
				xml.Indentation = 4;
				xml.Namespaces = false;

				xml.WriteStartDocument();

				xml.WriteStartElement("Config");

				xml.WriteStartElement("SoundSettings");
				foreach (KeyValuePair<string, SoundSetting> pair in soundSettings)
				{
					xml.WriteStartElement("SoundSetting");
					xml.WriteAttributeString("Special", pair.Value.special);
					xml.WriteAttributeString("SoundType", ((int)pair.Value.soundType).ToString());
					xml.WriteAttributeString("SoundData", pair.Value.soundData);
					xml.WriteEndElement();  //SoundSetting
				}
				xml.WriteEndElement();  //SoundSettings

				xml.WriteEndElement();  //Config

				xml.WriteEndDocument();
			}
		}

		SortedDictionary<string, SoundSetting> soundSettings = new SortedDictionary<string, SoundSetting>();
		private void btnSoundAdd_Click(object sender, EventArgs e)
		{
			SoundSetting setting = new SoundSetting();
			setting.special = tbAlertType.Text;
			if (rbAlertAsterisk.Checked)
				setting.soundType = SoundSettingTypeEnum.Asterisk;
			else if (rbAlertBeep.Checked)
				setting.soundType = SoundSettingTypeEnum.Beep;
			else if (rbAlertError.Checked)
				setting.soundType = SoundSettingTypeEnum.Error;
			else if (rbAlertExclamation.Checked)
				setting.soundType = SoundSettingTypeEnum.Exclamation;
			else if (rbAlertQuestion.Checked)
				setting.soundType = SoundSettingTypeEnum.Question;
			else if (rbAlertTts.Checked)
			{
				setting.soundType = SoundSettingTypeEnum.TTS;
				setting.soundData = tbAlertTts.Text;
			}
			else if (rbAlertWav.Checked)
			{
				setting.soundType = SoundSettingTypeEnum.Wav;
				setting.soundData = tbAlertWav.Text;
			}

			AddSoundSetting(setting);
		}
		private void btnSoundRemove_Click(object sender, EventArgs e)
		{
			if (lbSoundAlerts.SelectedIndex != -1)
			{
				string key = lbSoundAlerts.SelectedItem.ToString().ToLower();
				soundSettings.Remove(key);
				lbSoundAlerts.Items.RemoveAt(lbSoundAlerts.SelectedIndex);
			}
		}
		private void lbSoundAlerts_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbSoundAlerts.SelectedIndex != -1)
			{
				SoundSetting selected = soundSettings[lbSoundAlerts.SelectedItem.ToString().ToLower()];
				tbAlertType.Text = selected.special;
				switch (selected.soundType)
				{
					case SoundSettingTypeEnum.Asterisk:
						rbAlertAsterisk.Checked = true;
						break;
					case SoundSettingTypeEnum.Beep:
						rbAlertBeep.Checked = true;
						break;
					case SoundSettingTypeEnum.Error:
						rbAlertError.Checked = true;
						break;
					case SoundSettingTypeEnum.Exclamation:
						rbAlertExclamation.Checked = true;
						break;
					case SoundSettingTypeEnum.Question:
						rbAlertQuestion.Checked = true;
						break;
					case SoundSettingTypeEnum.TTS:
						rbAlertTts.Checked = true;
						break;
					case SoundSettingTypeEnum.Wav:
						rbAlertWav.Checked = true;
						break;
				}
				tbAlertTts.Text = rbAlertTts.Checked ? selected.soundData : String.Empty;
				tbAlertWav.Text = rbAlertWav.Checked ? selected.soundData : String.Empty;
			}
		}
		private void rbAlertWav_CheckedChanged(object sender, EventArgs e)
		{
			tbAlertWav.Enabled = rbAlertWav.Checked;
		}
		private void btnWavBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			Type actMain = ActGlobals.oFormActMain.GetType();
			FieldInfo fFolderMedia = actMain.GetField("folderMedia", BindingFlags.Instance | BindingFlags.NonPublic);
			DirectoryInfo folderMedia = (DirectoryInfo)fFolderMedia.GetValue(ActGlobals.oFormActMain);
			dialog.InitialDirectory = folderMedia.FullName;
			dialog.Title = "Select the alert WAV";
			dialog.Filter = "Waveform Files (*.wav)|*.wav";
			dialog.CheckFileExists = true;
			DialogResult result = dialog.ShowDialog();

			if (result == DialogResult.OK)
			{
				tbAlertWav.Text = dialog.FileName;
				rbAlertWav.Checked = true;
			}
		}
		private void btnWavPlay_Click(object sender, EventArgs e)
		{
			try
			{
				ActGlobals.oFormActMain.PlaySound(tbAlertWav.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Wave File", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void rbAlertTts_CheckedChanged(object sender, EventArgs e)
		{
			tbAlertTts.Enabled = rbAlertTts.Checked;
		}
		private void btnTtsPlay_Click(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.TTS(tbAlertTts.Text);
		}
		private void btnReset_Click(object sender, EventArgs e)
		{
			totalSwings = 0;
			specialProc.Clear();
			specialExtra.Clear();
			usedSpecials.Clear();
			lvAttacks.Items.Clear();
			gbDetectedAttacks.Text = "Detected Attacks";
		}
	}
	enum SoundSettingTypeEnum
	{
		Beep = 1,
		Asterisk = 2,
		Exclamation = 3,
		Error = 4,
		Question = 5,
		Wav = 6,
		TTS = 7
	}
	class SoundSetting
	{
		public string special = String.Empty;
		public SoundSettingTypeEnum soundType = SoundSettingTypeEnum.Beep;
		public string soundData = String.Empty;

		public void PlayAlert()
		{
			switch (soundType)
			{
				case SoundSettingTypeEnum.Asterisk:
					System.Media.SystemSounds.Asterisk.Play();
					break;
				case SoundSettingTypeEnum.Beep:
					System.Media.SystemSounds.Beep.Play();
					break;
				case SoundSettingTypeEnum.Error:
					System.Media.SystemSounds.Hand.Play();
					break;
				case SoundSettingTypeEnum.Exclamation:
					System.Media.SystemSounds.Exclamation.Play();
					break;
				case SoundSettingTypeEnum.Question:
					System.Media.SystemSounds.Question.Play();
					break;
				case SoundSettingTypeEnum.TTS:
					ActGlobals.oFormActMain.TTS(soundData);
					break;
				case SoundSettingTypeEnum.Wav:
					ActGlobals.oFormActMain.PlaySound(soundData);
					break;
			}
		}
		public override string ToString()
		{
			return special;
		}
		public override bool Equals(object obj)
		{
			SoundSetting other = (SoundSetting)obj;
			return this.ToString().Equals(other.ToString());
		}
		public override int GetHashCode()
		{
			return this.ToString().GetHashCode();
		}
	}

}
