namespace AplikacjaHotelowa.add_forms
{
    partial class Form_add_budynek
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_add_budynek));
            this.adresyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aplikacjaHotelowaDataSet = new AplikacjaHotelowa.AplikacjaHotelowaDataSet();
            this.adresyTableAdapter = new AplikacjaHotelowa.AplikacjaHotelowaDataSetTableAdapters.AdresyTableAdapter();
            this.adresyBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.t_adresid = new System.Windows.Forms.TextBox();
            this.t_telrecepcja = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.t_telmenadzera = new System.Windows.Forms.TextBox();
            this.t_opis = new System.Windows.Forms.TextBox();
            this.t_nazwa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.myListBox6 = new AplikacjaHotelowa.MyListBox();
            this.myListBox5 = new AplikacjaHotelowa.MyListBox();
            this.myListBox4 = new AplikacjaHotelowa.MyListBox();
            this.myListBox3 = new AplikacjaHotelowa.MyListBox();
            this.myListBox2 = new AplikacjaHotelowa.MyListBox();
            this.myListBox1 = new AplikacjaHotelowa.MyListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.adresyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aplikacjaHotelowaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adresyBindingSource1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // adresyBindingSource
            // 
            this.adresyBindingSource.DataMember = "Adresy";
            this.adresyBindingSource.DataSource = this.aplikacjaHotelowaDataSet;
            // 
            // aplikacjaHotelowaDataSet
            // 
            this.aplikacjaHotelowaDataSet.DataSetName = "AplikacjaHotelowaDataSet";
            this.aplikacjaHotelowaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adresyTableAdapter
            // 
            this.adresyTableAdapter.ClearBeforeFill = true;
            // 
            // adresyBindingSource1
            // 
            this.adresyBindingSource1.DataMember = "Adresy";
            this.adresyBindingSource1.DataSource = this.aplikacjaHotelowaDataSet;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.t_adresid);
            this.groupBox2.Controls.Add(this.t_telrecepcja);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.t_telmenadzera);
            this.groupBox2.Controls.Add(this.t_opis);
            this.groupBox2.Controls.Add(this.t_nazwa);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 188);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Budynek";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(76, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Opis";
            // 
            // t_adresid
            // 
            this.t_adresid.Location = new System.Drawing.Point(110, 150);
            this.t_adresid.Name = "t_adresid";
            this.t_adresid.Size = new System.Drawing.Size(100, 20);
            this.t_adresid.TabIndex = 17;
            // 
            // t_telrecepcja
            // 
            this.t_telrecepcja.Location = new System.Drawing.Point(110, 120);
            this.t_telrecepcja.Name = "t_telrecepcja";
            this.t_telrecepcja.Size = new System.Drawing.Size(100, 20);
            this.t_telrecepcja.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "AdresID";
            // 
            // t_telmenadzera
            // 
            this.t_telmenadzera.Location = new System.Drawing.Point(110, 86);
            this.t_telmenadzera.Name = "t_telmenadzera";
            this.t_telmenadzera.Size = new System.Drawing.Size(100, 20);
            this.t_telmenadzera.TabIndex = 10;
            // 
            // t_opis
            // 
            this.t_opis.Location = new System.Drawing.Point(110, 60);
            this.t_opis.Name = "t_opis";
            this.t_opis.Size = new System.Drawing.Size(100, 20);
            this.t_opis.TabIndex = 8;
            // 
            // t_nazwa
            // 
            this.t_nazwa.Location = new System.Drawing.Point(110, 30);
            this.t_nazwa.Name = "t_nazwa";
            this.t_nazwa.Size = new System.Drawing.Size(100, 20);
            this.t_nazwa.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Telefon Recepcja";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Telefon Menadzera";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nazwa";
            // 
            // myListBox6
            // 
            this.myListBox6.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.myListBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.myListBox6.FormattingEnabled = true;
            this.myListBox6.ItemHeight = 20;
            this.myListBox6.Location = new System.Drawing.Point(93, 154);
            this.myListBox6.Name = "myListBox6";
            this.myListBox6.Size = new System.Drawing.Size(117, 24);
            this.myListBox6.TabIndex = 23;
            this.myListBox6.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            // 
            // myListBox5
            // 
            this.myListBox5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.myListBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.myListBox5.FormattingEnabled = true;
            this.myListBox5.ItemHeight = 20;
            this.myListBox5.Location = new System.Drawing.Point(93, 128);
            this.myListBox5.Name = "myListBox5";
            this.myListBox5.Size = new System.Drawing.Size(117, 24);
            this.myListBox5.TabIndex = 22;
            this.myListBox5.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            this.myListBox5.SelectedIndexChanged += new System.EventHandler(this.myListBox5_SelectedIndexChanged);
            // 
            // myListBox4
            // 
            this.myListBox4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.myListBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.myListBox4.FormattingEnabled = true;
            this.myListBox4.ItemHeight = 20;
            this.myListBox4.Location = new System.Drawing.Point(93, 102);
            this.myListBox4.Name = "myListBox4";
            this.myListBox4.Size = new System.Drawing.Size(117, 24);
            this.myListBox4.TabIndex = 21;
            this.myListBox4.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            this.myListBox4.SelectedIndexChanged += new System.EventHandler(this.myListBox4_SelectedIndexChanged);
            // 
            // myListBox3
            // 
            this.myListBox3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.myListBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.myListBox3.FormattingEnabled = true;
            this.myListBox3.ItemHeight = 20;
            this.myListBox3.Location = new System.Drawing.Point(93, 76);
            this.myListBox3.Name = "myListBox3";
            this.myListBox3.Size = new System.Drawing.Size(117, 24);
            this.myListBox3.TabIndex = 20;
            this.myListBox3.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            this.myListBox3.SelectedIndexChanged += new System.EventHandler(this.myListBox3_SelectedIndexChanged);
            // 
            // myListBox2
            // 
            this.myListBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.myListBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.myListBox2.FormattingEnabled = true;
            this.myListBox2.ItemHeight = 20;
            this.myListBox2.Location = new System.Drawing.Point(93, 49);
            this.myListBox2.Name = "myListBox2";
            this.myListBox2.Size = new System.Drawing.Size(117, 24);
            this.myListBox2.TabIndex = 19;
            this.myListBox2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            this.myListBox2.SelectedIndexChanged += new System.EventHandler(this.myListBox2_SelectedIndexChanged);
            // 
            // myListBox1
            // 
            this.myListBox1.BackColor = System.Drawing.SystemColors.Window;
            this.myListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.myListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.myListBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.myListBox1.FormattingEnabled = true;
            this.myListBox1.ItemHeight = 20;
            this.myListBox1.Location = new System.Drawing.Point(93, 23);
            this.myListBox1.Name = "myListBox1";
            this.myListBox1.Size = new System.Drawing.Size(117, 24);
            this.myListBox1.TabIndex = 19;
            this.myListBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            this.myListBox1.SelectedIndexChanged += new System.EventHandler(this.myListBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 39);
            this.button1.TabIndex = 13;
            this.button1.Text = "Skopiuj ID Adresu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(59, 206);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 39);
            this.button2.TabIndex = 24;
            this.button2.Text = "Dodaj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.myListBox6);
            this.groupBox1.Controls.Add(this.myListBox5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.myListBox4);
            this.groupBox1.Controls.Add(this.myListBox1);
            this.groupBox1.Controls.Add(this.myListBox3);
            this.groupBox1.Controls.Add(this.myListBox2);
            this.groupBox1.Location = new System.Drawing.Point(248, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 239);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adres";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(71, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "ID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(64, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Kraj";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Województwo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Numer Budynku";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Ulica";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Miasto";
            // 
            // Form_add_budynek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 263);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_add_budynek";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form_add_budynek";
            this.Load += new System.EventHandler(this.Form_add_budynek_Load);
            ((System.ComponentModel.ISupportInitialize)(this.adresyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aplikacjaHotelowaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adresyBindingSource1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private AplikacjaHotelowaDataSet aplikacjaHotelowaDataSet;
        private System.Windows.Forms.BindingSource adresyBindingSource;
        private AplikacjaHotelowaDataSetTableAdapters.AdresyTableAdapter adresyTableAdapter;
        private System.Windows.Forms.BindingSource adresyBindingSource1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox t_telmenadzera;
        private System.Windows.Forms.TextBox t_opis;
        private System.Windows.Forms.TextBox t_nazwa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox t_telrecepcja;
        private MyListBox myListBox1;
        private MyListBox myListBox6;
        private MyListBox myListBox5;
        private MyListBox myListBox4;
        private MyListBox myListBox3;
        private MyListBox myListBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox t_adresid;
    }
}