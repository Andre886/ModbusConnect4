namespace Modbus_Connect_4
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eseguiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avviaLetturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fermaLetturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impostazioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temaChiaroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temaScuroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baudrateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paritàToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopBitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 88);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1220, 648);
            this.dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.eseguiToolStripMenuItem,
            this.impostazioniToolStripMenuItem,
            this.displayToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1247, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // eseguiToolStripMenuItem
            // 
            this.eseguiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.avviaLetturaToolStripMenuItem,
            this.fermaLetturaToolStripMenuItem});
            this.eseguiToolStripMenuItem.Name = "eseguiToolStripMenuItem";
            this.eseguiToolStripMenuItem.Size = new System.Drawing.Size(53, 22);
            this.eseguiToolStripMenuItem.Text = "Esegui";
            // 
            // avviaLetturaToolStripMenuItem
            // 
            this.avviaLetturaToolStripMenuItem.Name = "avviaLetturaToolStripMenuItem";
            this.avviaLetturaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.avviaLetturaToolStripMenuItem.Text = "Avvia Lettura";
            this.avviaLetturaToolStripMenuItem.Click += new System.EventHandler(this.avviaLetturaToolStripMenuItem_Click);
            // 
            // fermaLetturaToolStripMenuItem
            // 
            this.fermaLetturaToolStripMenuItem.Name = "fermaLetturaToolStripMenuItem";
            this.fermaLetturaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fermaLetturaToolStripMenuItem.Text = "Ferma Lettura";
            this.fermaLetturaToolStripMenuItem.Click += new System.EventHandler(this.fermaLetturaToolStripMenuItem_Click);
            // 
            // impostazioniToolStripMenuItem
            // 
            this.impostazioniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portaToolStripMenuItem,
            this.baudrateToolStripMenuItem,
            this.dataBitsToolStripMenuItem,
            this.paritàToolStripMenuItem,
            this.stopBitToolStripMenuItem});
            this.impostazioniToolStripMenuItem.Name = "impostazioniToolStripMenuItem";
            this.impostazioniToolStripMenuItem.Size = new System.Drawing.Size(87, 22);
            this.impostazioniToolStripMenuItem.Text = "Impostazioni";
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.temaChiaroToolStripMenuItem,
            this.temaScuroToolStripMenuItem});
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(57, 22);
            this.displayToolStripMenuItem.Text = "Display";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(24, 33);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 46);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(1162, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 45);
            this.button2.TabIndex = 3;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Lime;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(1073, 33);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(59, 44);
            this.button3.TabIndex = 4;
            this.button3.Text = "Richieste";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Lime;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(976, 34);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 42);
            this.button4.TabIndex = 5;
            this.button4.Text = "Risposte";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // temaChiaroToolStripMenuItem
            // 
            this.temaChiaroToolStripMenuItem.Name = "temaChiaroToolStripMenuItem";
            this.temaChiaroToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.temaChiaroToolStripMenuItem.Text = "Tema Chiaro";
            this.temaChiaroToolStripMenuItem.Click += new System.EventHandler(this.temaChiaroToolStripMenuItem_Click);
            // 
            // temaScuroToolStripMenuItem
            // 
            this.temaScuroToolStripMenuItem.Name = "temaScuroToolStripMenuItem";
            this.temaScuroToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.temaScuroToolStripMenuItem.Text = "Tema Scuro";
            this.temaScuroToolStripMenuItem.Click += new System.EventHandler(this.temaScuroToolStripMenuItem_Click);
            // 
            // portaToolStripMenuItem
            // 
            this.portaToolStripMenuItem.Name = "portaToolStripMenuItem";
            this.portaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.portaToolStripMenuItem.Text = "porta";
            // 
            // baudrateToolStripMenuItem
            // 
            this.baudrateToolStripMenuItem.Name = "baudrateToolStripMenuItem";
            this.baudrateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.baudrateToolStripMenuItem.Text = "baudrate";
            // 
            // dataBitsToolStripMenuItem
            // 
            this.dataBitsToolStripMenuItem.Name = "dataBitsToolStripMenuItem";
            this.dataBitsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dataBitsToolStripMenuItem.Text = "dataBits";
            // 
            // paritàToolStripMenuItem
            // 
            this.paritàToolStripMenuItem.Name = "paritàToolStripMenuItem";
            this.paritàToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.paritàToolStripMenuItem.Text = "parità";
            // 
            // stopBitToolStripMenuItem
            // 
            this.stopBitToolStripMenuItem.Name = "stopBitToolStripMenuItem";
            this.stopBitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stopBitToolStripMenuItem.Text = "stopBit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 747);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Modbus Connect 4";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eseguiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem impostazioniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem avviaLetturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fermaLetturaToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem temaChiaroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem temaScuroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baudrateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataBitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paritàToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopBitToolStripMenuItem;
    }
}

