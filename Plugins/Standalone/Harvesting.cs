using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

[assembly: AssemblyTitle("Harvest Tracking")]
[assembly: AssemblyDescription("Parses and totals harvests")]
[assembly: AssemblyVersion("2.1.0.0")]

namespace ACT_Harvest_Plugin
{
	public class Harvest_Plugin : UserControl, IActPluginV1
	{
		#region Component Designer generated code

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private GroupBox groupBox1;
		private ListBox listBox1;
		private TableLayoutPanel tableLayoutPanel1;
		private GroupBox groupBox2;
		private ListBox listBox2;
		private Label label1;
		private Panel panel1;
		private Button buttonOverview;
		private Button buttonClear;
		private ContextMenuStrip menu1;
		private ToolStripMenuItem menuItemCsv;
		private DataGridView dataGridView1;
		private DataSet dataSetHarvests;
		private DataTable dataTable1;
		private DataColumn dataColumn1;
		private DataColumn dataColumn2;
		private DataColumn dataColumn3;
		private DataColumn dataColumn4;
		private DataColumn dataColumn5;
		private DataColumn dataColumn6;
		private DataColumn dataColumn7;
		private DataColumn dataColumn8;
		private DataColumn dataColumn9;
		private DataColumn dataColumn10;
		private DataColumn dataColumn11;
		private DataColumn dataColumn12;
		private DataTable dataTable2;
		private DataColumn dataColumn13;
		private DataColumn dataColumn14;
		private DataColumn dataColumn15;
		private DataColumn dataColumn16;
		private DataColumn dataColumn17;
		private DataColumn dataColumn18;
		private DataColumn dataColumn19;
		private DataColumn dataColumn20;
		private DataColumn dataColumn21;
		private DataColumn dataColumn22;
		private DataColumn dataColumn23;
		private DataColumn dataColumn24;
		private DataColumn dataColumn25;
		private DataTable dataTable3;
		private DataColumn dataColumn26;
		private DataColumn dataColumn27;
		private DataColumn dataColumn28;
		private DataColumn dataColumn29;
		private DataColumn dataColumn30;
		private DataColumn dataColumn31;
		private DataColumn dataColumn32;
		private DataColumn dataColumn33;
		private SplitContainer splitContainer1;
		private DataGridView dataGridViewPony;
		private DataSet dataSetGatherers;
		private DataTable dataTable4;
		private DataColumn dataColumn35;
		private DataTable dataTable5;
		private DataColumn dataColumn39;
		private DataColumn dataColumn34;
		private DataColumn dataColumn36;
		private DataColumn dataColumn37;
		private DataColumn dataColumn38;
		private Button buttonSaveHtml;
		private Button buttonSaveCsv;
		private SaveFileDialog saveFileDialog1;
		private ToolTip toolTip1;
		private DataColumn dataColumn42;
		private DataColumn dataColumn43;
		private DataColumn dataColumn40;
		private DataColumn dataColumn41;
		private DataColumn dataColumn44;
		private CheckBox checkBoxPony;
		private DataColumn dataColumn45;
		private ToolStripMenuItem menuItemHtml;

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

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.buttonOverview = new System.Windows.Forms.Button();
			this.buttonClear = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.menu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemCsv = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemHtml = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridViewPony = new System.Windows.Forms.DataGridView();
			this.checkBoxPony = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonSaveHtml = new System.Windows.Forms.Button();
			this.buttonSaveCsv = new System.Windows.Forms.Button();
			this.dataSetHarvests = new System.Data.DataSet();
			this.dataTable1 = new System.Data.DataTable();
			this.dataColumn1 = new System.Data.DataColumn();
			this.dataColumn2 = new System.Data.DataColumn();
			this.dataColumn3 = new System.Data.DataColumn();
			this.dataColumn4 = new System.Data.DataColumn();
			this.dataColumn5 = new System.Data.DataColumn();
			this.dataColumn6 = new System.Data.DataColumn();
			this.dataColumn7 = new System.Data.DataColumn();
			this.dataColumn8 = new System.Data.DataColumn();
			this.dataColumn9 = new System.Data.DataColumn();
			this.dataColumn10 = new System.Data.DataColumn();
			this.dataColumn11 = new System.Data.DataColumn();
			this.dataColumn12 = new System.Data.DataColumn();
			this.dataTable2 = new System.Data.DataTable();
			this.dataColumn13 = new System.Data.DataColumn();
			this.dataColumn14 = new System.Data.DataColumn();
			this.dataColumn15 = new System.Data.DataColumn();
			this.dataColumn16 = new System.Data.DataColumn();
			this.dataColumn17 = new System.Data.DataColumn();
			this.dataColumn18 = new System.Data.DataColumn();
			this.dataColumn19 = new System.Data.DataColumn();
			this.dataColumn20 = new System.Data.DataColumn();
			this.dataColumn21 = new System.Data.DataColumn();
			this.dataColumn22 = new System.Data.DataColumn();
			this.dataColumn23 = new System.Data.DataColumn();
			this.dataColumn24 = new System.Data.DataColumn();
			this.dataColumn25 = new System.Data.DataColumn();
			this.dataTable3 = new System.Data.DataTable();
			this.dataColumn26 = new System.Data.DataColumn();
			this.dataColumn27 = new System.Data.DataColumn();
			this.dataColumn28 = new System.Data.DataColumn();
			this.dataColumn29 = new System.Data.DataColumn();
			this.dataColumn30 = new System.Data.DataColumn();
			this.dataColumn31 = new System.Data.DataColumn();
			this.dataColumn32 = new System.Data.DataColumn();
			this.dataColumn33 = new System.Data.DataColumn();
			this.dataSetGatherers = new System.Data.DataSet();
			this.dataTable4 = new System.Data.DataTable();
			this.dataColumn35 = new System.Data.DataColumn();
			this.dataColumn42 = new System.Data.DataColumn();
			this.dataColumn45 = new System.Data.DataColumn();
			this.dataTable5 = new System.Data.DataTable();
			this.dataColumn39 = new System.Data.DataColumn();
			this.dataColumn34 = new System.Data.DataColumn();
			this.dataColumn36 = new System.Data.DataColumn();
			this.dataColumn37 = new System.Data.DataColumn();
			this.dataColumn38 = new System.Data.DataColumn();
			this.dataColumn43 = new System.Data.DataColumn();
			this.dataColumn40 = new System.Data.DataColumn();
			this.dataColumn41 = new System.Data.DataColumn();
			this.dataColumn44 = new System.Data.DataColumn();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.menu1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPony)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetHarvests)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetGatherers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable5)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 3);
			this.groupBox1.Controls.Add(this.listBox1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 67);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
			this.groupBox1.Size = new System.Drawing.Size(195, 269);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "By Action/Node";
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.IntegralHeight = false;
			this.listBox1.Location = new System.Drawing.Point(6, 19);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(183, 244);
			this.listBox1.Sorted = true;
			this.listBox1.TabIndex = 1;
			this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.buttonOverview, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonClear, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonSaveHtml, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.buttonSaveCsv, 2, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1157, 615);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// buttonOverview
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.buttonOverview, 3);
			this.buttonOverview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonOverview.Location = new System.Drawing.Point(3, 3);
			this.buttonOverview.Name = "buttonOverview";
			this.buttonOverview.Size = new System.Drawing.Size(195, 26);
			this.buttonOverview.TabIndex = 0;
			this.buttonOverview.Text = "Activate Overview Display";
			this.buttonOverview.Click += new System.EventHandler(this.buttonOverview_Click);
			// 
			// buttonClear
			// 
			this.buttonClear.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonClear.Location = new System.Drawing.Point(3, 35);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(61, 26);
			this.buttonClear.TabIndex = 1;
			this.buttonClear.Text = "Clear";
			this.toolTip1.SetToolTip(this.buttonClear, "Clear all harvest data");
			this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
			// 
			// groupBox2
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 3);
			this.groupBox2.Controls.Add(this.listBox2);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(3, 342);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
			this.groupBox2.Size = new System.Drawing.Size(195, 270);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "By Item";
			// 
			// listBox2
			// 
			this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox2.FormattingEnabled = true;
			this.listBox2.IntegralHeight = false;
			this.listBox2.Location = new System.Drawing.Point(6, 19);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(183, 245);
			this.listBox2.Sorted = true;
			this.listBox2.TabIndex = 2;
			this.listBox2.Click += new System.EventHandler(this.listBox2_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.splitContainer1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(204, 3);
			this.panel1.Name = "panel1";
			this.tableLayoutPanel1.SetRowSpan(this.panel1, 4);
			this.panel1.Size = new System.Drawing.Size(951, 609);
			this.panel1.TabIndex = 4;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 18);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dataGridViewPony);
			this.splitContainer1.Panel2.Controls.Add(this.checkBoxPony);
			this.splitContainer1.Size = new System.Drawing.Size(951, 591);
			this.splitContainer1.SplitterDistance = 469;
			this.splitContainer1.TabIndex = 6;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Menu;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.ContextMenuStrip = this.menu1;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 20;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(951, 469);
			this.dataGridView1.TabIndex = 5;
			this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
			// 
			// menu1
			// 
			this.menu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.menuItemCsv,
			this.menuItemHtml});
			this.menu1.Name = "menu1";
			this.menu1.Size = new System.Drawing.Size(180, 48);
			// 
			// menuItemCsv
			// 
			this.menuItemCsv.Name = "menuItemCsv";
			this.menuItemCsv.Size = new System.Drawing.Size(179, 22);
			this.menuItemCsv.Text = "Copy View as CSV";
			this.menuItemCsv.ToolTipText = "Copy the current data view as CSV";
			this.menuItemCsv.Click += new System.EventHandler(this.menuItemCsv_Click);
			// 
			// menuItemHtml
			// 
			this.menuItemHtml.Name = "menuItemHtml";
			this.menuItemHtml.Size = new System.Drawing.Size(179, 22);
			this.menuItemHtml.Text = "Copy View as HTML";
			this.menuItemHtml.ToolTipText = "Copy the current data view as HTML";
			this.menuItemHtml.Click += new System.EventHandler(this.menuItemHtml_Click);
			// 
			// dataGridViewPony
			// 
			this.dataGridViewPony.AllowUserToAddRows = false;
			this.dataGridViewPony.AllowUserToResizeRows = false;
			this.dataGridViewPony.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridViewPony.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewPony.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewPony.Location = new System.Drawing.Point(0, 17);
			this.dataGridViewPony.Name = "dataGridViewPony";
			this.dataGridViewPony.Size = new System.Drawing.Size(951, 101);
			this.dataGridViewPony.TabIndex = 0;
			// 
			// checkBoxPony
			// 
			this.checkBoxPony.AutoSize = true;
			this.checkBoxPony.BackColor = System.Drawing.Color.LightSteelBlue;
			this.checkBoxPony.Checked = true;
			this.checkBoxPony.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxPony.Dock = System.Windows.Forms.DockStyle.Top;
			this.checkBoxPony.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxPony.ForeColor = System.Drawing.Color.MidnightBlue;
			this.checkBoxPony.Location = new System.Drawing.Point(0, 0);
			this.checkBoxPony.Name = "checkBoxPony";
			this.checkBoxPony.Size = new System.Drawing.Size(951, 17);
			this.checkBoxPony.TabIndex = 6;
			this.checkBoxPony.Text = "Pony and Plant Status";
			this.checkBoxPony.UseVisualStyleBackColor = false;
			this.checkBoxPony.CheckedChanged += new System.EventHandler(this.checkBoxPony_CheckedChanged);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(951, 18);
			this.label1.TabIndex = 4;
			this.label1.Text = "Data Displayed";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.TextChanged += new System.EventHandler(this.label1_TextChanged);
			// 
			// buttonSaveHtml
			// 
			this.buttonSaveHtml.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonSaveHtml.Enabled = false;
			this.buttonSaveHtml.Location = new System.Drawing.Point(70, 35);
			this.buttonSaveHtml.Name = "buttonSaveHtml";
			this.buttonSaveHtml.Size = new System.Drawing.Size(61, 26);
			this.buttonSaveHtml.TabIndex = 5;
			this.buttonSaveHtml.Text = "To HTML";
			this.toolTip1.SetToolTip(this.buttonSaveHtml, "Save current Data Selected to HTML file");
			this.buttonSaveHtml.UseVisualStyleBackColor = true;
			this.buttonSaveHtml.Click += new System.EventHandler(this.buttonSaveHtml_Click);
			// 
			// buttonSaveCsv
			// 
			this.buttonSaveCsv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonSaveCsv.Enabled = false;
			this.buttonSaveCsv.Location = new System.Drawing.Point(137, 35);
			this.buttonSaveCsv.Name = "buttonSaveCsv";
			this.buttonSaveCsv.Size = new System.Drawing.Size(61, 26);
			this.buttonSaveCsv.TabIndex = 6;
			this.buttonSaveCsv.Text = "To CSV";
			this.toolTip1.SetToolTip(this.buttonSaveCsv, "Save current Data Selected to CSV file");
			this.buttonSaveCsv.UseVisualStyleBackColor = true;
			this.buttonSaveCsv.Click += new System.EventHandler(this.buttonSaveCsv_Click);
			// 
			// dataSetHarvests
			// 
			this.dataSetHarvests.DataSetName = "NewDataSet";
			this.dataSetHarvests.Tables.AddRange(new System.Data.DataTable[] {
			this.dataTable1,
			this.dataTable2,
			this.dataTable3});
			// 
			// dataTable1
			// 
			this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
			this.dataColumn1,
			this.dataColumn2,
			this.dataColumn3,
			this.dataColumn4,
			this.dataColumn5,
			this.dataColumn6,
			this.dataColumn7,
			this.dataColumn8,
			this.dataColumn9,
			this.dataColumn10,
			this.dataColumn11,
			this.dataColumn12});
			this.dataTable1.Constraints.AddRange(new System.Data.Constraint[] {
			new System.Data.UniqueConstraint("Constraint1", new string[] {
						"Type"}, true)});
			this.dataTable1.PrimaryKey = new System.Data.DataColumn[] {
		this.dataColumn1};
			this.dataTable1.TableName = "Overview";
			// 
			// dataColumn1
			// 
			this.dataColumn1.AllowDBNull = false;
			this.dataColumn1.ColumnName = "Type";
			// 
			// dataColumn2
			// 
			this.dataColumn2.ColumnName = "# Attempts";
			this.dataColumn2.DataType = typeof(int);
			// 
			// dataColumn3
			// 
			this.dataColumn3.Caption = "% of Attempts";
			this.dataColumn3.ColumnName = "% of Attempts";
			this.dataColumn3.DataType = typeof(double);
			// 
			// dataColumn4
			// 
			this.dataColumn4.ColumnName = "# Collects";
			this.dataColumn4.DataType = typeof(int);
			// 
			// dataColumn5
			// 
			this.dataColumn5.ColumnName = "% of Collects";
			this.dataColumn5.DataType = typeof(double);
			// 
			// dataColumn6
			// 
			this.dataColumn6.ColumnName = "# Items";
			// 
			// dataColumn7
			// 
			this.dataColumn7.ColumnName = "% of Items";
			this.dataColumn7.DataType = typeof(double);
			// 
			// dataColumn8
			// 
			this.dataColumn8.ColumnName = "# Rares";
			this.dataColumn8.DataType = typeof(int);
			// 
			// dataColumn9
			// 
			this.dataColumn9.ColumnName = "% of Rares";
			this.dataColumn9.DataType = typeof(double);
			// 
			// dataColumn10
			// 
			this.dataColumn10.ColumnName = "# Bountiful";
			this.dataColumn10.DataType = typeof(int);
			// 
			// dataColumn11
			// 
			this.dataColumn11.ColumnName = "% of Bountifuls";
			this.dataColumn11.DataType = typeof(double);
			// 
			// dataColumn12
			// 
			this.dataColumn12.ColumnName = "# Bonus";
			this.dataColumn12.DataType = typeof(int);
			// 
			// dataTable2
			// 
			this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
			this.dataColumn13,
			this.dataColumn14,
			this.dataColumn15,
			this.dataColumn16,
			this.dataColumn17,
			this.dataColumn18,
			this.dataColumn19,
			this.dataColumn20,
			this.dataColumn21,
			this.dataColumn22,
			this.dataColumn23,
			this.dataColumn24,
			this.dataColumn25});
			this.dataTable2.Constraints.AddRange(new System.Data.Constraint[] {
			new System.Data.UniqueConstraint("Constraint1", new string[] {
						"Type"}, true)});
			this.dataTable2.PrimaryKey = new System.Data.DataColumn[] {
		this.dataColumn13};
			this.dataTable2.TableName = "Node";
			// 
			// dataColumn13
			// 
			this.dataColumn13.AllowDBNull = false;
			this.dataColumn13.ColumnName = "Type";
			// 
			// dataColumn14
			// 
			this.dataColumn14.ColumnName = "# Attempts";
			this.dataColumn14.DataType = typeof(int);
			// 
			// dataColumn15
			// 
			this.dataColumn15.ColumnName = "% of Attempts";
			this.dataColumn15.DataType = typeof(double);
			// 
			// dataColumn16
			// 
			this.dataColumn16.ColumnName = "# Collects";
			this.dataColumn16.DataType = typeof(int);
			// 
			// dataColumn17
			// 
			this.dataColumn17.ColumnName = "% of Collects";
			this.dataColumn17.DataType = typeof(double);
			// 
			// dataColumn18
			// 
			this.dataColumn18.ColumnName = "# Items";
			this.dataColumn18.DataType = typeof(int);
			// 
			// dataColumn19
			// 
			this.dataColumn19.ColumnName = "% of Items";
			this.dataColumn19.DataType = typeof(double);
			// 
			// dataColumn20
			// 
			this.dataColumn20.ColumnName = "Avg Items/Collect";
			this.dataColumn20.DataType = typeof(double);
			// 
			// dataColumn21
			// 
			this.dataColumn21.ColumnName = "# Rares";
			this.dataColumn21.DataType = typeof(int);
			// 
			// dataColumn22
			// 
			this.dataColumn22.ColumnName = "% of Rares";
			this.dataColumn22.DataType = typeof(double);
			// 
			// dataColumn23
			// 
			this.dataColumn23.ColumnName = "# Bountiful";
			this.dataColumn23.DataType = typeof(int);
			// 
			// dataColumn24
			// 
			this.dataColumn24.ColumnName = "% of Bountifuls";
			this.dataColumn24.DataType = typeof(double);
			// 
			// dataColumn25
			// 
			this.dataColumn25.ColumnName = "# Bonus";
			this.dataColumn25.DataType = typeof(int);
			// 
			// dataTable3
			// 
			this.dataTable3.Columns.AddRange(new System.Data.DataColumn[] {
			this.dataColumn26,
			this.dataColumn27,
			this.dataColumn28,
			this.dataColumn29,
			this.dataColumn30,
			this.dataColumn31,
			this.dataColumn32,
			this.dataColumn33});
			this.dataTable3.TableName = "Item";
			// 
			// dataColumn26
			// 
			this.dataColumn26.AllowDBNull = false;
			this.dataColumn26.ColumnName = "Time";
			this.dataColumn26.DataType = typeof(System.DateTime);
			// 
			// dataColumn27
			// 
			this.dataColumn27.ColumnName = "Action";
			// 
			// dataColumn28
			// 
			this.dataColumn28.ColumnName = "Amount";
			this.dataColumn28.DataType = typeof(int);
			// 
			// dataColumn29
			// 
			this.dataColumn29.ColumnName = "Item Name";
			// 
			// dataColumn30
			// 
			this.dataColumn30.ColumnName = "Node Name";
			// 
			// dataColumn31
			// 
			this.dataColumn31.ColumnName = "Rare";
			this.dataColumn31.DataType = typeof(bool);
			// 
			// dataColumn32
			// 
			this.dataColumn32.ColumnName = "Bountiful";
			this.dataColumn32.DataType = typeof(bool);
			// 
			// dataColumn33
			// 
			this.dataColumn33.ColumnName = "Bonus";
			this.dataColumn33.DataType = typeof(bool);
			// 
			// dataSetGatherers
			// 
			this.dataSetGatherers.DataSetName = "Pony";
			this.dataSetGatherers.Tables.AddRange(new System.Data.DataTable[] {
			this.dataTable4,
			this.dataTable5});
			// 
			// dataTable4
			// 
			this.dataTable4.Columns.AddRange(new System.Data.DataColumn[] {
			this.dataColumn35,
			this.dataColumn42,
			this.dataColumn45});
			this.dataTable4.TableName = "Settings";
			// 
			// dataColumn35
			// 
			this.dataColumn35.ColumnName = "SplitY";
			this.dataColumn35.DataType = typeof(int);
			// 
			// dataColumn42
			// 
			this.dataColumn42.ColumnName = "SavePath";
			// 
			// dataColumn45
			// 
			this.dataColumn45.ColumnName = "Tracking";
			this.dataColumn45.DataType = typeof(bool);
			// 
			// dataTable5
			// 
			this.dataTable5.Columns.AddRange(new System.Data.DataColumn[] {
			this.dataColumn39,
			this.dataColumn34,
			this.dataColumn36,
			this.dataColumn37,
			this.dataColumn38,
			this.dataColumn43,
			this.dataColumn40,
			this.dataColumn41,
			this.dataColumn44});
			this.dataTable5.Constraints.AddRange(new System.Data.Constraint[] {
			new System.Data.UniqueConstraint("Constraint1", new string[] {
						"Player"}, true)});
			this.dataTable5.PrimaryKey = new System.Data.DataColumn[] {
		this.dataColumn34};
			this.dataTable5.TableName = "Harvests";
			// 
			// dataColumn39
			// 
			this.dataColumn39.ColumnName = "TTS";
			this.dataColumn39.DataType = typeof(bool);
			// 
			// dataColumn34
			// 
			this.dataColumn34.AllowDBNull = false;
			this.dataColumn34.ColumnName = "Player";
			// 
			// dataColumn36
			// 
			this.dataColumn36.Caption = "Pony Harvests";
			this.dataColumn36.ColumnName = "PonyHarvests";
			// 
			// dataColumn37
			// 
			this.dataColumn37.Caption = "Pony State";
			this.dataColumn37.ColumnName = "PonyState";
			// 
			// dataColumn38
			// 
			this.dataColumn38.Caption = "Pony Started";
			this.dataColumn38.ColumnName = "PonyStarted";
			this.dataColumn38.DataType = typeof(System.DateTime);
			// 
			// dataColumn43
			// 
			this.dataColumn43.ColumnName = "PonyWait";
			this.dataColumn43.DataType = typeof(System.TimeSpan);
			// 
			// dataColumn40
			// 
			this.dataColumn40.Caption = "Plant State";
			this.dataColumn40.ColumnName = "PlantState";
			// 
			// dataColumn41
			// 
			this.dataColumn41.Caption = "Plant Started";
			this.dataColumn41.ColumnName = "PlantStarted";
			this.dataColumn41.DataType = typeof(System.DateTime);
			// 
			// dataColumn44
			// 
			this.dataColumn44.Caption = "Plant Wait";
			this.dataColumn44.ColumnName = "PlantWait";
			this.dataColumn44.DataType = typeof(System.TimeSpan);
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 6500;
			this.toolTip1.InitialDelay = 500;
			this.toolTip1.ReshowDelay = 100;
			// 
			// Harvest_Plugin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Harvest_Plugin";
			this.Size = new System.Drawing.Size(1157, 615);
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.menu1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPony)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetHarvests)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetGatherers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable5)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public Harvest_Plugin()
		{
			InitializeComponent();
		}

		Label lblStatus;
		bool rareNext = false;
		bool bountifulHarvest = false;
		bool isFirstShow = true;
		
		static int textIndex = 39;
		Regex regHarvestAction = new Regex(@"\GYou (?<action>[^ ]+) (?<number>\d+) \\aITEM -?\d+ -?\d+:(?<itemName>[^\\]+)\\/a from the (?<nodeType>[^\.]+)\.", RegexOptions.Compiled);
		Regex regBonusHarvestAction = new Regex(@"\GYour (?<actor>.*) has found a bonus harvest from (?<nodeType>[^\.]+)", RegexOptions.Compiled);
		Regex regBonusHarvestReceive = new Regex(@"\GYou (?<action>[^ ]+) (?:(?<number>\d+) )?\\aITEM -?\d+ -?\d+:(?<itemName>[^\\]+)\\/a\.", RegexOptions.Compiled);
		Regex regPonyStartArea = new Regex(@"\GYou say to \w+, ""Gather harvests from (?<area>.+)""", RegexOptions.Compiled);
		Regex regPonyStartLevel = new Regex(@"\GYou say to \w+, ""Gather level (?<area>.+)""", RegexOptions.Compiled);
		Regex regPonyStartHoliday = new Regex(@"\GYou say to \w+, ""I need some (?<area>.+)""", RegexOptions.Compiled);
		const string ponyPulled = "You remove a bundle of harvests from your faithful pack pony.";
		const string plantPulled = "You search the leaves and find something!";

		// data table names must match those set in the designer
		const string tableSettings = "Settings";
		const string tableHarvests = "Harvests";
		const string colTTS = "TTS";
		const string colPlayer = "Player";
		const string colPonyHarvest = "PonyHarvests";
		const string colPonyState = "PonyState";
		const string colPonyStarted = "PonyStarted";
		const string colPonyWait = "PonyWait";
		const string colPlantState = "PlantState";
		const string colPlantStarted = "PlantStarted";
		const string colPlantWait = "PlantWait";
		const string colSplitY = "SplitY";
		const string colSavePath = "SavePath";
		const string colPonyTrack = "Tracking";
		
		HarvestStats harvestStats = new HarvestStats();
		WindowsFormsSynchronizationContext mUiContext = new WindowsFormsSynchronizationContext();
		enum ViewType { NONE, OVERVIEW, NODE, ITEM }
		ViewType currentView = ViewType.NONE;
		//the fastest harvest speed possible is 750 milliseconds
		public static TimeSpan sameHarvestAttemptMax = new TimeSpan(0, 0, 0, 0, 750);
		public static TimeSpan ponyHarvestTime = new TimeSpan(0, 2, 0, 0, 0);
		public static TimeSpan plantHarvestTime = new TimeSpan(0, 23, 0, 0, 0);
		static string allRowType = "All";
		static string nonShadowedRaresType = "Rare Skills Comparison";
		DateTime lastHarvestTime = DateTime.MinValue;
		Queue<HarvestData> bonusQueue = new Queue<HarvestData>(3);
		System.Timers.Timer ponyTimer = new System.Timers.Timer();
		const string ponyTip = "Check to track pony and goblin plant harvest times.\n"
					+ "Pony/plant data is not collected when unchecked.\n"
					+ "When quickly switching between EQII characters\n"
					+ "be sure to let ACT switch log files\n"
					+ "so that updates can be captured.\n"
					+ "(Talking to the pony can help switch if chat is inactive.)"
					;
		string configFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\Harvesting.config.xml");
		string lastSavePath = "";

		#region IActPluginV1 Members
		public void DeInitPlugin()
		{
			SaveSettings();
			ActGlobals.oFormActMain.OnLogLineRead -= oFormActMain_OnLogLineRead;
			lblStatus.Text = "Plugin exited";
		}

		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			lblStatus = pluginStatusText;
			pluginScreenSpace.Controls.Add(this);
			this.Dock = DockStyle.Fill;

			LoadSettings();

			UpdatePonyTable();

			lblStatus.Text = "Plugin started";
			ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(oFormActMain_OnLogLineRead);
		}

		#endregion

		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);

			// can't set the splitter location until all the controls have been sized / located
			if (Visible && !Disposing && isFirstShow)
			{
				if (dataSetGatherers.Tables[tableSettings].Rows.Count > 0)
				{
					if (dataSetGatherers.Tables[tableSettings].Rows[0][colSplitY] != DBNull.Value && checkBoxPony.Checked)
						splitContainer1.SplitterDistance = (int)dataSetGatherers.Tables[tableSettings].Rows[0][colSplitY];
					else if (!checkBoxPony.Checked)
					{
						splitContainer1.SplitterDistance = splitContainer1.Height - checkBoxPony.Height;
						dataGridViewPony.Visible = false;
					}
				}
				isFirstShow = false;
			}
		}

		void LoadSettings()
		{
			if (File.Exists(configFile))
				dataSetGatherers.ReadXml(configFile);

			dataGridViewPony.DataSource = dataSetGatherers.Tables[tableHarvests];
			dataGridViewPony.Columns[colPonyState].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewPony.Columns[colPonyWait].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewPony.Columns[colPlantState].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewPony.Columns[colPlantWait].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewPony.Sort(dataGridViewPony.Columns[colPlayer], System.ComponentModel.ListSortDirection.Ascending);
			dataGridViewPony.Columns[colPonyWait].DefaultCellStyle.Format = "hh\\:mm";
			dataGridViewPony.Columns[colPlantWait].DefaultCellStyle.Format = "hh\\:mm";
			dataGridViewPony.Columns[colTTS].ToolTipText = "Check for Text-To-Speech when a harvest becomes ready";
			toolTip1.SetToolTip(checkBoxPony, ponyTip);

			if (dataSetGatherers.Tables[tableSettings].Rows.Count > 0)
			{
				if (dataSetGatherers.Tables[tableSettings].Rows[0][colSavePath] != DBNull.Value)
					lastSavePath = dataSetGatherers.Tables[tableSettings].Rows[0][colSavePath].ToString();
				if (dataSetGatherers.Tables[tableSettings].Rows[0][colPonyTrack] != DBNull.Value)
					checkBoxPony.Checked = (bool)dataSetGatherers.Tables[tableSettings].Rows[0][colPonyTrack];
			}

			// if anything is in progress, start the timer
			if (checkBoxPony.Checked)
			{
				foreach (DataRow row in dataSetGatherers.Tables[tableHarvests].Rows)
				{
					row[colPonyWait] = DBNull.Value;
					row[colPlantWait] = DBNull.Value;
					if (row[colPonyStarted] != DBNull.Value || row[colPlantStarted] != DBNull.Value)
					{
						StartPonyTimer();
					}
				}
			}
		}

		void SaveSettings()
		{
			if (dataSetGatherers.Tables[tableSettings].Rows.Count == 0)
			{
				DataRow row = dataSetGatherers.Tables[tableSettings].NewRow();
				dataSetGatherers.Tables[tableSettings].Rows.Add(row);
			}

			dataSetGatherers.Tables[tableSettings].Rows[0][colPonyTrack] = checkBoxPony.Checked;

			if (!isFirstShow && checkBoxPony.Checked)
			{
				// we should have a good splitter location to save
				dataSetGatherers.Tables[tableSettings].Rows[0][colSplitY] = splitContainer1.SplitterDistance;
			}

			if (string.IsNullOrEmpty(lastSavePath))
				dataSetGatherers.Tables[tableSettings].Rows[0][colSavePath] = DBNull.Value;
			else
				dataSetGatherers.Tables[tableSettings].Rows[0][colSavePath] = lastSavePath;

			dataSetGatherers.WriteXml(configFile);
		}

		void menuItemCsv_Click(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.SendToClipboard(BuildCsvString(), true);
		}

		string BuildCsvString()
		{
			DataTable dt = dataGridView1.DataSource as DataTable;
			if (dt == null)
				return "";
			StringBuilder table = new StringBuilder();
			//header row
			foreach (DataGridViewColumn col in dataGridView1.Columns)
			{
				table.AppendFormat("{0},", col.Name);
			}
			table.Remove(table.Length - 1, 1); //remove trailing comma
			table.Append("\n");
			//data rows
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				foreach (DataGridViewColumn col in dataGridView1.Columns)
				{
					if (col.Name.Contains("%"))
						table.AppendFormat("{0:P2},", row.Cells[col.Name].Value);
					else if (col.Name.Contains("Avg"))
						table.AppendFormat("\"{0:N2}\",", row.Cells[col.Name].Value);
					else
						table.AppendFormat("{0},", row.Cells[col.Name].Value);
				}
				table.Remove(table.Length - 1, 1); //remove trailing comma
				table.Append("\n");
			}
			return table.ToString();
		}

		void menuItemHtml_Click(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.SendHtmlToClipboard(BuildHtmlString());
		}

		string BuildHtmlString()
		{
			DataTable dt = dataGridView1.DataSource as DataTable;
			if (dt == null)
				return "";
			StringBuilder table = new StringBuilder();
			table.Append(@"<table border=""1"">\n<tr>");
			//header row
			foreach (DataGridViewColumn col in dataGridView1.Columns)
			{
				table.AppendFormat("<th>{0}</th>", col.Name);
			}
			table.Append("</tr>\n");
			//data rows
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				table.Append("<tr>");
				foreach (DataGridViewColumn col in dataGridView1.Columns)
				{
					if (col.Name.Contains("%"))
						table.AppendFormat(@"<td style=""text-align:center"">{0:P2}</td>", row.Cells[col.Name].Value);
					else if (col.Name.Contains("Avg"))
						table.AppendFormat(@"<td style=""text-align:center"">{0:N2}</td>", row.Cells[col.Name].Value);
					else
						table.AppendFormat(@"<td style=""text-align:center"">{0}</td>", row.Cells[col.Name].Value.ToString());
				}
				table.Append("</tr>");
			}
			table.Append("</table>\n");
			return table.ToString();
		}

		private void SaveToFile(string t)
		{
			string data;
			if (t.Equals("csv"))
				data = BuildCsvString();
			else
				data = BuildHtmlString();

			saveFileDialog1.Filter = string.Format("{0} files|*.{1}|all files|*.*", t, t);
			saveFileDialog1.DefaultExt = t;
			if (!string.IsNullOrEmpty(lastSavePath))
				saveFileDialog1.InitialDirectory = lastSavePath;
			saveFileDialog1.FileName = string.Format("{0}-harvests-{1}", DateTime.Now.ToString("yyyy-MM-dd"), label1.Text.Substring(label1.Text.IndexOf(':') + 2));
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				File.WriteAllText(saveFileDialog1.FileName, data);
				lastSavePath = Path.GetDirectoryName(saveFileDialog1.FileName);
			}
		}
		private void buttonSaveCsv_Click(object sender, EventArgs e)
		{
			SaveToFile("csv");
		}

		private void buttonSaveHtml_Click(object sender, EventArgs e)
		{
			SaveToFile("html");
		}

		// enable the file save buttons once data has been displayed
		private void label1_TextChanged(object sender, EventArgs e)
		{
			buttonSaveCsv.Enabled = true;
			buttonSaveHtml.Enabled = true;
		}

		void buttonOverview_Click(object sender, EventArgs e)
		{
			if (currentView == ViewType.OVERVIEW)
				currentView = ViewType.NONE; //cause a clear and refill
			buttonOverview.Text = "Return to Overview Display";
			PopulateLV0();
		}
		void buttonClear_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show("Are you sure you want to clear all data?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				harvestStats.items.Clear();
				currentView = ViewType.NONE; //to clear the datatable
				PopulateLV0();
				listBox1.Items.Clear();
				listBox2.Items.Clear();
				currentView = ViewType.NONE; //PopulateLV0 changed it
				buttonOverview.Text = "Activate Overview Display";
			}
		}
		/// <summary>
		/// Overview list
		/// </summary>
		void PopulateLV0()
		{
			bool allDirty = false;
			bool needResize = false;
			if (currentView != ViewType.OVERVIEW)
			{
				currentView = ViewType.OVERVIEW;
				allDirty = true;
				needResize = true;
				listBox1.SelectedIndex = -1;
				listBox2.Items.Clear();

				dataGridView1.DataSource = null;
				dataSetHarvests.Tables["Overview"].Rows.Clear();
				dataGridView1.Columns.Clear();
				dataGridView1.DataSource = dataSetHarvests.Tables["Overview"];
				SetLvTooltips();
			}
			harvestStats.items.Sort();
			for (int i = 0; i < harvestStats.items.Count; i++)
			{
				NodeStats nsi = harvestStats.items[i];
				if (nsi.isDirty || allDirty)
				{
					nsi.isDirty = false;
					// add a leading space to the node type names so that the "All" row sorts to the bottom
					string sortName = nsi.name.Equals(allRowType) ? nsi.name : " " + nsi.name;
					DataRow row = dataSetHarvests.Tables["Overview"].Rows.Find(sortName);
					bool exists = true; //default value
					if (row == null)
					{
						row = dataSetHarvests.Tables["Overview"].NewRow();
						exists = false;
						needResize = true;
					}
					row["Type"] = sortName;
					row["# Attempts"] = nsi.TotalAttempts;
					row["% of Attempts"] = nsi.PercentAttempts;
					row["# Collects"] = nsi.TotalCollects;
					row["% of Collects"] = nsi.PercentCollects;
					row["# Items"] = nsi.TotalItems;
					row["% of Items"] = nsi.PercentItems;
					row["# Rares"] = nsi.TotalRares;
					row["% of Rares"] = nsi.PercentRares;
					row["# Bountiful"] = nsi.TotalBountiful;
					row["% of Bountifuls"] = nsi.PercentBountiful;
					row["# Bonus"] = nsi.TotalBonus;
					if (!exists)
						dataSetHarvests.Tables["Overview"].Rows.Add(row);

					if (nsi.name.Equals(allRowType))
					{
						// add the skills comparison line, excluding shadowed rares
						DataRow rowExShadowedRares = dataSetHarvests.Tables["Overview"].Rows.Find(nonShadowedRaresType);
						exists = true; //default value
						if (rowExShadowedRares == null)
						{
							rowExShadowedRares = dataSetHarvests.Tables["Overview"].NewRow();
							rowExShadowedRares["Type"] = nonShadowedRaresType;
							exists = false;
							needResize = true;
						}
						if(nsi.TotalAttempts - nsi.TotalShadowedAttempts > 0)
							rowExShadowedRares["% of Attempts"] = (float)(nsi.TotalRares - nsi.TotalShadowedItems) / (float)(nsi.TotalAttempts - nsi.TotalShadowedAttempts);
						if(nsi.TotalCollects - nsi.TotalShadowedCollects > 0)
							rowExShadowedRares["% of Collects"] = (float)(nsi.TotalRares - nsi.TotalShadowedItems) / (float)(nsi.TotalCollects - nsi.TotalShadowedCollects);
						if(nsi.TotalItems - nsi.TotalShadowedItems > 0)
							rowExShadowedRares["% of Items"] = (float)(nsi.TotalRares - nsi.TotalShadowedItems) / (float)(nsi.TotalItems - nsi.TotalShadowedItems);
						rowExShadowedRares["% of Bountifuls"] = (float)nsi.TotalBountiful / (float)nsi.TotalAttempts;
						if (!exists)
							dataSetHarvests.Tables["Overview"].Rows.Add(rowExShadowedRares);
					}
				}
			}
			if (needResize)
				ResizeLVCols();
			label1.Text = "Data Selected: Overview";
		}
		void SetLvTooltips()
		{
			if (currentView == ViewType.OVERVIEW || currentView == ViewType.NODE)
			{ 
				dataGridView1.Columns["# Attempts"].ToolTipText = "Count of harvest node clicks"; 
				dataGridView1.Columns["% of Attempts"].ToolTipText = "Ratio of this-node-attempts over all-node-attempts";
				dataGridView1.Columns["# Collects"].ToolTipText = "How many times a collection occurred. Affected by Bountiful Harvests.";
				dataGridView1.Columns["% of Collects"].ToolTipText = "Ratio of this-node-collects over all-node-collects";
				dataGridView1.Columns["# Items"].ToolTipText = "How many items were collected";
				dataGridView1.Columns["% of Items"].ToolTipText = "Ratio of this-node-items over all-node-items";
				dataGridView1.Columns["# Rares"].ToolTipText = "How many rare items were collected";
				dataGridView1.Columns["% of Rares"].ToolTipText = "Ratio of this-node-rare-items over all-node-rare-items";
				dataGridView1.Columns["# Bountiful"].ToolTipText = "How many attempts resulted in a bountiful harvest";
				dataGridView1.Columns["% of Bountifuls"].ToolTipText = "Ratio of this-node-bountiful over all-node-bountiful";
				dataGridView1.Columns["# Bonus"].ToolTipText = "How many times the harvest pony made a bonus collection";
			}
			if(currentView == ViewType.NODE)
			{
				dataGridView1.Columns["Avg Items/Collect"].ToolTipText = "Average number of items per collect";
			}

		}
		void listBox1_Click(object sender, EventArgs e)
		{
			if (currentView == ViewType.NODE)
				currentView = ViewType.NONE; //cause a clear and refill
			PopulateLV1();
		}
		/// <summary>
		/// By node
		/// </summary>
		private void PopulateLV1()
		{
			bool allDirty = false;
			bool needResize = false;
			if (currentView != ViewType.NODE)
			{
				currentView = ViewType.NODE;
				allDirty = true;
				needResize = true;
				dataGridView1.DataSource = null;
				dataSetHarvests.Tables["Node"].Rows.Clear();
				dataGridView1.Columns.Clear();
				dataGridView1.DataSource = dataSetHarvests.Tables["Node"];
				SetLvTooltips();
			}
			listBox2.Items.Clear();
			if (listBox1.SelectedIndex > -1)
			{
				NodeStats nS = (NodeStats)listBox1.Items[listBox1.SelectedIndex];
				for (int i = 0; i < nS.items.Count; i++)
				{
					listBox2.Items.Add(nS.items[i]);
				}

				nS.items.Sort();
				for (int i = 0; i < nS.items.Count; i++)
				{
					ItemStats iS = nS.items[i];

					if (iS.isDirty || allDirty)
					{
						iS.isDirty = false;
						// add a leading space to the node type names so that the "All" row sorts to the bottom
						string sortName = iS.name.Equals(allRowType) ? iS.name : " " + iS.name;
						DataRow row = dataSetHarvests.Tables["Node"].Rows.Find(sortName);
						bool exists = true;
						if (row == null)
						{
							row = dataSetHarvests.Tables["Node"].NewRow();
							exists = false;
							needResize = true;
						}
						row["Type"] = sortName;
						row["# Attempts"] = iS.TotalAttempts;
						row["% of Attempts"] = iS.PercentAttempts;
						row["# Collects"] = iS.TotalCollects;
						row["% of Collects"] = iS.PercentCollects;
						row["# Items"] = iS.TotalItems;
						row["% of Items"] = iS.PercentItems;
						row["Avg Items/Collect"] = iS.AvgItemsPerCollect;
						row["# Rares"] = iS.TotalRares;
						row["% of Rares"] = iS.PercentRares;
						row["# Bountiful"] = iS.TotalBountiful;
						row["% of Bountifuls"] = iS.PercentBountiful;
						row["# Bonus"] = iS.TotalBonus;
						if (!exists)
							dataSetHarvests.Tables["Node"].Rows.Add(row);

						if (iS.name.Equals(allRowType))
						{
							// add the skills comparison line, excluding shadowed rares
							DataRow rowExShadowedRares = dataSetHarvests.Tables["Node"].Rows.Find(nonShadowedRaresType);
							exists = true; //default value
							if (rowExShadowedRares == null)
							{
								rowExShadowedRares = dataSetHarvests.Tables["Node"].NewRow();
								rowExShadowedRares["Type"] = nonShadowedRaresType;
								exists = false;
								needResize = true;
							}
							if(iS.TotalAttempts - iS.TotalShadowedAttempts > 0)
								rowExShadowedRares["% of Attempts"] = (float)(iS.TotalRares - iS.TotalShadowedItems) / (float)(iS.TotalAttempts - iS.TotalShadowedAttempts);
							if(iS.TotalCollects - iS.TotalShadowedCollects > 0)
								rowExShadowedRares["% of Collects"] = (float)(iS.TotalRares - iS.TotalShadowedItems) / (float)(iS.TotalCollects - iS.TotalShadowedCollects);
							if(iS.TotalItems - iS.TotalShadowedItems > 0)
								rowExShadowedRares["% of Items"] = (float)(iS.TotalRares - iS.TotalShadowedItems) / (float)(iS.TotalItems - iS.TotalShadowedItems);
							rowExShadowedRares["% of Bountifuls"] = (float)iS.TotalBountiful / (float)iS.TotalAttempts;
							if (!exists)
								dataSetHarvests.Tables["Node"].Rows.Add(rowExShadowedRares);
						}
					}

				}
				if (needResize)
					ResizeLVCols();
				label1.Text = String.Format("Data Selected: {0}", nS.name);
			}
		}
		void listBox2_Click(object sender, EventArgs e)
		{
			if (currentView == ViewType.ITEM)
				currentView = ViewType.NONE; //cause a clear and refill
			PopulateLV2();
		}
		/// <summary>
		/// By item
		/// </summary>
		private void PopulateLV2()
		{
			bool allDirty = false;
			bool needResize = false;
			if (currentView != ViewType.ITEM)
			{
				currentView = ViewType.ITEM;
				allDirty = true;
				needResize = true;
				dataGridView1.DataSource = null;
				dataSetHarvests.Tables["Item"].Rows.Clear();
				dataGridView1.Columns.Clear();
				dataGridView1.DataSource = dataSetHarvests.Tables["Item"];
			}

			if (listBox2.SelectedIndex > -1 && listBox1.SelectedIndex > -1)
			{
				NodeStats nS = (NodeStats)listBox1.Items[listBox1.SelectedIndex];
				ItemStats iS = (ItemStats)listBox2.Items[listBox2.SelectedIndex];

				iS.items.Sort();
				for (int i = 0; i < iS.items.Count; i++)
				{
					HarvestData hD = iS.items[i];

					if (hD.isDirty || allDirty)
					{
						hD.isDirty = false;
						needResize = true;
						DataRow row = dataSetHarvests.Tables["Item"].NewRow();
						row["Time"] = hD.time;
						row["Action"] = hD.actionVerb;
						row["Amount"] = hD.amount;
						row["Item Name"] = hD.itemName;
						row["Node Name"] = hD.nodeType;
						row["Rare"] = hD.rare;
						row["Bountiful"] = hD.bountiful;
						row["Bonus"] = hD.bonus;
						dataSetHarvests.Tables["Item"].Rows.Add(row);
					}
				}
				if (needResize)
					ResizeLVCols();
				label1.Text = String.Format("Data Selected: {0} - {1}", iS.parent.name, iS.name);
			}
		}
		private void ResizeLVCols()
		{
			dataGridView1.AutoResizeColumns();
			if (dataGridView1.Columns.Count > 0)
			{
				dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
				dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; //col[0] left, all other cells are centered
			}
			dataGridView1.ClearSelection(); //1st row is selected/highlighted by default. it's distracting. clear it
		}

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			DataGridView dgv = sender as DataGridView;
			DataTable dataTable = dgv.DataSource as DataTable;

			if (e.Value != null)
			{
				if (!string.IsNullOrEmpty(e.Value.ToString()))
				{
					if (dataTable.Columns[e.ColumnIndex].ColumnName.Contains("%"))
						e.CellStyle.Format = "P2";
					else if (dataTable.Columns[e.ColumnIndex].ColumnName.Contains("#"))
						e.CellStyle.Format = "N0";
					else if (dataTable.Columns[e.ColumnIndex].ColumnName.Contains("Avg"))
						e.CellStyle.Format = "N2";
					else if (dataTable.Columns[e.ColumnIndex].ColumnName.Contains("Time"))
						e.CellStyle.Format = "G";
					else
						e.CellStyle.Format = string.Empty;
				}
			}

			// different background color for the summary rows
			if(dgv.Rows[e.RowIndex].Cells[0] != null)
			{
				string t = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
				int odd = e.RowIndex & 1;
				if (t.Equals(allRowType))
				{
					e.CellStyle.BackColor = System.Drawing.Color.LawnGreen;
					if(e.ColumnIndex == 0)
						dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Sum Totals";
				}
				else if (t.Equals(nonShadowedRaresType))
				{
					e.CellStyle.BackColor = System.Drawing.Color.LawnGreen;
					if (e.ColumnIndex == 0)
						dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Actual results for comparison to your Rare Harvest Chance and Bountiful Harvest skills.\nRare results exclude shadowed harvests since they are 100% rare.";
				}
				else if (odd > 0)
					e.CellStyle.BackColor = dgv.AlternatingRowsDefaultCellStyle.BackColor;
				else
					e.CellStyle.BackColor = dgv.DefaultCellStyle.BackColor;
			}
		}

		void StartPonyTimer()
		{
			if (!ponyTimer.Enabled)
			{
				// update every minute
				ponyTimer.SynchronizingObject = this;
				ponyTimer.Interval = 60000;
				ponyTimer.Elapsed += PonyTimer_Elapsed;
				ponyTimer.Enabled = true;
			}
		}

		private void PonyTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			UpdatePonyTable();
		}

		private void UpdatePonyTable()
		{
			StringBuilder sb = new StringBuilder();
			foreach (DataRow row in dataSetGatherers.Tables[tableHarvests].Rows)
			{
				// see if the pony is busy
				if (row[colPonyStarted] != DBNull.Value)
				{
					// see if the pony is ready
					if (DateTime.Now - (DateTime)row[colPonyStarted] >= ponyHarvestTime)
					{
						if (row[colTTS] == DBNull.Value)
							row[colTTS] = false;

						// if we are alerting, add to the alert
						if (true == (bool)row[colTTS])
						{
							if (sb.Length > 0)
								sb.Append(", ");
							sb.Append(row[colPlayer].ToString());
						}
						row[colPonyStarted] = DBNull.Value;
						row[colPonyWait] = DBNull.Value;
						row[colPonyState] = "Full";
					}
					else
					{
						// update the remaining time
						row[colPonyWait] = ponyHarvestTime - (DateTime.Now - (DateTime)row[colPonyStarted]);
					}
				}

				// see if the plant is busy
				if (row[colPlantStarted] != DBNull.Value)
				{
					// see if the plant is ready
					if (DateTime.Now - (DateTime)row[colPlantStarted] >= plantHarvestTime)
					{
						if(row[colTTS] == DBNull.Value)
							row[colTTS] = false;

						// if we are alerting, add to the alert
						if (true == (bool)row[colTTS])
						{
							if (!sb.ToString().Contains(row[colPlayer].ToString()))
							{
								if (sb.Length > 0)
									sb.Append(", ");
								sb.Append(row[colPlayer].ToString());
							}
						}
						row[colPlantStarted] = DBNull.Value;
						row[colPlantWait] = DBNull.Value;
						row[colPlantState] = "Full";
					}
					else
					{
						// update the remining time
						row[colPlantWait] = plantHarvestTime - (DateTime.Now - (DateTime)row[colPlantStarted]);
					}
				}
			}
			if (sb.Length > 0)
				ActGlobals.oFormActMain.TTS("harvest ready for " + sb.ToString());
		}

		void oFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
		{
			bool isRare;
			if (logInfo.detectedType == 0 && logInfo.logLine.Length > textIndex)
			{
				if (logInfo.logLine.EndsWith("You have found a rare item!"))
					rareNext = true;
				else if (logInfo.logLine.EndsWith("You make a bountiful harvest!"))
					bountifulHarvest = true;
				bool itemProcessed = false;
				//pre-qualify with a simple search, faster than the regex
				bool containsItem = logInfo.logLine.Contains("\\aITEM");
				if (containsItem)
				{
					Match regLineMatch = regHarvestAction.Match(logInfo.logLine, textIndex);
					if (regLineMatch.Success)
					{
						itemProcessed = true;
						// The bountiful event is always the first log line of a harvest when it occurs.
						// If the harvest is bountiful, there can be 2 harvest events.
						// Both harvest events will have a common harvest (quantity > 1) and a rare quantity of 1.
						// The rare flag should be set on a quantity of 1 harvest.
						// The bountiful flag should be set for the first common harvest if the bountiful line was passed.
						// Example log lines: 
						//      You make a bountiful harvest!
						//      You have found a rare item!
						//      You acquire 1 \aITEM -985993535 1058133322:Jumping Creeper\/a from the crawling root break.
						//      You acquire 2 \aITEM -521413787 -1637582842:Slow Creeping Root\/a from the crawling root break.
						//      You acquire 2 \aITEM -521413787 -1637582842:Slow Creeping Root\/a from the crawling root break.
						int qty;
						if (int.TryParse(regLineMatch.Groups["number"].Value, out qty))
						{
							isRare = false;
							if (qty == 1 && rareNext)
							{
								isRare = true;
								if(regLineMatch.Groups["itemName"].Value.Contains("Shadow"))
								{
									// Shadow harvesting is always rare and does not generate the "bountiful harvest" message,
									// but it does use the bountiful harvest skill to acquire bountiful harvests.
									// Estimate the application of the bountiful harvest skill by using the timing.
									// (For live harvesting, this works pretty well since the bountiful item
									// will arrive in less than .75 seconds (neglecting lag), which is faster than you can harvest.
									// For imports it will be less accurate since the log time resolution is 1 second
									// and it is possible to manually harvest twice in the same second.)
									if ((isImport ? logInfo.detectedTime : DateTime.Now) - lastHarvestTime < sameHarvestAttemptMax)
										bountifulHarvest = true;
								}
							}
							lastHarvestTime = isImport ? logInfo.detectedTime : DateTime.Now;
							harvestStats.AddHarvest(new HarvestData(lastHarvestTime,
								regLineMatch.Groups["action"].Value, qty,
								regLineMatch.Groups["itemName"].Value, 
								regLineMatch.Groups["nodeType"].Value, isRare, bountifulHarvest, false));
							if (isRare)
								rareNext = false;
							bountifulHarvest = false;
							mUiContext.Post(UiPopulateLBs, null);
						}
					}
					else
					{
						// The pack pony will collect items in the following forms:
						//  ------qty == 1------------------
						//  You receive \aITEM 1406269934 -1503006936:Primal Luclizite Shard\/a.
						//  Your Pack Pony has found a bonus harvest from coalesced stone cluster
						//  ------qty > 1---------------------
						//  You receive 2 \aITEM -521413787 -1637582842:Slow Creeping Roots\/a.
						//  Your Pack Pony has found a bonus harvest from crawling root break
						//  ------got a rare------------------
						//  You receive 10 \aITEM 1826074139 - 164484783:severed sandalwoods\/ a.
						//  You receive \aITEM - 1413123717 902624791:severed ironwood\/ a.
						//  Your Pack Pony has found a bonus harvest from felled pine
						//  ------------------------
						// Save up to 2 matching "receive" items in case of a following "found a bonus" line
						Match regBonusHarvestMatch = regBonusHarvestReceive.Match(logInfo.logLine, textIndex);
						if (regBonusHarvestMatch.Success)
						{
							itemProcessed = true;
							// save item that might be pony find
							int qty;
							if (!int.TryParse(regBonusHarvestMatch.Groups["number"].Value, out qty))
							{
								// number is missing in logLine when the quantity is 1
								qty = 1;
							}
							HarvestData hd = new HarvestData(isImport ? logInfo.detectedTime : DateTime.Now,
								regBonusHarvestMatch.Groups["action"].Value, qty,
								regBonusHarvestMatch.Groups["itemName"].Value, "", false, false, true);
							bonusQueue.Enqueue(hd);
							//never need to save more than 2
							while (bonusQueue.Count > 2)
								bonusQueue.Dequeue(); //remove the oldest
						}
					}
				}
				if (!itemProcessed)
				{
					//use a simple faster search before trying to parse it
					if (logInfo.logLine.Contains("found a bonus harvest"))
					{
						Match regBonusActionMatch = regBonusHarvestAction.Match(logInfo.logLine, textIndex);
						if (regBonusActionMatch.Success)
						{
							// Pony found a bonus.
							// Pop "receive" items off the stack and if they occurred at the
							// same time as the "found a bonus" line, add the harvest.
							// (Note that this has a small chance at adding something inappropriate
							// since it depends on timing, not what the "receive" item actually is.)
							while(bonusQueue.Count > 0)
							{
								HarvestData hd = bonusQueue.Dequeue();
								DateTime bonusTime = isImport ? logInfo.detectedTime : DateTime.Now;
								if (bonusTime - hd.time < sameHarvestAttemptMax)
								{
									hd.nodeType = regBonusActionMatch.Groups["nodeType"].Value;
									harvestStats.AddHarvest(hd);
								}
							}
							mUiContext.Post(UiPopulateLBs, null);
						}
					}
					else if(checkBoxPony.Checked)
					{
						// harvest pony & plant tracker
						if (logInfo.logLine.Substring(textIndex).Equals(ponyPulled))
							mUiContext.Post(UiPonyEmpty, null);
						else if (logInfo.logLine.Substring(textIndex).Equals(plantPulled))
						{
							Gatherer g = new Gatherer { 
								TTS = false, 
								player = ActGlobals.charName, 
								plantStarted = logInfo.detectedTime, 
								plantState = "Harvesting"
							};
							mUiContext.Post(UiStartPlant, g);
						}
						else
						{
							Match pony = regPonyStartArea.Match(logInfo.logLine, textIndex);
							if (!pony.Success)
								pony = regPonyStartLevel.Match(logInfo.logLine, textIndex);
							if (!pony.Success)
								pony = regPonyStartHoliday.Match(logInfo.logLine, textIndex);
							if (pony.Success)
							{
								Gatherer g = new Gatherer { 
									TTS = false, 
									player = ActGlobals.charName, 
									ponyStarted = logInfo.detectedTime, 
									ponyArea = pony.Groups["area"].Value, 
									ponyState = "Harvesting"
								};
								mUiContext.Post(UiStartPony, g);
							}
						}
					}
				}
			}
		}

		void UiPonyEmpty(object o)
		{
			DataRow found = dataSetGatherers.Tables[tableHarvests].Rows.Find(ActGlobals.charName);
			if (found != null)
			{
				found[colPonyState] = "Idle";
				found[colPonyStarted] = DBNull.Value;
				found[colPonyHarvest] = DBNull.Value;
				found[colPonyWait] = DBNull.Value;
			}
		}

		void UiStartPlant(object o)
		{
			Gatherer g = o as Gatherer;
			if(g != null)
			{
				StartPonyTimer();
				DataRow found = dataSetGatherers.Tables[tableHarvests].Rows.Find(g.player);
				if (found == null)
				{
					// need a new row
					DataRow row = dataSetGatherers.Tables[tableHarvests].NewRow();
					row[colTTS] = g.TTS;
					row[colPlayer] = g.player;
					row[colPlantStarted] = g.plantStarted;
					row[colPlantState] = g.plantState;
					row[colPlantWait] = DBNull.Value;
					dataSetGatherers.Tables[tableHarvests].Rows.Add(row);
				}
				else
				{
					// update the existing row
					found[colPlantStarted] = g.plantStarted;
					found[colPlantState] = g.plantState;
				}
			}
		}

		void UiStartPony(object o)
		{
			Gatherer g = o as Gatherer;
			if(g != null)
			{
				StartPonyTimer();
				DataRow found = dataSetGatherers.Tables[tableHarvests].Rows.Find(g.player);
				if (found == null)
				{
					// need a new row
					DataRow row = dataSetGatherers.Tables[tableHarvests].NewRow();
					row[colTTS] = g.TTS;
					row[colPlayer] = g.player;
					row[colPonyStarted] = g.ponyStarted;
					row[colPonyHarvest] = g.ponyArea;
					row[colPonyState] = g.ponyState;
					row[colPonyWait] = DBNull.Value;
					dataSetGatherers.Tables[tableHarvests].Rows.Add(row);
				}
				else
				{
					// update the existing row
					found[colPonyStarted] = g.ponyStarted;
					found[colPonyHarvest] = g.ponyArea;
					found[colPonyState] = g.ponyState;
				}
			}
		}

		private void checkBoxPony_CheckedChanged(object sender, EventArgs e)
		{
			if(checkBoxPony.Checked)
			{
				// "open" and show the pony/plant datagridview
				dataGridViewPony.Visible = true;
				if (dataSetGatherers.Tables[tableSettings].Rows.Count > 0 && !isFirstShow)
				{
					// set the splitter location
					if (dataSetGatherers.Tables[tableSettings].Rows[0][colSplitY] != DBNull.Value)
						splitContainer1.SplitterDistance = (int)dataSetGatherers.Tables[tableSettings].Rows[0][colSplitY];
					else
						splitContainer1.SplitterDistance = (splitContainer1.Height * 4) / 5; // default to 20% pane size
				}
			}
			else if(!isFirstShow)
			{
				// hide the pony/plant datagridview
				splitContainer1.SplitterDistance = splitContainer1.Height - checkBoxPony.Height;
				dataGridViewPony.Visible = false;
			}
		}

		// on the UI thread
		void UiPopulateLBs(object o)
		{
			int itemCount = harvestStats.items.Count;

			for (int i = 0; i < itemCount; i++)
			{
				if (!listBox1.Items.Contains(harvestStats.items[i]))
					listBox1.Items.Add(harvestStats.items[i]);
			}
			if (listBox1.SelectedIndex > -1)
			{
				NodeStats ns = (NodeStats)listBox1.Items[listBox1.SelectedIndex];
				for (int i = 0; i < ns.items.Count; i++)
				{
					if (!listBox2.Items.Contains(ns.items[i]))
						listBox2.Items.Add(ns.items[i]);
				}
			}

			switch (currentView)
			{
				case ViewType.OVERVIEW:
					PopulateLV0();
					break;
				case ViewType.NODE:
					PopulateLV1();
					break;
				case ViewType.ITEM:
					PopulateLV2();
					break;
			}
		}
		private class HarvestData : IComparable<HarvestData>
		{
			public DateTime time;
			public string actionVerb;
			public int amount;
			public string itemName;
			public string nodeType;
			public bool rare;
			public bool bountiful;
			public bool bonus;
			public bool isDirty;
			public HarvestData(DateTime Time, string ActionVerb, int Amount, string ItemName, string NodeType, bool Rare, bool Bountiful, bool Bonus)
			{
				this.time = Time;
				this.actionVerb = ActionVerb;
				this.amount = Amount;
				this.itemName = ItemName;
				this.nodeType = NodeType;
				this.rare = Rare;
				this.bountiful = Bountiful;
				this.bonus = Bonus;
				isDirty = true;
			}

			public override string ToString()
			{
				return string.Format("{0} ({1})",itemName, amount);
			}

			#region IComparable<HarvestData> Members

			public int CompareTo(HarvestData other)
			{
				return this.time.CompareTo(other.time);
			}

			#endregion
		}
		private class ItemStats : IEquatable<ItemStats>, IComparable<ItemStats>
		{
			public string name;
			public bool isDirty;
			public NodeStats parent;
			public List<HarvestData> items = new List<HarvestData>();

			public ItemStats(string Name, NodeStats Parent)
			{
				name = Name;
				parent = Parent;
			}
			public void AddHarvest(HarvestData item)
			{
				items.Add(item);

				int listLength = items.Count;

				// "Shadow" instead of "Shadowed" to get the "Shadow Balanzite Crystal"
				bool isShadowed = item.itemName.Contains("Shadow") && item.rare;

				if (!item.bonus)
				{
					// The best approach to determining a "clicked on the node" count
					// seems to be to use the time between receiving items.
					// If this item comes in sooner than the fastest casting time of the
					// harvest skill, it is not a separate click, it is likely a
					// bountiful or rare obtained on a previous click.
					// If the time between this item and the previous item
					// is more that the fastest harvest casting time, it is likely a new
					// click on a node and thus a new attempt.
					// (This works better on live harvesting since the time resolution is better
					// than the fastest harvest cast time of 0.75 seconds. But it's
					// still reasonably accurate for imports.)
					if (listLength == 1)
					{
						// can't measure time difference if we only have one item
						TotalAttempts = 1;
						TotalShadowedAttempts = isShadowed ? 1 : 0;
					}
					else if (items[listLength - 1].time - items[listLength - 2].time >= Harvest_Plugin.sameHarvestAttemptMax)
					{
						TotalAttempts++;
						TotalShadowedAttempts += isShadowed ? 1 : 0;
					}
				}

				TotalItems += item.amount;
				TotalRares += item.rare ? 1 : 0;
				TotalBountiful += item.bountiful ? 1 : 0;
				TotalBonus += item.bonus ? 1 : 0;
				if (isShadowed)
				{
					TotalShadowedItems += item.amount;
					TotalShadowedCollects++;
				}
				isDirty = true;
			}
			public int TotalAttempts { get; private set; }
			public int TotalCollects
			{
				get
				{
					return items.Count;
				}
			}
			public int TotalItems { get; private set; }
			public int TotalRares { get; private set; }
			public int TotalBountiful { get; private set; }
			public int TotalBonus { get; private set; }
			public int TotalShadowedItems { get; private set; }
			public int TotalShadowedAttempts { get; protected set; }
			public int TotalShadowedCollects { get; protected set; }
			public float AvgItemsPerCollect
			{
				get
				{
					return (TotalCollects == 0) ? 0 : (float)TotalItems / (float)TotalCollects;
				}
			}
			public float PercentAttempts
			{
				get
				{
					return ((parent.TotalAttempts == 0) ? 0 : (float)TotalAttempts / (float)parent.TotalAttempts);
				}
			}
			public float PercentCollects
			{
				get
				{
					return ((parent.TotalCollects == 0) ? 0 : (float)TotalCollects / (float)parent.TotalCollects);
				}
			}
			public float PercentItems
			{
				get
				{
					return ((parent.TotalItems == 0) ? 0 : (float)TotalItems / (float)parent.TotalItems);
				}
			}
			public float PercentRares
			{
				get
				{
					return ((parent.TotalRares == 0) ? 0 : (float)TotalRares / (float)parent.TotalRares);
				}
			}
			public float PercentBountiful
			{
				get
				{
					return ((parent.TotalBountiful == 0) ? 0 : (float)TotalBountiful / (float)parent.TotalBountiful);
				}
			}
			public override string ToString()
			{
				return name;
			}
			#region IEquatable<ItemStats> Members
			public bool Equals(ItemStats other)
			{
				return this.name.Equals(other.name);
			}
			#endregion
			#region IComparable<ItemStats> Members
			public int CompareTo(ItemStats other)
			{
				return this.name.CompareTo(other.name);
			}
			#endregion
		}
		private class NodeStats : IEquatable<NodeStats>, IComparable<NodeStats>
		{
			public string name;
			public bool isDirty;
			public HarvestStats parent;
			public List<ItemStats> items = new List<ItemStats>();
			public NodeStats(string Name, HarvestStats Parent)
			{
				name = Name;
				parent = Parent;
			}
			public void AddHarvest(HarvestData item)
			{
				ItemStats all = new ItemStats(allRowType, this);
				int index = items.IndexOf(all);
				if (index > -1)
					all = items[index];
				else
					items.Add(all);
				ItemStats unique = new ItemStats(item.itemName, this);
				index = items.IndexOf(unique);
				if (index > -1)
					unique = items[index];
				else
					items.Add(unique);

				all.AddHarvest(item);
				unique.AddHarvest(item);
				isDirty = true;
			}
			public int TotalAttempts
			{
				get
				{
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].name == allRowType)
						{
							return items[i].TotalAttempts;
						}
					}
					return 0;
				}
			}
			public int TotalCollects
			{
				get
				{
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].name == allRowType)
						{
							return items[i].TotalCollects;
						}
					}
					return 0;
				}
			}
			public int TotalItems
			{
				get
				{
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].name == allRowType)
						{
							return items[i].TotalItems;
						}
					}
					return 0;
				}
			}
			public int TotalRares
			{
				get
				{
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].name == allRowType)
						{
							return items[i].TotalRares;
						}
					}
					return 0;
				}
			}
			public int TotalBountiful
			{
				get
				{
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].name == allRowType)
						{
							return items[i].TotalBountiful;
						}
					}
					return 0;
				}
			}
			public int TotalBonus
			{
				get
				{
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].name == allRowType)
						{
							return items[i].TotalBonus;
						}
					}
					return 0;
				}
			}
			public int TotalShadowedAttempts
			{
				get
				{
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].name == allRowType)
						{
							return items[i].TotalShadowedAttempts;
						}
					}
					return 0;
				}
			}
			public int TotalShadowedItems
			{
				get
				{
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].name == allRowType)
						{
							return items[i].TotalShadowedItems;
						}
					}
					return 0;
				}
			}
			public int TotalShadowedCollects
			{
				get
				{
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].name == allRowType)
						{
							return items[i].TotalShadowedCollects;
						}
					}
					return 0;
				}
			}
			public float PercentAttempts
			{
				get
				{
					return ((parent.TotalAttempts == 0) ? 0 : (float)TotalAttempts / (float)parent.TotalAttempts);
				}
			}
			public float PercentCollects
			{
				get
				{
					return ((parent.TotalCollects == 0) ? 0 : (float)TotalCollects / (float)parent.TotalCollects);
				}
			}
			public float PercentItems
			{
				get
				{
					return ((parent.TotalItems == 0) ? 0 : (float)TotalItems / (float)parent.TotalItems);
				}
			}
			public float PercentRares
			{
				get
				{
					return ((parent.TotalRares == 0) ? 0 : (float)TotalRares / (float)parent.TotalRares);
				}
			}
			public float PercentBountiful
			{
				get
				{
					return ((parent.TotalBountiful == 0) ? 0 : (float)TotalBountiful / (float)parent.TotalBountiful);
				}
			}
			public override string ToString()
			{
				return name;
			}

			#region IEquatable<NodeStats> Members
			public bool Equals(NodeStats other)
			{
				return this.name.Equals(other.name);
			}
			#endregion
			#region IComparable<NodeStats> Members
			public int CompareTo(NodeStats other)
			{
				return this.name.CompareTo(other.name);
			}
			#endregion
		}
		private class HarvestStats
		{
			public List<NodeStats> items = new List<NodeStats>();

			public void AddHarvest(HarvestData item)
			{
				NodeStats all = new NodeStats(allRowType, this);
				int index = items.IndexOf(all);
				if (index > -1)
					all = items[index];
				else
					items.Add(all);
				NodeStats uniqueAction = new NodeStats(item.actionVerb, this);
				index = items.IndexOf(uniqueAction);
				if (index > -1)
					uniqueAction = items[index];
				else
					items.Add(uniqueAction);
				NodeStats uniqueNode = new NodeStats(item.nodeType, this);
				index = items.IndexOf(uniqueNode);
				if (index > -1)
					uniqueNode = items[index];
				else
					items.Add(uniqueNode);

				all.AddHarvest(item);
				uniqueAction.AddHarvest(item);
				uniqueNode.AddHarvest(item);
			}
			public int TotalAttempts
			{
				get
				{
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].name == allRowType)
						{
							return items[i].TotalAttempts;
						}
					}
					return 0;
				}
			}
			public int TotalCollects
			{
				get
				{
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].name == allRowType)
						{
							return items[i].TotalCollects;
						}
					}
					return 0;
				}
			}
			public int TotalItems
			{
				get
				{
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].name == allRowType)
						{
							return items[i].TotalItems;
						}
					}
					return 0;
				}
			}
			public int TotalRares
			{
				get
				{
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].name == allRowType)
						{
							return items[i].TotalRares;
						}
					}
					return 0;
				}
			}
			public int TotalBountiful
			{
				get
				{
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].name == allRowType)
						{
							return items[i].TotalBountiful;
						}
					}
					return 0;
				}
			}
			public int TotalBonus
			{
				get
				{
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].name == allRowType)
						{
							return items[i].TotalBonus;
						}
					}
					return 0;
				}
			}
		}

		// used to pass pony/plant data from the logline thread to the UI thread
		private class Gatherer
		{
			public bool TTS;
			public string player;
			public DateTime ponyStarted;
			public string ponyArea;
			public string ponyState;
			public DateTime plantStarted;
			public string plantState;
		}
	}
}
