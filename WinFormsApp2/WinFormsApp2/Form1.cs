namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textBoxValue = nhapbankinh.Text;
            int intValue = int.Parse(textBoxValue);
            // Use the intValue variable for further processing
            double chuvi = intValue * 3.14;
            double dientich = intValue * intValue * 3.14;
            textBox2.Text = dientich.ToString();
            textBox1.Text = chuvi.ToString();
        }

        private void LamLai_Click(object sender, EventArgs e)
        {
            nhapbankinh.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }
    }
}
