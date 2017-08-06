namespace Client
{
    partial class frmMain
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
            this.tmrHide = new System.Windows.Forms.Timer(this.components);
            this.tmrCommand = new System.Windows.Forms.Timer(this.components);
            this.lblClientId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tmrHide
            // 
            this.tmrHide.Tick += new System.EventHandler(this.tmrHide_Tick);
            // 
            // tmrCommand
            // 
            this.tmrCommand.Tick += new System.EventHandler(this.tmrCommand_Tick);
            // 
            // lblClientId
            // 
            this.lblClientId.AutoSize = true;
            this.lblClientId.Location = new System.Drawing.Point(27, 39);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(44, 13);
            this.lblClientId.TabIndex = 0;
            this.lblClientId.Text = "ClientID";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblClientId);
            this.Name = "frmMain";
            this.Text = "RAT";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrHide;
        private System.Windows.Forms.Timer tmrCommand;
        private System.Windows.Forms.Label lblClientId;
    }
}

