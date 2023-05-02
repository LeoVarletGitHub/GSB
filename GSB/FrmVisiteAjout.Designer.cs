namespace GSB {
    partial class FrmVisiteAjout {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.motif = new System.Windows.Forms.Label();
            this.praticien = new System.Windows.Forms.Label();
            this.PraticienBox = new System.Windows.Forms.ComboBox();
            this.MotifBox = new System.Windows.Forms.ComboBox();
            this.date = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.messagelabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.Size = new System.Drawing.Size(1163, 64);
            this.lblTitre.Text = "Enregister un nouveau rendez-vous";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.motif);
            this.groupBox1.Controls.Add(this.praticien);
            this.groupBox1.Controls.Add(this.PraticienBox);
            this.groupBox1.Controls.Add(this.MotifBox);
            this.groupBox1.Controls.Add(this.date);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(818, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 276);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nouveau Rendez-vous";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(137, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ajouter";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // motif
            // 
            this.motif.AutoSize = true;
            this.motif.Location = new System.Drawing.Point(25, 116);
            this.motif.Name = "motif";
            this.motif.Size = new System.Drawing.Size(30, 13);
            this.motif.TabIndex = 5;
            this.motif.Text = "Motif";
            // 
            // praticien
            // 
            this.praticien.AutoSize = true;
            this.praticien.Location = new System.Drawing.Point(25, 58);
            this.praticien.Name = "praticien";
            this.praticien.Size = new System.Drawing.Size(48, 13);
            this.praticien.TabIndex = 4;
            this.praticien.Text = "Praticien";
            // 
            // PraticienBox
            // 
            this.PraticienBox.FormattingEnabled = true;
            this.PraticienBox.Location = new System.Drawing.Point(84, 50);
            this.PraticienBox.Name = "PraticienBox";
            this.PraticienBox.Size = new System.Drawing.Size(216, 21);
            this.PraticienBox.TabIndex = 3;
            this.PraticienBox.SelectedIndexChanged += new System.EventHandler(this.PraticienBox_SelectedIndexChanged);
            // 
            // MotifBox
            // 
            this.MotifBox.FormattingEnabled = true;
            this.MotifBox.Location = new System.Drawing.Point(84, 113);
            this.MotifBox.Name = "MotifBox";
            this.MotifBox.Size = new System.Drawing.Size(216, 21);
            this.MotifBox.TabIndex = 2;
            this.MotifBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Location = new System.Drawing.Point(6, 180);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(72, 13);
            this.date.TabIndex = 1;
            this.date.Text = "Date et heure";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(84, 174);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(239, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(559, 329);
            this.dataGridView1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Liste des rendez-vous déjà enregistrés";
            // 
            // messagelabel
            // 
            this.messagelabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.messagelabel.AutoSize = true;
            this.messagelabel.Location = new System.Drawing.Point(888, 433);
            this.messagelabel.Name = "messagelabel";
            this.messagelabel.Size = new System.Drawing.Size(35, 13);
            this.messagelabel.TabIndex = 16;
            this.messagelabel.Text = "label2";
            this.messagelabel.Visible = false;
            // 
            // FrmVisiteAjout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 557);
            this.Controls.Add(this.messagelabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(1179, 596);
            this.Name = "FrmVisiteAjout";
            this.Text = "FrmVisiteAjout";
            this.Load += new System.EventHandler(this.FrmVisiteAjout_Load);
            this.Controls.SetChildIndex(this.lblTitre, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.messagelabel, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label motif;
        private System.Windows.Forms.Label praticien;
        private System.Windows.Forms.ComboBox PraticienBox;
        private System.Windows.Forms.ComboBox MotifBox;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label messagelabel;
    }
}