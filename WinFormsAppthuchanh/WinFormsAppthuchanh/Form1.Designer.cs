namespace WinFormsAppthuchanh
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
            panel3 = new Panel();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            panel4 = new Panel();
            button5 = new Button();
            Diem = new TextBox();
            SoTinChi = new TextBox();
            TenMonHoc = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(418, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(651, 609);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(button4);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(8, 320);
            panel3.Name = "panel3";
            panel3.Size = new Size(621, 286);
            panel3.TabIndex = 1;
            panel3.MouseDown += panel3_MouseDown;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(141, 106);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 9;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(459, 21);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 8;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(131, 15);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 7;
            // 
            // button4
            // 
            button4.Location = new Point(428, 191);
            button4.Name = "button4";
            button4.Size = new Size(80, 37);
            button4.TabIndex = 6;
            button4.Text = "Thoát";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(301, 195);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 5;
            button3.Text = "Xóa";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(163, 195);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "Sửa";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(31, 195);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Tính";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 109);
            label3.Name = "label3";
            label3.Size = new Size(119, 20);
            label3.TabIndex = 2;
            label3.Text = "Điểm Trung Bình";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(284, 22);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 1;
            label2.Text = "Tổng Số Điểm";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 18);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 0;
            label1.Text = "Tổng Số Tín Chỉ";
            // 
            // panel2
            // 
            panel2.Controls.Add(listView1);
            panel2.Location = new Point(3, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(648, 269);
            panel2.TabIndex = 0;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listView1.Location = new Point(3, 28);
            listView1.Name = "listView1";
            listView1.Size = new Size(642, 224);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.ItemChecked += listView1_ItemChecked;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            listView1.KeyDown += listView1_KeyDown;
            listView1.MouseClick += listView1_MouseClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Ten Mon";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "So Tin Chi";
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Diem";
            columnHeader3.Width = 200;
            // 
            // panel4
            // 
            panel4.Controls.Add(button5);
            panel4.Controls.Add(Diem);
            panel4.Controls.Add(SoTinChi);
            panel4.Controls.Add(TenMonHoc);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(12, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(383, 606);
            panel4.TabIndex = 1;
            // 
            // button5
            // 
            button5.Location = new Point(96, 323);
            button5.Name = "button5";
            button5.Size = new Size(159, 58);
            button5.TabIndex = 7;
            button5.Text = "Thêm";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Diem
            // 
            Diem.Location = new Point(130, 220);
            Diem.Name = "Diem";
            Diem.Size = new Size(125, 27);
            Diem.TabIndex = 6;
            // 
            // SoTinChi
            // 
            SoTinChi.Location = new Point(130, 137);
            SoTinChi.Name = "SoTinChi";
            SoTinChi.Size = new Size(125, 27);
            SoTinChi.TabIndex = 5;
            // 
            // TenMonHoc
            // 
            TenMonHoc.Location = new Point(130, 77);
            TenMonHoc.Name = "TenMonHoc";
            TenMonHoc.Size = new Size(125, 27);
            TenMonHoc.TabIndex = 4;
            TenMonHoc.TextChanged += TenMonHoc_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 227);
            label7.Name = "label7";
            label7.Size = new Size(45, 20);
            label7.TabIndex = 3;
            label7.Text = "Điểm";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 140);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 2;
            label6.Text = "Số Tín Chỉ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 80);
            label5.Name = "label5";
            label5.Size = new Size(97, 20);
            label5.TabIndex = 1;
            label5.Text = "Tên Môn Học";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 20);
            label4.Name = "label4";
            label4.Size = new Size(175, 20);
            label4.TabIndex = 0;
            label4.Text = "Thông Tin Đến Sinh Viên ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1081, 633);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Panel panel3;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel4;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button button5;
        private TextBox Diem;
        private TextBox SoTinChi;
        private TextBox TenMonHoc;
    }
}
