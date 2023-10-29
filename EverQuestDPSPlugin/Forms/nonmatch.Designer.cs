namespace EverQuestDPSPlugin
{
    partial class nonmatch
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.nonMatchList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // nonMatchList
            // 
            this.nonMatchList.FormattingEnabled = true;
            this.nonMatchList.Location = new System.Drawing.Point(1, 7);
            this.nonMatchList.Name = "nonMatchList";
            this.nonMatchList.Size = new System.Drawing.Size(799, 446);
            this.nonMatchList.TabIndex = 1;
            // 
            // nonmatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nonMatchList);
            this.Name = "nonmatch";
            this.Text = "nonmatch";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox nonMatchList;
    }
}