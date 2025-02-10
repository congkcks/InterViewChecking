namespace Bai12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = (textBox1.Text).Trim();
            foreach (char c in str)
            {
                if (char.IsLetter(c) == true)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("Chuỗi có chứa ký tự chữ", "Thông báo", buttons);
                    return;
                }
            }
            listBox1.Items.Add(str);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index == -1)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Chưa chọn phần tử cần xóa", "Thông báo", buttons);
                return;
            }
            listBox1.Items.RemoveAt(index);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string str = listBox1.SelectedItem.ToString();
            int n= int.Parse(str);
            if (isPrime(n))
            {
                label2.Text = "Là số nguyên tố";
            }
            else
            {
                label2.Text = "Không phải số nguyên tố";
            }
            
        }



        //ham kiem tra so nguyen to
        public bool isPrime(int n)
        {
            if (n < 2)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
