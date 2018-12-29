namespace UpdaterManagerLibrary
{
    partial class DownloadForm
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
            this.labelTitleStatic = new System.Windows.Forms.Label();
            this.coloredProgressBarDownload = new CustomControlCollection.ColoredProgressBar();
            this.labelCurrentByte = new System.Windows.Forms.Label();
            this.labelTotalByte = new System.Windows.Forms.Label();
            this.labelInformation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitleStatic
            // 
            this.labelTitleStatic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(90)))));
            this.labelTitleStatic.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitleStatic.Font = new System.Drawing.Font("Segoe UI Semibold", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleStatic.ForeColor = System.Drawing.Color.White;
            this.labelTitleStatic.Location = new System.Drawing.Point(0, 0);
            this.labelTitleStatic.Name = "labelTitleStatic";
            this.labelTitleStatic.Size = new System.Drawing.Size(484, 47);
            this.labelTitleStatic.TabIndex = 0;
            this.labelTitleStatic.Text = "Download nuova versione!";
            this.labelTitleStatic.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // coloredProgressBarDownload
            // 
            this.coloredProgressBarDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.coloredProgressBarDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(70)))), ((int)(((byte)(96)))));
            this.coloredProgressBarDownload.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(75)))), ((int)(((byte)(115)))));
            this.coloredProgressBarDownload.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coloredProgressBarDownload.ForeColor = System.Drawing.Color.White;
            this.coloredProgressBarDownload.Location = new System.Drawing.Point(12, 86);
            this.coloredProgressBarDownload.Name = "coloredProgressBarDownload";
            this.coloredProgressBarDownload.ProgressColor = System.Drawing.Color.DarkBlue;
            this.coloredProgressBarDownload.ShowPercentageText = true;
            this.coloredProgressBarDownload.Size = new System.Drawing.Size(460, 37);
            this.coloredProgressBarDownload.TabIndex = 3;
            // 
            // labelCurrentByte
            // 
            this.labelCurrentByte.AutoSize = true;
            this.labelCurrentByte.ForeColor = System.Drawing.Color.White;
            this.labelCurrentByte.Location = new System.Drawing.Point(12, 63);
            this.labelCurrentByte.Name = "labelCurrentByte";
            this.labelCurrentByte.Size = new System.Drawing.Size(70, 20);
            this.labelCurrentByte.TabIndex = 1;
            this.labelCurrentByte.Text = "00.00 MB";
            // 
            // labelTotalByte
            // 
            this.labelTotalByte.AutoSize = true;
            this.labelTotalByte.ForeColor = System.Drawing.Color.White;
            this.labelTotalByte.Location = new System.Drawing.Point(402, 63);
            this.labelTotalByte.Name = "labelTotalByte";
            this.labelTotalByte.Size = new System.Drawing.Size(70, 20);
            this.labelTotalByte.TabIndex = 2;
            this.labelTotalByte.Text = "00.00 MB";
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInformation.ForeColor = System.Drawing.Color.White;
            this.labelInformation.Location = new System.Drawing.Point(12, 129);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(95, 20);
            this.labelInformation.TabIndex = 4;
            this.labelInformation.Text = "Informazioni";
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(70)))), ((int)(((byte)(96)))));
            this.ClientSize = new System.Drawing.Size(484, 156);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.labelTotalByte);
            this.Controls.Add(this.labelCurrentByte);
            this.Controls.Add(this.coloredProgressBarDownload);
            this.Controls.Add(this.labelTitleStatic);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = global::UpdaterManagerLibrary.Properties.Resources.Icon;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 195);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 192);
            this.Name = "DownloadForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download Manager";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadForm_FormClosing);
            this.Load += new System.EventHandler(this.DownloadForm_Load);
            this.Shown += new System.EventHandler(this.DownloadForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitleStatic;
        private CustomControlCollection.ColoredProgressBar coloredProgressBarDownload;
        private System.Windows.Forms.Label labelCurrentByte;
        private System.Windows.Forms.Label labelTotalByte;
        private System.Windows.Forms.Label labelInformation;
    }
}