namespace UpdaterManagerLibrary
{
    partial class UpdateForm
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
            this.richTextBoxChangelog = new System.Windows.Forms.RichTextBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.labelCurrentVersion = new System.Windows.Forms.Label();
            this.tableLayoutPanelVersions = new System.Windows.Forms.TableLayoutPanel();
            this.labelLastVersion = new System.Windows.Forms.Label();
            this.tableLayoutPanelVersions.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitleStatic
            // 
            this.labelTitleStatic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(90)))));
            this.labelTitleStatic.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitleStatic.Font = new System.Drawing.Font("Segoe UI Semibold", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleStatic.ForeColor = System.Drawing.Color.White;
            this.labelTitleStatic.Location = new System.Drawing.Point(0, 0);
            this.labelTitleStatic.Name = "labelTitleStatic";
            this.labelTitleStatic.Size = new System.Drawing.Size(454, 45);
            this.labelTitleStatic.TabIndex = 0;
            this.labelTitleStatic.Text = "Nuova versione disponibile!";
            this.labelTitleStatic.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // richTextBoxChangelog
            // 
            this.richTextBoxChangelog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxChangelog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(76)))), ((int)(((byte)(105)))));
            this.richTextBoxChangelog.ForeColor = System.Drawing.Color.White;
            this.richTextBoxChangelog.Location = new System.Drawing.Point(12, 84);
            this.richTextBoxChangelog.Name = "richTextBoxChangelog";
            this.richTextBoxChangelog.ReadOnly = true;
            this.richTextBoxChangelog.Size = new System.Drawing.Size(430, 340);
            this.richTextBoxChangelog.TabIndex = 4;
            this.richTextBoxChangelog.Text = "";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(127)))));
            this.buttonUpdate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.buttonUpdate.Location = new System.Drawing.Point(150, 432);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(151, 47);
            this.buttonUpdate.TabIndex = 5;
            this.buttonUpdate.Text = "Aggiorna";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // labelCurrentVersion
            // 
            this.labelCurrentVersion.AutoSize = true;
            this.labelCurrentVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCurrentVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentVersion.ForeColor = System.Drawing.Color.White;
            this.labelCurrentVersion.Location = new System.Drawing.Point(3, 0);
            this.labelCurrentVersion.Name = "labelCurrentVersion";
            this.labelCurrentVersion.Size = new System.Drawing.Size(221, 30);
            this.labelCurrentVersion.TabIndex = 2;
            this.labelCurrentVersion.Text = "Versione corrente: ";
            this.labelCurrentVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelVersions
            // 
            this.tableLayoutPanelVersions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(90)))));
            this.tableLayoutPanelVersions.ColumnCount = 2;
            this.tableLayoutPanelVersions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelVersions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelVersions.Controls.Add(this.labelLastVersion, 1, 0);
            this.tableLayoutPanelVersions.Controls.Add(this.labelCurrentVersion, 0, 0);
            this.tableLayoutPanelVersions.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelVersions.Location = new System.Drawing.Point(0, 45);
            this.tableLayoutPanelVersions.Name = "tableLayoutPanelVersions";
            this.tableLayoutPanelVersions.RowCount = 1;
            this.tableLayoutPanelVersions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelVersions.Size = new System.Drawing.Size(454, 30);
            this.tableLayoutPanelVersions.TabIndex = 1;
            // 
            // labelLastVersion
            // 
            this.labelLastVersion.AutoSize = true;
            this.labelLastVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelLastVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLastVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLastVersion.ForeColor = System.Drawing.Color.White;
            this.labelLastVersion.Location = new System.Drawing.Point(230, 0);
            this.labelLastVersion.Name = "labelLastVersion";
            this.labelLastVersion.Size = new System.Drawing.Size(221, 30);
            this.labelLastVersion.TabIndex = 3;
            this.labelLastVersion.Text = "Versione nuova: ";
            this.labelLastVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(70)))), ((int)(((byte)(96)))));
            this.ClientSize = new System.Drawing.Size(454, 486);
            this.Controls.Add(this.tableLayoutPanelVersions);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.richTextBoxChangelog);
            this.Controls.Add(this.labelTitleStatic);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = global::UpdaterManagerLibrary.Properties.Resources.Icon;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(430, 460);
            this.Name = "UpdateForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Manager";
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.tableLayoutPanelVersions.ResumeLayout(false);
            this.tableLayoutPanelVersions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitleStatic;
        private System.Windows.Forms.RichTextBox richTextBoxChangelog;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label labelCurrentVersion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelVersions;
        private System.Windows.Forms.Label labelLastVersion;
    }
}