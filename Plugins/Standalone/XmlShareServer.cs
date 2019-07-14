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
using System.Net;

[assembly: AssemblyTitle("XML Share Server")]
[assembly: AssemblyDescription("A web interface plugin to generate custom XML share files")]
[assembly: AssemblyCompany("Aditu of Permafrost")]
[assembly: AssemblyVersion("1.0.0.1")]

namespace ACT_Plugin
{
	public class XmlShareServer : UserControl, IActPluginV1
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
			this.clbWebSpellIncludes = new System.Windows.Forms.CheckedListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnWebSpellDel = new System.Windows.Forms.Button();
			this.btnWebSpellCopy = new System.Windows.Forms.Button();
			this.btnWebSpellRefresh = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnWebTriggerDel = new System.Windows.Forms.Button();
			this.btnWebTriggerCopy = new System.Windows.Forms.Button();
			this.btnWebTriggerRefresh = new System.Windows.Forms.Button();
			this.clbWebTriggerIncludes = new System.Windows.Forms.CheckedListBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbWebSpellSounds = new System.Windows.Forms.CheckBox();
			this.tbWebTriggersUrl = new System.Windows.Forms.TextBox();
			this.tbWebTimerUrl = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cbEnableWebTriggers = new System.Windows.Forms.CheckBox();
			this.cbEnableWebTimers = new System.Windows.Forms.CheckBox();
			this.cbHideDefaultUrls = new System.Windows.Forms.CheckBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnFileSpellDel = new System.Windows.Forms.Button();
			this.btnFileSpellCopy = new System.Windows.Forms.Button();
			this.btnFileSpellRefresh = new System.Windows.Forms.Button();
			this.clbFileSpellIncludes = new System.Windows.Forms.CheckedListBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.btnFileTriggerDel = new System.Windows.Forms.Button();
			this.btnFileTriggerCopy = new System.Windows.Forms.Button();
			this.btnFileTriggerRefresh = new System.Windows.Forms.Button();
			this.clbFileTriggerIncludes = new System.Windows.Forms.CheckedListBox();
			this.btnFileTimersExport = new System.Windows.Forms.Button();
			this.btnFileTriggersExport = new System.Windows.Forms.Button();
			this.btnFileBothExport = new System.Windows.Forms.Button();
			this.cbFileSpellSounds = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.nudFtpPort = new System.Windows.Forms.NumericUpDown();
			this.cbFtpPassive = new System.Windows.Forms.CheckBox();
			this.tbFtpBothFile = new System.Windows.Forms.TextBox();
			this.tbFtpPath = new System.Windows.Forms.TextBox();
			this.tbFtpPass = new System.Windows.Forms.TextBox();
			this.tbFtpTriggerFile = new System.Windows.Forms.TextBox();
			this.tbFtpTimerFile = new System.Windows.Forms.TextBox();
			this.tbFtpHost = new System.Windows.Forms.TextBox();
			this.tbFtpUser = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.btnFileTimersFtp = new System.Windows.Forms.Button();
			this.btnFileBothFtp = new System.Windows.Forms.Button();
			this.btnFileTriggersFtp = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudFtpPort)).BeginInit();
			this.SuspendLayout();
			// 
			// clbWebSpellIncludes
			// 
			this.clbWebSpellIncludes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.clbWebSpellIncludes.CheckOnClick = true;
			this.clbWebSpellIncludes.FormattingEnabled = true;
			this.clbWebSpellIncludes.IntegralHeight = false;
			this.clbWebSpellIncludes.Location = new System.Drawing.Point(6, 19);
			this.clbWebSpellIncludes.Name = "clbWebSpellIncludes";
			this.clbWebSpellIncludes.Size = new System.Drawing.Size(217, 137);
			this.clbWebSpellIncludes.Sorted = true;
			this.clbWebSpellIncludes.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnWebSpellDel);
			this.groupBox1.Controls.Add(this.btnWebSpellCopy);
			this.groupBox1.Controls.Add(this.btnWebSpellRefresh);
			this.groupBox1.Controls.Add(this.clbWebSpellIncludes);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(229, 191);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Timer Web Export (Categories)";
			// 
			// btnWebSpellDel
			// 
			this.btnWebSpellDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnWebSpellDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnWebSpellDel.Location = new System.Drawing.Point(6, 162);
			this.btnWebSpellDel.Name = "btnWebSpellDel";
			this.btnWebSpellDel.Size = new System.Drawing.Size(30, 23);
			this.btnWebSpellDel.TabIndex = 1;
			this.btnWebSpellDel.Text = "Del";
			this.btnWebSpellDel.UseVisualStyleBackColor = true;
			this.btnWebSpellDel.Click += new System.EventHandler(this.btnWebSpellDel_Click);
			// 
			// btnWebSpellCopy
			// 
			this.btnWebSpellCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnWebSpellCopy.Location = new System.Drawing.Point(42, 162);
			this.btnWebSpellCopy.Name = "btnWebSpellCopy";
			this.btnWebSpellCopy.Size = new System.Drawing.Size(100, 23);
			this.btnWebSpellCopy.TabIndex = 2;
			this.btnWebSpellCopy.Text = "Copy Below";
			this.btnWebSpellCopy.UseVisualStyleBackColor = true;
			this.btnWebSpellCopy.Click += new System.EventHandler(this.btnWebSpellCopy_Click);
			// 
			// btnWebSpellRefresh
			// 
			this.btnWebSpellRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnWebSpellRefresh.Location = new System.Drawing.Point(148, 162);
			this.btnWebSpellRefresh.Name = "btnWebSpellRefresh";
			this.btnWebSpellRefresh.Size = new System.Drawing.Size(75, 23);
			this.btnWebSpellRefresh.TabIndex = 3;
			this.btnWebSpellRefresh.Text = "Refresh List";
			this.btnWebSpellRefresh.UseVisualStyleBackColor = true;
			this.btnWebSpellRefresh.Click += new System.EventHandler(this.btnWebSpellRefresh_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.btnWebTriggerDel);
			this.groupBox2.Controls.Add(this.btnWebTriggerCopy);
			this.groupBox2.Controls.Add(this.btnWebTriggerRefresh);
			this.groupBox2.Controls.Add(this.clbWebTriggerIncludes);
			this.groupBox2.Location = new System.Drawing.Point(238, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(715, 191);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Custom Trigger Web Export";
			// 
			// btnWebTriggerDel
			// 
			this.btnWebTriggerDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnWebTriggerDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnWebTriggerDel.Location = new System.Drawing.Point(6, 163);
			this.btnWebTriggerDel.Name = "btnWebTriggerDel";
			this.btnWebTriggerDel.Size = new System.Drawing.Size(30, 23);
			this.btnWebTriggerDel.TabIndex = 1;
			this.btnWebTriggerDel.Text = "Del";
			this.btnWebTriggerDel.UseVisualStyleBackColor = true;
			this.btnWebTriggerDel.Click += new System.EventHandler(this.btnWebTriggerDel_Click);
			// 
			// btnWebTriggerCopy
			// 
			this.btnWebTriggerCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnWebTriggerCopy.Location = new System.Drawing.Point(528, 162);
			this.btnWebTriggerCopy.Name = "btnWebTriggerCopy";
			this.btnWebTriggerCopy.Size = new System.Drawing.Size(100, 23);
			this.btnWebTriggerCopy.TabIndex = 2;
			this.btnWebTriggerCopy.Text = "Copy Below";
			this.btnWebTriggerCopy.UseVisualStyleBackColor = true;
			this.btnWebTriggerCopy.Click += new System.EventHandler(this.btnWebTriggerCopy_Click);
			// 
			// btnWebTriggerRefresh
			// 
			this.btnWebTriggerRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnWebTriggerRefresh.Location = new System.Drawing.Point(634, 162);
			this.btnWebTriggerRefresh.Name = "btnWebTriggerRefresh";
			this.btnWebTriggerRefresh.Size = new System.Drawing.Size(75, 23);
			this.btnWebTriggerRefresh.TabIndex = 3;
			this.btnWebTriggerRefresh.Text = "Refresh List";
			this.btnWebTriggerRefresh.UseVisualStyleBackColor = true;
			this.btnWebTriggerRefresh.Click += new System.EventHandler(this.btnWebTriggerRefresh_Click);
			// 
			// clbWebTriggerIncludes
			// 
			this.clbWebTriggerIncludes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.clbWebTriggerIncludes.CheckOnClick = true;
			this.clbWebTriggerIncludes.FormattingEnabled = true;
			this.clbWebTriggerIncludes.IntegralHeight = false;
			this.clbWebTriggerIncludes.Location = new System.Drawing.Point(6, 19);
			this.clbWebTriggerIncludes.Name = "clbWebTriggerIncludes";
			this.clbWebTriggerIncludes.Size = new System.Drawing.Size(703, 137);
			this.clbWebTriggerIncludes.Sorted = true;
			this.clbWebTriggerIncludes.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.cbWebSpellSounds);
			this.groupBox3.Controls.Add(this.tbWebTriggersUrl);
			this.groupBox3.Controls.Add(this.tbWebTimerUrl);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.cbEnableWebTriggers);
			this.groupBox3.Controls.Add(this.cbEnableWebTimers);
			this.groupBox3.Controls.Add(this.cbHideDefaultUrls);
			this.groupBox3.Location = new System.Drawing.Point(3, 200);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(950, 90);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Web Interface General Settings";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(709, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(235, 12);
			this.label3.TabIndex = 5;
			this.label3.Text = "Note: Timers with \"noexport\" in the Tooltip will be ignored";
			// 
			// cbWebSpellSounds
			// 
			this.cbWebSpellSounds.AutoSize = true;
			this.cbWebSpellSounds.Location = new System.Drawing.Point(518, 42);
			this.cbWebSpellSounds.Name = "cbWebSpellSounds";
			this.cbWebSpellSounds.Size = new System.Drawing.Size(166, 17);
			this.cbWebSpellSounds.TabIndex = 4;
			this.cbWebSpellSounds.Text = "Include spell timer sound data";
			this.cbWebSpellSounds.UseVisualStyleBackColor = true;
			// 
			// tbWebTriggersUrl
			// 
			this.tbWebTriggersUrl.Location = new System.Drawing.Point(312, 62);
			this.tbWebTriggersUrl.Name = "tbWebTriggersUrl";
			this.tbWebTriggersUrl.Size = new System.Drawing.Size(200, 20);
			this.tbWebTriggersUrl.TabIndex = 8;
			this.tbWebTriggersUrl.Text = "triggerexport";
			// 
			// tbWebTimerUrl
			// 
			this.tbWebTimerUrl.Location = new System.Drawing.Point(312, 39);
			this.tbWebTimerUrl.Name = "tbWebTimerUrl";
			this.tbWebTimerUrl.Size = new System.Drawing.Size(200, 20);
			this.tbWebTimerUrl.TabIndex = 3;
			this.tbWebTimerUrl.Text = "timerexport";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(228, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Absolute URL: /";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(228, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Absolute URL: /";
			// 
			// cbEnableWebTriggers
			// 
			this.cbEnableWebTriggers.AutoSize = true;
			this.cbEnableWebTriggers.Location = new System.Drawing.Point(6, 65);
			this.cbEnableWebTriggers.Name = "cbEnableWebTriggers";
			this.cbEnableWebTriggers.Size = new System.Drawing.Size(211, 17);
			this.cbEnableWebTriggers.TabIndex = 6;
			this.cbEnableWebTriggers.Text = "Create a custom triggers web export file";
			this.cbEnableWebTriggers.UseVisualStyleBackColor = true;
			this.cbEnableWebTriggers.CheckedChanged += new System.EventHandler(this.cbEnableWebTriggers_CheckedChanged);
			// 
			// cbEnableWebTimers
			// 
			this.cbEnableWebTimers.AutoSize = true;
			this.cbEnableWebTimers.Location = new System.Drawing.Point(6, 42);
			this.cbEnableWebTimers.Name = "cbEnableWebTimers";
			this.cbEnableWebTimers.Size = new System.Drawing.Size(191, 17);
			this.cbEnableWebTimers.TabIndex = 1;
			this.cbEnableWebTimers.Text = "Create a spell timers web export file";
			this.cbEnableWebTimers.UseVisualStyleBackColor = true;
			this.cbEnableWebTimers.CheckedChanged += new System.EventHandler(this.cbEnableWebTimers_CheckedChanged);
			// 
			// cbHideDefaultUrls
			// 
			this.cbHideDefaultUrls.AutoSize = true;
			this.cbHideDefaultUrls.Location = new System.Drawing.Point(6, 19);
			this.cbHideDefaultUrls.Name = "cbHideDefaultUrls";
			this.cbHideDefaultUrls.Size = new System.Drawing.Size(219, 17);
			this.cbHideDefaultUrls.TabIndex = 0;
			this.cbHideDefaultUrls.Text = "Hide all default ACT web interface pages";
			this.cbHideDefaultUrls.UseVisualStyleBackColor = true;
			this.cbHideDefaultUrls.CheckedChanged += new System.EventHandler(this.cbHideDefaultUrls_CheckedChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.btnFileSpellDel);
			this.groupBox4.Controls.Add(this.btnFileSpellCopy);
			this.groupBox4.Controls.Add(this.btnFileSpellRefresh);
			this.groupBox4.Controls.Add(this.clbFileSpellIncludes);
			this.groupBox4.Location = new System.Drawing.Point(3, 323);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(229, 191);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Timer File Export (Categories)";
			// 
			// btnFileSpellDel
			// 
			this.btnFileSpellDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnFileSpellDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFileSpellDel.Location = new System.Drawing.Point(6, 162);
			this.btnFileSpellDel.Name = "btnFileSpellDel";
			this.btnFileSpellDel.Size = new System.Drawing.Size(30, 23);
			this.btnFileSpellDel.TabIndex = 1;
			this.btnFileSpellDel.Text = "Del";
			this.btnFileSpellDel.UseVisualStyleBackColor = true;
			this.btnFileSpellDel.Click += new System.EventHandler(this.btnFileSpellDel_Click);
			// 
			// btnFileSpellCopy
			// 
			this.btnFileSpellCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFileSpellCopy.Location = new System.Drawing.Point(42, 162);
			this.btnFileSpellCopy.Name = "btnFileSpellCopy";
			this.btnFileSpellCopy.Size = new System.Drawing.Size(100, 23);
			this.btnFileSpellCopy.TabIndex = 2;
			this.btnFileSpellCopy.Text = "Copy Above";
			this.btnFileSpellCopy.UseVisualStyleBackColor = true;
			this.btnFileSpellCopy.Click += new System.EventHandler(this.btnFileSpellCopy_Click);
			// 
			// btnFileSpellRefresh
			// 
			this.btnFileSpellRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFileSpellRefresh.Location = new System.Drawing.Point(148, 162);
			this.btnFileSpellRefresh.Name = "btnFileSpellRefresh";
			this.btnFileSpellRefresh.Size = new System.Drawing.Size(75, 23);
			this.btnFileSpellRefresh.TabIndex = 3;
			this.btnFileSpellRefresh.Text = "Refresh List";
			this.btnFileSpellRefresh.UseVisualStyleBackColor = true;
			this.btnFileSpellRefresh.Click += new System.EventHandler(this.btnFileSpellRefresh_Click);
			// 
			// clbFileSpellIncludes
			// 
			this.clbFileSpellIncludes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.clbFileSpellIncludes.CheckOnClick = true;
			this.clbFileSpellIncludes.FormattingEnabled = true;
			this.clbFileSpellIncludes.IntegralHeight = false;
			this.clbFileSpellIncludes.Location = new System.Drawing.Point(6, 19);
			this.clbFileSpellIncludes.Name = "clbFileSpellIncludes";
			this.clbFileSpellIncludes.Size = new System.Drawing.Size(217, 137);
			this.clbFileSpellIncludes.Sorted = true;
			this.clbFileSpellIncludes.TabIndex = 0;
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.btnFileTriggerDel);
			this.groupBox5.Controls.Add(this.btnFileTriggerCopy);
			this.groupBox5.Controls.Add(this.btnFileTriggerRefresh);
			this.groupBox5.Controls.Add(this.clbFileTriggerIncludes);
			this.groupBox5.Location = new System.Drawing.Point(238, 323);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(715, 191);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Custom Trigger File Export";
			// 
			// btnFileTriggerDel
			// 
			this.btnFileTriggerDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnFileTriggerDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFileTriggerDel.Location = new System.Drawing.Point(6, 162);
			this.btnFileTriggerDel.Name = "btnFileTriggerDel";
			this.btnFileTriggerDel.Size = new System.Drawing.Size(30, 23);
			this.btnFileTriggerDel.TabIndex = 1;
			this.btnFileTriggerDel.Text = "Del";
			this.btnFileTriggerDel.UseVisualStyleBackColor = true;
			this.btnFileTriggerDel.Click += new System.EventHandler(this.btnFileTriggerDel_Click);
			// 
			// btnFileTriggerCopy
			// 
			this.btnFileTriggerCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFileTriggerCopy.Location = new System.Drawing.Point(528, 162);
			this.btnFileTriggerCopy.Name = "btnFileTriggerCopy";
			this.btnFileTriggerCopy.Size = new System.Drawing.Size(100, 23);
			this.btnFileTriggerCopy.TabIndex = 2;
			this.btnFileTriggerCopy.Text = "Copy Above";
			this.btnFileTriggerCopy.UseVisualStyleBackColor = true;
			this.btnFileTriggerCopy.Click += new System.EventHandler(this.btnFileTriggerCopy_Click);
			// 
			// btnFileTriggerRefresh
			// 
			this.btnFileTriggerRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFileTriggerRefresh.Location = new System.Drawing.Point(634, 162);
			this.btnFileTriggerRefresh.Name = "btnFileTriggerRefresh";
			this.btnFileTriggerRefresh.Size = new System.Drawing.Size(75, 23);
			this.btnFileTriggerRefresh.TabIndex = 3;
			this.btnFileTriggerRefresh.Text = "Refresh List";
			this.btnFileTriggerRefresh.UseVisualStyleBackColor = true;
			this.btnFileTriggerRefresh.Click += new System.EventHandler(this.btnFileTriggerRefresh_Click);
			// 
			// clbFileTriggerIncludes
			// 
			this.clbFileTriggerIncludes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.clbFileTriggerIncludes.CheckOnClick = true;
			this.clbFileTriggerIncludes.FormattingEnabled = true;
			this.clbFileTriggerIncludes.IntegralHeight = false;
			this.clbFileTriggerIncludes.Location = new System.Drawing.Point(6, 19);
			this.clbFileTriggerIncludes.Name = "clbFileTriggerIncludes";
			this.clbFileTriggerIncludes.Size = new System.Drawing.Size(703, 137);
			this.clbFileTriggerIncludes.Sorted = true;
			this.clbFileTriggerIncludes.TabIndex = 0;
			// 
			// btnFileTimersExport
			// 
			this.btnFileTimersExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFileTimersExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFileTimersExport.Location = new System.Drawing.Point(560, 16);
			this.btnFileTimersExport.Name = "btnFileTimersExport";
			this.btnFileTimersExport.Size = new System.Drawing.Size(124, 23);
			this.btnFileTimersExport.TabIndex = 1;
			this.btnFileTimersExport.Text = "Export Timers to File...";
			this.btnFileTimersExport.UseVisualStyleBackColor = true;
			this.btnFileTimersExport.Click += new System.EventHandler(this.btnFileTimersExport_Click);
			// 
			// btnFileTriggersExport
			// 
			this.btnFileTriggersExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFileTriggersExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFileTriggersExport.Location = new System.Drawing.Point(690, 16);
			this.btnFileTriggersExport.Name = "btnFileTriggersExport";
			this.btnFileTriggersExport.Size = new System.Drawing.Size(124, 23);
			this.btnFileTriggersExport.TabIndex = 2;
			this.btnFileTriggersExport.Text = "Export Triggers to File...";
			this.btnFileTriggersExport.UseVisualStyleBackColor = true;
			this.btnFileTriggersExport.Click += new System.EventHandler(this.btnFileTriggersExport_Click);
			// 
			// btnFileBothExport
			// 
			this.btnFileBothExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFileBothExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFileBothExport.Location = new System.Drawing.Point(820, 16);
			this.btnFileBothExport.Name = "btnFileBothExport";
			this.btnFileBothExport.Size = new System.Drawing.Size(124, 23);
			this.btnFileBothExport.TabIndex = 3;
			this.btnFileBothExport.Text = "Export Both to File...";
			this.btnFileBothExport.UseVisualStyleBackColor = true;
			this.btnFileBothExport.Click += new System.EventHandler(this.btnFileBothExport_Click);
			// 
			// cbFileSpellSounds
			// 
			this.cbFileSpellSounds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbFileSpellSounds.AutoSize = true;
			this.cbFileSpellSounds.Location = new System.Drawing.Point(778, 72);
			this.cbFileSpellSounds.Name = "cbFileSpellSounds";
			this.cbFileSpellSounds.Size = new System.Drawing.Size(166, 17);
			this.cbFileSpellSounds.TabIndex = 7;
			this.cbFileSpellSounds.Text = "Include spell timer sound data";
			this.cbFileSpellSounds.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(709, 90);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(235, 12);
			this.label4.TabIndex = 8;
			this.label4.Text = "Note: Timers with \"noexport\" in the Tooltip will be ignored";
			// 
			// groupBox6
			// 
			this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox6.Controls.Add(this.groupBox7);
			this.groupBox6.Controls.Add(this.cbFileSpellSounds);
			this.groupBox6.Controls.Add(this.label4);
			this.groupBox6.Controls.Add(this.btnFileTimersFtp);
			this.groupBox6.Controls.Add(this.btnFileBothFtp);
			this.groupBox6.Controls.Add(this.btnFileTimersExport);
			this.groupBox6.Controls.Add(this.btnFileTriggersFtp);
			this.groupBox6.Controls.Add(this.btnFileBothExport);
			this.groupBox6.Controls.Add(this.btnFileTriggersExport);
			this.groupBox6.Location = new System.Drawing.Point(3, 520);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(950, 108);
			this.groupBox6.TabIndex = 5;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "XML File General Settings";
			// 
			// groupBox7
			// 
			this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox7.Controls.Add(this.nudFtpPort);
			this.groupBox7.Controls.Add(this.cbFtpPassive);
			this.groupBox7.Controls.Add(this.tbFtpBothFile);
			this.groupBox7.Controls.Add(this.tbFtpPath);
			this.groupBox7.Controls.Add(this.tbFtpPass);
			this.groupBox7.Controls.Add(this.tbFtpTriggerFile);
			this.groupBox7.Controls.Add(this.tbFtpTimerFile);
			this.groupBox7.Controls.Add(this.tbFtpHost);
			this.groupBox7.Controls.Add(this.tbFtpUser);
			this.groupBox7.Controls.Add(this.label11);
			this.groupBox7.Controls.Add(this.label5);
			this.groupBox7.Controls.Add(this.label6);
			this.groupBox7.Controls.Add(this.label8);
			this.groupBox7.Controls.Add(this.label10);
			this.groupBox7.Controls.Add(this.label9);
			this.groupBox7.Controls.Add(this.label12);
			this.groupBox7.Controls.Add(this.label7);
			this.groupBox7.Location = new System.Drawing.Point(6, 19);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(548, 82);
			this.groupBox7.TabIndex = 0;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "FTP Server Settings";
			// 
			// nudFtpPort
			// 
			this.nudFtpPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nudFtpPort.Location = new System.Drawing.Point(260, 15);
			this.nudFtpPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.nudFtpPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudFtpPort.Name = "nudFtpPort";
			this.nudFtpPort.Size = new System.Drawing.Size(76, 20);
			this.nudFtpPort.TabIndex = 6;
			this.nudFtpPort.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
			// 
			// cbFtpPassive
			// 
			this.cbFtpPassive.AutoSize = true;
			this.cbFtpPassive.Checked = true;
			this.cbFtpPassive.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbFtpPassive.Location = new System.Drawing.Point(9, 60);
			this.cbFtpPassive.Name = "cbFtpPassive";
			this.cbFtpPassive.Size = new System.Drawing.Size(154, 17);
			this.cbFtpPassive.TabIndex = 4;
			this.cbFtpPassive.Text = "Client behind router (PASV)";
			this.cbFtpPassive.UseVisualStyleBackColor = true;
			// 
			// tbFtpBothFile
			// 
			this.tbFtpBothFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbFtpBothFile.Location = new System.Drawing.Point(421, 57);
			this.tbFtpBothFile.Name = "tbFtpBothFile";
			this.tbFtpBothFile.Size = new System.Drawing.Size(121, 20);
			this.tbFtpBothFile.TabIndex = 16;
			this.tbFtpBothFile.Text = "act-timers-triggers.xml";
			// 
			// tbFtpPath
			// 
			this.tbFtpPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tbFtpPath.Location = new System.Drawing.Point(41, 36);
			this.tbFtpPath.Name = "tbFtpPath";
			this.tbFtpPath.Size = new System.Drawing.Size(178, 20);
			this.tbFtpPath.TabIndex = 3;
			this.tbFtpPath.Text = "act-exports";
			// 
			// tbFtpPass
			// 
			this.tbFtpPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbFtpPass.Location = new System.Drawing.Point(260, 57);
			this.tbFtpPass.Name = "tbFtpPass";
			this.tbFtpPass.Size = new System.Drawing.Size(76, 20);
			this.tbFtpPass.TabIndex = 10;
			this.tbFtpPass.Text = "dummypass";
			// 
			// tbFtpTriggerFile
			// 
			this.tbFtpTriggerFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbFtpTriggerFile.Location = new System.Drawing.Point(421, 36);
			this.tbFtpTriggerFile.Name = "tbFtpTriggerFile";
			this.tbFtpTriggerFile.Size = new System.Drawing.Size(121, 20);
			this.tbFtpTriggerFile.TabIndex = 14;
			this.tbFtpTriggerFile.Text = "act-triggers.xml";
			// 
			// tbFtpTimerFile
			// 
			this.tbFtpTimerFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbFtpTimerFile.Location = new System.Drawing.Point(421, 15);
			this.tbFtpTimerFile.Name = "tbFtpTimerFile";
			this.tbFtpTimerFile.Size = new System.Drawing.Size(121, 20);
			this.tbFtpTimerFile.TabIndex = 12;
			this.tbFtpTimerFile.Text = "act-timers.xml";
			// 
			// tbFtpHost
			// 
			this.tbFtpHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tbFtpHost.Location = new System.Drawing.Point(41, 15);
			this.tbFtpHost.Name = "tbFtpHost";
			this.tbFtpHost.Size = new System.Drawing.Size(178, 20);
			this.tbFtpHost.TabIndex = 1;
			this.tbFtpHost.Text = "ftp.domain.com";
			// 
			// tbFtpUser
			// 
			this.tbFtpUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbFtpUser.Location = new System.Drawing.Point(260, 36);
			this.tbFtpUser.Name = "tbFtpUser";
			this.tbFtpUser.Size = new System.Drawing.Size(76, 20);
			this.tbFtpUser.TabIndex = 8;
			this.tbFtpUser.Text = "dummyuser";
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(342, 60);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(73, 13);
			this.label11.TabIndex = 15;
			this.label11.Text = "Combined File";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(225, 39);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "User";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(225, 60);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(30, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Pass";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(225, 18);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(26, 13);
			this.label8.TabIndex = 5;
			this.label8.Text = "Port";
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(342, 18);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(52, 13);
			this.label10.TabIndex = 11;
			this.label10.Text = "Timer File";
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(342, 39);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(59, 13);
			this.label9.TabIndex = 13;
			this.label9.Text = "Trigger File";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 39);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(29, 13);
			this.label12.TabIndex = 2;
			this.label12.Text = "Path";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 18);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(29, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "Host";
			// 
			// btnFileTimersFtp
			// 
			this.btnFileTimersFtp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFileTimersFtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFileTimersFtp.Location = new System.Drawing.Point(560, 45);
			this.btnFileTimersFtp.Name = "btnFileTimersFtp";
			this.btnFileTimersFtp.Size = new System.Drawing.Size(124, 23);
			this.btnFileTimersFtp.TabIndex = 4;
			this.btnFileTimersFtp.Text = "Export Timers to FTP";
			this.btnFileTimersFtp.UseVisualStyleBackColor = true;
			this.btnFileTimersFtp.Click += new System.EventHandler(this.btnFileTimersFtp_Click);
			// 
			// btnFileBothFtp
			// 
			this.btnFileBothFtp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFileBothFtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFileBothFtp.Location = new System.Drawing.Point(820, 45);
			this.btnFileBothFtp.Name = "btnFileBothFtp";
			this.btnFileBothFtp.Size = new System.Drawing.Size(124, 23);
			this.btnFileBothFtp.TabIndex = 6;
			this.btnFileBothFtp.Text = "Export Both to FTP";
			this.btnFileBothFtp.UseVisualStyleBackColor = true;
			this.btnFileBothFtp.Click += new System.EventHandler(this.btnFileBothFtp_Click);
			// 
			// btnFileTriggersFtp
			// 
			this.btnFileTriggersFtp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFileTriggersFtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFileTriggersFtp.Location = new System.Drawing.Point(690, 45);
			this.btnFileTriggersFtp.Name = "btnFileTriggersFtp";
			this.btnFileTriggersFtp.Size = new System.Drawing.Size(124, 23);
			this.btnFileTriggersFtp.TabIndex = 5;
			this.btnFileTriggersFtp.Text = "Export Triggers to FTP";
			this.btnFileTriggersFtp.UseVisualStyleBackColor = true;
			this.btnFileTriggersFtp.Click += new System.EventHandler(this.btnFileTriggersFtp_Click);
			// 
			// XmlShareServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox1);
			this.Name = "XmlShareServer";
			this.Size = new System.Drawing.Size(956, 687);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudFtpPort)).EndInit();
			this.ResumeLayout(false);

		}

		private CheckedListBox clbWebSpellIncludes;
		private GroupBox groupBox1;
		private Button btnWebSpellRefresh;
		private GroupBox groupBox2;
		private Button btnWebTriggerRefresh;
		private CheckedListBox clbWebTriggerIncludes;
		private GroupBox groupBox3;
		private TextBox tbWebTimerUrl;
		private Label label2;
		private Label label1;
		private CheckBox cbEnableWebTriggers;
		private CheckBox cbEnableWebTimers;
		private CheckBox cbHideDefaultUrls;
		private Label label3;
		private CheckBox cbWebSpellSounds;
		private TextBox tbWebTriggersUrl;
		private GroupBox groupBox4;
		private Button btnFileSpellCopy;
		private Button btnFileSpellRefresh;
		private CheckedListBox clbFileSpellIncludes;
		private GroupBox groupBox5;
		private Button btnFileTriggerRefresh;
		private CheckedListBox clbFileTriggerIncludes;
		private Button btnFileTimersExport;
		private Button btnFileTriggerCopy;
		private Button btnFileTriggersExport;
		private CheckBox cbFileSpellSounds;
		private Label label4;
		private Button btnWebSpellDel;
		private Button btnWebSpellCopy;
		private Button btnWebTriggerDel;
		private Button btnWebTriggerCopy;
		private Button btnFileSpellDel;
		private Button btnFileTriggerDel;
		private GroupBox groupBox6;
		private GroupBox groupBox7;
		private Button btnFileTimersFtp;
		private Button btnFileBothFtp;
		private Button btnFileTriggersFtp;
		private TextBox tbFtpPass;
		private TextBox tbFtpUser;
		private TextBox tbFtpHost;
		private Label label6;
		private Label label7;
		private Label label5;
		private CheckBox cbFtpPassive;
		private Label label8;
		private NumericUpDown nudFtpPort;
		private TextBox tbFtpBothFile;
		private TextBox tbFtpTriggerFile;
		private TextBox tbFtpTimerFile;
		private Label label11;
		private Label label10;
		private Label label9;
		private TextBox tbFtpPath;
		private Label label12;
		private Button btnFileBothExport;

		#endregion


		#endregion
		public XmlShareServer()
		{
			InitializeComponent();
		}

		Label lblStatus;	// The status label that appears in ACT's Plugin tab
		string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\XmlShareServer.config.xml");
		SettingsSerializer xmlSettings;

		#region IActPluginV1 Members
		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			lblStatus = pluginStatusText;	// Hand the status label's reference to our local var
			pluginScreenSpace.Controls.Add(this);	// Add this UserControl to the tab ACT provides
			this.Dock = DockStyle.Fill;	// Expand the UserControl to fill the tab's client space
			xmlSettings = new SettingsSerializer(this);	// Create a new settings serializer and pass it this instance
			LoadSettings();

			ActGlobals.oFormActMain.UrlRequest += new UrlRequestEventDelegate(oFormActMain_UrlRequest);

			lblStatus.Text = "Plugin Started";
		}
		public void DeInitPlugin()
		{
			// Unsubscribe from any events you listen to when exiting!
			ActGlobals.oFormActMain.UrlRequest -= oFormActMain_UrlRequest;
			SaveSettings();
			lblStatus.Text = "Plugin Exited";
		}
		#endregion

		void oFormActMain_UrlRequest(UrlRequestEventArgs urlInfo)
		{
			if (urlInfo.url == "/" + tbWebTimerUrl.Text && cbEnableWebTimers.Checked)
			{
				MemoryStream ms = new MemoryStream();
				GetTimersXmlStream(ms, true);
				ms.Seek(0, SeekOrigin.Begin);
				StreamReader sr = new StreamReader(ms, Encoding.UTF8);

				urlInfo.SetTextData(sr.ReadToEnd(), "text/xml; charset=UTF-8");
				sr.Close();
			}
			else if (urlInfo.url == "/" + tbWebTriggersUrl.Text && cbEnableWebTriggers.Checked)
			{
				MemoryStream ms = new MemoryStream();
				GetTriggersXmlStream(ms, true);
				ms.Seek(0, SeekOrigin.Begin);
				StreamReader sr = new StreamReader(ms, Encoding.UTF8);

				urlInfo.SetTextData(sr.ReadToEnd(), "text/xml; charset=UTF-8");
				sr.Close();
			}
		}
		private void GetTimersXmlStream(Stream ms, bool WebList)
		{
			XmlTextWriter xWriter = new XmlTextWriter(ms, Encoding.UTF8);
			xWriter.Formatting = Formatting.Indented;
			xWriter.Indentation = 1;
			xWriter.IndentChar = '\t';
			xWriter.WriteStartDocument(true);
			xWriter.WriteStartElement("Config");	// <Config>

			List<string> checkedItems = new List<string>();
			if (WebList)
			{
				for (int i = 0; i < clbWebSpellIncludes.Items.Count; i++)
				{
					if (clbWebSpellIncludes.GetItemChecked(i))
						checkedItems.Add((string)clbWebSpellIncludes.Items[i]);
				}
				SaveXmlSpellTimers(xWriter, checkedItems, cbWebSpellSounds.Checked);
			}
			else
			{
				for (int i = 0; i < clbFileSpellIncludes.Items.Count; i++)
				{
					if (clbFileSpellIncludes.GetItemChecked(i))
						checkedItems.Add((string)clbFileSpellIncludes.Items[i]);
				}
				SaveXmlSpellTimers(xWriter, checkedItems, cbFileSpellSounds.Checked);
			}

			xWriter.WriteEndElement();	// </Config>
			xWriter.WriteEndDocument();	// Tie up loose ends (shouldn't be any)
			xWriter.Flush();	// Flush the file buffer to disk
		}
		private void GetTriggersXmlStream(Stream ms, bool WebList)
		{
			XmlTextWriter xWriter = new XmlTextWriter(ms, Encoding.UTF8);
			xWriter.Formatting = Formatting.Indented;
			xWriter.Indentation = 1;
			xWriter.IndentChar = '\t';
			xWriter.WriteStartDocument(true);
			xWriter.WriteStartElement("Config");	// <Config>

			List<string> checkedItems = new List<string>();
			if (WebList)
			{
				for (int i = 0; i < clbWebTriggerIncludes.Items.Count; i++)
				{
					if (clbWebTriggerIncludes.GetItemChecked(i))
						checkedItems.Add((string)clbWebTriggerIncludes.Items[i]);
				}
				SaveXmlCustomTriggers(xWriter, checkedItems);
			}
			else
			{
				for (int i = 0; i < clbFileTriggerIncludes.Items.Count; i++)
				{
					if (clbFileTriggerIncludes.GetItemChecked(i))
						checkedItems.Add((string)clbFileTriggerIncludes.Items[i]);
				}
				SaveXmlCustomTriggers(xWriter, checkedItems);
			}

			xWriter.WriteEndElement();	// </Config>
			xWriter.WriteEndDocument();	// Tie up loose ends (shouldn't be any)
			xWriter.Flush();	// Flush the file buffer to disk
		}
		private void GetTimersTriggersXmlStream(Stream ms, bool WebList)
		{
			XmlTextWriter xWriter = new XmlTextWriter(ms, Encoding.UTF8);
			xWriter.Formatting = Formatting.Indented;
			xWriter.Indentation = 1;
			xWriter.IndentChar = '\t';
			xWriter.WriteStartDocument(true);
			xWriter.WriteStartElement("Config");	// <Config>

			List<string> checkedItems = new List<string>();
			if (WebList)
			{
				for (int i = 0; i < clbWebSpellIncludes.Items.Count; i++)
				{
					if (clbWebSpellIncludes.GetItemChecked(i))
						checkedItems.Add((string)clbWebSpellIncludes.Items[i]);
				}
				SaveXmlSpellTimers(xWriter, checkedItems, cbWebSpellSounds.Checked);

				checkedItems.Clear();
				for (int i = 0; i < clbWebTriggerIncludes.Items.Count; i++)
				{
					if (clbWebTriggerIncludes.GetItemChecked(i))
						checkedItems.Add((string)clbWebTriggerIncludes.Items[i]);
				}
				SaveXmlCustomTriggers(xWriter, checkedItems);
			}
			else
			{
				for (int i = 0; i < clbFileSpellIncludes.Items.Count; i++)
				{
					if (clbFileSpellIncludes.GetItemChecked(i))
						checkedItems.Add((string)clbFileSpellIncludes.Items[i]);
				}
				SaveXmlSpellTimers(xWriter, checkedItems, cbFileSpellSounds.Checked);

				checkedItems.Clear();
				for (int i = 0; i < clbFileTriggerIncludes.Items.Count; i++)
				{
					if (clbFileTriggerIncludes.GetItemChecked(i))
						checkedItems.Add((string)clbFileTriggerIncludes.Items[i]);
				}
				SaveXmlCustomTriggers(xWriter, checkedItems);
			}

			xWriter.WriteEndElement();	// </Config>
			xWriter.WriteEndDocument();	// Tie up loose ends (shouldn't be any)
			xWriter.Flush();	// Flush the file buffer to disk
		}

		void LoadSettings()
		{
			xmlSettings.AddControlSetting(cbEnableWebTimers.Name, cbEnableWebTimers);
			xmlSettings.AddControlSetting(cbEnableWebTriggers.Name, cbEnableWebTriggers);
			xmlSettings.AddControlSetting(cbFileSpellSounds.Name, cbFileSpellSounds);
			xmlSettings.AddControlSetting(cbHideDefaultUrls.Name, cbHideDefaultUrls);
			xmlSettings.AddControlSetting(cbWebSpellSounds.Name, cbWebSpellSounds);
			xmlSettings.AddControlSetting(cbFtpPassive.Name, cbFtpPassive);

			xmlSettings.AddControlSetting(tbWebTimerUrl.Name, tbWebTimerUrl);
			xmlSettings.AddControlSetting(tbWebTriggersUrl.Name, tbWebTriggersUrl);
			xmlSettings.AddControlSetting(tbFtpBothFile.Name, tbFtpBothFile);
			xmlSettings.AddControlSetting(tbFtpHost.Name, tbFtpHost);
			xmlSettings.AddControlSetting(tbFtpPass.Name, tbFtpPass);
			xmlSettings.AddControlSetting(tbFtpPath.Name, tbFtpPath);
			xmlSettings.AddControlSetting(tbFtpTimerFile.Name, tbFtpTimerFile);
			xmlSettings.AddControlSetting(tbFtpTriggerFile.Name, tbFtpTriggerFile);
			xmlSettings.AddControlSetting(tbFtpUser.Name, tbFtpUser);

			xmlSettings.AddControlSetting(clbFileSpellIncludes.Name, clbFileSpellIncludes);
			xmlSettings.AddControlSetting(clbFileTriggerIncludes.Name, clbFileTriggerIncludes);
			xmlSettings.AddControlSetting(clbWebSpellIncludes.Name, clbWebSpellIncludes);
			xmlSettings.AddControlSetting(clbWebTriggerIncludes.Name, clbWebTriggerIncludes);

			xmlSettings.AddControlSetting(nudFtpPort.Name, nudFtpPort);

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

		private void btnWebSpellRefresh_Click(object sender, EventArgs e)
		{
			foreach (KeyValuePair<string, TimerData> pair in ActGlobals.oFormSpellTimers.TimerDefs)
			{
				if (!clbWebSpellIncludes.Items.Contains(pair.Value.Category))
					clbWebSpellIncludes.Items.Add(pair.Value.Category, true);
			}
		}
		private void btnFileSpellRefresh_Click(object sender, EventArgs e)
		{
			foreach (KeyValuePair<string, TimerData> pair in ActGlobals.oFormSpellTimers.TimerDefs)
			{
				if (!clbFileSpellIncludes.Items.Contains(pair.Value.Category))
					clbFileSpellIncludes.Items.Add(pair.Value.Category, true);
			}
		}
		private void btnFileSpellCopy_Click(object sender, EventArgs e)
		{
			clbFileSpellIncludes.Items.Clear();
			clbFileSpellIncludes.Items.AddRange(clbWebSpellIncludes.Items);
			for (int i = 0; i < clbWebSpellIncludes.Items.Count; i++)
			{
				clbFileSpellIncludes.SetItemChecked(i, clbWebSpellIncludes.GetItemChecked(i));
			}
		}
		private void btnWebTriggerRefresh_Click(object sender, EventArgs e)
		{
			foreach (KeyValuePair<string, CustomTrigger> pair in ActGlobals.oFormActMain.CustomTriggers)
			{
				if (!clbWebTriggerIncludes.Items.Contains(pair.Key))
					clbWebTriggerIncludes.Items.Add(pair.Key, true);
			}
		}
		private void btnFileTriggerRefresh_Click(object sender, EventArgs e)
		{
			foreach (KeyValuePair<string, CustomTrigger> pair in ActGlobals.oFormActMain.CustomTriggers)
			{
				if (!clbFileTriggerIncludes.Items.Contains(pair.Key))
					clbFileTriggerIncludes.Items.Add(pair.Key, true);
			}
		}
		private void btnFileTriggerCopy_Click(object sender, EventArgs e)
		{
			clbFileTriggerIncludes.Items.Clear();
			clbFileTriggerIncludes.Items.AddRange(clbWebTriggerIncludes.Items);
			for (int i = 0; i < clbWebTriggerIncludes.Items.Count; i++)
			{
				clbFileTriggerIncludes.SetItemChecked(i, clbWebTriggerIncludes.GetItemChecked(i));
			}
		}
		private void btnWebSpellCopy_Click(object sender, EventArgs e)
		{
			clbWebSpellIncludes.Items.Clear();
			clbWebSpellIncludes.Items.AddRange(clbFileSpellIncludes.Items);
			for (int i = 0; i < clbWebSpellIncludes.Items.Count; i++)
			{
				clbWebSpellIncludes.SetItemChecked(i, clbFileSpellIncludes.GetItemChecked(i));
			}
		}
		private void btnWebTriggerCopy_Click(object sender, EventArgs e)
		{
			clbWebTriggerIncludes.Items.Clear();
			clbWebTriggerIncludes.Items.AddRange(clbFileTriggerIncludes.Items);
			for (int i = 0; i < clbWebTriggerIncludes.Items.Count; i++)
			{
				clbWebTriggerIncludes.SetItemChecked(i, clbFileTriggerIncludes.GetItemChecked(i));
			}
		}
		private void btnWebSpellDel_Click(object sender, EventArgs e)
		{
			if (clbWebSpellIncludes.SelectedIndex != -1)
				clbWebSpellIncludes.Items.RemoveAt(clbWebSpellIncludes.SelectedIndex);
		}
		private void btnWebTriggerDel_Click(object sender, EventArgs e)
		{
			if (clbWebTriggerIncludes.SelectedIndex != -1)
				clbWebTriggerIncludes.Items.RemoveAt(clbWebTriggerIncludes.SelectedIndex);
		}
		private void btnFileSpellDel_Click(object sender, EventArgs e)
		{
			if (clbFileSpellIncludes.SelectedIndex != -1)
				clbFileSpellIncludes.Items.RemoveAt(clbFileSpellIncludes.SelectedIndex);
		}
		private void btnFileTriggerDel_Click(object sender, EventArgs e)
		{
			if (clbFileTriggerIncludes.SelectedIndex != -1)
				clbFileTriggerIncludes.Items.RemoveAt(clbFileTriggerIncludes.SelectedIndex);
		}

		private void btnFileTimersExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog fD = new SaveFileDialog();
			fD.CheckPathExists = true;
			fD.CreatePrompt = false;
			fD.Filter = "XML Settings File (*.xml)|*.xml";
			fD.Title = "Export Spells to XML";
			fD.AddExtension = true;
			fD.ValidateNames = true;
			fD.OverwritePrompt = false;
			fD.InitialDirectory = ActGlobals.oFormActMain.AppDataFolder.FullName;
			DialogResult result = fD.ShowDialog();
			if (result != DialogResult.OK)
				return;

			FileStream fs = new FileStream(fD.FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
			fs.SetLength(0);
			GetTimersXmlStream(fs, false);
			fs.Close();
		}
		private void btnFileTriggersExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog fD = new SaveFileDialog();
			fD.CheckPathExists = true;
			fD.CreatePrompt = false;
			fD.Filter = "XML Settings File (*.xml)|*.xml";
			fD.Title = "Export Spells to XML";
			fD.AddExtension = true;
			fD.ValidateNames = true;
			fD.OverwritePrompt = false;
			fD.InitialDirectory = ActGlobals.oFormActMain.AppDataFolder.FullName;
			DialogResult result = fD.ShowDialog();
			if (result != DialogResult.OK)
				return;

			FileStream fs = new FileStream(fD.FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
			fs.SetLength(0);
			GetTriggersXmlStream(fs, false);
			fs.Close();
		}
		private void btnFileBothExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog fD = new SaveFileDialog();
			fD.CheckPathExists = true;
			fD.CreatePrompt = false;
			fD.Filter = "XML Settings File (*.xml)|*.xml";
			fD.Title = "Export Spells to XML";
			fD.AddExtension = true;
			fD.ValidateNames = true;
			fD.OverwritePrompt = false;
			fD.InitialDirectory = ActGlobals.oFormActMain.AppDataFolder.FullName;
			DialogResult result = fD.ShowDialog();
			if (result != DialogResult.OK)
				return;

			FileStream fs = new FileStream(fD.FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
			fs.SetLength(0);
			GetTimersTriggersXmlStream(fs, false);
			fs.Close();
		}
		private void SaveXmlSpellTimers(XmlTextWriter xWriter, List<string> checkedItems, bool SaveSounds)
		{
			xWriter.WriteStartElement("SpellTimers");
			foreach (KeyValuePair<string, TimerData> pair in ActGlobals.oFormSpellTimers.TimerDefs)
			{
				TimerData tD = pair.Value;
				if (checkedItems.Contains(tD.Category) && !tD.Tooltip.Contains("noexport"))
				{
					xWriter.WriteStartElement("Spell");
					xWriter.WriteAttributeString("Checked", tD.ActiveInList.ToString());
					xWriter.WriteAttributeString("Name", tD.Name);
					xWriter.WriteAttributeString("Timer", tD.TimerValue.ToString());
					xWriter.WriteAttributeString("Restrict", tD.RestrictToMe.ToString());
					xWriter.WriteAttributeString("Absolute", tD.AbsoluteTiming.ToString());
					if (SaveSounds)
					{
						xWriter.WriteAttributeString("StartWav", tD.StartSoundData);
						xWriter.WriteAttributeString("WarningWav", tD.WarningSoundData);
					}
					xWriter.WriteAttributeString("WarningValue", tD.WarningValue.ToString());
					xWriter.WriteAttributeString("RadialDisplay", tD.RadialDisplay.ToString());
					xWriter.WriteAttributeString("Modable", tD.Modable.ToString());
					xWriter.WriteAttributeString("Tooltip", tD.Tooltip);
					xWriter.WriteAttributeString("FillColor", tD.FillColor.ToArgb().ToString());
					xWriter.WriteAttributeString("Panel1", tD.Panel1Display.ToString());
					xWriter.WriteAttributeString("Panel2", tD.Panel2Display.ToString());
					xWriter.WriteAttributeString("RemoveValue", tD.RemoveValue.ToString());
					xWriter.WriteAttributeString("Category", tD.Category);
					xWriter.WriteAttributeString("RestrictCategory", tD.RestrictToCategory.ToString());
					xWriter.WriteEndElement();	// SpellTimer
				}
			}
			xWriter.WriteEndElement();	// Spells
		}
		private void SaveXmlCustomTriggers(XmlTextWriter xWriter, List<string> checkedItems)
		{
			xWriter.WriteStartElement("CustomTriggers");
			foreach (KeyValuePair<string, CustomTrigger> pair in ActGlobals.oFormActMain.CustomTriggers)
			{
				if (checkedItems.Contains(pair.Key))
				{
					xWriter.WriteStartElement("Trigger");
					xWriter.WriteAttributeString("Active", pair.Value.Active.ToString());
					xWriter.WriteAttributeString("Regex", pair.Value.ShortRegexString);
					xWriter.WriteAttributeString("SoundData", pair.Value.SoundData);
					xWriter.WriteAttributeString("SoundType", pair.Value.SoundType.ToString());
					xWriter.WriteAttributeString("CategoryRestrict", pair.Value.RestrictToCategoryZone.ToString());
					xWriter.WriteAttributeString("Category", pair.Value.Category);
					xWriter.WriteAttributeString("Timer", pair.Value.Timer.ToString());
					xWriter.WriteAttributeString("TimerName", pair.Value.TimerName);
					xWriter.WriteAttributeString("Tabbed", pair.Value.Tabbed.ToString());
					xWriter.WriteEndElement();	// Trigger
				}
			}
			xWriter.WriteEndElement();	// CustomTriggers
		}

		List<WebIndexLink> removedLinks = new List<WebIndexLink>();
		private void cbHideDefaultUrls_CheckedChanged(object sender, EventArgs e)
		{
			if (cbHideDefaultUrls.Checked)
			{
				for (int i = ActGlobals.oFormActMain.WebIndexLinks.Count - 1; i >= 0; i--)
				{
					switch (ActGlobals.oFormActMain.WebIndexLinks[i].Url)
					{
						case "/current":
						case "/mini":
						case "/browse":
						case "/timers":
							removedLinks.Add(ActGlobals.oFormActMain.WebIndexLinks[i]);
							ActGlobals.oFormActMain.WebIndexLinks.RemoveAt(i);
							break;
						default:
							break;
					}
				}
			}
			else
			{
				for (int i = 0; i < removedLinks.Count; i++)
					ActGlobals.oFormActMain.WebIndexLinks.Add(removedLinks[i]);
				removedLinks.Clear();
			}
		}
		private void cbEnableWebTimers_CheckedChanged(object sender, EventArgs e)
		{
			if (cbEnableWebTimers.Checked)
			{
				tbWebTimerUrl.ReadOnly = true;
				ActGlobals.oFormActMain.WebIndexLinks.Add(new WebIndexLink("/" + tbWebTimerUrl.Text, "Spell Timer Export", "A dynamically generated XML settings file containing spell timers, importable by ACT."));
			}
			else
			{
				for (int i = 0; i < ActGlobals.oFormActMain.WebIndexLinks.Count; i++)
				{
					if (ActGlobals.oFormActMain.WebIndexLinks[i].Url == "/" + tbWebTimerUrl.Text)
					{
						ActGlobals.oFormActMain.WebIndexLinks.RemoveAt(i);
						break;
					}
				}
				tbWebTimerUrl.ReadOnly = false;
			}
		}
		private void cbEnableWebTriggers_CheckedChanged(object sender, EventArgs e)
		{
			if (cbEnableWebTriggers.Checked)
			{
				tbWebTriggersUrl.ReadOnly = true;
				ActGlobals.oFormActMain.WebIndexLinks.Add(new WebIndexLink("/" + tbWebTriggersUrl.Text, "Custom Trigger Export", "A dynamically generated XML settings file containing custom triggers, importable by ACT."));
			}
			else
			{
				for (int i = 0; i < ActGlobals.oFormActMain.WebIndexLinks.Count; i++)
				{
					if (ActGlobals.oFormActMain.WebIndexLinks[i].Url == "/" + tbWebTriggersUrl.Text)
					{
						ActGlobals.oFormActMain.WebIndexLinks.RemoveAt(i);
						break;
					}
				}
				tbWebTriggersUrl.ReadOnly = false;
			}
		}

		private void btnFileTimersFtp_Click(object sender, EventArgs e)
		{
			MemoryStream ms = new MemoryStream();
			GetTimersXmlStream(ms, false);
			ms.Seek(0, SeekOrigin.Begin);

			FtpUploadStream(tbFtpTimerFile.Text, ms);
		}
		private void btnFileTriggersFtp_Click(object sender, EventArgs e)
		{
			MemoryStream ms = new MemoryStream();
			GetTriggersXmlStream(ms, false);
			ms.Seek(0, SeekOrigin.Begin);

			FtpUploadStream(tbFtpTriggerFile.Text, ms);
		}
		private void btnFileBothFtp_Click(object sender, EventArgs e)
		{
			MemoryStream ms = new MemoryStream();
			GetTimersTriggersXmlStream(ms, false);
			ms.Seek(0, SeekOrigin.Begin);

			FtpUploadStream(tbFtpBothFile.Text, ms);
		}
		private void FtpUploadStream(string FileName, Stream FileData)
		{
			try
			{
				string ftpPath = tbFtpHost.Text + ":" + nudFtpPort.Value.ToString("0") + "/" + tbFtpPath.Text + "/";
				ftpPath = "ftp://" + ftpPath.Replace("//", "/");
				System.Net.FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpPath + FileName.Replace("/", string.Empty));
				request.Timeout = 20000;
				request.Credentials = new NetworkCredential(tbFtpUser.Text, tbFtpPass.Text);
				request.Method = WebRequestMethods.Ftp.UploadFile;
				request.UseBinary = false;
				request.UsePassive = cbFtpPassive.Checked;
				request.KeepAlive = false;

				StreamWriter uploadWriter = new StreamWriter(request.GetRequestStream());
				StreamReader streamReader = new StreamReader(FileData);
				uploadWriter.Write(streamReader.ReadToEnd());
				uploadWriter.Flush();
				uploadWriter.Close();

				FtpWebResponse response = (FtpWebResponse)request.GetResponse();
				if (response.StatusCode != FtpStatusCode.ClosingData)
				{
					MessageBox.Show(response.StatusDescription, response.StatusCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show(response.StatusDescription, response.StatusCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "FTP Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
