namespace ToDo
{
    partial class renkForm
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.circularButton1 = new ToDo.CircularButton();
            this.circularButton2 = new ToDo.CircularButton();
            this.circularButton3 = new ToDo.CircularButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // circularButton1
            // 
            this.circularButton1.BackColor = System.Drawing.SystemColors.Highlight;
            this.circularButton1.FlatAppearance.BorderSize = 0;
            this.circularButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton1.Location = new System.Drawing.Point(305, 150);
            this.circularButton1.Name = "circularButton1";
            this.circularButton1.Size = new System.Drawing.Size(116, 95);
            this.circularButton1.TabIndex = 0;
            this.circularButton1.Text = "Tehlike Renk";
            this.circularButton1.UseVisualStyleBackColor = false;
            this.circularButton1.Click += new System.EventHandler(this.circularButton1_Click);
            // 
            // circularButton2
            // 
            this.circularButton2.BackColor = System.Drawing.SystemColors.Highlight;
            this.circularButton2.FlatAppearance.BorderSize = 0;
            this.circularButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton2.Location = new System.Drawing.Point(461, 150);
            this.circularButton2.Name = "circularButton2";
            this.circularButton2.Size = new System.Drawing.Size(116, 95);
            this.circularButton2.TabIndex = 1;
            this.circularButton2.Text = "Uyarı Renk";
            this.circularButton2.UseVisualStyleBackColor = false;
            this.circularButton2.Click += new System.EventHandler(this.circularButton2_Click);
            // 
            // circularButton3
            // 
            this.circularButton3.BackColor = System.Drawing.SystemColors.Highlight;
            this.circularButton3.FlatAppearance.BorderSize = 0;
            this.circularButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton3.Location = new System.Drawing.Point(612, 150);
            this.circularButton3.Name = "circularButton3";
            this.circularButton3.Size = new System.Drawing.Size(116, 95);
            this.circularButton3.TabIndex = 2;
            this.circularButton3.Text = "Genel Renk";
            this.circularButton3.UseVisualStyleBackColor = false;
            this.circularButton3.Click += new System.EventHandler(this.circularButton3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(143, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(24, 58);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tehlike Günü";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Uyarı Günü";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(78, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "Kaydet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Location = new System.Drawing.Point(12, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 240);
            this.panel1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 9;
            // 
            // renkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.circularButton3);
            this.Controls.Add(this.circularButton2);
            this.Controls.Add(this.circularButton1);
            this.Name = "renkForm";
            this.Text = "renkForm";
            this.Load += new System.EventHandler(this.renkForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private CircularButton circularButton1;
        private CircularButton circularButton2;
        private CircularButton circularButton3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}