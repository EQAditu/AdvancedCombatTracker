using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

[assembly: AssemblyTitle("Harvest Tracking")]
[assembly: AssemblyDescription("Parses and totals harvests")]
[assembly: AssemblyVersion("1.2.1.3")]

namespace Some_ACT_Plugin
{
	public class Harvest_Plugin : UserControl, IActPluginV1
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private GroupBox groupBox1;
		private ListBox listBox1;
		private TableLayoutPanel tableLayoutPanel1;
		private GroupBox groupBox2;
		private ListBox listBox2;
		private ListView listView1;
		private Label label1;
		private Panel panel1;
		private Button button1;
		private Button button2;
		private ContextMenuStrip menu1;
		private ToolStripMenuItem menuItemCsv;
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.listView1 = new System.Windows.Forms.ListView();
			this.menu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemCsv = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemHtml = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.menu1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.listBox1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 67);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
			this.groupBox1.Size = new System.Drawing.Size(194, 269);
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
			this.listBox1.Size = new System.Drawing.Size(182, 244);
			this.listBox1.Sorted = true;
			this.listBox1.TabIndex = 1;
			this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.button2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
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
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button1.Location = new System.Drawing.Point(3, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(194, 26);
			this.button1.TabIndex = 0;
			this.button1.Text = "Return to Overview Display";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button2.Location = new System.Drawing.Point(3, 35);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(194, 26);
			this.button2.TabIndex = 1;
			this.button2.Text = "Reset/Clear Data";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.listBox2);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(3, 342);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
			this.groupBox2.Size = new System.Drawing.Size(194, 270);
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
			this.listBox2.Size = new System.Drawing.Size(182, 245);
			this.listBox2.Sorted = true;
			this.listBox2.TabIndex = 2;
			this.listBox2.Click += new System.EventHandler(this.listBox2_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.listView1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(203, 3);
			this.panel1.Name = "panel1";
			this.tableLayoutPanel1.SetRowSpan(this.panel1, 4);
			this.panel1.Size = new System.Drawing.Size(951, 609);
			this.panel1.TabIndex = 4;
			// 
			// listView1
			// 
			this.listView1.ContextMenuStrip = this.menu1;
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.Location = new System.Drawing.Point(0, 18);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(951, 591);
			this.listView1.TabIndex = 3;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// menu1
			// 
			this.menu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.menuItemCsv,
			this.menuItemHtml});
			this.menu1.Name = "menu1";
			this.menu1.Size = new System.Drawing.Size(153, 48);
			// 
			// menuItemCsv
			// 
			this.menuItemCsv.Name = "menuItemCsv";
			this.menuItemCsv.Size = new System.Drawing.Size(152, 22);
			this.menuItemCsv.Text = "Copy as CSV";
			this.menuItemCsv.Click += new System.EventHandler(this.menuItemCsv_Click);
			// 
			// menuItemHtml
			// 
			this.menuItemHtml.Name = "menuItemHtml";
			this.menuItemHtml.Size = new System.Drawing.Size(152, 22);
			this.menuItemHtml.Text = "Copy as HTML";
			this.menuItemHtml.Click += new System.EventHandler(this.menuItemHtml_Click);
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
			this.menu1.ResumeLayout(false);
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
		Regex regHarvestAction = new Regex(@"\(\d{10}\)\[.{24}\] You (?<action>[^ ]+) (?<number>\d+) \\aITEM -?\d+ -?\d+:(?<itemName>[^\\]+)\\/a from the (?<nodeType>[^\.]+)\.", RegexOptions.Compiled);
		Regex regBonusHarvestAction = new Regex(@"\(\d{10}\)\[.{24}\] Your (?<actor>.*) has found a bonus harvest from (?<nodeType>[^\.]+)", RegexOptions.Compiled);
		Regex regBonusHarvestReceive = new Regex(@"\(\d{10}\)\[.{24}\] You (?<action>[^ ]+) (?<number>\d+) \\aITEM -?\d+ -?\d+:(?<itemName>[^\\]+)\\/a\.", RegexOptions.Compiled);
		HarvestStats harvestStats = new HarvestStats();
		HarvestData bonusHarvestData = null;

		#region IActPluginV1 Members
		public void DeInitPlugin()
		{
			ActGlobals.oFormActMain.OnLogLineRead -= oFormActMain_OnLogLineRead;
			lblStatus.Text = "Plugin exited";
		}

		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			lblStatus = pluginStatusText;
			pluginScreenSpace.Controls.Add(this);
			this.Dock = DockStyle.Fill;
			lblStatus.Text = "Plugin started";
			ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(oFormActMain_OnLogLineRead);
		}
		#endregion
		void menuItemCsv_Click(object sender, EventArgs e)
		{
			if (listView1.Columns.Count == 0)
				return;
			StringBuilder table = new StringBuilder();
			StringBuilder row = new StringBuilder();
			for (int i = 0; i < listView1.Columns.Count; i++)
			{
				row.AppendFormat("{0},", listView1.Columns[i].Text);
			}
			table.AppendFormat("{0}\n", row.ToString(0, row.Length - 1));

			foreach (ListViewItem lvi in listView1.Items)
			{
				row = new StringBuilder();
				for (int i = 0; i < listView1.Columns.Count; i++)
				{
					row.AppendFormat("{0},", lvi.SubItems[i].Text);
				}
				table.AppendFormat("{0}\n", row.ToString(0, row.Length - 1));
			}
			ActGlobals.oFormActMain.SendToClipboard(table.ToString(), true);
		}
		void menuItemHtml_Click(object sender, EventArgs e)
		{
			if (listView1.Columns.Count == 0)
				return;
			StringBuilder table = new StringBuilder();
			table.Append("<table>\n");
			StringBuilder row = new StringBuilder("<tr>");
			for (int i = 0; i < listView1.Columns.Count; i++)
			{
				row.AppendFormat("<th>{0}</th>", listView1.Columns[i].Text);
			}
			table.AppendFormat("{0}</tr>\n", row.ToString());

			foreach (ListViewItem lvi in listView1.Items)
			{
				row = new StringBuilder("<tr>");
				for (int i = 0; i < listView1.Columns.Count; i++)
				{
					row.AppendFormat("<td>{0}</td>", lvi.SubItems[i].Text);
				}
				table.AppendFormat("{0}</tr>\n", row.ToString());
			}
			table.Append("</table>\n");
			ActGlobals.oFormActMain.SendHtmlToClipboard(table.ToString());
		}
		void button1_Click(object sender, EventArgs e)
		{
			listView1.BeginUpdate();
			PopulateLV0();
			listView1.EndUpdate();
		}
		void button2_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show("Are you sure you want to reset?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				listView1.BeginUpdate();
				harvestStats.items.Clear();
				PopulateLV0();
				listBox1.Items.Clear();
				listBox2.Items.Clear();
				listView1.EndUpdate();
			}
		}
		void PopulateLV0()
		{
			listBox1.SelectedIndex = -1;
			listBox2.Items.Clear();
			listView1.Columns.Clear();
			listView1.Items.Clear();
			listView1.Columns.Add("Type");
			listView1.Columns.Add("# Attempts");
			listView1.Columns.Add("% Attempts");
			listView1.Columns.Add("# Collects");
			listView1.Columns.Add("% Collects");
			listView1.Columns.Add("# Items");
			listView1.Columns.Add("% Items");
			listView1.Columns.Add("# Rares");
			listView1.Columns.Add("% Rares");
			listView1.Columns.Add("# Bountiful");
			listView1.Columns.Add("% Bountiful");
			listView1.Columns.Add("# Bonus");
			harvestStats.items.Sort();
			for (int i = 0; i < harvestStats.items.Count; i++)
			{
				NodeStats nsi = harvestStats.items[i];
				ListViewItem lvi = new ListViewItem(nsi.name);
				lvi.SubItems.Add(nsi.TotalAttempts.ToString());
				lvi.SubItems.Add(String.Format("{0:0.00}%", nsi.PercentAttempts));
				lvi.SubItems.Add(nsi.TotalCollects.ToString());
				lvi.SubItems.Add(String.Format("{0:0.00}%", nsi.PercentCollects));
				lvi.SubItems.Add(nsi.TotalItems.ToString());
				lvi.SubItems.Add(String.Format("{0:0.00}%", nsi.PercentItems));
				lvi.SubItems.Add(nsi.TotalRares.ToString());
				lvi.SubItems.Add(String.Format("{0:0.00}%", nsi.PercentRares));
				lvi.SubItems.Add(nsi.TotalBountiful.ToString());
				lvi.SubItems.Add(String.Format("{0:0.00}%", nsi.PercentBountiful));
				lvi.SubItems.Add(String.Format("{0:0.00}%", nsi.TotalBonus));
				listView1.Items.Add(lvi);
			}
			ResizeLVCols();
			label1.Text = "Data Selected: Overview";
		}
		void listBox1_Click(object sender, EventArgs e)
		{
			listView1.BeginUpdate();
			PopulateLV1();
			listView1.EndUpdate();
		}
		private void PopulateLV1()
		{
			listBox2.Items.Clear();
			listView1.Columns.Clear();
			listView1.Items.Clear();
			if (listBox1.SelectedIndex > -1)
			{
				NodeStats nS = null;
				for (int i = 0; i < listBox1.Items.Count; i++)
				{
					if (harvestStats.items[i].name == (string)listBox1.Items[listBox1.SelectedIndex])
						nS = harvestStats.items[i];
				}
				for (int i = 0; i < nS.items.Count; i++)
				{
					listBox2.Items.Add(nS.items[i].name);
				}

				listView1.Columns.Clear();
				listView1.Items.Clear();
				listView1.Columns.Add("Type");
				listView1.Columns.Add("# Attempts");
				listView1.Columns.Add("% Attempts");
				listView1.Columns.Add("# Collects");
				listView1.Columns.Add("% Collects");
				listView1.Columns.Add("# Items");
				listView1.Columns.Add("% Items");
				listView1.Columns.Add("Avg Items/Collect");
				listView1.Columns.Add("# Rares");
				listView1.Columns.Add("% Rares");
				listView1.Columns.Add("# Bountiful");
				listView1.Columns.Add("% Bountiful");
				listView1.Columns.Add("# Bonus");
				nS.items.Sort();
				for (int i = 0; i < nS.items.Count; i++)
				{
					ItemStats iS = nS.items[i];
					ListViewItem lvi = new ListViewItem(iS.name);
					lvi.SubItems.Add(iS.TotalAttempts.ToString());
					lvi.SubItems.Add(String.Format("{0:0.00}%", iS.PercentAttempts));
					lvi.SubItems.Add(iS.TotalCollects.ToString());
					lvi.SubItems.Add(String.Format("{0:0.00}%", iS.PercentCollects));
					lvi.SubItems.Add(iS.TotalItems.ToString());
					lvi.SubItems.Add(String.Format("{0:0.00}%", iS.PercentItems));
					lvi.SubItems.Add(String.Format("{0:0.00}", iS.AvgItemsPerCollect));
					lvi.SubItems.Add(iS.TotalRares.ToString());
					lvi.SubItems.Add(String.Format("{0:0.00}%", iS.PercentRares));
					lvi.SubItems.Add(iS.TotalBountiful.ToString());
					lvi.SubItems.Add(String.Format("{0:0.00}%", iS.PercentBountiful));
					lvi.SubItems.Add(iS.TotalBonus.ToString());
					listView1.Items.Add(lvi);
				}
				ResizeLVCols();
				label1.Text = String.Format("Data Selected: {0}", nS.name);
			}
		}
		void listBox2_Click(object sender, EventArgs e)
		{
			listView1.BeginUpdate();
			PopulateLV2();
			listView1.EndUpdate();
		}
		private void PopulateLV2()
		{
			listView1.Columns.Clear();
			listView1.Items.Clear();
			if (listBox2.SelectedIndex > -1)
			{
				NodeStats nS = null;
				for (int i = 0; i < listBox1.Items.Count; i++)
				{
					if (harvestStats.items[i].name == (string)listBox1.Items[listBox1.SelectedIndex])
						nS = harvestStats.items[i];
				}
				ItemStats iS = null;
				for (int i = 0; i < listBox2.Items.Count; i++)
				{
					if (nS.items[i].name == (string)listBox2.Items[listBox2.SelectedIndex])
						iS = nS.items[i];
				}

				listView1.Columns.Clear();
				listView1.Items.Clear();
				listView1.Columns.Add("Time");
				listView1.Columns.Add("Action");
				listView1.Columns.Add("Amount");
				listView1.Columns.Add("Item Name");
				listView1.Columns.Add("Node Name");
				listView1.Columns.Add("Rare");
				listView1.Columns.Add("Bountiful");
				iS.items.Sort();
				for (int i = 0; i < iS.items.Count; i++)
				{
					HarvestData hD = iS.items[i];
					ListViewItem lvi = new ListViewItem(hD.time.ToLongTimeString());
					lvi.SubItems.Add(hD.actionVerb);
					lvi.SubItems.Add(hD.amount.ToString());
					lvi.SubItems.Add(hD.itemName);
					lvi.SubItems.Add(hD.nodeType);
					lvi.SubItems.Add(hD.rare.ToString());
					lvi.SubItems.Add(hD.bountiful.ToString());
					listView1.Items.Add(lvi);
				}
				ResizeLVCols();
				label1.Text = String.Format("Data Selected: {0} - {1}", iS.parent.name, iS.name);
			}
		}
		private void ResizeLVCols()
		{
			try
			{
				int totalChrs = 0;
				int[] chrNums = new int[listView1.Columns.Count];
				int[] chrMax = new int[listView1.Columns.Count];

				if (listView1.Items.Count == 0)
				{
					for (int i = 0; i < listView1.Columns.Count; i++)
					{
						chrNums[i] += 10;
						totalChrs += 10;
					}
				}
				else
				{
					for (int j = 0; j < listView1.Items.Count; j++)
					{
						ListViewItem lvi = listView1.Items[j];
						for (int i = 0; i < listView1.Columns.Count; i++)
						{
							if (chrMax[i] < lvi.SubItems[i].Text.Length)
								chrMax[i] = lvi.SubItems[i].Text.Length;
							int total = lvi.SubItems[i].Text.Length + (listView1.Columns[i].Text.Length);
							chrNums[i] += total;
							totalChrs += total;
						}
					}
					for (int i = 0; i < listView1.Columns.Count; i++)
					{
						chrNums[i] += chrMax[i] * listView1.Items.Count;
						totalChrs += chrMax[i] * listView1.Items.Count;
					}
				}
				for (int i = 0; i < listView1.Columns.Count; i++)
				{
					ColumnHeader cH = listView1.Columns[i];
					cH.Width = Convert.ToInt32((listView1.Width - 24) * ((float)chrNums[i] / totalChrs));
				}
			}
			catch { }
		}
		void oFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
		{
			bool isRare;
			if (logInfo.detectedType == 0)
			{
				if (logInfo.logLine.EndsWith("You have found a rare item!"))
					rareNext = true;
				if (logInfo.logLine.EndsWith("You make a bountiful harvest!"))
					bountifulHarvest = true;
				Match regLineMatch = regHarvestAction.Match(logInfo.logLine);
				if (regLineMatch.Success)
				{
					// The bountiful event is always the first log line of a harvest when it occurs.
					// If the harvest is bountiful, there can be 2 harvest events.
					// Both harvest events will have a common harvest (quantity > 1) and a rare quantity of 1.
					// The rare flag should be set on a quantity of 1 harvest.
					// The bountiful flag should be set for the first common harvest if the bountiful line was passed.
					int qty = 0;
					if (int.TryParse(regLineMatch.Groups["number"].Value, out qty))
					{
						isRare = false;
						if (qty == 1 && rareNext)
							isRare = true;
						harvestStats.AddHarvest(new HarvestData(logInfo.detectedTime,
							regHarvestAction.Replace(logInfo.logLine, "$1"), Int32.Parse(regHarvestAction.Replace(logInfo.logLine, "$2")),
							regHarvestAction.Replace(logInfo.logLine, "$3"), regHarvestAction.Replace(logInfo.logLine, "$4"), isRare, bountifulHarvest, false));
						if (isRare)
							rareNext = false;
						bountifulHarvest = false;
						PopulateLBs();
					}
				}
				else
				{
					Match regBonusActionMatch = regBonusHarvestAction.Match(logInfo.logLine);
					if (regBonusActionMatch.Success)
					{
						if (bonusHarvestData == null)
						{
							bonusHarvestData = new HarvestData(logInfo.detectedTime, regBonusActionMatch.Groups["actor"].Value, 0, "",
								regBonusActionMatch.Groups["nodeType"].Value, false, false, true);
						}
						else
						{
							if (bonusHarvestData.time == logInfo.detectedTime)
							{
								bonusHarvestData.nodeType = regBonusActionMatch.Groups["nodeType"].Value;
								harvestStats.AddHarvest(bonusHarvestData);
								PopulateLBs();
							}
							bonusHarvestData = null;
						}
					}
					else
					{
						Match regBonusHarvestMatch = regBonusHarvestReceive.Match(logInfo.logLine);
						if (regBonusHarvestMatch.Success)
						{
							int qty = 0;
							if (int.TryParse(regBonusHarvestMatch.Groups["number"].Value, out qty))
							{
								if (bonusHarvestData == null)
								{
									bonusHarvestData = new HarvestData(logInfo.detectedTime, regBonusHarvestMatch.Groups["action"].Value, qty,
										regBonusHarvestMatch.Groups["itemName"].Value, "", false, false, true);
								}
								else
								{
									if (bonusHarvestData.time == logInfo.detectedTime)
									{
										bonusHarvestData.amount = qty;
										bonusHarvestData.actionVerb = regBonusHarvestMatch.Groups["action"].Value;
										bonusHarvestData.itemName = regBonusHarvestMatch.Groups["itemName"].Value;
										harvestStats.AddHarvest(bonusHarvestData);
										PopulateLBs();
									}
									bonusHarvestData = null;
								}
							}
						}
					}
				}
			}
		}
		void PopulateLBs()
		{
			for (int i = 0; i < harvestStats.items.Count; i++)
			{
				if (!listBox1.Items.Contains(harvestStats.items[i].name))
					listBox1.Items.Add(harvestStats.items[i].name);
			}
			if (listBox1.SelectedIndex > -1)
			{
				NodeStats ns = null;
				string selected = (string)listBox1.Items[listBox1.SelectedIndex];
				for (int i = 0; i < harvestStats.items.Count; i++)
				{
					if (harvestStats.items[i].name == selected)
					{
						ns = harvestStats.items[i];
						break;
					}
				}
				for (int i = 0; i < harvestStats.items.Count; i++)
				{
					if (!listBox2.Items.Contains(ns.items[i].name))
						listBox2.Items.Add(ns.items[i].name);
				}
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
			}
			public int TotalAttempts
			{
				get
				{
					List<DateTime> lst = new List<DateTime>();
					for (int i = 0; i < items.Count; i++)
					{
						if (!lst.Contains(items[i].time))
							lst.Add(items[i].time);
					}
					return lst.Count;
				}
			}
			public int TotalCollects
			{
				get
				{
					return items.Count;
				}
			}
			public int TotalItems
			{
				get
				{
					int total = 0;
					for (int i = 0; i < items.Count; i++)
					{
						total += items[i].amount;
					}
					return total;
				}
			}
			public int TotalRares
			{
				get
				{
					int total = 0;
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].rare)
							total++;
					}
					return total;
				}
			}
			public int TotalBountiful
			{
				get
				{
					int total = 0;
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].bountiful)
							total++;
					}
					return total;
				}
			}
			public int TotalBonus
			{
				get
				{
					int total = 0;
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].bonus)
							total++;
					}
					return total;
				}
			}
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
					return ((parent.TotalAttempts == 0) ? 0 : (float)TotalAttempts / (float)parent.TotalAttempts) * 100F;
				}
			}
			public float PercentCollects
			{
				get
				{
					return ((parent.TotalCollects == 0) ? 0 : (float)TotalCollects / (float)parent.TotalCollects) * 100F;
				}
			}
			public float PercentItems
			{
				get
				{
					return ((parent.TotalItems == 0) ? 0 : (float)TotalItems / (float)parent.TotalItems) * 100F;
				}
			}
			public float PercentRares
			{
				get
				{
					return ((parent.TotalRares == 0) ? 0 : (float)TotalRares / (float)parent.TotalRares) * 100F;
				}
			}
			public float PercentBountiful
			{
				get
				{
					return ((parent.TotalBountiful == 0) ? 0 : (float)TotalBountiful / (float)parent.TotalBountiful) * 100F;
				}
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
			public HarvestStats parent;
			public List<ItemStats> items = new List<ItemStats>();
			public NodeStats(string Name, HarvestStats Parent)
			{
				name = Name;
				parent = Parent;
			}
			public void AddHarvest(HarvestData item)
			{
				ItemStats all = new ItemStats(" All", this);
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
			}
			public int TotalAttempts
			{
				get
				{
					for (int i = 0; i < items.Count; i++)
					{
						if (items[i].name == " All")
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
						if (items[i].name == " All")
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
						if (items[i].name == " All")
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
						if (items[i].name == " All")
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
						if (items[i].name == " All")
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
						if (items[i].name == " All")
						{
							return items[i].TotalBonus;
						}
					}
					return 0;
				}
			}
			public float PercentAttempts
			{
				get
				{
					return ((parent.TotalAttempts == 0) ? 0 : (float)TotalAttempts / (float)parent.TotalAttempts) * 100F;
				}
			}
			public float PercentCollects
			{
				get
				{
					return ((parent.TotalCollects == 0) ? 0 : (float)TotalCollects / (float)parent.TotalCollects) * 100F;
				}
			}
			public float PercentItems
			{
				get
				{
					return ((parent.TotalItems == 0) ? 0 : (float)TotalItems / (float)parent.TotalItems) * 100F;
				}
			}
			public float PercentRares
			{
				get
				{
					return ((parent.TotalRares == 0) ? 0 : (float)TotalRares / (float)parent.TotalRares) * 100F;
				}
			}
			public float PercentBountiful
			{
				get
				{
					return ((parent.TotalBountiful == 0) ? 0 : (float)TotalBountiful / (float)parent.TotalBountiful) * 100F;
				}
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
				NodeStats all = new NodeStats(" All", this);
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
						if (items[i].name == " All")
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
						if (items[i].name == " All")
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
						if (items[i].name == " All")
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
						if (items[i].name == " All")
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
						if (items[i].name == " All")
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
						if (items[i].name == " All")
						{
							return items[i].TotalBonus;
						}
					}
					return 0;
				}
			}
		}
	}
}
