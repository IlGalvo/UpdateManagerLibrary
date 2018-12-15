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
            this.coloredProgressBarDownload = new CustomControlCollection.ColoredProgressBar();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelCurrentByte = new System.Windows.Forms.Label();
            this.labelTotalByte = new System.Windows.Forms.Label();
            this.labelInformation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // coloredProgressBarDownload
            // 
            this.coloredProgressBarDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.coloredProgressBarDownload.ForeColor = System.Drawing.Color.Blue;
            this.coloredProgressBarDownload.Location = new System.Drawing.Point(12, 83);
            this.coloredProgressBarDownload.Name = "coloredProgressBarDownload";
            this.coloredProgressBarDownload.ShowPercentageText = true;
            this.coloredProgressBarDownload.Size = new System.Drawing.Size(487, 38);
            this.coloredProgressBarDownload.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(511, 46);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Download aggiornamento in corso...";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelCurrentByte
            // 
            this.labelCurrentByte.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCurrentByte.AutoSize = true;
            this.labelCurrentByte.Location = new System.Drawing.Point(12, 60);
            this.labelCurrentByte.Name = "labelCurrentByte";
            this.labelCurrentByte.Size = new System.Drawing.Size(57, 20);
            this.labelCurrentByte.TabIndex = 2;
            this.labelCurrentByte.Text = "Current";
            // 
            // labelTotalByte
            // 
            this.labelTotalByte.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelTotalByte.AutoSize = true;
            this.labelTotalByte.Location = new System.Drawing.Point(457, 60);
            this.labelTotalByte.Name = "labelTotalByte";
            this.labelTotalByte.Size = new System.Drawing.Size(42, 20);
            this.labelTotalByte.TabIndex = 3;
            this.labelTotalByte.Text = "Total";
            // 
            // labelInformation
            // 
            this.labelInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelInformation.AutoSize = true;
            this.labelInformation.Location = new System.Drawing.Point(12, 127);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(87, 20);
            this.labelInformation.TabIndex = 4;
            this.labelInformation.Text = "Information";
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 153);
            this.ControlBox = false;
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.labelTotalByte);
            this.Controls.Add(this.labelCurrentByte);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.coloredProgressBarDownload);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DownloadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DownloadForm";
            this.Load += new System.EventHandler(this.DownloadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControlCollection.ColoredProgressBar coloredProgressBarDownload;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelCurrentByte;
        private System.Windows.Forms.Label labelTotalByte;
        private System.Windows.Forms.Label labelInformation;
    }
}