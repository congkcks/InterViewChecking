namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            Thoat = new Button();
            LamLai = new Button();
            Tinh = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            nhapbankinh = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(6, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(684, 106);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(684, 106);
            label1.TabIndex = 0;
            label1.Text = "TINH DIEN TICH VA CHU VI";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.UseMnemonic = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(6, 139);
            panel2.Name = "panel2";
            panel2.Size = new Size(684, 353);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(Thoat);
            panel3.Controls.Add(LamLai);
            panel3.Controls.Add(Tinh);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(nhapbankinh);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(6, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(700, 700);
            panel3.TabIndex = 0;
            // 
            // Thoat
            // 
            Thoat.Location = new Point(432, 271);
            Thoat.Name = "Thoat";
            Thoat.Size = new Size(128, 47);
            Thoat.TabIndex = 8;
            Thoat.Text = "Thoat";
            Thoat.UseVisualStyleBackColor = true;
            // 
            // LamLai
            // 
            LamLai.Location = new Point(260, 267);
            LamLai.Name = "LamLai";
            LamLai.Size = new Size(106, 54);
            LamLai.TabIndex = 7;
            LamLai.Text = "LamLai";
            LamLai.UseVisualStyleBackColor = true;
            LamLai.Click += LamLai_Click;
            // 
            // Tinh
            // 
            Tinh.Location = new Point(57, 264);
            Tinh.Name = "Tinh";
            Tinh.Size = new Size(122, 54);
            Tinh.TabIndex = 6;
            Tinh.Text = "Tinh";
            Tinh.UseVisualStyleBackColor = true;
            Tinh.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(271, 159);
            textBox2.Margin = new Padding(0);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(275, 27);
            textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(271, 101);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(275, 27);
            textBox1.TabIndex = 4;
            // 
            // nhapbankinh
            // 
            nhapbankinh.Location = new Point(271, 36);
            nhapbankinh.Multiline = true;
            nhapbankinh.Name = "nhapbankinh";
            nhapbankinh.Size = new Size(275, 29);
            nhapbankinh.TabIndex = 3;
            nhapbankinh.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(20, 140);
            label4.Name = "label4";
            label4.Size = new Size(228, 59);
            label4.TabIndex = 2;
            label4.Text = "Dien Tich";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(20, 87);
            label3.Name = "label3";
            label3.Size = new Size(228, 32);
            label3.TabIndex = 1;
            label3.Text = "Chu Vi";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(20, 22);
            label2.Name = "label2";
            label2.Size = new Size(245, 42);
            label2.TabIndex = 0;
            label2.Text = "Nhap ban Kinh";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(721, 504);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private Label label2;
        private Label label4;
        private Label label3;
        private TextBox textBox2;
        private TextBox textBox1;
        public TextBox nhapbankinh;
        private Button Thoat;
        private Button LamLai;
        private Button Tinh;
    }
}
