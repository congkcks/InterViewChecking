namespace Bai12
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
            button2 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            button5 = new Button();
            button4 = new Button();
            listBox1 = new ListBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            label2 = new Label();
            button3 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(44, 26);
            panel1.Name = "panel1";
            panel1.Size = new Size(384, 173);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(167, 116);
            button2.Name = "button2";
            button2.Size = new Size(103, 37);
            button2.TabIndex = 3;
            button2.Text = "Xóa";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(55, 116);
            button1.Name = "button1";
            button1.Size = new Size(88, 39);
            button1.TabIndex = 2;
            button1.Text = "Thêm ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(167, 47);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(185, 34);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 54);
            label1.Name = "label1";
            label1.Size = new Size(134, 20);
            label1.TabIndex = 0;
            label1.Text = "Nhập Số Tự Nhiên ";
            // 
            // panel2
            // 
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(listBox1);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(453, 26);
            panel2.Name = "panel2";
            panel2.Size = new Size(287, 395);
            panel2.TabIndex = 1;
            // 
            // button5
            // 
            button5.Location = new Point(75, 333);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 3;
            button5.Text = "Thoát";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(75, 271);
            button4.Name = "button4";
            button4.Size = new Size(108, 36);
            button4.TabIndex = 2;
            button4.Text = "Làm Mới ";
            button4.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(75, 47);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(115, 204);
            listBox1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 9);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 0;
            label3.Text = "Dãy Số";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(button3);
            groupBox1.Location = new Point(44, 252);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(384, 162);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kiêm Tra Số Nguyên Tố";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 111);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 1;
            // 
            // button3
            // 
            button3.Location = new Point(40, 45);
            button3.Name = "button3";
            button3.Size = new Size(103, 36);
            button3.TabIndex = 0;
            button3.Text = "Kiểm Tra";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button2;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Panel panel2;
        private GroupBox groupBox1;
        private Label label2;
        private Button button3;
        private Button button5;
        private Button button4;
        private ListBox listBox1;
        private Label label3;
    }
}
