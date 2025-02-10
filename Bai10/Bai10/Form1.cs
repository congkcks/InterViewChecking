namespace Bai10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //kiem tra xem cac textbox co nhap so hay khong
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Vui lòng nhập đủ số a và b", "Thông báo", buttons);
                return;
            }
            //ham kiem tra ki tu
            foreach (char c in textBox1.Text)
            {
                if (char.IsLetter(c))
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show("Vui lòng nhập số", "Thông báo", buttons);
                    return;
                }
            }
            foreach (char c in textBox2.Text)
            {
                if (char.IsLetter(c))
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show("Vui lòng nhập số", "Thông báo", buttons);
                    return;
                }
            }
            //khai bao bien a va b
            if (radioButton1.Checked)
            {
                textBox4.Text = giaiphuongtrinhbac1(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
            }
            if (radioButton2.Checked)
            {
                if (textBox3.Text == "")
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show("Vui lòng nhập số c", "Thông báo", buttons);
                    return;
                }
                foreach (char c in textBox3.Text)
                {
                    if (char.IsLetter(c))
                    {
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBox.Show("Vui lòng nhập số", "Thông báo", buttons);
                        return;
                    }
                }
                textBox4.Text = giaiphuongtrinhbac2(double.Parse(textBox1.Text), double.Parse(textBox2.Text), double.Parse(textBox3.Text));
            }

        }
        public string giaiphuongtrinhbac1(double a, double b)
        {
            if (a == 0)
            {
                if (b == 0)
                {
                    return "Phương trình có vô số nghiệm";
                }
                else
                {
                    return "Phương trình vô nghiệm";
                }
            }
            else
            {
                return "Phương trình có nghiệm x = " + (-b / a);
            }
        }
        public string giaiphuongtrinhbac2(double a, double b, double c)
        {
            double delta = b * b - 4 * a * c;
            if (delta < 0)
            {
                return "Phương trình vô nghiệm";
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                return "Phương trình có nghiệm kép x = " + x;
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                return "Phương trình có 2 nghiệm phân biệt: x1 = " + x1 + ", x2 = " + x2;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt| Keys.T))
            {
                button2_Click(null,null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
