using System;
using System.Collections.Generic;
using System.Text;
using Advanced_Combat_Tracker;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Threading;
using System.Security;

[assembly: AssemblyTitle("Detriment Call Macro")]
[assembly: AssemblyDescription("Creates /do_file_commands files with social text warnings about players being afflicted with certain effects")]
[assembly: AssemblyCopyright("EQAditu <aditu@advancedcombattracker.com>")]
[assembly: AssemblyVersion("1.3.1.9")]

namespace ACT_Plugin
{
	class DetrimentCallMacro : UserControl, IActPluginV1
	{
		#region User Interface
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

		private CheckedListBox clbEffects;
		private TableLayoutPanel tableLayoutPanel1;
		private Button btnAdd;
		private Button btnRemove;
		private TableLayoutPanel tableLayoutPanel2;
		private TextBox tbMob;
		private Label label2;
		private Label label1;
		private TextBox tbSpell;
		private Label label3;
		private Label label4;
		private ComboBox ddlCategory;
		private NumericUpDown nudPlayerCount;
		private Label label5;
		private NumericUpDown nudSecondCount;
		private Label label6;
		private CheckBox cbAnyMob;
		private Label label7;
		private TextBox tbExportChannel;
		private CheckBox cbSingleLine;
		private Label label9;
		private TextBox tbExportFormat;
		private Label lblInstructions;
		private Label label8;
		private ComboBox ddlSound;
		private Label label11;
		private TextBox tbExFilename;
		private Label label12;
		private CheckBox cbShowDetWindow;
		private Button btnPlayTrigger;
		private FontColorControl fccExportWindow;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem copyAsSharableXMLToolStripMenuItem;
		private ToolStripMenuItem copyAsSharableXMLToolStripMenuItem2;
		private GroupBox groupBox1;
		private CheckBox cbShowChannel;
		private CheckBox cbShowFile;
		private Label label10;
		private NumericUpDown nudExportLife;
		private Button btnTestEntry;
		private TextBox tbSound;

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.clbEffects = new System.Windows.Forms.CheckedListBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyAsSharableXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyAsSharableXMLToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tbMob = new System.Windows.Forms.TextBox();
			this.tbExportChannel = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbSpell = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.ddlCategory = new System.Windows.Forms.ComboBox();
			this.nudPlayerCount = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.nudSecondCount = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.cbAnyMob = new System.Windows.Forms.CheckBox();
			this.cbSingleLine = new System.Windows.Forms.CheckBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tbExportFormat = new System.Windows.Forms.TextBox();
			this.lblInstructions = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.ddlSound = new System.Windows.Forms.ComboBox();
			this.tbSound = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.tbExFilename = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.btnPlayTrigger = new System.Windows.Forms.Button();
			this.cbShowDetWindow = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnTestEntry = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.nudExportLife = new System.Windows.Forms.NumericUpDown();
			this.cbShowChannel = new System.Windows.Forms.CheckBox();
			this.cbShowFile = new System.Windows.Forms.CheckBox();
			this.fccExportWindow = new Advanced_Combat_Tracker.FontColorControl();
			this.contextMenuStrip1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudPlayerCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudSecondCount)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudExportLife)).BeginInit();
			this.SuspendLayout();
			// 
			// clbEffects
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.clbEffects, 2);
			this.clbEffects.ContextMenuStrip = this.contextMenuStrip1;
			this.clbEffects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clbEffects.FormattingEnabled = true;
			this.clbEffects.IntegralHeight = false;
			this.clbEffects.Location = new System.Drawing.Point(3, 3);
			this.clbEffects.Name = "clbEffects";
			this.clbEffects.Size = new System.Drawing.Size(237, 506);
			this.clbEffects.TabIndex = 0;
			this.clbEffects.SelectedIndexChanged += new System.EventHandler(this.clbEffects_SelectedIndexChanged);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.copyAsSharableXMLToolStripMenuItem,
			this.copyAsSharableXMLToolStripMenuItem2});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(284, 48);
			this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
			// 
			// copyAsSharableXMLToolStripMenuItem
			// 
			this.copyAsSharableXMLToolStripMenuItem.Enabled = false;
			this.copyAsSharableXMLToolStripMenuItem.Name = "copyAsSharableXMLToolStripMenuItem";
			this.copyAsSharableXMLToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
			this.copyAsSharableXMLToolStripMenuItem.Text = "Copy as Sharable XML";
			this.copyAsSharableXMLToolStripMenuItem.ToolTipText = "Paste into chat for other copies of ACT to import";
			this.copyAsSharableXMLToolStripMenuItem.Click += new System.EventHandler(this.copyAsSharableXMLToolStripMenuItem_Click);
			// 
			// copyAsSharableXMLToolStripMenuItem2
			// 
			this.copyAsSharableXMLToolStripMenuItem2.Enabled = false;
			this.copyAsSharableXMLToolStripMenuItem2.Name = "copyAsSharableXMLToolStripMenuItem2";
			this.copyAsSharableXMLToolStripMenuItem2.Size = new System.Drawing.Size(283, 22);
			this.copyAsSharableXMLToolStripMenuItem2.Text = "Copy as Double-Encoded Sharable XML";
			this.copyAsSharableXMLToolStripMenuItem2.ToolTipText = "Paste into Forums for other copies of ACT to import";
			this.copyAsSharableXMLToolStripMenuItem2.Click += new System.EventHandler(this.copyAsSharableXMLToolStripMenuItem2_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnAdd.Location = new System.Drawing.Point(3, 515);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(115, 22);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add/Edit";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnRemove.Location = new System.Drawing.Point(124, 515);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(116, 22);
			this.btnRemove.TabIndex = 2;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.btnAdd, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.clbEffects, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnRemove, 1, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(243, 540);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 5;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
			this.tableLayoutPanel2.Controls.Add(this.tbMob, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.tbExportChannel, 1, 4);
			this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.label7, 0, 4);
			this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.tbSpell, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.label3, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.ddlCategory, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.nudPlayerCount, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.label5, 2, 3);
			this.tableLayoutPanel2.Controls.Add(this.nudSecondCount, 3, 3);
			this.tableLayoutPanel2.Controls.Add(this.label6, 4, 3);
			this.tableLayoutPanel2.Controls.Add(this.cbAnyMob, 4, 1);
			this.tableLayoutPanel2.Controls.Add(this.cbSingleLine, 3, 4);
			this.tableLayoutPanel2.Controls.Add(this.label9, 0, 5);
			this.tableLayoutPanel2.Controls.Add(this.tbExportFormat, 1, 5);
			this.tableLayoutPanel2.Controls.Add(this.lblInstructions, 0, 8);
			this.tableLayoutPanel2.Controls.Add(this.label8, 0, 6);
			this.tableLayoutPanel2.Controls.Add(this.ddlSound, 1, 6);
			this.tableLayoutPanel2.Controls.Add(this.tbSound, 2, 6);
			this.tableLayoutPanel2.Controls.Add(this.label11, 0, 7);
			this.tableLayoutPanel2.Controls.Add(this.tbExFilename, 1, 7);
			this.tableLayoutPanel2.Controls.Add(this.label12, 3, 7);
			this.tableLayoutPanel2.Controls.Add(this.btnPlayTrigger, 4, 6);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(261, 125);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 9;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(554, 427);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// tbMob
			// 
			this.tableLayoutPanel2.SetColumnSpan(this.tbMob, 3);
			this.tbMob.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbMob.Location = new System.Drawing.Point(113, 33);
			this.tbMob.Name = "tbMob";
			this.tbMob.Size = new System.Drawing.Size(375, 20);
			this.tbMob.TabIndex = 3;
			// 
			// tbExportChannel
			// 
			this.tableLayoutPanel2.SetColumnSpan(this.tbExportChannel, 2);
			this.tbExportChannel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbExportChannel.Location = new System.Drawing.Point(113, 123);
			this.tbExportChannel.Name = "tbExportChannel";
			this.tbExportChannel.Size = new System.Drawing.Size(244, 20);
			this.tbExportChannel.TabIndex = 13;
			this.tbExportChannel.Text = "raidsay";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(3, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 30);
			this.label2.TabIndex = 2;
			this.label2.Text = "Mob Name";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label7.Location = new System.Drawing.Point(3, 120);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(104, 30);
			this.label7.TabIndex = 12;
			this.label7.Text = "Export Channel";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 30);
			this.label1.TabIndex = 0;
			this.label1.Text = "Spell Name";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbSpell
			// 
			this.tableLayoutPanel2.SetColumnSpan(this.tbSpell, 3);
			this.tbSpell.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbSpell.Location = new System.Drawing.Point(113, 3);
			this.tbSpell.Name = "tbSpell";
			this.tbSpell.Size = new System.Drawing.Size(375, 20);
			this.tbSpell.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Location = new System.Drawing.Point(3, 90);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 30);
			this.label3.TabIndex = 7;
			this.label3.Text = "Trigger Conditions";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label4.Location = new System.Drawing.Point(3, 60);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 30);
			this.label4.TabIndex = 5;
			this.label4.Text = "Effect Category";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ddlCategory
			// 
			this.ddlCategory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ddlCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlCategory.FormattingEnabled = true;
			this.ddlCategory.Items.AddRange(new object[] {
			"Emote (Regex)",
			"Any Combat Action",
			"Non-Melee",
			"Power Drain"});
			this.ddlCategory.Location = new System.Drawing.Point(113, 63);
			this.ddlCategory.Name = "ddlCategory";
			this.ddlCategory.Size = new System.Drawing.Size(115, 21);
			this.ddlCategory.TabIndex = 6;
			this.ddlCategory.SelectedIndexChanged += new System.EventHandler(this.ddlCategory_SelectedIndexChanged);
			// 
			// nudPlayerCount
			// 
			this.nudPlayerCount.Dock = System.Windows.Forms.DockStyle.Right;
			this.nudPlayerCount.Location = new System.Drawing.Point(175, 93);
			this.nudPlayerCount.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.nudPlayerCount.Name = "nudPlayerCount";
			this.nudPlayerCount.Size = new System.Drawing.Size(53, 20);
			this.nudPlayerCount.TabIndex = 8;
			this.nudPlayerCount.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label5.Location = new System.Drawing.Point(234, 90);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(123, 30);
			this.label5.TabIndex = 9;
			this.label5.Text = "Players                OR";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nudSecondCount
			// 
			this.nudSecondCount.Dock = System.Windows.Forms.DockStyle.Right;
			this.nudSecondCount.Location = new System.Drawing.Point(435, 93);
			this.nudSecondCount.Name = "nudSecondCount";
			this.nudSecondCount.Size = new System.Drawing.Size(53, 20);
			this.nudSecondCount.TabIndex = 10;
			this.nudSecondCount.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label6.Location = new System.Drawing.Point(494, 90);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(57, 30);
			this.label6.TabIndex = 11;
			this.label6.Text = "Seconds";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbAnyMob
			// 
			this.cbAnyMob.AutoSize = true;
			this.cbAnyMob.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbAnyMob.Location = new System.Drawing.Point(494, 33);
			this.cbAnyMob.Name = "cbAnyMob";
			this.cbAnyMob.Size = new System.Drawing.Size(57, 24);
			this.cbAnyMob.TabIndex = 4;
			this.cbAnyMob.Text = "Any";
			this.cbAnyMob.UseVisualStyleBackColor = true;
			this.cbAnyMob.CheckedChanged += new System.EventHandler(this.cbAnyMob_CheckedChanged);
			// 
			// cbSingleLine
			// 
			this.cbSingleLine.AutoSize = true;
			this.tableLayoutPanel2.SetColumnSpan(this.cbSingleLine, 2);
			this.cbSingleLine.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbSingleLine.Location = new System.Drawing.Point(363, 123);
			this.cbSingleLine.Name = "cbSingleLine";
			this.cbSingleLine.Size = new System.Drawing.Size(188, 24);
			this.cbSingleLine.TabIndex = 14;
			this.cbSingleLine.Text = "Export list to only one line";
			this.cbSingleLine.UseVisualStyleBackColor = true;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label9.Location = new System.Drawing.Point(3, 150);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(104, 30);
			this.label9.TabIndex = 15;
			this.label9.Text = "Export Format";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbExportFormat
			// 
			this.tableLayoutPanel2.SetColumnSpan(this.tbExportFormat, 4);
			this.tbExportFormat.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbExportFormat.Location = new System.Drawing.Point(113, 153);
			this.tbExportFormat.Name = "tbExportFormat";
			this.tbExportFormat.Size = new System.Drawing.Size(438, 20);
			this.tbExportFormat.TabIndex = 16;
			this.tbExportFormat.Text = ">>> {0} <<< has {1}";
			// 
			// lblInstructions
			// 
			this.lblInstructions.AutoSize = true;
			this.lblInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tableLayoutPanel2.SetColumnSpan(this.lblInstructions, 5);
			this.lblInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblInstructions.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lblInstructions.Location = new System.Drawing.Point(3, 240);
			this.lblInstructions.Name = "lblInstructions";
			this.lblInstructions.Padding = new System.Windows.Forms.Padding(8, 8, 6, 0);
			this.lblInstructions.Size = new System.Drawing.Size(548, 187);
			this.lblInstructions.TabIndex = 24;
			this.lblInstructions.Text = "<Instructions>";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label8.Location = new System.Drawing.Point(3, 180);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(104, 30);
			this.label8.TabIndex = 17;
			this.label8.Text = "Trigger Sound";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ddlSound
			// 
			this.ddlSound.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ddlSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlSound.FormattingEnabled = true;
			this.ddlSound.Items.AddRange(new object[] {
			"Beep",
			"Astersk",
			"TTS",
			"Custom TTS",
			"Custom WAV"});
			this.ddlSound.Location = new System.Drawing.Point(113, 183);
			this.ddlSound.Name = "ddlSound";
			this.ddlSound.Size = new System.Drawing.Size(115, 21);
			this.ddlSound.TabIndex = 18;
			this.ddlSound.SelectedIndexChanged += new System.EventHandler(this.ddlSound_SelectedIndexChanged);
			// 
			// tbSound
			// 
			this.tableLayoutPanel2.SetColumnSpan(this.tbSound, 2);
			this.tbSound.Enabled = false;
			this.tbSound.Location = new System.Drawing.Point(234, 183);
			this.tbSound.Name = "tbSound";
			this.tbSound.Size = new System.Drawing.Size(254, 20);
			this.tbSound.TabIndex = 19;
			this.tbSound.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbSound_MouseUp);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label11.Location = new System.Drawing.Point(3, 210);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(104, 30);
			this.label11.TabIndex = 21;
			this.label11.Text = "Export File";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbExFilename
			// 
			this.tableLayoutPanel2.SetColumnSpan(this.tbExFilename, 2);
			this.tbExFilename.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbExFilename.Location = new System.Drawing.Point(113, 213);
			this.tbExFilename.Name = "tbExFilename";
			this.tbExFilename.Size = new System.Drawing.Size(244, 20);
			this.tbExFilename.TabIndex = 22;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.tableLayoutPanel2.SetColumnSpan(this.label12, 2);
			this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label12.Location = new System.Drawing.Point(363, 210);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(188, 30);
			this.label12.TabIndex = 23;
			this.label12.Text = "Leave blank for \"detriment.txt\"";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnPlayTrigger
			// 
			this.btnPlayTrigger.Location = new System.Drawing.Point(494, 183);
			this.btnPlayTrigger.Name = "btnPlayTrigger";
			this.btnPlayTrigger.Size = new System.Drawing.Size(38, 21);
			this.btnPlayTrigger.TabIndex = 20;
			this.btnPlayTrigger.Text = "|>";
			this.btnPlayTrigger.UseVisualStyleBackColor = true;
			this.btnPlayTrigger.Click += new System.EventHandler(this.btnPlayTrigger_Click);
			// 
			// cbShowDetWindow
			// 
			this.cbShowDetWindow.AutoSize = true;
			this.cbShowDetWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbShowDetWindow.Location = new System.Drawing.Point(6, 17);
			this.cbShowDetWindow.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
			this.cbShowDetWindow.Name = "cbShowDetWindow";
			this.cbShowDetWindow.Size = new System.Drawing.Size(174, 17);
			this.cbShowDetWindow.TabIndex = 0;
			this.cbShowDetWindow.Text = "Show Live Export Window";
			this.cbShowDetWindow.UseVisualStyleBackColor = true;
			this.cbShowDetWindow.CheckedChanged += new System.EventHandler(this.cbShowDetWindow_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btnTestEntry);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.nudExportLife);
			this.groupBox1.Controls.Add(this.cbShowChannel);
			this.groupBox1.Controls.Add(this.cbShowFile);
			this.groupBox1.Controls.Add(this.cbShowDetWindow);
			this.groupBox1.Controls.Add(this.fccExportWindow);
			this.groupBox1.Location = new System.Drawing.Point(261, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(554, 97);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// btnTestEntry
			// 
			this.btnTestEntry.Location = new System.Drawing.Point(473, 71);
			this.btnTestEntry.Name = "btnTestEntry";
			this.btnTestEntry.Size = new System.Drawing.Size(75, 23);
			this.btnTestEntry.TabIndex = 6;
			this.btnTestEntry.Text = "Trigger Test";
			this.btnTestEntry.UseVisualStyleBackColor = true;
			this.btnTestEntry.Click += new System.EventHandler(this.btnTestEntry_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(78, 75);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(183, 13);
			this.label10.TabIndex = 4;
			this.label10.Text = "Hide exports after this many seconds.";
			// 
			// nudExportLife
			// 
			this.nudExportLife.Location = new System.Drawing.Point(24, 71);
			this.nudExportLife.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
			this.nudExportLife.Maximum = new decimal(new int[] {
			120,
			0,
			0,
			0});
			this.nudExportLife.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.nudExportLife.Name = "nudExportLife";
			this.nudExportLife.Size = new System.Drawing.Size(48, 20);
			this.nudExportLife.TabIndex = 3;
			this.nudExportLife.Value = new decimal(new int[] {
			15,
			0,
			0,
			0});
			// 
			// cbShowChannel
			// 
			this.cbShowChannel.AutoSize = true;
			this.cbShowChannel.Location = new System.Drawing.Point(24, 53);
			this.cbShowChannel.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
			this.cbShowChannel.Name = "cbShowChannel";
			this.cbShowChannel.Size = new System.Drawing.Size(128, 17);
			this.cbShowChannel.TabIndex = 2;
			this.cbShowChannel.Text = "Show Export Channel";
			this.cbShowChannel.UseVisualStyleBackColor = true;
			// 
			// cbShowFile
			// 
			this.cbShowFile.AutoSize = true;
			this.cbShowFile.Location = new System.Drawing.Point(24, 35);
			this.cbShowFile.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
			this.cbShowFile.Name = "cbShowFile";
			this.cbShowFile.Size = new System.Drawing.Size(105, 17);
			this.cbShowFile.TabIndex = 1;
			this.cbShowFile.Text = "Show Export File";
			this.cbShowFile.UseVisualStyleBackColor = true;
			// 
			// fccExportWindow
			// 
			this.fccExportWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.fccExportWindow.AutoSize = true;
			this.fccExportWindow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.fccExportWindow.BackColorSetting = System.Drawing.Color.Black;
			this.fccExportWindow.FontChangable = true;
			this.fccExportWindow.FontSetting = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fccExportWindow.ForeColorSetting = System.Drawing.Color.White;
			this.fccExportWindow.Location = new System.Drawing.Point(292, 19);
			this.fccExportWindow.Name = "fccExportWindow";
			this.fccExportWindow.Size = new System.Drawing.Size(256, 50);
			this.fccExportWindow.TabIndex = 5;
			this.fccExportWindow.Text = " ";
			this.fccExportWindow.FontSettingChanged += new Advanced_Combat_Tracker.FontColorControl.FontSettingEventDelegate(this.fccExportWindow_FontSettingChanged);
			this.fccExportWindow.ForeColorSettingChanged += new Advanced_Combat_Tracker.FontColorControl.ColorSettingEventDelegate(this.fccExportWindow_ForeColorSettingChanged);
			this.fccExportWindow.BackColorSettingChanged += new Advanced_Combat_Tracker.FontColorControl.ColorSettingEventDelegate(this.fccExportWindow_BackColorSettingChanged);
			// 
			// DetrimentCallMacro
			// 
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.tableLayoutPanel2);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MaximumSize = new System.Drawing.Size(1000, 10000);
			this.Name = "DetrimentCallMacro";
			this.Size = new System.Drawing.Size(818, 555);
			this.contextMenuStrip1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudPlayerCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudSecondCount)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudExportLife)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		Label lblPluginStatus;
		System.Windows.Forms.Timer tmr;
		DetrimentForm detrimentForm;
		DateTime lastExport;
		bool parseRaid = false;
		Dictionary<string, int> playerGroups = new Dictionary<string, int>();
		Regex whoplayerRegex = new Regex(@"\[\d+ \w+\] (\w+) \(.+\)", RegexOptions.Compiled);
		List<ExportHistoryEntry> exportHistory = new List<ExportHistoryEntry>();
		SettingsSerializer xmlSettings;

		public DetrimentCallMacro()
		{
			InitializeComponent();
			#region lblInstructions
			// Avoid using a .resx
			lblInstructions.Text = @"In the above export formatting, {0} will be replaced by the player name or list of players. {2} will be replaced by the playername and group number if known(use /whoraid before pull).  {1} will be replaced by the spell name being tracked.

In the case of the spell name being an emote/regular expression, you should set the spell name using a comment block: IE, ""(?#SpellName)"".  The player name in the regular expression will be extracted as the first capuring group in a match.

For custom TTS, {0} will be replaced by an affected players list and {1} will be replaced by the spell name(or regex comment).

To execute the export in EQ2, type: /do_file_commands detriment.txt   (or chosen filename)";
			#endregion
		}

		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			lblPluginStatus = pluginStatusText;
			pluginScreenSpace.Controls.Add(this);
			this.Dock = DockStyle.Fill;
			detrimentForm = new DetrimentForm();
			lastExport = ActGlobals.oFormActMain.LastEstimatedTime;
			tmr = new System.Windows.Forms.Timer();
			tmr.Interval = 500;
			tmr.Tick += new EventHandler(tmr_Tick);
			tmr.Enabled = true;
			ActGlobals.oFormActMain.AfterCombatAction += new CombatActionDelegate(oFormActMain_AfterCombatAction);
			ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(oFormActMain_OnLogLineRead);
			LoadXmlSettings();
			lblPluginStatus.Text = "Plugin Started\nClick to show/hide the detriment status window.";
			lblPluginStatus.Click += new EventHandler(lblPluginStatus_Click);
			ActGlobals.oFormActMain.XmlSnippetAdded += new FormActMain.XmlSnippetAddedDelegate(oFormActMain_XmlSnippetAdded);

			ActGlobals.oFormActMain.UpdateCheckClicked += new FormActMain.NullDelegate(oFormActMain_UpdateCheckClicked);
			if (ActGlobals.oFormActMain.GetAutomaticUpdatesAllowed())   // If ACT is set to automatically check for updates, check for updates to the plugin
				new Thread(new ThreadStart(oFormActMain_UpdateCheckClicked)).Start();   // If we don't put this on a separate thread, web latency will delay the plugin init phase
		}

		public void DeInitPlugin()
		{
			tmr.Enabled = false;
			lblPluginStatus.Click -= lblPluginStatus_Click;
			ActGlobals.oFormActMain.AfterCombatAction -= oFormActMain_AfterCombatAction;
			ActGlobals.oFormActMain.OnLogLineRead -= oFormActMain_OnLogLineRead;
			ActGlobals.oFormActMain.XmlSnippetAdded -= oFormActMain_XmlSnippetAdded;
			ActGlobals.oFormActMain.UpdateCheckClicked -= oFormActMain_UpdateCheckClicked;

			SaveXmlSettings();
			detrimentForm.Dispose();
			lblPluginStatus.Text = "Plugin Stopped";
		}

		void oFormActMain_UpdateCheckClicked()
		{
			int pluginId = 24;    // This ID must be the same ID used on ACT's website.  
			try
			{
				DateTime localDate = ActGlobals.oFormActMain.PluginGetSelfDateUtc(this);
				DateTime remoteDate = ActGlobals.oFormActMain.PluginGetRemoteDateUtc(pluginId);
				if (localDate.AddHours(2) < remoteDate)
				{
					DialogResult result = MessageBox.Show("There is an updated version of the Detriment Call Macro Plugin.  Update it now?\n\n(If there is an update to ACT, you should click No and update ACT first.)", "New Version", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

		private void cbShowDetWindow_CheckedChanged(object sender, EventArgs e)
		{
			detrimentForm.Visible = cbShowDetWindow.Checked;
		}
		void lblPluginStatus_Click(object sender, EventArgs e)
		{
			cbShowDetWindow.Checked = !cbShowDetWindow.Checked;
		}
		void tbSound_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && ddlSound.SelectedIndex == 4)
			{
				OpenFileDialog fd = new OpenFileDialog();
				fd.FileName = tbSound.Text;
				fd.Multiselect = false;
				fd.CheckFileExists = true;
				fd.Filter = "(*.wav) Waveform Files|*.wav";

				DialogResult result = fd.ShowDialog();
				if (result == DialogResult.OK)
					tbSound.Text = fd.FileName;
			}
		}
		void ddlSound_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (ddlSound.SelectedIndex)
			{
				case 0: // Beep
					tbSound.Text = string.Empty;
					tbSound.Enabled = false;
					break;
				case 1: // Asterisk
					tbSound.Text = string.Empty;
					tbSound.Enabled = false;
					break;
				case 2: // TTS
					tbSound.Text = string.Empty;
					tbSound.Enabled = false;
					break;
				case 3: // Custom TTS
					tbSound.Enabled = true;
					break;
				case 4: // Custom WAV
					tbSound.Enabled = true;
					break;
			}
		}
		void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ddlCategory.SelectedIndex == 0)
			{
				cbAnyMob.Checked = true;
				cbAnyMob.Enabled = false;
			}
			else
			{
				cbAnyMob.Enabled = true;
			}
		}
		void clbEffects_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (clbEffects.SelectedIndex != -1)
			{
				EffectTrigger eff = (EffectTrigger)clbEffects.Items[clbEffects.SelectedIndex];
				tbMob.Text = eff.mob;
				cbAnyMob.Checked = eff.anyMob;
				tbSpell.Text = eff.spell;
				ddlCategory.SelectedIndex = eff.effCategory;
				cbSingleLine.Checked = eff.singleLine;
				nudPlayerCount.Value = eff.playerCount;
				nudSecondCount.Value = eff.waitCount;
				tbExportChannel.Text = eff.exportChannel;
				tbExFilename.Text = eff.exportFilename;
				tbExportFormat.Text = eff.exportFormat;
				ddlSound.SelectedIndex = eff.soundType;
				tbSound.Text = eff.soundData;
			}
		}
		void btnAdd_Click(object sender, EventArgs e)
		{
			EffectTrigger eff = new EffectTrigger(cbAnyMob.Checked, tbMob.Text, tbSpell.Text, ddlCategory.SelectedIndex, (int)nudPlayerCount.Value,
				(int)nudSecondCount.Value, tbExportChannel.Text, tbExFilename.Text, tbExportFormat.Text, cbSingleLine.Checked, ddlSound.SelectedIndex, tbSound.Text);
			AddEditEffectTrigger(eff);
		}

		private void AddEditEffectTrigger(EffectTrigger eff)
		{
			int index = clbEffects.Items.IndexOf(eff);
			if (index == -1)
			{
				clbEffects.Items.Add(eff);
				clbEffects.SetItemChecked(clbEffects.Items.Count - 1, true);
			}
			else
				clbEffects.Items[index] = eff;
		}
		void btnRemove_Click(object sender, EventArgs e)
		{
			if (clbEffects.SelectedIndex != -1)
				clbEffects.Items.RemoveAt(clbEffects.SelectedIndex);
		}
		void cbAnyMob_CheckedChanged(object sender, EventArgs e)
		{
			if (cbAnyMob.Checked)
			{
				tbMob.Text = string.Empty;
				tbMob.Enabled = false;
			}
			else
				tbMob.Enabled = true;
		}

		void oFormActMain_AfterCombatAction(bool isImport, CombatActionEventArgs actionInfo)
		{
			if (isImport)
				return;
			for (int i = 0; i < clbEffects.Items.Count; i++)
			{
				EffectTrigger eff = (EffectTrigger)clbEffects.Items[i];
				switch (eff.effCategory)
				{
					case 0: // Regex
						continue;
					case 2: // Non-Melee
						if (actionInfo.swingType != (int)SwingTypeEnum.NonMelee)
							continue;
						break;
					case 3: // Power Drain
						if (actionInfo.swingType != (int)SwingTypeEnum.PowerDrain)
							continue;
						break;
				}
				if (eff.anyMob || actionInfo.attacker == eff.mob)
				{
					if (actionInfo.theAttackType == eff.spell)
					{
						eff.AddPlayer(actionInfo.victim);
					}
				}
			}
		}
		void oFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
		{
			if (isImport)
				return;
			try
			{
				if (logInfo.logLine.Length > ActGlobals.oFormActMain.TimeStampLen)
				{
					for (int i = 0; i < clbEffects.Items.Count; i++)
					{
						EffectTrigger eff = (EffectTrigger)clbEffects.Items[i];
						if (eff.effCategory == 0 && logInfo.logLine.Length > ActGlobals.oFormActMain.TimeStampLen)
						{
							string logLine = logInfo.logLine.Substring(ActGlobals.oFormActMain.TimeStampLen);
							if (eff.emoteRegex.IsMatch(logLine))
							{
								string player = eff.emoteRegex.Replace(logLine, "$1");
								eff.AddPlayer(player);
							}
						}
					}
				}
				if (logInfo.logLine.Length > ActGlobals.oFormActMain.TimeStampLen)
				{
					if (logInfo.logLine.Substring(ActGlobals.oFormActMain.TimeStampLen).StartsWith("/whoraid search results for"))
					{
						parseRaid = true;
						playerGroups.Clear();
					}
					if (parseRaid)
					{
						string logLine = logInfo.logLine.Substring(ActGlobals.oFormActMain.TimeStampLen);
						if (whoplayerRegex.IsMatch(logLine))
							playerGroups.Add(whoplayerRegex.Replace(logLine, "$1"), playerGroups.Count / 6 + 1);
					}
				}
				if (parseRaid && logInfo.logLine.EndsWith(" players found"))
				{
					parseRaid = false;
					//if (playerGroups.Count < 24)
					//    playerGroups.Clear();
				}
			}
			catch (Exception ex)
			{
				ActGlobals.oFormActMain.WriteExceptionLog(ex, "DetrimentCallMacro -> OnLogLineRead");
			}
		}
		void tmr_Tick(object sender, EventArgs e)
		{
			TimeSpan tsLastExport = ActGlobals.oFormActMain.LastEstimatedTime - lastExport;
			detrimentForm.Text = String.Format("Detriments (Last was {0:0,0}s ago)", tsLastExport.TotalSeconds);
			DoTimedExports();
			UpdateExportWindow();
		}

		private void UpdateExportWindow()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = exportHistory.Count - 1; i >= 0; i--)
			{
				if (DateTime.Now - exportHistory[i].exportTime > TimeSpan.FromSeconds((double)nudExportLife.Value))
					exportHistory.RemoveAt(i);
			}
			for (int i = exportHistory.Count - 1; i >= 0; i--)
			{
				ExportHistoryEntry entry = exportHistory[i];
				if (cbShowFile.Checked)
					sb.Append(entry.filename + "\t");
				if (cbShowChannel.Checked)
					sb.Append(entry.channel + "\t");
				sb.Append(entry.text.TrimEnd(new char[] { '\r', '\n' }) + "\n");
			}
			string output = sb.ToString();
			if (detrimentForm.rtb.Text != output)
				detrimentForm.rtb.Text = output;
		}

		private void DoTimedExports()
		{
			for (int i = 0; i < clbEffects.Items.Count; i++)
			{
				if (clbEffects.GetItemChecked(i))
				{
					EffectTrigger eff = (EffectTrigger)clbEffects.Items[i];
					if (eff.IsTriggerMet())
					{
						lastExport = ActGlobals.oFormActMain.LastEstimatedTime;
						string effectName = String.IsNullOrEmpty(eff.shortName) ? eff.spell : eff.shortName;
						StringBuilder sb = new StringBuilder();
						if (eff.singleLine)
						{
							string concatPlayers = string.Empty;
							for (int j = 0; j < eff.players.Count; j++)
								concatPlayers += String.Format("{0}, ", eff.players[j]);
							concatPlayers = concatPlayers.TrimEnd(new char[] { ' ', ',' });

							string concatPlayersGroup = string.Empty;
							try
							{
								if (playerGroups.Count > 0)
								{
									for (int j = 0; j < eff.players.Count; j++)
										concatPlayersGroup += String.Format("{0}(G{1}), ", eff.players[j], playerGroups[eff.players[j]]);
									concatPlayersGroup = concatPlayersGroup.TrimEnd(new char[] { ' ', ',' });
								}
							}
							catch
							{
								playerGroups.Clear();
								concatPlayersGroup = string.Empty;
							}
							sb.AppendLine(String.Format(eff.exportFormat, concatPlayers, effectName, String.IsNullOrEmpty(concatPlayersGroup) ? concatPlayers : concatPlayersGroup));
						}
						else
						{
							for (int j = 0; j < eff.players.Count; j++)
							{
								string playerGroup = string.Empty;
								try
								{
									playerGroup = String.Format("{0}(G{1})", eff.players[j], playerGroups[eff.players[j]]);
								}
								catch
								{
									playerGroup = string.Empty;
									playerGroups.Clear();
								}
								sb.Append(String.Format(eff.exportFormat, eff.players[j], effectName, String.IsNullOrEmpty(playerGroup) ? eff.players[j] : playerGroup) + "\n");
							}
						}
						ActGlobals.oFormActMain.SendToMacroFile(String.IsNullOrEmpty(eff.exportFilename) ? "detriment.txt" : eff.exportFilename, sb.ToString(), eff.exportChannel);
						exportHistory.Add(new ExportHistoryEntry(DateTime.Now, String.IsNullOrEmpty(eff.exportFilename) ? "detriment.txt" : eff.exportFilename, eff.exportChannel, sb.ToString()));
						try
						{
							eff.TriggerSound();
						}
						catch (Exception ex)
						{
							ActGlobals.oFormActMain.WriteExceptionLog(ex, "EffectTrigger Sound");
							System.Media.SystemSounds.Beep.Play();
						}
						eff.ResetList();
					}
				}
			}
		}

		private void LoadXmlSettings()
		{
			xmlSettings = new SettingsSerializer(this);
			xmlSettings.AddControlSetting("DetrimentWindow", detrimentForm);
			xmlSettings.AddControlSetting(cbShowDetWindow.Name, cbShowDetWindow);
			xmlSettings.AddControlSetting(cbShowChannel.Name, cbShowChannel);
			xmlSettings.AddControlSetting(cbShowFile.Name, cbShowFile);
			xmlSettings.AddControlSetting(nudExportLife.Name, nudExportLife);
			xmlSettings.AddControlSetting(fccExportWindow.Name, fccExportWindow);

			string path = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\DetrimentCallMacro.config.xml");
			if (!File.Exists(path))
				return;

			XmlTextReader xReader = new XmlTextReader(File.OpenRead(path));
			try
			{
				while (xReader.Read())
				{
					if (xReader.NodeType == XmlNodeType.Element)
					{
						try
						{
							if (xReader.LocalName == "SettingsSerializer")
								xmlSettings.ImportFromXml(xReader);
							if (xReader.LocalName == "EffectTriggers")
								LoadXmlEffectTriggers(xReader);
						}
						catch (Exception ex)
						{
							ActGlobals.oFormActMain.WriteExceptionLog(ex, "DetCallMacro LoadSettings");
						}
					}
				}
			}
			catch (Exception ex)
			{
				ActGlobals.oFormActMain.WriteExceptionLog(ex, "DetCallMacro LoadSettings");
			}
			xReader.Close();
		}

		private void LoadXmlEffectTriggers(XmlTextReader xReader)
		{
			if (xReader.IsEmptyElement)
				return;
			while (xReader.Read())
			{
				if (xReader.NodeType == XmlNodeType.EndElement)
					return;
				if (xReader.NodeType == XmlNodeType.Element)
				{
					if (xReader.LocalName == "EffectTrigger")
					{
						try
						{
							string name = xReader.GetAttribute("Name");
							EffectTrigger eff = new EffectTrigger(
								Boolean.Parse(xReader.GetAttribute("AnyMob")),
								xReader.GetAttribute("Mob"),
								xReader.GetAttribute("Spell"),
								Int32.Parse(xReader.GetAttribute("EffCategory")),
								Int32.Parse(xReader.GetAttribute("PlayerCount")),
								Int32.Parse(xReader.GetAttribute("WaitCount")),
								xReader.GetAttribute("ExportChannel"),
								xReader.GetAttribute("ExportFilename"),
								xReader.GetAttribute("ExportFormat"),
								Boolean.Parse(xReader.GetAttribute("SingleLine")),
								Int32.Parse(xReader.GetAttribute("SoundType")),
								xReader.GetAttribute("SoundData"));
							clbEffects.Items.Add(eff);
							clbEffects.SetItemChecked(clbEffects.Items.Count - 1, Boolean.Parse(xReader.GetAttribute("Checked")));

						}
						catch (Exception ex)
						{
							ActGlobals.oFormActMain.WriteExceptionLog(ex, "EffectTrigger" + xReader.ReadOuterXml());
						}
					}
					else
						break;
				}
			}
		}
		private void SaveXmlSettings()
		{
			string path = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\DetrimentCallMacro.config.xml");
			XmlTextWriter xml = new XmlTextWriter(path, Encoding.UTF8);
			xml.Formatting = Formatting.Indented;
			xml.Indentation = 4;
			xml.Namespaces = false;

			xml.WriteStartDocument();

			xml.WriteStartElement("Config");

			xml.WriteStartElement("SettingsSerializer");
			xmlSettings.ExportToXml(xml);
			xml.WriteEndElement();

			xml.WriteStartElement("EffectTriggers");
			for (int i = 0; i < clbEffects.Items.Count; i++)
			{
				EffectTrigger eff = (EffectTrigger)clbEffects.Items[i];
				xml.WriteStartElement("EffectTrigger");
				xml.WriteAttributeString("Checked", clbEffects.GetItemChecked(i).ToString());
				xml.WriteAttributeString("AnyMob", eff.anyMob.ToString());
				xml.WriteAttributeString("EffCategory", eff.effCategory.ToString());
				xml.WriteAttributeString("ExportChannel", eff.exportChannel.ToString());
				xml.WriteAttributeString("ExportFilename", eff.exportFilename.ToString());
				xml.WriteAttributeString("ExportFormat", eff.exportFormat.ToString());
				xml.WriteAttributeString("Mob", eff.mob.ToString());
				xml.WriteAttributeString("SingleLine", eff.singleLine.ToString());
				xml.WriteAttributeString("PlayerCount", eff.playerCount.ToString());
				xml.WriteAttributeString("WaitCount", eff.waitCount.ToString());
				xml.WriteAttributeString("Spell", eff.spell.ToString());
				xml.WriteAttributeString("SoundType", eff.soundType.ToString());
				xml.WriteAttributeString("SoundData", eff.soundData.ToString());
				xml.WriteEndElement();
			}
			xml.WriteEndElement();

			xml.WriteEndElement();

			xml.WriteEndDocument();
			xml.Flush();
			xml.Close();
		}

		private class EffectTrigger : IEquatable<EffectTrigger>
		{
			internal static Regex findComment = new Regex(@".*?\(\?#([^\)]+)\).*", RegexOptions.Compiled);
			DateTime firstUpdate = DateTime.MinValue;
			public readonly string shortName = string.Empty;
			public readonly string spell, mob, exportChannel, exportFormat, soundData, exportFilename;
			public readonly bool anyMob, singleLine;
			public readonly int effCategory, playerCount, waitCount, soundType;
			public readonly Regex emoteRegex;
			public readonly List<string> players = new List<string>();

			public EffectTrigger(bool AnyMob, string MobName, string SpellName, int EffectCategory, int PlayerCount, int WaitCount,
				string ExportChannel, string ExportFilename, string ExportFormat, bool SingleLineExport, int SoundType, string SoundData)
			{
				anyMob = AnyMob;
				spell = SpellName;
				if (!anyMob)
					mob = MobName;
				else
					mob = string.Empty;
				effCategory = EffectCategory;
				playerCount = PlayerCount;
				waitCount = WaitCount;
				exportChannel = ExportChannel;
				exportFilename = ExportFilename;
				exportFormat = ExportFormat;
				singleLine = SingleLineExport;
				soundType = SoundType;
				soundData = SoundData;
				if (effCategory == 0)
				{
					emoteRegex = new Regex(spell, RegexOptions.Compiled);
					shortName = findComment.Replace(spell, "$1");
				}
			}
			public void AddPlayer(string Player)
			{
				if (!players.Contains(Player))
					players.Add(Player);
				if (firstUpdate == DateTime.MinValue)
					firstUpdate = ActGlobals.oFormActMain.LastEstimatedTime;
			}
			public void ResetList()
			{
				players.Clear();
				firstUpdate = DateTime.MinValue;
			}
			public bool IsTriggerMet()
			{
				if (players.Count >= playerCount)
					return true;
				if (firstUpdate != DateTime.MinValue && players.Count > 0 &&
					ActGlobals.oFormActMain.LastEstimatedTime - firstUpdate >= TimeSpan.FromSeconds(waitCount) && waitCount != 0)
					return true;
				return false;
			}
			public void TriggerSound()
			{
				switch (soundType)
				{
					case 0: // Beep
						System.Media.SystemSounds.Beep.Play();
						break;
					case 1: // Asterisk
						System.Media.SystemSounds.Asterisk.Play();
						break;
					case 2: // TTS
						ActGlobals.oFormActMain.TTS(this.ToString());
						break;
					case 3: // Custom TTS
						string concatPlayers = string.Empty;
						for (int j = 0; j < players.Count; j++)
							concatPlayers += String.Format("{0}, ", players[j]);
						ActGlobals.oFormActMain.TTS(String.Format(soundData, concatPlayers, String.IsNullOrEmpty(shortName) ? spell : shortName));
						break;
					case 4: // Custom WAV
						ActGlobals.oFormActMain.PlaySound(soundData);
						break;
				}
			}
			public override int GetHashCode()
			{
				return String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}", spell, mob, exportChannel, exportFormat, anyMob, singleLine, effCategory, playerCount, waitCount).GetHashCode();
			}
			public override bool Equals(object obj)
			{
				if (obj.GetType().FullName == "System.DBNull")
					return false;
				if (obj == null)
					return false;
				EffectTrigger r = (EffectTrigger)obj;
				return this.Equals(r);
			}
			public bool Equals(EffectTrigger other)
			{
				return this.ToString().Equals(other.ToString());
			}
			public override string ToString()
			{
				if (!String.IsNullOrEmpty(shortName))
					return shortName;
				return String.Format("({0}) {1}", mob, spell);
			}
		}
		private class ExportHistoryEntry
		{
			public readonly string filename, channel, text;
			public readonly DateTime exportTime;

			public ExportHistoryEntry(DateTime ExportTime, string FileName, string Channel, string Text)
			{
				this.exportTime = ExportTime;
				this.filename = FileName;
				this.channel = Channel;
				this.text = Text;
			}
		}

		private void btnPlayTrigger_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ddlSound.SelectedIndex)
				{
					case 0: // Beep
						System.Media.SystemSounds.Beep.Play();
						break;
					case 1: // Asterisk
						System.Media.SystemSounds.Asterisk.Play();
						break;
					case 2: // TTS
						ActGlobals.oFormActMain.TTS(tbSound.Text);
						break;
					case 3: // Custom TTS
						string concatPlayers = "Player Name";
						string shortName = EffectTrigger.findComment.Replace(tbSpell.Text, "$1");
						ActGlobals.oFormActMain.TTS(String.Format(tbSound.Text, concatPlayers, String.IsNullOrEmpty(shortName) ? tbSpell.Text : shortName));
						break;
					case 4: // Custom WAV
						ActGlobals.oFormActMain.PlaySound(tbSound.Text);
						break;
				}
			}
			catch (Exception ex)
			{
				ActGlobals.oFormActMain.WriteExceptionLog(ex, "Sound Preview");
			}
		}

		private string EffectTriggerToXml(int Index, EffectTrigger Effect)
		{
			return String.Format("<DetCall C=\"{11}\" M=\"{0}\" S=\"{1}\" Ec=\"{2}\" Pc=\"{3}\" Wc=\"{4}\" Ech=\"{5}\" Efn=\"{6}\" Ef=\"{7}\" Sl=\"{8}\" St=\"{9}\" Sd=\"{10}\" />",
				SecurityElement.Escape(Effect.mob).Replace("&apos;", "'"),
				SecurityElement.Escape(Effect.spell).Replace("&apos;", "'"),
				Effect.effCategory,
				Effect.playerCount,
				Effect.waitCount,
				System.Security.SecurityElement.Escape(Effect.exportChannel).Replace("&apos;", "'"),
				System.Security.SecurityElement.Escape(Effect.exportFilename).Replace("&apos;", "'"),
				System.Security.SecurityElement.Escape(Effect.exportFormat).Replace("&apos;", "'"),
				Effect.singleLine ? "T" : "F",
				Effect.soundType,
				System.Security.SecurityElement.Escape(Effect.soundData).Replace("&apos;", "'"),
				clbEffects.GetItemChecked(Index) ? "T" : "F");
		}
		private void copyAsSharableXMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EffectTrigger eff = (EffectTrigger)clbEffects.Items[clbEffects.SelectedIndex];
			string xmlStr = EffectTriggerToXml(clbEffects.SelectedIndex, eff);
			ActGlobals.oFormActMain.SendToClipboard(xmlStr, true);
		}
		private void copyAsSharableXMLToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			EffectTrigger eff = (EffectTrigger)clbEffects.Items[clbEffects.SelectedIndex];
			string xmlStr = EffectTriggerToXml(clbEffects.SelectedIndex, eff);
			ActGlobals.oFormActMain.SendToClipboard(SecurityElement.Escape(xmlStr).Replace("&apos;", "'"), true);
		}
		void oFormActMain_XmlSnippetAdded(object sender, XmlSnippetEventArgs e)
		{
			if (e.ShareType == "DetCall")
			{
				EffectTrigger eff = new EffectTrigger(
					String.IsNullOrWhiteSpace(e.XmlAttributes["M"]),
					e.XmlAttributes["M"],
					e.XmlAttributes["S"],
					Int32.Parse(e.XmlAttributes["Ec"]),
					Int32.Parse(e.XmlAttributes["Pc"]),
					Int32.Parse(e.XmlAttributes["Wc"]),
					e.XmlAttributes["Ech"],
					e.XmlAttributes["Efn"],
					e.XmlAttributes["Ef"],
					e.XmlAttributes["Sl"] == "T",
					Int32.Parse(e.XmlAttributes["St"]),
					e.XmlAttributes["Sd"]);

				AddEditEffectTrigger(eff);
				if (e.XmlAttributes.ContainsKey("C"))
				{
					int index = clbEffects.Items.IndexOf(eff);
					clbEffects.SetItemChecked(index, e.XmlAttributes["C"] == "T");
				}

				e.Handled = true;
			}
		}

		private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (clbEffects.SelectedIndex == -1)
			{
				copyAsSharableXMLToolStripMenuItem.Enabled = false;
				copyAsSharableXMLToolStripMenuItem2.Enabled = false;
			}
			else
			{
				copyAsSharableXMLToolStripMenuItem.Enabled = true;
				copyAsSharableXMLToolStripMenuItem2.Enabled = true;
			}
		}

		private void fccExportWindow_FontSettingChanged(Font NewFont)
		{
			detrimentForm.rtb.Font = NewFont;
		}
		private void fccExportWindow_ForeColorSettingChanged(Color NewColor)
		{
			detrimentForm.rtb.ForeColor = NewColor;
		}
		private void fccExportWindow_BackColorSettingChanged(Color NewColor)
		{
			detrimentForm.rtb.BackColor = NewColor;
		}

		private void btnTestEntry_Click(object sender, EventArgs e)
		{
			if (clbEffects.SelectedIndex != -1)
			{
				EffectTrigger eff = (EffectTrigger)clbEffects.Items[clbEffects.SelectedIndex];
				int rand = (int)(new Random().NextDouble() * 100);
				eff.AddPlayer("Player" + rand);
			}
		}
	}
	class DetrimentForm : Form
	{
		public readonly RichTextBox rtb;
		public DetrimentForm()
		{
			rtb = new RichTextBox();
			rtb.Dock = DockStyle.Fill;
			rtb.BackColor = Color.Black;
			rtb.ForeColor = Color.White;
			rtb.Font = new Font("Arial", 14F);
			rtb.ReadOnly = true;
			this.Controls.Add(rtb);
			this.Size = new Size(450, 150);
			this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			this.StartPosition = FormStartPosition.Manual;
			this.TopMost = true;
			FormClosing += new FormClosingEventHandler(DetrimentForm_FormClosing);
		}
		void DetrimentForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}
	}
}
