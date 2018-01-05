namespace AplikacjaHotelowa.add_forms
{
    partial class Form_add_udogodnienia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_add_udogodnienia));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.t_Opis = new System.Windows.Forms.TextBox();
            this.t_Nazwa = new System.Windows.Forms.TextBox();
            this.t_ID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(90, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 39);
            this.button1.TabIndex = 14;
            this.button1.Text = "Dodaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.t_Opis);
            this.groupBox2.Controls.Add(this.t_Nazwa);
            this.groupBox2.Controls.Add(this.t_ID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 177);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Udogodnienie";
            // 
            // t_Opis
            // 
            this.t_Opis.Location = new System.Drawing.Point(111, 72);
            this.t_Opis.Multiline = true;
            this.t_Opis.Name = "t_Opis";
            this.t_Opis.Size = new System.Drawing.Size(146, 86);
            this.t_Opis.TabIndex = 8;
            // 
            // t_Nazwa
            // 
            this.t_Nazwa.Location = new System.Drawing.Point(111, 42);
            this.t_Nazwa.Name = "t_Nazwa";
            this.t_Nazwa.Size = new System.Drawing.Size(146, 20);
            this.t_Nazwa.TabIndex = 7;
            // 
            // t_ID
            // 
            this.t_ID.Enabled = false;
            this.t_ID.Location = new System.Drawing.Point(111, 16);
            this.t_ID.Name = "t_ID";
            this.t_ID.Size = new System.Drawing.Size(146, 20);
            this.t_ID.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Opis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nazwa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // Form_add_udogodnienia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 244);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_add_udogodnienia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form_add_udogodnienia";
            this.Load += new System.EventHandler(this.Form_add_udogodnienia_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox t_Opis;
        private System.Windows.Forms.TextBox t_Nazwa;
        private System.Windows.Forms.TextBox t_ID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}