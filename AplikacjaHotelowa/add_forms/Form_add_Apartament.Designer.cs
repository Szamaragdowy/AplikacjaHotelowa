namespace AplikacjaHotelowa.add_forms
{
    partial class Form_add_Apartament
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_add_Apartament));
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.t_budynekID = new System.Windows.Forms.TextBox();
            this.t_typID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.t_Numerpokoju = new System.Windows.Forms.TextBox();
            this.adresyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aplikacjaHotelowaDataSet = new AplikacjaHotelowa.AplikacjaHotelowaDataSet();
            this.adresyTableAdapter = new AplikacjaHotelowa.AplikacjaHotelowaDataSetTableAdapters.AdresyTableAdapter();
            this.adresyBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.t_Cena = new System.Windows.Forms.TextBox();
            this.t_ID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.adresyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aplikacjaHotelowaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adresyBindingSource1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "NumerPokoju";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(66, 206);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 39);
            this.button2.TabIndex = 27;
            this.button2.Text = "Dodaj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // t_budynekID
            // 
            this.t_budynekID.Location = new System.Drawing.Point(110, 150);
            this.t_budynekID.Name = "t_budynekID";
            this.t_budynekID.Size = new System.Drawing.Size(100, 20);
            this.t_budynekID.TabIndex = 17;
            // 
            // t_typID
            // 
            this.t_typID.Location = new System.Drawing.Point(110, 120);
            this.t_typID.Name = "t_typID";
            this.t_typID.Size = new System.Drawing.Size(100, 20);
            this.t_typID.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Budynek ID";
            // 
            // t_Numerpokoju
            // 
            this.t_Numerpokoju.Location = new System.Drawing.Point(110, 86);
            this.t_Numerpokoju.Name = "t_Numerpokoju";
            this.t_Numerpokoju.Size = new System.Drawing.Size(100, 20);
            this.t_Numerpokoju.TabIndex = 10;
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
            this.groupBox2.Controls.Add(this.t_budynekID);
            this.groupBox2.Controls.Add(this.t_typID);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.t_Numerpokoju);
            this.groupBox2.Controls.Add(this.t_Cena);
            this.groupBox2.Controls.Add(this.t_ID);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(4, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 188);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Apartament";
            // 
            // t_Cena
            // 
            this.t_Cena.Location = new System.Drawing.Point(110, 60);
            this.t_Cena.Name = "t_Cena";
            this.t_Cena.Size = new System.Drawing.Size(100, 20);
            this.t_Cena.TabIndex = 8;
            // 
            // t_ID
            // 
            this.t_ID.Location = new System.Drawing.Point(110, 30);
            this.t_ID.Name = "t_ID";
            this.t_ID.Size = new System.Drawing.Size(100, 20);
            this.t_ID.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cena";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Typ ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID";
            // 
            // Form_add_Aprtament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 252);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_add_Aprtament";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form_add_Apartament";
            this.Load += new System.EventHandler(this.Form_add_Aprtament_Load);
            ((System.ComponentModel.ISupportInitialize)(this.adresyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aplikacjaHotelowaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adresyBindingSource1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox t_budynekID;
        private System.Windows.Forms.TextBox t_typID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox t_Numerpokoju;
        private System.Windows.Forms.BindingSource adresyBindingSource;
        private AplikacjaHotelowaDataSet aplikacjaHotelowaDataSet;
        private AplikacjaHotelowaDataSetTableAdapters.AdresyTableAdapter adresyTableAdapter;
        private System.Windows.Forms.BindingSource adresyBindingSource1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox t_Cena;
        private System.Windows.Forms.TextBox t_ID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}