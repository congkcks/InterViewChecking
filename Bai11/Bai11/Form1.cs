using System.Security.Permissions;

namespace Bai11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form1_Load();
        }
        public void Form1_Load()
        {
            //.vnTime, .vnTimeH, .vnArial,
            //.vnArialH, .vnUniverse, .vnUniverseH
            foreach (FontFamily font in FontFamily.Families)
            {
                comboBox1.Items.Add(font.Name);
            }
            for (int i = 1; i < 30; i++)
            {
                comboBox2.Items.Add(i);
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (int.TryParse(comboBox2.Text, out int fontSize))
            {
                fontSize = int.Parse(comboBox2.Text);
                richTextBox1.Font = new Font(comboBox1.Text, fontSize);
            }
            else
            {
                MessageBox.Show("Please select a valid font size.");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(comboBox1.Text, int.Parse(comboBox2.Text));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(comboBox1.Text, int.Parse(comboBox2.Text), FontStyle.Bold);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(comboBox1.Text, int.Parse(comboBox2.Text), FontStyle.Italic);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            richTextBox1.Font = new Font(comboBox1.Text, int.Parse(comboBox2.Text), FontStyle.Underline);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Color.Red;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Color.Green;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show("Ban Co Muon Thoat Khong ", "Thong Bao", buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }
    }
}
