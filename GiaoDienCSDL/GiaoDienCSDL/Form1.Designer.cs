namespace GiaoDienCSDL
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
            XuatFileExxel = new Button();
            GhiChu = new TextBox();
            label13 = new Label();
            Gia = new TextBox();
            DonVi = new TextBox();
            NgayHH = new DateTimePicker();
            NgaySx = new DateTimePicker();
            tenSp = new TextBox();
            MaSp = new TextBox();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            TImKiem = new Button();
            Them = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1070, 86);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(387, 24);
            label1.Name = "label1";
            label1.Size = new Size(243, 35);
            label1.TabIndex = 0;
            label1.Text = "QUAN LI SAN PHAM";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(XuatFileExxel);
            panel2.Controls.Add(GhiChu);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(Gia);
            panel2.Controls.Add(DonVi);
            panel2.Controls.Add(NgayHH);
            panel2.Controls.Add(NgaySx);
            panel2.Controls.Add(tenSp);
            panel2.Controls.Add(MaSp);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.ForeColor = Color.Black;
            panel2.Location = new Point(12, 104);
            panel2.Name = "panel2";
            panel2.Size = new Size(1070, 505);
            panel2.TabIndex = 1;
            // 
            // XuatFileExxel
            // 
            XuatFileExxel.Location = new Point(518, 56);
            XuatFileExxel.Name = "XuatFileExxel";
            XuatFileExxel.Size = new Size(125, 29);
            XuatFileExxel.TabIndex = 25;
            XuatFileExxel.Text = "Xuất File Exel";
            XuatFileExxel.UseVisualStyleBackColor = true;
            XuatFileExxel.Click += XuatFileExxel_Click;
            // 
            // GhiChu
            // 
            GhiChu.Location = new Point(782, 371);
            GhiChu.Multiline = true;
            GhiChu.Name = "GhiChu";
            GhiChu.Size = new Size(250, 84);
            GhiChu.TabIndex = 24;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(700, 12);
            label13.Name = "label13";
            label13.Size = new Size(56, 20);
            label13.TabIndex = 23;
            label13.Text = "Chi tiet";
            // 
            // Gia
            // 
            Gia.Location = new Point(781, 321);
            Gia.Multiline = true;
            Gia.Name = "Gia";
            Gia.Size = new Size(250, 34);
            Gia.TabIndex = 21;
            // 
            // DonVi
            // 
            DonVi.Location = new Point(782, 260);
            DonVi.Multiline = true;
            DonVi.Name = "DonVi";
            DonVi.Size = new Size(250, 34);
            DonVi.TabIndex = 20;
            // 
            // NgayHH
            // 
            NgayHH.Format = DateTimePickerFormat.Short;
            NgayHH.Location = new Point(781, 198);
            NgayHH.Name = "NgayHH";
            NgayHH.Size = new Size(250, 27);
            NgayHH.TabIndex = 19;
            // 
            // NgaySx
            // 
            NgaySx.Format = DateTimePickerFormat.Short;
            NgaySx.Location = new Point(781, 141);
            NgaySx.Name = "NgaySx";
            NgaySx.Size = new Size(250, 27);
            NgaySx.TabIndex = 18;
            // 
            // tenSp
            // 
            tenSp.Location = new Point(782, 84);
            tenSp.Multiline = true;
            tenSp.Name = "tenSp";
            tenSp.Size = new Size(250, 34);
            tenSp.TabIndex = 17;
            tenSp.TextChanged += tenSp_TextChanged;
            // 
            // MaSp
            // 
            MaSp.Location = new Point(782, 44);
            MaSp.Multiline = true;
            MaSp.Name = "MaSp";
            MaSp.Size = new Size(249, 34);
            MaSp.TabIndex = 16;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(700, 392);
            label12.Name = "label12";
            label12.Size = new Size(60, 20);
            label12.TabIndex = 13;
            label12.Text = "Ghi Chu";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(700, 335);
            label11.Name = "label11";
            label11.Size = new Size(31, 20);
            label11.TabIndex = 12;
            label11.Text = "Gia";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(700, 263);
            label10.Name = "label10";
            label10.Size = new Size(54, 20);
            label10.TabIndex = 11;
            label10.Text = "Don Vi";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(700, 203);
            label9.Name = "label9";
            label9.Size = new Size(66, 20);
            label9.TabIndex = 10;
            label9.Text = "NgayHH";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(700, 148);
            label8.Name = "label8";
            label8.Size = new Size(61, 20);
            label8.TabIndex = 9;
            label8.Text = "NgaySX";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(700, 98);
            label7.Name = "label7";
            label7.Size = new Size(48, 20);
            label7.TabIndex = 8;
            label7.Text = "TenSP";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(700, 47);
            label6.Name = "label6";
            label6.Size = new Size(46, 20);
            label6.TabIndex = 7;
            label6.Text = "MaSP";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(25, 160);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(618, 331);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 112);
            label5.Name = "label5";
            label5.Size = new Size(62, 20);
            label5.TabIndex = 5;
            label5.Text = "Ket Qua";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(342, 58);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 27);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(95, 58);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(148, 27);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(276, 61);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 2;
            label4.Text = "Mã SP";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 61);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 1;
            label3.Text = "Tên SP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 12);
            label2.Name = "label2";
            label2.Size = new Size(141, 20);
            label2.TabIndex = 0;
            label2.Text = "Tìm Kiếm Sản Phẩm";
            // 
            // TImKiem
            // 
            TImKiem.Location = new Point(37, 672);
            TImKiem.Name = "TImKiem";
            TImKiem.Size = new Size(94, 29);
            TImKiem.TabIndex = 2;
            TImKiem.Text = "Tìm Kiếm";
            TImKiem.UseVisualStyleBackColor = true;
            TImKiem.Click += TImKiem_Click;
            // 
            // Them
            // 
            Them.Location = new Point(172, 672);
            Them.Name = "Them";
            Them.Size = new Size(94, 29);
            Them.TabIndex = 3;
            Them.Text = "Thêm ";
            Them.UseVisualStyleBackColor = false;
            Them.Click += Them_Click;
            // 
            // button4
            // 
            button4.Location = new Point(324, 672);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 4;
            button4.Text = "Sửa";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(466, 672);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 5;
            button5.Text = "Xóa";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(613, 672);
            button6.Name = "button6";
            button6.Size = new Size(86, 29);
            button6.TabIndex = 6;
            button6.Text = "Thoát";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1094, 746);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(Them);
            Controls.Add(TImKiem);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Label label5;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private DateTimePicker NgaySx;
        private TextBox tenSp;
        private TextBox MaSp;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox Gia;
        private TextBox DonVi;
        private DateTimePicker NgayHH;
        private Label label13;
        private TextBox GhiChu;
        private Button TImKiem;
        private Button Them;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button XuatFileExxel;
    }
}
