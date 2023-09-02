using System;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.Reflection;

[assembly: AssemblyTitle("Notifications")]
[assembly: AssemblyDescription("A sample of an ACT plugin that uses notifications and TraySliders")]
[assembly: AssemblyCompany("EQAditu")]
[assembly: AssemblyVersion("1.0.0.1")]

namespace ACT_Plugin
{
	public class Notifications : UserControl, IActPluginV1
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
			this.btnNotification = new System.Windows.Forms.Button();
			this.tbTitle = new System.Windows.Forms.TextBox();
			this.rtbMessage = new System.Windows.Forms.RichTextBox();
			this.btnTraySlider = new System.Windows.Forms.Button();
			this.btnNotification2 = new System.Windows.Forms.Button();
			this.btnTraySlider2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnNotification
			// 
			this.btnNotification.Location = new System.Drawing.Point(3, 104);
			this.btnNotification.Name = "btnNotification";
			this.btnNotification.Size = new System.Drawing.Size(187, 23);
			this.btnNotification.TabIndex = 0;
			this.btnNotification.Text = "Add Notification";
			this.btnNotification.UseVisualStyleBackColor = true;
			this.btnNotification.Click += new System.EventHandler(this.btnNotification_Click);
			// 
			// tbTitle
			// 
			this.tbTitle.Location = new System.Drawing.Point(3, 3);
			this.tbTitle.Name = "tbTitle";
			this.tbTitle.Size = new System.Drawing.Size(363, 20);
			this.tbTitle.TabIndex = 1;
			// 
			// rtbMessage
			// 
			this.rtbMessage.Location = new System.Drawing.Point(3, 29);
			this.rtbMessage.Name = "rtbMessage";
			this.rtbMessage.Size = new System.Drawing.Size(363, 69);
			this.rtbMessage.TabIndex = 2;
			this.rtbMessage.Text = "";
			// 
			// btnTraySlider
			// 
			this.btnTraySlider.Location = new System.Drawing.Point(196, 104);
			this.btnTraySlider.Name = "btnTraySlider";
			this.btnTraySlider.Size = new System.Drawing.Size(170, 23);
			this.btnTraySlider.TabIndex = 3;
			this.btnTraySlider.Text = "Add TraySlider";
			this.btnTraySlider.UseVisualStyleBackColor = true;
			this.btnTraySlider.Click += new System.EventHandler(this.btnTraySlider_Click);
			// 
			// btnNotification2
			// 
			this.btnNotification2.Location = new System.Drawing.Point(3, 133);
			this.btnNotification2.Name = "btnNotification2";
			this.btnNotification2.Size = new System.Drawing.Size(187, 23);
			this.btnNotification2.TabIndex = 0;
			this.btnNotification2.Text = "Add Notification (Callback)";
			this.btnNotification2.UseVisualStyleBackColor = true;
			this.btnNotification2.Click += new System.EventHandler(this.btnNotification2_Click);
			// 
			// btnTraySlider2
			// 
			this.btnTraySlider2.Location = new System.Drawing.Point(196, 133);
			this.btnTraySlider2.Name = "btnTraySlider2";
			this.btnTraySlider2.Size = new System.Drawing.Size(170, 23);
			this.btnTraySlider2.TabIndex = 3;
			this.btnTraySlider2.Text = "Add TraySlider (Callback)";
			this.btnTraySlider2.UseVisualStyleBackColor = true;
			this.btnTraySlider2.Click += new System.EventHandler(this.btnTraySlider2_Click);
			// 
			// Notifications
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnTraySlider2);
			this.Controls.Add(this.btnTraySlider);
			this.Controls.Add(this.rtbMessage);
			this.Controls.Add(this.tbTitle);
			this.Controls.Add(this.btnNotification2);
			this.Controls.Add(this.btnNotification);
			this.Name = "Notifications";
			this.Size = new System.Drawing.Size(686, 384);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		#endregion
		public Notifications()
		{
			InitializeComponent();
		}

		Label lblStatus;    // The status label that appears in ACT's Plugin tab
		private Button btnNotification;
		private TextBox tbTitle;
		private RichTextBox rtbMessage;
		private Button btnNotification2;
		private Button btnTraySlider2;
		private Button btnTraySlider;

		#region IActPluginV1 Members
		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			lblStatus = pluginStatusText;   // Hand the status label's reference to our local var
			pluginScreenSpace.Controls.Add(this);   // Add this UserControl to the tab ACT provides
			this.Dock = DockStyle.Fill; // Expand the UserControl to fill the tab's client space

			lblStatus.Text = "Plugin Started";
		}
		public void DeInitPlugin()
		{
			lblStatus.Text = "Plugin Exited";
		}
		#endregion

		private void btnNotification_Click(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.NotificationAdd(tbTitle.Text, rtbMessage.Text);
		}
		private void btnNotification2_Click(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.NotificationAdd(tbTitle.Text, rtbMessage.Text, (s1, e1) => { MessageBox.Show("Extra message"); });
			ActGlobals.oFormActMain.NotificationAdd(tbTitle.Text, rtbMessage.Text, Notification2, "Extra message2");
		}
		private void Notification2(object sender, EventArgs e)
		{
			string extraMessage = (string)sender;
			MessageBox.Show(extraMessage, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnTraySlider_Click(object sender, EventArgs e)
		{
			TraySlider slider = new TraySlider();
			slider.ButtonLayout = TraySlider.ButtonLayoutEnum.OneButton;	// Defaults to "OK"
			slider.ShowDurationMs = 30000;
			slider.ShowTraySlider(rtbMessage.Text, tbTitle.Text);
		}
		private void btnTraySlider2_Click(object sender, EventArgs e)
		{
			TraySlider slider = new TraySlider();
			slider.ButtonLayout = TraySlider.ButtonLayoutEnum.TwoButton;
			slider.ButtonSW.Text = "OK";	// Do nothing and hide
			slider.ButtonSE.Text = "Message";
			slider.ButtonSE.Click += (sender1, eventArgs1) => { MessageBox.Show("Message"); };
			slider.TrayTitle.Text = tbTitle.Text;
			slider.TrayText.Text = rtbMessage.Text;
			slider.AddNotification = false;	// Don't create notification
			slider.ShowTraySlider();
		}
	}
}
