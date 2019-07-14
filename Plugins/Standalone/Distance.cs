using System;
using System.Collections.Generic;
using System.Text;
using Advanced_Combat_Tracker;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
[assembly: AssemblyTitle("Distance")]
[assembly: AssemblyDescription("Measures the distance between given /locs")]
[assembly: AssemblyVersion("1.0.0.1")]

namespace ACT_Plugin1
{
    class Export_All : IActPluginV1
    {
        Label statusLabel;
        TabPage pluginSpace;
        Regex logLocRegex = new Regex(@"\(\d{10}\)\[.{24}\] Your location is (-?[\d,]+\.\d+, -?[\d,]+\.\d+, -?[\d,]+\.\d+)\..+", RegexOptions.Compiled);
        Regex locRegex = new Regex(@"^(?<y>-?[\d,]+(?:\.\d+)?), ?(?:(?<z>-?[\d,]+(?:\.\d+)?), ?)?(?<x>-?[\d,]+(?:\.\d+)?)$", RegexOptions.Compiled);
        #region Interface
        private void InitUI()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbLocA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLocB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAtoB = new System.Windows.Forms.Button();
            this.tbLocC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAtoC = new System.Windows.Forms.Button();
            this.lblDistBC = new System.Windows.Forms.Label();
            this.lblDistAB = new System.Windows.Forms.Label();
            this.lblDistAC = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();

            this.panel1.Controls.Add(this.lblDistAC);
            this.panel1.Controls.Add(this.lblDistAB);
            this.panel1.Controls.Add(this.lblDistBC);
            this.panel1.Controls.Add(this.btnAtoC);
            this.panel1.Controls.Add(this.btnAtoB);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbLocC);
            this.panel1.Controls.Add(this.tbLocB);
            this.panel1.Controls.Add(this.tbLocA);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;

            this.tbLocA.Location = new System.Drawing.Point(211, 42);
            this.tbLocA.Size = new System.Drawing.Size(168, 20);
            this.tbLocA.TabIndex = 0;
            this.tbLocA.TextChanged += new EventHandler(tbLoc_TextChanged);

            this.tbLocB.Location = new System.Drawing.Point(12, 395);
            this.tbLocB.Size = new System.Drawing.Size(168, 20);
            this.tbLocB.TabIndex = 1;
            this.tbLocB.TextChanged += new EventHandler(tbLoc_TextChanged);

            this.tbLocC.Location = new System.Drawing.Point(410, 395);
            this.tbLocC.Size = new System.Drawing.Size(168, 20);
            this.tbLocC.TabIndex = 3;
            this.tbLocC.TextChanged += new EventHandler(tbLoc_TextChanged);

            this.btnAtoB.Location = new System.Drawing.Point(59, 421);
            this.btnAtoB.Size = new System.Drawing.Size(75, 23);
            this.btnAtoB.TabIndex = 2;
            this.btnAtoB.Text = "Set B as A";
            this.btnAtoB.UseVisualStyleBackColor = true;
            this.btnAtoB.Click += new EventHandler(btnAtoB_Click);

            this.btnAtoC.Location = new System.Drawing.Point(457, 421);
            this.btnAtoC.Size = new System.Drawing.Size(75, 23);
            this.btnAtoC.TabIndex = 4;
            this.btnAtoC.Text = "Set C as A";
            this.btnAtoC.UseVisualStyleBackColor = true;
            this.btnAtoC.Click += new EventHandler(btnAtoC_Click);

            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 23);
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.Text = "Location A";

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 376);
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.Text = "Location B";

            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(465, 376);
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Location C";

            this.lblDistBC.Location = new System.Drawing.Point(186, 395);
            this.lblDistBC.Size = new System.Drawing.Size(218, 20);
            this.lblDistBC.Text = "0xy (0xyz)";
            this.lblDistBC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblDistAB.Location = new System.Drawing.Point(12, 219);
            this.lblDistAB.Size = new System.Drawing.Size(218, 20);
            this.lblDistAB.Text = "0xy (0xyz)";
            this.lblDistAB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblDistAC.Location = new System.Drawing.Point(360, 219);
            this.lblDistAC.Size = new System.Drawing.Size(218, 20);
            this.lblDistAC.Text = "0xy (0xyz)";
            this.lblDistAC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            pluginSpace.Controls.Add(panel1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDistBC;
        private System.Windows.Forms.Button btnAtoC;
        private System.Windows.Forms.Button btnAtoB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLocC;
        private System.Windows.Forms.TextBox tbLocB;
        private System.Windows.Forms.TextBox tbLocA;
        private System.Windows.Forms.Label lblDistAC;
        private System.Windows.Forms.Label lblDistAB;
        #endregion

        void btnAtoC_Click(object sender, EventArgs e)
        {
            tbLocC.Text = tbLocA.Text;
        }
        void btnAtoB_Click(object sender, EventArgs e)
        {
            tbLocB.Text = tbLocA.Text;
        }
        void tbLoc_TextChanged(object sender, EventArgs e)
        {
            if (locRegex.IsMatch(tbLocA.Text))
                tbLocA.BackColor = SystemColors.Window;
            else
                tbLocA.BackColor = Color.LightPink;
            if (locRegex.IsMatch(tbLocB.Text))
                tbLocB.BackColor = SystemColors.Window;
            else
                tbLocB.BackColor = Color.LightPink;
            if (locRegex.IsMatch(tbLocC.Text))
                tbLocC.BackColor = SystemColors.Window;
            else
                tbLocC.BackColor = Color.LightPink;

            if (tbLocA.BackColor == SystemColors.Window && tbLocB.BackColor == SystemColors.Window)
            {
                string x1s = locRegex.Replace(tbLocA.Text, "$3").Replace(",", "");
                string y1s = locRegex.Replace(tbLocA.Text, "$1").Replace(",", "");
                string z1s = locRegex.Replace(tbLocA.Text, "$2").Replace(",", "");
                string x2s = locRegex.Replace(tbLocB.Text, "$3").Replace(",", "");
                string y2s = locRegex.Replace(tbLocB.Text, "$1").Replace(",", "");
                string z2s = locRegex.Replace(tbLocB.Text, "$2").Replace(",", "");

                if (!String.IsNullOrEmpty(x1s) && !String.IsNullOrEmpty(y1s) &&
                    !String.IsNullOrEmpty(x2s) && !String.IsNullOrEmpty(y2s))
                {
                    double x1 = Double.Parse(x1s);
                    double y1 = Double.Parse(y1s);
                    double x2 = Double.Parse(x2s);
                    double y2 = Double.Parse(y2s);
                    double xyDist = GetXYDistance(x1, y1, x2, y2);
                    if (!String.IsNullOrEmpty(z1s) && !String.IsNullOrEmpty(z2s))
                    {
                        double z1 = Double.Parse(z1s);
                        double z2 = Double.Parse(z2s);
                        double xyzDist = GetXYZDistance(x1, y1, x2, y2, z1, z2);
                        lblDistAB.Text = String.Format("{0:0.00}xy ({1:0.00}xyz)", xyDist, xyzDist);
                    }
                    else
                        lblDistAB.Text = String.Format("{0:0.00}xy", xyDist);
                }
            }
            if (tbLocA.BackColor == SystemColors.Window && tbLocC.BackColor == SystemColors.Window)
            {
                string x1s = locRegex.Replace(tbLocA.Text, "$3").Replace(",", "");
                string y1s = locRegex.Replace(tbLocA.Text, "$1").Replace(",", "");
                string z1s = locRegex.Replace(tbLocA.Text, "$2").Replace(",", "");
                string x2s = locRegex.Replace(tbLocC.Text, "$3").Replace(",", "");
                string y2s = locRegex.Replace(tbLocC.Text, "$1").Replace(",", "");
                string z2s = locRegex.Replace(tbLocC.Text, "$2").Replace(",", "");

                if (!String.IsNullOrEmpty(x1s) && !String.IsNullOrEmpty(y1s) &&
                    !String.IsNullOrEmpty(x2s) && !String.IsNullOrEmpty(y2s))
                {
                    double x1 = Double.Parse(x1s);
                    double y1 = Double.Parse(y1s);
                    double x2 = Double.Parse(x2s);
                    double y2 = Double.Parse(y2s);
                    double xyDist = GetXYDistance(x1, y1, x2, y2);
                    if (!String.IsNullOrEmpty(z1s) && !String.IsNullOrEmpty(z2s))
                    {
                        double z1 = Double.Parse(z1s);
                        double z2 = Double.Parse(z2s);
                        double xyzDist = GetXYZDistance(x1, y1, x2, y2, z1, z2);
                        lblDistAC.Text = String.Format("{0:0.00}xy ({1:0.00}xyz)", xyDist, xyzDist);
                    }
                    else
                        lblDistAC.Text = String.Format("{0:0.00}xy", xyDist);
                }
            }
            if (tbLocB.BackColor == SystemColors.Window && tbLocC.BackColor == SystemColors.Window)
            {
                string x1s = locRegex.Replace(tbLocB.Text, "$3").Replace(",", "");
                string y1s = locRegex.Replace(tbLocB.Text, "$1").Replace(",", "");
                string z1s = locRegex.Replace(tbLocB.Text, "$2").Replace(",", "");
                string x2s = locRegex.Replace(tbLocC.Text, "$3").Replace(",", "");
                string y2s = locRegex.Replace(tbLocC.Text, "$1").Replace(",", "");
                string z2s = locRegex.Replace(tbLocC.Text, "$2").Replace(",", "");

                if (!String.IsNullOrEmpty(x1s) && !String.IsNullOrEmpty(y1s) &&
                    !String.IsNullOrEmpty(x2s) && !String.IsNullOrEmpty(y2s))
                {
                    double x1 = Double.Parse(x1s);
                    double y1 = Double.Parse(y1s);
                    double x2 = Double.Parse(x2s);
                    double y2 = Double.Parse(y2s);
                    double xyDist = GetXYDistance(x1, y1, x2, y2);
                    if (!String.IsNullOrEmpty(z1s) && !String.IsNullOrEmpty(z2s))
                    {
                        double z1 = Double.Parse(z1s);
                        double z2 = Double.Parse(z2s);
                        double xyzDist = GetXYZDistance(x1, y1, x2, y2, z1, z2);
                        lblDistBC.Text = String.Format("{0:0.00}xy ({1:0.00}xyz)", xyDist, xyzDist);
                    }
                    else
                        lblDistBC.Text = String.Format("{0:0.00}xy", xyDist);
                }
            }
        }
        private static double GetXYZDistance(double x1, double y1, double x2, double y2, double z1, double z2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(x1 - x2), 2) + Math.Pow(Math.Abs(y1 - y2), 2) + Math.Pow(Math.Abs(z1 - z2), 2));
        }
        private static double GetXYDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(x1 - x2), 2) + Math.Pow(Math.Abs(y1 - y2), 2));
        }

        public void DeInitPlugin()
        {
            statusLabel.Text = "Plugin exited";
        }
        public void InitPlugin(System.Windows.Forms.TabPage pluginScreenSpace, System.Windows.Forms.Label pluginStatusText)
        {
            statusLabel = pluginStatusText;
            statusLabel.Text = "Plugin started";
            pluginSpace = pluginScreenSpace;
            InitUI();
            ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(oFormActMain_OnLogLineRead);
        }
        void oFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            if (isImport)
                return;
            if (logInfo.detectedType == 0 && logLocRegex.IsMatch(logInfo.logLine))
                tbLocA.Text = logLocRegex.Replace(logInfo.logLine, "$1");
        }
    }
}
