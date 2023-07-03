namespace Birleştirme0205.AdminSayfa
{
    partial class Zimmet
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.KategoriEkleBtn = new System.Windows.Forms.Button();
            this.KategoriTxt = new System.Windows.Forms.TextBox();
            this.txtUrunadi = new System.Windows.Forms.TextBox();
            this.UrunEkleBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.urunkategoriCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.personelCombobx = new System.Windows.Forms.ComboBox();
            this.lblPersonel = new System.Windows.Forms.Label();
            this.UrunAtaBtn = new System.Windows.Forms.Button();
            this.urunLbl = new System.Windows.Forms.Label();
            this.UrunCombobx = new System.Windows.Forms.ComboBox();
            this.KaydetBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 79);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(357, 616);
            this.dataGridView1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(380, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kategori adı:";
            // 
            // KategoriEkleBtn
            // 
            this.KategoriEkleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.KategoriEkleBtn.FlatAppearance.BorderSize = 2;
            this.KategoriEkleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KategoriEkleBtn.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KategoriEkleBtn.Location = new System.Drawing.Point(384, 34);
            this.KategoriEkleBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.KategoriEkleBtn.Name = "KategoriEkleBtn";
            this.KategoriEkleBtn.Size = new System.Drawing.Size(275, 35);
            this.KategoriEkleBtn.TabIndex = 1;
            this.KategoriEkleBtn.Text = "Ürün Kategorisi Ekle";
            this.KategoriEkleBtn.UseVisualStyleBackColor = false;
            this.KategoriEkleBtn.Click += new System.EventHandler(this.KategoriEkleBtn_Click);
            // 
            // KategoriTxt
            // 
            this.KategoriTxt.Location = new System.Drawing.Point(487, 9);
            this.KategoriTxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.KategoriTxt.Name = "KategoriTxt";
            this.KategoriTxt.Size = new System.Drawing.Size(172, 21);
            this.KategoriTxt.TabIndex = 0;
            // 
            // txtUrunadi
            // 
            this.txtUrunadi.Location = new System.Drawing.Point(487, 125);
            this.txtUrunadi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUrunadi.Name = "txtUrunadi";
            this.txtUrunadi.Size = new System.Drawing.Size(172, 21);
            this.txtUrunadi.TabIndex = 3;
            // 
            // UrunEkleBtn
            // 
            this.UrunEkleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.UrunEkleBtn.FlatAppearance.BorderSize = 2;
            this.UrunEkleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UrunEkleBtn.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.UrunEkleBtn.Location = new System.Drawing.Point(384, 152);
            this.UrunEkleBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.UrunEkleBtn.Name = "UrunEkleBtn";
            this.UrunEkleBtn.Size = new System.Drawing.Size(275, 35);
            this.UrunEkleBtn.TabIndex = 4;
            this.UrunEkleBtn.Text = "Ürün Ekle";
            this.UrunEkleBtn.UseVisualStyleBackColor = false;
            this.UrunEkleBtn.Click += new System.EventHandler(this.UrunEkleBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(384, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kategori seç:";
            // 
            // urunkategoriCombo
            // 
            this.urunkategoriCombo.FormattingEnabled = true;
            this.urunkategoriCombo.Location = new System.Drawing.Point(487, 95);
            this.urunkategoriCombo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.urunkategoriCombo.Name = "urunkategoriCombo";
            this.urunkategoriCombo.Size = new System.Drawing.Size(172, 21);
            this.urunkategoriCombo.TabIndex = 2;
            this.urunkategoriCombo.SelectedIndexChanged += new System.EventHandler(this.urunkategoriCombo_SelectedIndexChanged);
            this.urunkategoriCombo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.urunkategoriCombo_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(414, 126);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ürün adı:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(243)))), ((int)(((byte)(207)))));
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(4, 1);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(357, 35);
            this.button1.TabIndex = 11;
            this.button1.Text = "Personeller ve Demirbaşlar Listesi";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(243)))), ((int)(((byte)(207)))));
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.Location = new System.Drawing.Point(4, 40);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(357, 35);
            this.button3.TabIndex = 11;
            this.button3.Text = "Kategori ve Ürünler";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // personelCombobx
            // 
            this.personelCombobx.FormattingEnabled = true;
            this.personelCombobx.Location = new System.Drawing.Point(387, 291);
            this.personelCombobx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.personelCombobx.Name = "personelCombobx";
            this.personelCombobx.Size = new System.Drawing.Size(272, 21);
            this.personelCombobx.TabIndex = 7;
            this.personelCombobx.Visible = false;
            this.personelCombobx.SelectedIndexChanged += new System.EventHandler(this.personelCombobx_SelectedIndexChanged_1);
            this.personelCombobx.MouseClick += new System.Windows.Forms.MouseEventHandler(this.personelCombobx_MouseClick);
            // 
            // lblPersonel
            // 
            this.lblPersonel.AutoSize = true;
            this.lblPersonel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPersonel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPersonel.Location = new System.Drawing.Point(387, 271);
            this.lblPersonel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPersonel.Name = "lblPersonel";
            this.lblPersonel.Size = new System.Drawing.Size(105, 16);
            this.lblPersonel.TabIndex = 6;
            this.lblPersonel.Text = "Personel Seç:";
            this.lblPersonel.Visible = false;
            // 
            // UrunAtaBtn
            // 
            this.UrunAtaBtn.BackColor = System.Drawing.Color.SkyBlue;
            this.UrunAtaBtn.FlatAppearance.BorderSize = 2;
            this.UrunAtaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UrunAtaBtn.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.UrunAtaBtn.Location = new System.Drawing.Point(384, 227);
            this.UrunAtaBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.UrunAtaBtn.Name = "UrunAtaBtn";
            this.UrunAtaBtn.Size = new System.Drawing.Size(275, 35);
            this.UrunAtaBtn.TabIndex = 5;
            this.UrunAtaBtn.Text = "Personele Ürün Ata";
            this.UrunAtaBtn.UseVisualStyleBackColor = false;
            this.UrunAtaBtn.Click += new System.EventHandler(this.UrunAtaBtn_Click);
            // 
            // urunLbl
            // 
            this.urunLbl.AutoSize = true;
            this.urunLbl.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.urunLbl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.urunLbl.Location = new System.Drawing.Point(387, 324);
            this.urunLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.urunLbl.Name = "urunLbl";
            this.urunLbl.Size = new System.Drawing.Size(76, 16);
            this.urunLbl.TabIndex = 8;
            this.urunLbl.Text = "Ürün Seç:";
            this.urunLbl.Visible = false;
            // 
            // UrunCombobx
            // 
            this.UrunCombobx.FormattingEnabled = true;
            this.UrunCombobx.Location = new System.Drawing.Point(387, 347);
            this.UrunCombobx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.UrunCombobx.Name = "UrunCombobx";
            this.UrunCombobx.Size = new System.Drawing.Size(272, 21);
            this.UrunCombobx.TabIndex = 9;
            this.UrunCombobx.Visible = false;
            this.UrunCombobx.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UrunCombobx_MouseClick);
            // 
            // KaydetBtn
            // 
            this.KaydetBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.KaydetBtn.FlatAppearance.BorderSize = 2;
            this.KaydetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KaydetBtn.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KaydetBtn.ForeColor = System.Drawing.Color.Black;
            this.KaydetBtn.Location = new System.Drawing.Point(387, 385);
            this.KaydetBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.KaydetBtn.Name = "KaydetBtn";
            this.KaydetBtn.Size = new System.Drawing.Size(272, 35);
            this.KaydetBtn.TabIndex = 10;
            this.KaydetBtn.Text = "Kaydet";
            this.KaydetBtn.UseVisualStyleBackColor = false;
            this.KaydetBtn.Visible = false;
            this.KaydetBtn.Click += new System.EventHandler(this.KaydetBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1098, 521);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 53);
            this.button2.TabIndex = 12;
            this.button2.Text = "Geri Dön";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Zimmet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 586);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.KaydetBtn);
            this.Controls.Add(this.UrunCombobx);
            this.Controls.Add(this.urunLbl);
            this.Controls.Add(this.UrunAtaBtn);
            this.Controls.Add(this.lblPersonel);
            this.Controls.Add(this.personelCombobx);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.urunkategoriCombo);
            this.Controls.Add(this.txtUrunadi);
            this.Controls.Add(this.UrunEkleBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.KategoriTxt);
            this.Controls.Add(this.KategoriEkleBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Zimmet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zimmet Sayfası";
            this.Load += new System.EventHandler(this.Zimmet_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button KategoriEkleBtn;
        private System.Windows.Forms.TextBox KategoriTxt;
        private System.Windows.Forms.TextBox txtUrunadi;
        private System.Windows.Forms.Button UrunEkleBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox urunkategoriCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox personelCombobx;
        private System.Windows.Forms.Label lblPersonel;
        private System.Windows.Forms.Button UrunAtaBtn;
        private System.Windows.Forms.Label urunLbl;
        private System.Windows.Forms.ComboBox UrunCombobx;
        private System.Windows.Forms.Button KaydetBtn;
        private System.Windows.Forms.Button button2;
    }
}