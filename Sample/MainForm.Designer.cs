namespace Sample
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCheckUpdates = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCheckUpdates
            // 
            this.buttonCheckUpdates.Location = new System.Drawing.Point(13, 20);
            this.buttonCheckUpdates.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCheckUpdates.Name = "buttonCheckUpdates";
            this.buttonCheckUpdates.Size = new System.Drawing.Size(275, 61);
            this.buttonCheckUpdates.TabIndex = 0;
            this.buttonCheckUpdates.Text = "Cerca aggiornamenti...";
            this.buttonCheckUpdates.UseVisualStyleBackColor = true;
            this.buttonCheckUpdates.Click += new System.EventHandler(this.buttonCheckUpdates_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 95);
            this.Controls.Add(this.buttonCheckUpdates);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCheckUpdates;
    }
}

