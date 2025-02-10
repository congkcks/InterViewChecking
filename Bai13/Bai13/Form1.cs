namespace Bai13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;
            label2.Text = "Day So Nhap Vao Tu Ban Phim La " + textBox1.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] a = textBox1.Text.Split(' ');
            Array.Sort(a);
            label3.Text = "So Duong Co Gia Tri Nho Nhat La " + a[0];

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = textBox2.Text;
            string[] b = textBox1.Text.Split(" ");
            int vitri = 0;
            foreach (string item in b)
            {
                vitri++;
                if (item == s)
                {
                    break;

                }
            }
            MessageBox.Show("Vi Tri Cua K Trong Day La" + vitri);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            label2.Text = "";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Ban Co Muon Thoat Khong", "Thong Bao", buttons);
            if (result == DialogResult.Yes)
            {
                   Application.Exit();
            }
            else
            {
                MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show("Ban Da Chon Khong Thoat", "Thong Bao", buttons1);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = textBox2.Text;
            string[] b = textBox1.Text.Split(" ");
            int vitri = 0;
            foreach (string item in b)
            {
                vitri++;
                if (item == s)
                {
                    break;

                }
            }
            MessageBox.Show("Vi Tri Cua K Trong Day La" + vitri);
        }
    }

}
