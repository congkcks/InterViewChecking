namespace Bai_Tap_Dien_Tu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadText();
        }
        public void LoadText()
        {
            // Load text from file
            string path = "C:\\Users\\ACER\\source\\repos\\Bai Tap Dien Tu\\Bai Tap Dien Tu\\TaiLieu\\cauhoi.txt";
            string text = File.ReadAllText(path);
            richTextBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //check dap an o cac text box

        }


        private void baiTapDienTuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Form2();
            form.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "C")
            {
                textBox3.ForeColor = Color.Green;
            }
            else
            {
                textBox3.ForeColor = Color.Red;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "A")
            {
                textBox1.ForeColor = Color.Green;
            }
            else
            {
                textBox1.ForeColor = Color.Red;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "B")
            {
                textBox2.ForeColor = Color.Green;
            }
            else
            {
                textBox2.ForeColor = Color.Red;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "D")
            {
                textBox4.ForeColor = Color.Green;
            }
            else
            {
                textBox4.ForeColor = Color.Red;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "E")
            {
                textBox5.ForeColor = Color.Green;
            }
            else
            {
                textBox5.ForeColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "A";
            textBox2.Text = "B";
            textBox3.Text = "C";
            textBox4.Text = "D";
            textBox5.Text = "E";
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "A")
            {
                textBox1.ForeColor = Color.Green;
            }
            else
            {
                textBox1.ForeColor = Color.Red;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "A")
            {
                textBox1.ForeColor = Color.Green;
            }
            else
            {
                textBox1.ForeColor = Color.Red;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
