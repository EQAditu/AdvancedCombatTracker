using System;
using System.Collections.Generic;
using System.Text;
using Advanced_Combat_Tracker;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.IO;
[assembly: AssemblyTitle("TimerMods")]
[assembly: AssemblyDescription("Adjusts the duration/amount of automatically created timer mods.")]
[assembly: AssemblyVersion("1.0.0.4")]
namespace Some_ACT_Plugin
{
    public class TimerMods : IActPluginV1
    {
        #region Interface
        private System.Windows.Forms.ListBox lbChanges;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbCurrent;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudModDuration;
        private System.Windows.Forms.NumericUpDown nudModAmount;
        private System.Windows.Forms.TextBox tbSkillMod;
        private System.Windows.Forms.TextBox tbPlayer;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

        private void InitUI()
        {
            this.lbChanges = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbCurrent = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudModDuration = new System.Windows.Forms.NumericUpDown();
            this.nudModAmount = new System.Windows.Forms.NumericUpDown();
            this.tbSkillMod = new System.Windows.Forms.TextBox();
            this.tbPlayer = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudModDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudModAmount)).BeginInit();
            // 
            // lbChanges
            // 
            this.lbChanges.FormattingEnabled = true;
            this.lbChanges.Location = new System.Drawing.Point(6, 19);
            this.lbChanges.Size = new System.Drawing.Size(401, 225);
            lbChanges.SelectedIndexChanged += new EventHandler(lbChanges_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbChanges);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Size = new System.Drawing.Size(413, 252);
            this.groupBox1.Text = "Recast Mod Changes";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbCurrent);
            this.groupBox2.Location = new System.Drawing.Point(13, 283);
            this.groupBox2.Size = new System.Drawing.Size(413, 252);
            this.groupBox2.Text = "Currently Active Recast Mods";
            // 
            // lbCurrent
            // 
            this.lbCurrent.BackColor = System.Drawing.SystemColors.Control;
            this.lbCurrent.FormattingEnabled = true;
            this.lbCurrent.Items.AddRange(new object[] {
            "Teramo (Traumatic Swipe) -> Mayong Mistmoore (50% - 30s)"});
            this.lbCurrent.Location = new System.Drawing.Point(6, 19);
            this.lbCurrent.Size = new System.Drawing.Size(401, 225);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRemove);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.nudModDuration);
            this.groupBox3.Controls.Add(this.nudModAmount);
            this.groupBox3.Controls.Add(this.tbSkillMod);
            this.groupBox3.Controls.Add(this.tbPlayer);
            this.groupBox3.Location = new System.Drawing.Point(432, 13);
            this.groupBox3.Size = new System.Drawing.Size(317, 154);
            this.groupBox3.Text = "Add/Remove a Recast Mod Change";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(161, 123);
            this.btnRemove.Size = new System.Drawing.Size(146, 23);
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += new EventHandler(btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(9, 123);
            this.btnAdd.Size = new System.Drawing.Size(146, 23);
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += new EventHandler(btnAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 99);
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.Text = "Debuff Debuff Duration";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.Text = "Debuff Amount%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.Text = "Debuff Skill";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.Text = "Debuff Source";
            // 
            // nudModDuration
            // 
            this.nudModDuration.Location = new System.Drawing.Point(129, 97);
            this.nudModDuration.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudModDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudModDuration.Size = new System.Drawing.Size(64, 20);
            this.nudModDuration.Value = new decimal(new int[] {
            34,
            0,
            0,
            0});
            // 
            // nudModAmount
            // 
            this.nudModAmount.Location = new System.Drawing.Point(129, 71);
            this.nudModAmount.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudModAmount.Size = new System.Drawing.Size(64, 20);
            this.nudModAmount.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // tbSkillMod
            // 
            this.tbSkillMod.Location = new System.Drawing.Point(114, 45);
            this.tbSkillMod.Size = new System.Drawing.Size(197, 20);
            this.tbSkillMod.Text = "Traumatic Swipe";
            // 
            // tbPlayer
            // 
            this.tbPlayer.Location = new System.Drawing.Point(114, 19);
            this.tbPlayer.Size = new System.Drawing.Size(197, 20);
            this.tbPlayer.Text = "Rogue1";
            // 
            // Form2
            // 
            screenSpace.Controls.Add(this.groupBox3);
            screenSpace.Controls.Add(this.groupBox2);
            screenSpace.Controls.Add(this.groupBox1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudModDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudModAmount)).EndInit();
        }

        void lbChanges_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbChanges.SelectedIndex != -1)
            {
                TimerModChange selected = modChanges[lbChanges.SelectedIndex];
                tbPlayer.Text = selected.playerName;
                tbSkillMod.Text = selected.skillName;
                nudModAmount.Value = (decimal)(selected.modAmount * 100F);
                nudModDuration.Value = (decimal)selected.modDuration.TotalSeconds;
            }
        }
        void btnAdd_Click(object sender, EventArgs e)
        {
            TimerModChange newChange = new TimerModChange(tbPlayer.Text, tbSkillMod.Text, 
                Convert.ToSingle(nudModAmount.Value / 100), Convert.ToInt32(nudModDuration.Value));
            modChanges.Add(newChange);
            lbChanges.Items.Add(newChange.ToString());
        }
        void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbChanges.SelectedIndex != -1)
            {
                modChanges.RemoveAt(lbChanges.SelectedIndex);
                lbChanges.Items.RemoveAt(lbChanges.SelectedIndex);
            }
        }
        #endregion
        Label statusLabel;
        TabPage screenSpace;
        Timer tmrTick;
        List<TimerModChange> modChanges = new List<TimerModChange>();
        string xmlFileName = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\TimerMods.config.xml");

        public void DeInitPlugin()
        {
            tmrTick.Enabled = false;
            SaveXmlSettings();
            statusLabel.Text = "Plugin Stopped";
        }
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            screenSpace = pluginScreenSpace;
            statusLabel = pluginStatusText;
            InitUI();
            LoadXmlSettings();
            tmrTick = new Timer();
            tmrTick.Interval = 1000;
            tmrTick.Tick += new EventHandler(tmrTick_Tick);
            tmrTick.Enabled = true;
            statusLabel.Text = "Plugin Started";
            ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(oFormActMain_OnLogLineRead);
        }

        void oFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            if (logInfo.logLine.Contains("I cast aside your accursed enchantments. The end is near, gnoll lovers!"))
            {
                for (int i = ActGlobals.oFormSpellTimers.TimerMods.Count - 1; i >= 0; i--)
                {
                    if (ActGlobals.oFormSpellTimers.TimerMods[i].Victim == "gynok moltor")
                        ActGlobals.oFormSpellTimers.TimerMods.RemoveAt(i);
                }
            }
        }
        void tmrTick_Tick(object sender, EventArgs e)
        {
            foreach (TimerModChange change in modChanges)
            {
                foreach (TimerMod mod in ActGlobals.oFormSpellTimers.TimerMods)
                {
                    if (change.playerName.ToLower() == mod.Attacker && change.skillName == mod.ModName)
                    {
                        mod.ModValue = change.modAmount;
                        mod.UseDuration = change.modDuration;
                    }
                }
            }
            lbCurrent.BeginUpdate();
            lbCurrent.Items.Clear();
            foreach (TimerMod mod in ActGlobals.oFormSpellTimers.TimerMods)
                lbCurrent.Items.Add(String.Format("{0} ({1}) -> {2} ({3:0}% {4:0}s)", mod.Attacker, mod.ModName, mod.Victim,
                    mod.ModValue * 100, mod.UseDuration.TotalSeconds));
            lbCurrent.EndUpdate();
        }

        private void LoadXmlSettings()
        {
            FileInfo file = new FileInfo(xmlFileName);
            if (file.Exists == false)
                return;

            XmlTextReader xml = new XmlTextReader(xmlFileName);

            try
            {
                while (xml.Read())
                {
                    if (xml.NodeType == XmlNodeType.Element)
                    {
                        try
                        {
                            if (xml.LocalName == "ModChange")
                            {
                                string player, skill;
                                float amount;
                                int duration;
                                player = xml.GetAttribute("Player");
                                skill = xml.GetAttribute("Skill");
                                amount = Convert.ToSingle(xml.GetAttribute("Amount"));
                                duration = Convert.ToInt32(xml.GetAttribute("Duration"));
                                TimerModChange newChange = new TimerModChange(player, skill, amount, duration);
                                modChanges.Add(newChange);
                                lbChanges.Items.Add(newChange.ToString());
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
            xml.Close();
        }
        private void SaveXmlSettings()
        {
            XmlTextWriter xml = new XmlTextWriter(xmlFileName, System.Text.Encoding.UTF8);

            xml.Formatting = Formatting.Indented;
            xml.Indentation = 4;
            xml.Namespaces = false;

            xml.WriteStartDocument();

            xml.WriteStartElement("", "Config", "");

            foreach (TimerModChange change in modChanges)
            {
                xml.WriteStartElement("", "ModChange", "");
                xml.WriteAttributeString("Player", change.playerName);
                xml.WriteAttributeString("Skill", change.skillName);
                xml.WriteAttributeString("Amount", change.modAmount.ToString("0.00"));
                xml.WriteAttributeString("Duration", change.modDuration.TotalSeconds.ToString("0"));
                xml.WriteEndElement();
            }

            xml.WriteEndElement();	//Config

            xml.WriteEndDocument();
            xml.Flush();
            xml.Close();
        }

        private class TimerModChange
        {
            public readonly string playerName;
            public readonly string skillName;
            public readonly float modAmount;
            public readonly TimeSpan modDuration;
            public TimerModChange(string PlayerName, string SkillName, float ModAmount, int ModDuration)
            {
                playerName = PlayerName;
                skillName = SkillName;
                modAmount = ModAmount;
                modDuration = TimeSpan.FromSeconds(ModDuration);
            }
            public override string ToString()
            {
                return String.Format("{0} ({1}) | {2:0} ({3:0}s)", playerName, skillName, modAmount * 100, modDuration.TotalSeconds);
            }
        }
    }
}