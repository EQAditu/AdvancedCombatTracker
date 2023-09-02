using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Xml;
using System.IO;
using System.Threading;

[assembly: AssemblyTitle("Loot Parsing Plugin")]
[assembly: AssemblyDescription("Parses items looted and attaches chat text to them")]
[assembly: AssemblyCompany("Aditu of Permafrost")]
[assembly: AssemblyVersion("1.1.0.8")]

namespace ACT_Plugin
{
	public class LootTracking : UserControl, IActPluginV1
	{
		#region Generated Designer Code (Avoid Direct Modification)
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
			this.components = new System.ComponentModel.Container();
			this.lvItems = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cmsLvItems = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyItemLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyItemNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.copyAsCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyAsTSCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyAsHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyAsPlainTexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyActualLogLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lvChat = new System.Windows.Forms.ListView();
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cmsLvChat = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyActualLogLinesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pChatArea = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblCurrentItem = new System.Windows.Forms.Label();
			this.linkLabel5 = new System.Windows.Forms.LinkLabel();
			this.linkLabel4 = new System.Windows.Forms.LinkLabel();
			this.linkLabel3 = new System.Windows.Forms.LinkLabel();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.clbBlacklist = new System.Windows.Forms.CheckedListBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbBlacklist = new System.Windows.Forms.TextBox();
			this.btnRemoveBlacklist = new System.Windows.Forms.Button();
			this.btnAddBlacklist = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.rbGerman = new System.Windows.Forms.RadioButton();
			this.rbFrench = new System.Windows.Forms.RadioButton();
			this.rbEnglish = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbNamedChat = new System.Windows.Forms.TextBox();
			this.btnRemoveNamedChat = new System.Windows.Forms.Button();
			this.btnAddNamedChat = new System.Windows.Forms.Button();
			this.lbNamedChat = new System.Windows.Forms.ListBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.nudChatLines = new System.Windows.Forms.NumericUpDown();
			this.nudChatSeconds = new System.Windows.Forms.NumericUpDown();
			this.cbChatLines = new System.Windows.Forms.CheckBox();
			this.cbChatSeconds = new System.Windows.Forms.CheckBox();
			this.tmrHalfSec = new System.Windows.Forms.Timer(this.components);
			this.btnClear = new System.Windows.Forms.Button();
			this.cmsLvItems.SuspendLayout();
			this.cmsLvChat.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.pChatArea.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudChatLines)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudChatSeconds)).BeginInit();
			this.SuspendLayout();
			// 
			// lvItems
			// 
			this.lvItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6});
			this.lvItems.ContextMenuStrip = this.cmsLvItems;
			this.lvItems.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvItems.GridLines = true;
			this.lvItems.HideSelection = false;
			this.lvItems.Location = new System.Drawing.Point(0, 0);
			this.lvItems.Name = "lvItems";
			this.lvItems.Size = new System.Drawing.Size(711, 386);
			this.lvItems.TabIndex = 0;
			this.lvItems.UseCompatibleStateImageBehavior = false;
			this.lvItems.View = System.Windows.Forms.View.Details;
			this.lvItems.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvItems_ColumnClick);
			this.lvItems.SelectedIndexChanged += new System.EventHandler(this.lvItems_SelectedIndexChanged);
			this.lvItems.Resize += new System.EventHandler(this.lvItems_Resize);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "DateTime";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Zone";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Player";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "ItemName";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Container";
			// 
			// cmsLvItems
			// 
			this.cmsLvItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyItemLinkToolStripMenuItem,
            this.copyItemNameToolStripMenuItem,
            this.toolStripSeparator1,
            this.copyAsCSVToolStripMenuItem,
            this.copyAsTSCToolStripMenuItem,
            this.copyAsHTMLToolStripMenuItem,
            this.copyAsPlainTexToolStripMenuItem,
            this.copyActualLogLinesToolStripMenuItem});
			this.cmsLvItems.Name = "contextMenuStrip1";
			this.cmsLvItems.Size = new System.Drawing.Size(185, 164);
			// 
			// copyItemLinkToolStripMenuItem
			// 
			this.copyItemLinkToolStripMenuItem.Name = "copyItemLinkToolStripMenuItem";
			this.copyItemLinkToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.copyItemLinkToolStripMenuItem.Text = "Copy item link";
			this.copyItemLinkToolStripMenuItem.Click += new System.EventHandler(this.copyItemLinkToolStripMenuItem_Click);
			// 
			// copyItemNameToolStripMenuItem
			// 
			this.copyItemNameToolStripMenuItem.Name = "copyItemNameToolStripMenuItem";
			this.copyItemNameToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.copyItemNameToolStripMenuItem.Text = "Copy item name";
			this.copyItemNameToolStripMenuItem.Click += new System.EventHandler(this.copyItemNameToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
			// 
			// copyAsCSVToolStripMenuItem
			// 
			this.copyAsCSVToolStripMenuItem.Name = "copyAsCSVToolStripMenuItem";
			this.copyAsCSVToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.copyAsCSVToolStripMenuItem.Text = "Copy as CSV";
			this.copyAsCSVToolStripMenuItem.Click += new System.EventHandler(this.copyAsCSVToolStripMenuItem_Click);
			// 
			// copyAsTSCToolStripMenuItem
			// 
			this.copyAsTSCToolStripMenuItem.Name = "copyAsTSCToolStripMenuItem";
			this.copyAsTSCToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.copyAsTSCToolStripMenuItem.Text = "Copy as TSV";
			this.copyAsTSCToolStripMenuItem.Click += new System.EventHandler(this.copyAsTSCToolStripMenuItem_Click);
			// 
			// copyAsHTMLToolStripMenuItem
			// 
			this.copyAsHTMLToolStripMenuItem.Name = "copyAsHTMLToolStripMenuItem";
			this.copyAsHTMLToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.copyAsHTMLToolStripMenuItem.Text = "Copy as HTML";
			this.copyAsHTMLToolStripMenuItem.Click += new System.EventHandler(this.copyAsHTMLToolStripMenuItem_Click);
			// 
			// copyAsPlainTexToolStripMenuItem
			// 
			this.copyAsPlainTexToolStripMenuItem.Name = "copyAsPlainTexToolStripMenuItem";
			this.copyAsPlainTexToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.copyAsPlainTexToolStripMenuItem.Text = "Copy as Plain Text";
			this.copyAsPlainTexToolStripMenuItem.Click += new System.EventHandler(this.copyAsPlainTexToolStripMenuItem_Click);
			// 
			// copyActualLogLinesToolStripMenuItem
			// 
			this.copyActualLogLinesToolStripMenuItem.Name = "copyActualLogLinesToolStripMenuItem";
			this.copyActualLogLinesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.copyActualLogLinesToolStripMenuItem.Text = "Copy actual log lines";
			this.copyActualLogLinesToolStripMenuItem.Click += new System.EventHandler(this.copyActualLogLinesToolStripMenuItem_Click);
			// 
			// lvChat
			// 
			this.lvChat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
			this.lvChat.ContextMenuStrip = this.cmsLvChat;
			this.lvChat.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvChat.GridLines = true;
			this.lvChat.Location = new System.Drawing.Point(3, 16);
			this.lvChat.Name = "lvChat";
			this.lvChat.Size = new System.Drawing.Size(699, 110);
			this.lvChat.TabIndex = 1;
			this.lvChat.UseCompatibleStateImageBehavior = false;
			this.lvChat.View = System.Windows.Forms.View.Details;
			this.lvChat.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvChat_ColumnClick);
			this.lvChat.Resize += new System.EventHandler(this.lvChat_Resize);
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "DateTime";
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Channel";
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Player";
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Text";
			// 
			// cmsLvChat
			// 
			this.cmsLvChat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyActualLogLinesToolStripMenuItem1});
			this.cmsLvChat.Name = "cmsLvChat";
			this.cmsLvChat.Size = new System.Drawing.Size(185, 26);
			// 
			// copyActualLogLinesToolStripMenuItem1
			// 
			this.copyActualLogLinesToolStripMenuItem1.Name = "copyActualLogLinesToolStripMenuItem1";
			this.copyActualLogLinesToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
			this.copyActualLogLinesToolStripMenuItem1.Text = "Copy actual log lines";
			this.copyActualLogLinesToolStripMenuItem1.Click += new System.EventHandler(this.copyActualLogLinesToolStripMenuItem1_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.lvChat);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(705, 129);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Chat Preceeding Item";
			// 
			// pChatArea
			// 
			this.pChatArea.Controls.Add(this.panel2);
			this.pChatArea.Controls.Add(this.groupBox1);
			this.pChatArea.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pChatArea.Location = new System.Drawing.Point(3, 394);
			this.pChatArea.Name = "pChatArea";
			this.pChatArea.Size = new System.Drawing.Size(711, 152);
			this.pChatArea.TabIndex = 4;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lblCurrentItem);
			this.panel2.Controls.Add(this.linkLabel5);
			this.panel2.Controls.Add(this.linkLabel4);
			this.panel2.Controls.Add(this.linkLabel3);
			this.panel2.Controls.Add(this.linkLabel2);
			this.panel2.Controls.Add(this.linkLabel1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 129);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(711, 23);
			this.panel2.TabIndex = 3;
			// 
			// lblCurrentItem
			// 
			this.lblCurrentItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lblCurrentItem.Location = new System.Drawing.Point(3, 0);
			this.lblCurrentItem.Name = "lblCurrentItem";
			this.lblCurrentItem.Size = new System.Drawing.Size(416, 23);
			this.lblCurrentItem.TabIndex = 1;
			this.lblCurrentItem.Text = "No Item";
			this.lblCurrentItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// linkLabel5
			// 
			this.linkLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel5.AutoSize = true;
			this.linkLabel5.Location = new System.Drawing.Point(643, 5);
			this.linkLabel5.Name = "linkLabel5";
			this.linkLabel5.Size = new System.Drawing.Size(50, 13);
			this.linkLabel5.TabIndex = 0;
			this.linkLabel5.TabStop = true;
			this.linkLabel5.Text = "EQ2Wire";
			this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
			// 
			// linkLabel4
			// 
			this.linkLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel4.AutoSize = true;
			this.linkLabel4.Location = new System.Drawing.Point(575, 5);
			this.linkLabel4.Name = "linkLabel4";
			this.linkLabel4.Size = new System.Drawing.Size(62, 13);
			this.linkLabel4.TabIndex = 0;
			this.linkLabel4.TabStop = true;
			this.linkLabel4.Text = "EQ2@ZAM";
			this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
			// 
			// linkLabel3
			// 
			this.linkLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel3.AutoSize = true;
			this.linkLabel3.Location = new System.Drawing.Point(539, 5);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new System.Drawing.Size(30, 13);
			this.linkLabel3.TabIndex = 0;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Text = "EQ2i";
			this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
			// 
			// linkLabel2
			// 
			this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.Location = new System.Drawing.Point(474, 5);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(59, 13);
			this.linkLabel2.TabIndex = 0;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "EQ2LLinks";
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
			// 
			// linkLabel1
			// 
			this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(425, 5);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(43, 13);
			this.linkLabel1.TabIndex = 0;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "LootDB";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lvItems);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(3, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(711, 386);
			this.panel3.TabIndex = 5;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(725, 575);
			this.tabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.panel3);
			this.tabPage1.Controls.Add(this.splitter1);
			this.tabPage1.Controls.Add(this.pChatArea);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(717, 549);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Session Loot Logs";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(3, 389);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(711, 5);
			this.splitter1.TabIndex = 6;
			this.splitter1.TabStop = false;
			// 
			// tabPage2
			// 
			this.tabPage2.AutoScroll = true;
			this.tabPage2.Controls.Add(this.groupBox5);
			this.tabPage2.Controls.Add(this.groupBox4);
			this.tabPage2.Controls.Add(this.groupBox3);
			this.tabPage2.Controls.Add(this.groupBox2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(717, 549);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Settings";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.clbBlacklist);
			this.groupBox5.Controls.Add(this.label5);
			this.groupBox5.Controls.Add(this.tbBlacklist);
			this.groupBox5.Controls.Add(this.btnRemoveBlacklist);
			this.groupBox5.Controls.Add(this.btnAddBlacklist);
			this.groupBox5.Location = new System.Drawing.Point(7, 381);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(704, 137);
			this.groupBox5.TabIndex = 3;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Item Logline Blacklist";
			// 
			// clbBlacklist
			// 
			this.clbBlacklist.FormattingEnabled = true;
			this.clbBlacklist.IntegralHeight = false;
			this.clbBlacklist.Location = new System.Drawing.Point(6, 19);
			this.clbBlacklist.Name = "clbBlacklist";
			this.clbBlacklist.Size = new System.Drawing.Size(194, 112);
			this.clbBlacklist.TabIndex = 10;
			this.clbBlacklist.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbBlacklist_ItemCheck);
			this.clbBlacklist.SelectedIndexChanged += new System.EventHandler(this.clbBlacklist_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label5.Location = new System.Drawing.Point(339, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(359, 112);
			this.label5.TabIndex = 9;
			// 
			// tbBlacklist
			// 
			this.tbBlacklist.Location = new System.Drawing.Point(207, 111);
			this.tbBlacklist.Name = "tbBlacklist";
			this.tbBlacklist.Size = new System.Drawing.Size(127, 20);
			this.tbBlacklist.TabIndex = 6;
			// 
			// btnRemoveBlacklist
			// 
			this.btnRemoveBlacklist.Location = new System.Drawing.Point(207, 44);
			this.btnRemoveBlacklist.Name = "btnRemoveBlacklist";
			this.btnRemoveBlacklist.Size = new System.Drawing.Size(127, 23);
			this.btnRemoveBlacklist.TabIndex = 7;
			this.btnRemoveBlacklist.Text = "Remove Term";
			this.btnRemoveBlacklist.UseVisualStyleBackColor = true;
			this.btnRemoveBlacklist.Click += new System.EventHandler(this.btnRemoveBlacklist_Click);
			// 
			// btnAddBlacklist
			// 
			this.btnAddBlacklist.Location = new System.Drawing.Point(207, 19);
			this.btnAddBlacklist.Name = "btnAddBlacklist";
			this.btnAddBlacklist.Size = new System.Drawing.Size(127, 23);
			this.btnAddBlacklist.TabIndex = 8;
			this.btnAddBlacklist.Text = "Add Blacklisted Term";
			this.btnAddBlacklist.UseVisualStyleBackColor = true;
			this.btnAddBlacklist.Click += new System.EventHandler(this.btnAddBlacklist_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.rbGerman);
			this.groupBox4.Controls.Add(this.rbFrench);
			this.groupBox4.Controls.Add(this.rbEnglish);
			this.groupBox4.Location = new System.Drawing.Point(7, 275);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(704, 100);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Log Input Language";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.Location = new System.Drawing.Point(339, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(359, 78);
			this.label4.TabIndex = 1;
			// 
			// rbGerman
			// 
			this.rbGerman.AutoSize = true;
			this.rbGerman.Location = new System.Drawing.Point(6, 38);
			this.rbGerman.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.rbGerman.Name = "rbGerman";
			this.rbGerman.Size = new System.Drawing.Size(181, 17);
			this.rbGerman.TabIndex = 0;
			this.rbGerman.TabStop = true;
			this.rbGerman.Text = "German (Credit to Mayriia@Valor)";
			this.rbGerman.UseVisualStyleBackColor = true;
			this.rbGerman.CheckedChanged += new System.EventHandler(this.rbGerman_CheckedChanged);
			// 
			// rbFrench
			// 
			this.rbFrench.AutoSize = true;
			this.rbFrench.Location = new System.Drawing.Point(6, 57);
			this.rbFrench.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.rbFrench.Name = "rbFrench";
			this.rbFrench.Size = new System.Drawing.Size(184, 17);
			this.rbFrench.TabIndex = 0;
			this.rbFrench.TabStop = true;
			this.rbFrench.Text = "French (Credit to Khams@Storms)";
			this.rbFrench.UseVisualStyleBackColor = true;
			this.rbFrench.CheckedChanged += new System.EventHandler(this.rbFrench_CheckedChanged);
			// 
			// rbEnglish
			// 
			this.rbEnglish.AutoSize = true;
			this.rbEnglish.Checked = true;
			this.rbEnglish.Location = new System.Drawing.Point(6, 19);
			this.rbEnglish.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.rbEnglish.Name = "rbEnglish";
			this.rbEnglish.Size = new System.Drawing.Size(59, 17);
			this.rbEnglish.TabIndex = 0;
			this.rbEnglish.TabStop = true;
			this.rbEnglish.Text = "English";
			this.rbEnglish.UseVisualStyleBackColor = true;
			this.rbEnglish.CheckedChanged += new System.EventHandler(this.rbEnglish_CheckedChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.tbNamedChat);
			this.groupBox3.Controls.Add(this.btnRemoveNamedChat);
			this.groupBox3.Controls.Add(this.btnAddNamedChat);
			this.groupBox3.Controls.Add(this.lbNamedChat);
			this.groupBox3.Location = new System.Drawing.Point(6, 132);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(705, 137);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Preceeding Chat Channels";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Location = new System.Drawing.Point(340, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(359, 115);
			this.label3.TabIndex = 5;
			// 
			// tbNamedChat
			// 
			this.tbNamedChat.Location = new System.Drawing.Point(207, 111);
			this.tbNamedChat.Name = "tbNamedChat";
			this.tbNamedChat.Size = new System.Drawing.Size(127, 20);
			this.tbNamedChat.TabIndex = 3;
			// 
			// btnRemoveNamedChat
			// 
			this.btnRemoveNamedChat.Location = new System.Drawing.Point(207, 44);
			this.btnRemoveNamedChat.Name = "btnRemoveNamedChat";
			this.btnRemoveNamedChat.Size = new System.Drawing.Size(127, 23);
			this.btnRemoveNamedChat.TabIndex = 4;
			this.btnRemoveNamedChat.Text = "Remove Channel";
			this.btnRemoveNamedChat.UseVisualStyleBackColor = true;
			this.btnRemoveNamedChat.Click += new System.EventHandler(this.btnRemoveNamedChat_Click);
			// 
			// btnAddNamedChat
			// 
			this.btnAddNamedChat.Location = new System.Drawing.Point(207, 19);
			this.btnAddNamedChat.Name = "btnAddNamedChat";
			this.btnAddNamedChat.Size = new System.Drawing.Size(127, 23);
			this.btnAddNamedChat.TabIndex = 4;
			this.btnAddNamedChat.Text = "Add Channel";
			this.btnAddNamedChat.UseVisualStyleBackColor = true;
			this.btnAddNamedChat.Click += new System.EventHandler(this.btnAddNamedChat_Click);
			// 
			// lbNamedChat
			// 
			this.lbNamedChat.FormattingEnabled = true;
			this.lbNamedChat.IntegralHeight = false;
			this.lbNamedChat.Location = new System.Drawing.Point(6, 19);
			this.lbNamedChat.Name = "lbNamedChat";
			this.lbNamedChat.Size = new System.Drawing.Size(195, 112);
			this.lbNamedChat.TabIndex = 2;
			this.lbNamedChat.SelectedIndexChanged += new System.EventHandler(this.lbNamedChat_SelectedIndexChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.nudChatLines);
			this.groupBox2.Controls.Add(this.nudChatSeconds);
			this.groupBox2.Controls.Add(this.cbChatLines);
			this.groupBox2.Controls.Add(this.cbChatSeconds);
			this.groupBox2.Location = new System.Drawing.Point(6, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(705, 120);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Preceeding Chat Limits";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(88, 94);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(180, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Number of lines to retain per channel";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(88, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(255, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Number of seconds to record chat preceding an item";
			// 
			// nudChatLines
			// 
			this.nudChatLines.Location = new System.Drawing.Point(27, 91);
			this.nudChatLines.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudChatLines.Name = "nudChatLines";
			this.nudChatLines.Size = new System.Drawing.Size(55, 20);
			this.nudChatLines.TabIndex = 1;
			this.nudChatLines.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// nudChatSeconds
			// 
			this.nudChatSeconds.Location = new System.Drawing.Point(27, 42);
			this.nudChatSeconds.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
			this.nudChatSeconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudChatSeconds.Name = "nudChatSeconds";
			this.nudChatSeconds.Size = new System.Drawing.Size(55, 20);
			this.nudChatSeconds.TabIndex = 1;
			this.nudChatSeconds.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
			// 
			// cbChatLines
			// 
			this.cbChatLines.AutoSize = true;
			this.cbChatLines.Checked = true;
			this.cbChatLines.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbChatLines.Location = new System.Drawing.Point(6, 68);
			this.cbChatLines.Name = "cbChatLines";
			this.cbChatLines.Size = new System.Drawing.Size(222, 17);
			this.cbChatLines.TabIndex = 0;
			this.cbChatLines.Text = "Keep chat by number of lines per channel";
			this.cbChatLines.UseVisualStyleBackColor = true;
			// 
			// cbChatSeconds
			// 
			this.cbChatSeconds.AutoSize = true;
			this.cbChatSeconds.Checked = true;
			this.cbChatSeconds.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbChatSeconds.Location = new System.Drawing.Point(6, 19);
			this.cbChatSeconds.Name = "cbChatSeconds";
			this.cbChatSeconds.Size = new System.Drawing.Size(111, 17);
			this.cbChatSeconds.TabIndex = 0;
			this.cbChatSeconds.Text = "Keep chat by time";
			this.cbChatSeconds.UseVisualStyleBackColor = true;
			// 
			// tmrHalfSec
			// 
			this.tmrHalfSec.Enabled = true;
			this.tmrHalfSec.Interval = 500;
			this.tmrHalfSec.Tick += new System.EventHandler(this.tmrSec_Tick);
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClear.Location = new System.Drawing.Point(653, -1);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(68, 20);
			this.btnClear.TabIndex = 1;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// LootTracking
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.tabControl1);
			this.Name = "LootTracking";
			this.Size = new System.Drawing.Size(725, 575);
			this.cmsLvItems.ResumeLayout(false);
			this.cmsLvChat.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.pChatArea.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudChatLines)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudChatSeconds)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ColumnHeader columnHeader1;
		private ToolStripMenuItem copyAsTSCToolStripMenuItem;
		private ToolStripMenuItem copyAsHTMLToolStripMenuItem;
		private ToolStripMenuItem copyAsPlainTexToolStripMenuItem;
		private ToolStripMenuItem copyActualLogLinesToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.GroupBox groupBox1;
		private Panel pChatArea;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private Splitter splitter1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ListView lvItems;
		private System.Windows.Forms.ListView lvChat;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnRemoveNamedChat;
		private System.Windows.Forms.Button btnAddNamedChat;
		private System.Windows.Forms.TextBox tbNamedChat;
		private System.Windows.Forms.NumericUpDown nudChatSeconds;
		private System.Windows.Forms.CheckBox cbChatSeconds;
		private System.Windows.Forms.NumericUpDown nudChatLines;
		private System.Windows.Forms.CheckBox cbChatLines;
		private System.Windows.Forms.ListBox lbNamedChat;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Timer tmrHalfSec;
		private ContextMenuStrip cmsLvItems;
		private ToolStripMenuItem copyAsCSVToolStripMenuItem;
		private ContextMenuStrip cmsLvChat;
		private ToolStripMenuItem copyActualLogLinesToolStripMenuItem1;
		private GroupBox groupBox4;
		private Label label4;
		private RadioButton rbGerman;
		private RadioButton rbFrench;
		private RadioButton rbEnglish;
		private ToolStripMenuItem copyItemLinkToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem copyItemNameToolStripMenuItem;
		private LinkLabel linkLabel2;
		private LinkLabel linkLabel3;
		private LinkLabel linkLabel4;
		private LinkLabel linkLabel5;
		private Label lblCurrentItem;
		private GroupBox groupBox5;
		private CheckedListBox clbBlacklist;
		private Label label5;
		private TextBox tbBlacklist;
		private Button btnRemoveBlacklist;
		private Button btnAddBlacklist;
		private Button btnClear;
		private System.Windows.Forms.ColumnHeader columnHeader10;

		#endregion
		public LootTracking()
		{
			InitializeComponent();
			this.label3.Text = @"Enter the chat channels to attach to a looted item.
These listings may be partial matches to the chat channel identifier.

IE: ""raid"" will match identifiers, ""say to the raid party"" and ""says to the raid party""";
			this.label4.Text = @"Loot parsing speed can be greatly increased by temporarily disabling ACT's combat parsing.

To do this, in the Plugins tab, uncheck ACT_English_Parser or similar.";
			this.label5.Text = @"This blacklist is a collection of Regular Expressions that may block the listing of a particular item.

The Regex does not need to match the entire item or logline, but will be matched against the entire logline.  So you may blacklist anything from the item, mob, looter, container, etc.
""the corpse of"" will blacklist all loot from corpses.  In general, you can just enter something that appears in the log line.  (Capitalization matters)

Visit the forums if you need help with Regular Expressions... (or Google)";
		}


		static Regex regexItem = new Regex(@"\\aITEM (?<itemid>-?\d+) [-\d ]+:(?<itemname>[^\\]+)\\/a", RegexOptions.Compiled);
		const string logTimeStampRegexStr = @"\(\d{10}\)\[.{24}\] ";
		Regex regexLoot, regexChat, regexZone;
		Regex regexLootEng = new Regex(logTimeStampRegexStr + @"(?<looter>\w+) (?<chance>loots?|wins? the lotto for) \\aITEM (?<itemid>-?\d+) [-\d ]+:(?<itemname>[^\\]+)\\/a from (?<container>.+)\.", RegexOptions.Compiled);
		Regex regexChatEng = new Regex(logTimeStampRegexStr + @"(?:(?<speaker>You)|\\aPC -?\d+ (?<speaker>\w+):\w+\\/a) (?<channel>.+?), ?""(?<text>.+)""", RegexOptions.Compiled);
		Regex regexLootFr = new Regex(logTimeStampRegexStr + @"(?<looter>\w+) (?<chance>pille.?|gagne.? la loterie pour) \\aITEM (?<itemid>-?\d+) [-\d ]+:(?<itemname>[^\\]+)\\/a du (?<container>.+)\.", RegexOptions.Compiled);
		Regex regexChatFr = new Regex(logTimeStampRegexStr + @"(?:(?<speaker>Vous)|\\aPC -?\d+ (?<speaker>\w+):\w+\\/a) (?<channel>.+?), ?""(?<text>.+)""", RegexOptions.Compiled);
		Regex regexLootGer = new Regex(logTimeStampRegexStr + @"(?<looter>\w+) (?<chance>erbeutet:?(?: die)?|.+Lotterie gewonnen) \\aITEM (?<itemid>-?\d+) [-\d ]+:(?<itemname>[^\\]+)\\/a(. Aus:| von) (?<container>.+)\.", RegexOptions.Compiled);
		Regex regexChatGer = new Regex(logTimeStampRegexStr + @"(?:(?<speaker>Ihr)|\\aPC -?\d+ (?<speaker>\w+):\w+\\.a) (?<channel>.+?), ?""(?<text>.+)""", RegexOptions.Compiled);
		Regex regexZoneEng = new Regex(logTimeStampRegexStr + @"You have entered (?::.+?:)?(?<zone>.+)\.", RegexOptions.Compiled);
		string lootVerb, persona;
		List<LootedItemData> lootedItems = new List<LootedItemData>();
		Dictionary<string, List<ChatLine>> chatCollections = new Dictionary<string, List<ChatLine>>();
		SettingsSerializer xmlSettings;

		Label lblPluginStatus;
		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			lblPluginStatus = pluginStatusText;
			SetParseLang(0);
			xmlSettings = new SettingsSerializer(this);
			LoadSettings();
			pluginScreenSpace.Controls.Add(this);
			this.Dock = DockStyle.Fill;
			ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(oFormActMain_OnLogLineRead);
			ActGlobals.oFormActMain.UpdateCheckClicked += new FormActMain.NullDelegate(oFormActMain_UpdateCheckClicked);
			if (ActGlobals.oFormActMain.GetAutomaticUpdatesAllowed())   // If ACT is set to automatically check for updates, check for updates to the plugin
				new Thread(new ThreadStart(oFormActMain_UpdateCheckClicked)).Start();	// If we don't put this on a separate thread, web latency will delay the plugin init phase
		}

		void oFormActMain_UpdateCheckClicked()
		{
			int pluginId = 26;
			try
			{
				DateTime localDate = ActGlobals.oFormActMain.PluginGetSelfDateUtc(this);
				DateTime remoteDate = ActGlobals.oFormActMain.PluginGetRemoteDateUtc(pluginId);
				if (localDate.AddHours(2) < remoteDate)
				{
					DialogResult result = MessageBox.Show("There is an updated version of the Loot Parsing Plugin.  Update it now?\n\n(If there is an update to ACT, you should click No and update ACT first.)", "New Version", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
		private void LoadSettings()
		{
			xmlSettings.AddControlSetting(cbChatLines.Name, cbChatLines);
			xmlSettings.AddControlSetting(cbChatSeconds.Name, cbChatSeconds);
			xmlSettings.AddControlSetting(nudChatLines.Name, nudChatLines);
			xmlSettings.AddControlSetting(nudChatSeconds.Name, nudChatSeconds);
			xmlSettings.AddControlSetting(lbNamedChat.Name, lbNamedChat);
			xmlSettings.AddControlSetting(pChatArea.Name, pChatArea);
			xmlSettings.AddControlSetting(rbEnglish.Name, rbEnglish);
			xmlSettings.AddControlSetting(rbGerman.Name, rbGerman);
			xmlSettings.AddControlSetting(rbFrench.Name, rbFrench);
			xmlSettings.AddControlSetting(clbBlacklist.Name, clbBlacklist);

			DirectoryInfo appDataFolder = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Advanced Combat Tracker");
			FileInfo configFile = new FileInfo(appDataFolder.FullName + "\\Config\\LootParsing.config.xml");
			if (configFile.Exists)
			{
				FileStream fs = new FileStream(configFile.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				XmlTextReader xReader = new XmlTextReader(fs);
				while (xReader.Read())
					if (xReader.NodeType == XmlNodeType.Element && xReader.Name == "Config")
						break;
				xmlSettings.ImportFromXml(xReader);
				xReader.Close();
			}
			for (int i = 0; i < clbBlacklist.Items.Count; i++)
			{
				if (clbBlacklist.GetItemChecked(i))
					lootBlacklist.Add((string)clbBlacklist.Items[i], new Regex((string)clbBlacklist.Items[i], RegexOptions.Compiled));
			}
		}
		public void DeInitPlugin()
		{
			ActGlobals.oFormActMain.OnLogLineRead -= oFormActMain_OnLogLineRead;
			SaveSettings();
		}
		private void SaveSettings()
		{
			DirectoryInfo configFolder = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Advanced Combat Tracker");
			FileInfo configFile = new FileInfo(configFolder.FullName + "\\Config\\LootParsing.config.xml");
			FileStream fs = new FileStream(configFile.FullName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
			XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8);
			xWriter.Formatting = Formatting.Indented;
			xWriter.Indentation = 1;
			xWriter.IndentChar = '\t';
			xWriter.WriteStartDocument(true);
			xWriter.WriteStartElement("Config");
			xmlSettings.ExportToXml(xWriter);
			xWriter.WriteEndElement();
			xWriter.WriteEndDocument();
			xWriter.Flush();
			xWriter.Close();
		}

		public void SetParseLang(int Language)
		{
			switch (Language)
			{
				case 1: // German
					regexChat = regexChatGer;
					regexLoot = regexLootGer;
					regexZone = regexZoneEng;
					lootVerb = "erbeutet";
					persona = "Ihr";
					lblPluginStatus.Text = "Language set to German.";
					break;
				case 2: // French
					regexChat = regexChatFr;
					regexLoot = regexLootFr;
					regexZone = regexZoneEng;
					lootVerb = "pille";
					persona = "Vous";
					lblPluginStatus.Text = "Language set to French.";
					break;
				default: // English
					regexChat = regexChatEng;
					regexLoot = regexLootEng;
					regexZone = regexZoneEng;
					lootVerb = "loot";
					persona = "You";
					lblPluginStatus.Text = "Language set to English.";
					break;
			}
		}
		void oFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
		{
			if (regexZone.IsMatch(logInfo.logLine))
			{
				Match match = regexZone.Match(logInfo.logLine);
				ActGlobals.oFormActMain.CurrentZone = match.Groups["zone"].Value;
			}
			if (logInfo.detectedType == 0)
			{
				if (regexChat.IsMatch(logInfo.logLine))
				{
					Match match = regexChat.Match(logInfo.logLine);
					string channel = match.Groups["channel"].Value;
					foreach (string s in lbNamedChat.Items)
					{
						if (channel.ToUpper().Contains(s.ToUpper()))
						{
							string speaker = match.Groups["speaker"].Value == persona ? ActGlobals.charName : match.Groups["speaker"].Value;
							string text = match.Groups["text"].Value;
							if (!chatCollections.ContainsKey(s.ToUpper()))
								chatCollections.Add(s.ToUpper(), new List<ChatLine>());
							chatCollections[s.ToUpper()].Add(new ChatLine(logInfo.detectedTime, logInfo.logLine, channel, speaker, text));
							break;
						}
					}
				}
				else if (regexLoot.IsMatch(logInfo.logLine))
				{
					bool blackListed = false;

					foreach (KeyValuePair<string, Regex> pair in lootBlacklist)
					{
						if (pair.Value.IsMatch(logInfo.logLine))
						{
							blackListed = true;
							break;
						}
					}

					if (!blackListed)
					{
						Match match = regexLoot.Match(logInfo.logLine);
						string container = match.Groups["chance"].Value.StartsWith(lootVerb) ? match.Groups["container"].Value : match.Groups["container"].Value + " (lotto)";
						string looter = match.Groups["looter"].Value == persona ? ActGlobals.charName : match.Groups["looter"].Value;
						LootedItemData item = new LootedItemData(logInfo.detectedTime, looter, match.Groups["itemname"].Value, match.Groups["itemid"].Value, container, logInfo.detectedZone, logInfo.logLine);
						if (cbChatLines.Checked)
						{
							int count = (int)nudChatLines.Value;
							foreach (KeyValuePair<string, List<ChatLine>> pair in chatCollections)
							{
								if (pair.Value.Count <= count)
									item.chat.AddRange(pair.Value);
								else
								{
									for (int i = pair.Value.Count - 1; i >= pair.Value.Count - count; i--)
										item.chat.Add(pair.Value[i]);
								}
							}
						}
						if (cbChatSeconds.Checked)
						{
							int timeLimit = (int)nudChatSeconds.Value;
							foreach (KeyValuePair<string, List<ChatLine>> pair in chatCollections)
							{
								for (int i = pair.Value.Count - 1; i >= 0; i--)
								{
									ChatLine cl = pair.Value[i];
									if (logInfo.detectedTime - cl.time <= TimeSpan.FromSeconds(timeLimit))
										item.chat.Add(cl);
									else
										break;
								}
							}
						}
						item.chat.Sort();
						for (int i = item.chat.Count - 1; i > 0; i--)
						{
							if (item.chat[i].fullLine == item.chat[i - 1].fullLine)
								item.chat.RemoveAt(i);
						}

						lootedItems.Add(item);
						refreshLvItems = true;
					}
				}
			}
		}

		#region UI Logic
		int lvItemsSorting = 0;
		bool lvItemsReverse = true;
		public bool refreshLvItems = false;
		int lvChatSorting = 0;
		bool lvChatReverse = true;
		Dictionary<string, Regex> lootBlacklist = new Dictionary<string, Regex>();
		private void lbNamedChat_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbNamedChat.SelectedIndex != -1)
			{
				tbNamedChat.Text = (string)lbNamedChat.Items[lbNamedChat.SelectedIndex];
			}
		}
		private void btnAddNamedChat_Click(object sender, EventArgs e)
		{
			if (!lbNamedChat.Items.Contains(tbNamedChat.Text) && !String.IsNullOrEmpty(tbNamedChat.Text))
			{
				lbNamedChat.Items.Add(tbNamedChat.Text);
			}
		}
		private void btnRemoveNamedChat_Click(object sender, EventArgs e)
		{
			if (lbNamedChat.SelectedIndex != -1)
			{
				lbNamedChat.Items.RemoveAt(lbNamedChat.SelectedIndex);
			}
		}
		private void lvItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvItems.SelectedIndices.Count > 0)
			{
				ListViewItem lvi = lvItems.Items[lvItems.SelectedIndices[0]];
				LootedItemData item = (LootedItemData)lvi.Tag;
				lblCurrentItem.Text = item.itemName;
			}
			else
				lblCurrentItem.Text = "No Item";
			SortLvChat();
			RepopulateLvChat();
		}
		private void RepopulateLvChat()
		{
			lvChat.BeginUpdate();
			lvChat.Items.Clear();
			if (lvItems.SelectedIndices.Count > 0)
			{
				ListViewItem lvi = lvItems.Items[lvItems.SelectedIndices[0]];
				LootedItemData item = (LootedItemData)lvi.Tag;
				for (int i = item.chat.Count - 1; i >= 0; i--)
				{
					ChatLine cl = item.chat[i];
					lvi = new ListViewItem(cl.time.ToShortDateString() + " " + cl.time.ToLongTimeString());
					lvi.SubItems.Add(cl.channel);
					lvi.SubItems.Add(cl.player);
					lvi.SubItems.Add(cl.text);
					lvi.UseItemStyleForSubItems = false;
					lvi.SubItems[lvChatSorting].BackColor = SystemColors.ControlLight;
					lvi.Tag = cl;
					lvChat.Items.Add(lvi);
				}
			}
			ActGlobals.oFormActMain.ResizeLVCols(lvChat);
			lvChat.EndUpdate();
		}
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (lvItems.SelectedIndices.Count > 0)
			{
				ListViewItem lvi = lvItems.Items[lvItems.SelectedIndices[0]];
				LootedItemData item = (LootedItemData)lvi.Tag;
				Process.Start("http://lootdb.com/eq2/item/" + item.itemId);
			}
		}
		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (lvItems.SelectedIndices.Count > 0)
			{
				ListViewItem lvi = lvItems.Items[lvItems.SelectedIndices[0]];
				LootedItemData item = (LootedItemData)lvi.Tag;
				Process.Start("http://www.eq2llinks.com/item.php?id=" + item.itemId);
			}
		}
		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (lvItems.SelectedIndices.Count > 0)
			{
				ListViewItem lvi = lvItems.Items[lvItems.SelectedIndices[0]];
				LootedItemData item = (LootedItemData)lvi.Tag;
				Process.Start("http://eq2.wikia.com/wiki/" + item.itemName.Replace(' ', '_'));
			}
		}
		private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (lvItems.SelectedIndices.Count > 0)
			{
				ListViewItem lvi = lvItems.Items[lvItems.SelectedIndices[0]];
				LootedItemData item = (LootedItemData)lvi.Tag;
				Process.Start("http://eq2.zam.com/search.html?q=" + item.itemName.Replace(' ', '+'));
			}
		}
		private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (lvItems.SelectedIndices.Count > 0)
			{
				ListViewItem lvi = lvItems.Items[lvItems.SelectedIndices[0]];
				LootedItemData item = (LootedItemData)lvi.Tag;
				Process.Start("http://u.eq2wire.com/item/index/" + item.itemId);
			}
		}
		private void lvItems_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (lvItemsSorting == e.Column)
				lvItemsReverse = !lvItemsReverse;
			lvItemsSorting = e.Column;
			refreshLvItems = true;
		}
		private void SortLvChat()
		{
			if (lvItems.SelectedIndices.Count > 0)
			{
				ListViewItem lvi = lvItems.Items[lvItems.SelectedIndices[0]];
				LootedItemData item = (LootedItemData)lvi.Tag;
				item.chat.Sort(new ChatLine.Sorter(lvChatSorting));
				if (lvChatReverse)
					item.chat.Reverse();
			}
		}
		private void SortLvItems()
		{
			lootedItems.Sort(new LootedItemData.Sorter(lvItemsSorting));
			if (lvItemsReverse)
				lootedItems.Reverse();
		}
		private void RepopulateLvItems()
		{
			lvItems.BeginUpdate();
			lvItems.Items.Clear();
			for (int i = 0; i < lootedItems.Count; i++)
			{
				LootedItemData item = lootedItems[i];
				ListViewItem lvi = new ListViewItem(item.time.ToShortDateString() + " " + item.time.ToLongTimeString());
				lvi.SubItems.Add(item.zone);
				lvi.SubItems.Add(item.player);
				lvi.SubItems.Add(item.itemName);
				lvi.SubItems.Add(item.container);
				if (item.container.Contains("Exquisite"))
					lvi.SubItems[4].ForeColor = Color.DarkRed;
				if (item.container.Contains("Ornate"))
					lvi.SubItems[4].ForeColor = Color.DarkOrange;
				if (item.container.Contains("Treasure"))
					lvi.SubItems[4].ForeColor = Color.DarkCyan;
				if (item.container.Contains("corpse"))
					lvi.SubItems[4].ForeColor = Color.DarkGray;
				lvi.UseItemStyleForSubItems = false;
				lvi.SubItems[lvItemsSorting].BackColor = SystemColors.ControlLight;
				lvi.Tag = item;
				lvItems.Items.Add(lvi);
			}
			ActGlobals.oFormActMain.ResizeLVCols(lvItems);
			lvItems.EndUpdate();
		}
		private void lvChat_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (lvChatSorting == e.Column)
				lvChatReverse = !lvChatReverse;
			lvChatSorting = e.Column;
			SortLvChat();
			RepopulateLvChat();
		}
		private void tmrSec_Tick(object sender, EventArgs e)
		{
			if (refreshLvItems)
			{
				refreshLvItems = false;
				SortLvItems();
				RepopulateLvItems();
			}
		}
		private void copyAsCSVToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < lvItems.Columns.Count; i++)
			{
				sb.AppendFormat("{0},", lvItems.Columns[i].Text.Replace(',', '_'));
			}
			sb.Length = sb.Length - 1;
			sb.AppendLine();
			for (int i = 0; i < lvItems.Items.Count; i++)
			{
				if (lvItems.SelectedIndices.Count == 0 || lvItems.SelectedIndices.Contains(i))
				{
					ListViewItem lvi = lvItems.Items[i];
					for (int j = 0; j < lvi.SubItems.Count; j++)
					{
						sb.AppendFormat("{0},", lvi.SubItems[j].Text.Replace(',', '_'));
					}
					sb.Length = sb.Length - 1;
					sb.AppendLine();
				}
			}
			ActGlobals.oFormActMain.SendToClipboard(sb.ToString(), true);
		}
		private void copyAsTSCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < lvItems.Columns.Count; i++)
			{
				sb.AppendFormat("{0}\t", lvItems.Columns[i].Text);
			}
			sb.Length = sb.Length - 1;
			sb.AppendLine();
			for (int i = 0; i < lvItems.Items.Count; i++)
			{
				if (lvItems.SelectedIndices.Count == 0 || lvItems.SelectedIndices.Contains(i))
				{
					ListViewItem lvi = lvItems.Items[i];
					for (int j = 0; j < lvi.SubItems.Count; j++)
					{
						sb.AppendFormat("{0}\t", lvi.SubItems[j].Text);
					}
					sb.Length = sb.Length - 1;
					sb.AppendLine();
				}
			}
			ActGlobals.oFormActMain.SendToClipboard(sb.ToString(), true);
		}
		private void copyAsHTMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder html = new StringBuilder();
			html.Append("<table border='1'> <tr>");
			for (int i = 0; i < lvItems.Columns.Count; i++)
			{
				html.AppendFormat("<th>{0}</th> ", lvItems.Columns[i].Text);
			}
			html.Append("</tr> ");
			for (int i = 0; i < lvItems.Items.Count; i++)
			{
				if (lvItems.SelectedIndices.Count == 0 || lvItems.SelectedIndices.Contains(i))
				{
					html.Append("<tr>");
					for (int j = 0; j < lvItems.Columns.Count; j++)
					{
						html.AppendFormat("<td>{0}</td> ", lvItems.Items[i].SubItems[j].Text);
					}
					html.Append("</tr> ");
				}
			}
			html.Append("</table>");
			ActGlobals.oFormActMain.SendHtmlToClipboard(html.ToString());
		}
		private void copyAsPlainTexToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int[] columnWidths = new int[lvItems.Columns.Count];
			for (int i = 0; i < lvItems.Columns.Count; i++)
			{
				int colMax = lvItems.Columns[i].Text.Length;
				for (int j = 0; j < lvItems.Items.Count; j++)
				{
					if (lvItems.SelectedIndices.Count == 0 || lvItems.SelectedIndices.Contains(j))
					{
						ListViewItem lvi = lvItems.Items[j];
						int length = lvi.SubItems[i].Text.Length;
						if (length > colMax)
							colMax = length;
					}
				}
				columnWidths[i] = colMax + 2;
			}
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < lvItems.Columns.Count; i++)
			{
				sb.Append(lvItems.Columns[i].Text.ToUpper().PadRight(columnWidths[i]));
			}
			sb.AppendLine();
			for (int i = 0; i < lvItems.Items.Count; i++)
			{
				if (lvItems.SelectedIndices.Count == 0 || lvItems.SelectedIndices.Contains(i))
				{
					ListViewItem lvi = lvItems.Items[i];
					for (int j = 0; j < lvi.SubItems.Count; j++)
					{
						sb.Append(lvi.SubItems[j].Text.PadRight(columnWidths[j]));
					}
					sb.AppendLine();
				}
			}
			ActGlobals.oFormActMain.SendToClipboard(sb.ToString(), true);
		}
		private void copyActualLogLinesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < lvItems.Items.Count; i++)
			{
				if (lvItems.SelectedIndices.Count == 0 || lvItems.SelectedIndices.Contains(i))
				{
					ListViewItem lvi = lvItems.Items[i];
					LootedItemData item = (LootedItemData)lvi.Tag;
					sb.AppendLine(item.logLine);
				}
			}
			ActGlobals.oFormActMain.SendToClipboard(sb.ToString(), true);
		}
		private void copyItemLinkToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < lvItems.Items.Count; i++)
			{
				if (lvItems.SelectedIndices.Count == 0 || lvItems.SelectedIndices.Contains(i))
				{
					ListViewItem lvi = lvItems.Items[i];
					LootedItemData item = (LootedItemData)lvi.Tag;
					sb.AppendLine(item.itemLink);
				}
			}
			ActGlobals.oFormActMain.SendToClipboard(sb.ToString().Trim(new char[] { '\r', '\n' }), true);
		}
		private void copyItemNameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < lvItems.Items.Count; i++)
			{
				if (lvItems.SelectedIndices.Count == 0 || lvItems.SelectedIndices.Contains(i))
				{
					ListViewItem lvi = lvItems.Items[i];
					LootedItemData item = (LootedItemData)lvi.Tag;
					sb.AppendLine(item.itemName);
				}
			}
			ActGlobals.oFormActMain.SendToClipboard(sb.ToString().Trim(new char[] { '\r', '\n' }), true);
		}
		private void copyActualLogLinesToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < lvChat.Items.Count; i++)
			{
				if (lvChat.SelectedIndices.Count == 0 | lvChat.SelectedIndices.Contains(i))
				{
					ChatLine cl = (ChatLine)lvChat.Items[i].Tag;
					sb.AppendLine(cl.fullLine);
				}
			}
			ActGlobals.oFormActMain.SendToClipboard(sb.ToString(), true);
		}
		private void rbEnglish_CheckedChanged(object sender, EventArgs e)
		{
			if (rbEnglish.Checked)
				SetParseLang(0);
		}
		private void rbGerman_CheckedChanged(object sender, EventArgs e)
		{
			if (rbGerman.Checked)
				SetParseLang(1);
		}
		private void rbFrench_CheckedChanged(object sender, EventArgs e)
		{
			if (rbFrench.Checked)
				SetParseLang(2);
		}
		private void lvItems_Resize(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.ResizeLVCols(lvItems);
		}
		private void lvChat_Resize(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.ResizeLVCols(lvChat);
		}
		private void btnAddBlacklist_Click(object sender, EventArgs e)
		{
			AddBlacklist(tbBlacklist.Text);
		}
		private void clbBlacklist_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (e.CurrentValue == e.NewValue)
				return;
			string itemText = clbBlacklist.Items[e.Index].ToString();
			if (String.IsNullOrWhiteSpace(itemText))
				return;
			if (e.NewValue == CheckState.Checked)
			{
				if (!lootBlacklist.ContainsKey(itemText))
					lootBlacklist.Add(tbBlacklist.Text, new Regex(itemText, RegexOptions.Compiled));
			}
			else
			{
				if (lootBlacklist.ContainsKey(itemText))
					lootBlacklist.Remove(itemText);
			}
		}
		private void AddBlacklist(string Term)
		{
			if (!String.IsNullOrWhiteSpace(Term) && !lootBlacklist.ContainsKey(Term))
			{
				try
				{
					lootBlacklist.Add(Term, new Regex(Term, RegexOptions.Compiled));
					clbBlacklist.Items.Add(Term, true);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Regular Expression Syntax Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void btnRemoveBlacklist_Click(object sender, EventArgs e)
		{
			if (clbBlacklist.SelectedIndex != -1)
			{
				clbBlacklist.Items.Remove(tbBlacklist.Text);
				lootBlacklist.Remove(tbBlacklist.Text);
			}
		}
		private void clbBlacklist_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (clbBlacklist.SelectedIndex != -1)
				tbBlacklist.Text = clbBlacklist.Items[clbBlacklist.SelectedIndex].ToString();
		}
		private void btnClear_Click(object sender, EventArgs e)
		{
			lootedItems.Clear();
			RepopulateLvItems();
		}
		#endregion

		internal class ChatLine : IEquatable<ChatLine>, IComparable<ChatLine>
		{
			public DateTime time;
			public string fullLine, channel, player, text;

			public ChatLine(DateTime Time, string FullLine, string Channel, string Player, string Text)
			{
				this.time = Time;
				this.fullLine = FullLine;
				this.channel = Channel;
				this.player = Player;
				this.text = regexItem.Replace(Text, "$2");
				if (player == "You")
					player = ActGlobals.charName;
			}

			public override string ToString()
			{
				return fullLine;
			}
			public bool Equals(ChatLine other)
			{
				return this.ToString().Equals(other.ToString());
			}
			public override bool Equals(object obj)
			{
				ChatLine r = (ChatLine)obj;
				return this.ToString().Equals(r.ToString());
			}
			public override int GetHashCode()
			{
				return fullLine.GetHashCode();
			}
			public int CompareTo(ChatLine other)
			{
				return this.time.CompareTo(other.time);
			}
			public class Sorter : IComparer<ChatLine>
			{
				int sortColumn = 0;
				public Sorter(int SortColumn)
				{
					this.sortColumn = SortColumn;
				}
				public int Compare(ChatLine x, ChatLine y)
				{
					switch (sortColumn)
					{
						case 0: // Datetime
							return x.time.CompareTo(y.time);
						case 1: // Channel
							return x.channel.CompareTo(y.channel);
						case 2: // Player
							return x.player.CompareTo(y.player);
						case 3: // Text
							return x.text.CompareTo(y.text);
						default:
							return 0;
					}
				}
			}
		}
		internal class LootedItemData
		{
			public string player, itemName, itemId, container, zone, logLine, itemLink;
			public DateTime time;
			public List<ChatLine> chat;

			public LootedItemData(DateTime Time, string Player, string ItemName, string ItemId, string Container, string Zone, string LogLine)
			{
				this.time = Time;
				this.player = Player;
				this.itemName = ItemName;
				this.itemId = ItemId;
				this.container = Container;
				this.zone = Zone;
				this.chat = new List<ChatLine>();
				this.logLine = LogLine;
				this.itemLink = regexItem.Match(LogLine).Value;
			}

			public class Sorter : IComparer<LootedItemData>
			{
				int sortColumn = 0;
				public Sorter(int SortColumn)
				{
					this.sortColumn = SortColumn;
				}
				public int Compare(LootedItemData x, LootedItemData y)
				{
					switch (sortColumn)
					{
						case 0: // Datetime
							return x.time.CompareTo(y.time);
						case 1: // Zone
							return x.zone.CompareTo(y.zone);
						case 2: // Player
							return x.player.CompareTo(y.player);
						case 3: // Item Name
							return x.itemName.CompareTo(y.itemName);
						case 4: // Container
							return x.container.CompareTo(y.container);
						default:
							return 0;
					}
				}
			}

		}
	}
}
