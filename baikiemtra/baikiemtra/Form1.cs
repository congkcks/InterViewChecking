using System.Configuration;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data;
namespace BaiKiemTra
{
    public partial class Form1 : Form
    {
        string connectionstring = "Data Source=CONGKC\\SQLEXPRESS;Initial Catalog=QuanLyNhanVien;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Form1()
        {
            InitializeComponent();
            Form_Load();


        }
        public void Form_Load()
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string query = "select * from NhanVien";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            connection.Close();
            comboBox1.Items.Add("Kinh Doanh");
            comboBox1.Items.Add("Nhan Su");
            comboBox1.Items.Add("Ke Toan");
            comboBox1.Items.Add("Ky Thuat");
            comboBox1.Items.Add("Thu Ngan");
            comboBox1.Items.Add("Bao Ve");

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //hien thi thong tin nen text box
            int i;
            i = dataGridView1.CurrentRow.Index;
            //ma nhan vien
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //ten nhan vien
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            //SO DT
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            //gioi Tinh
            if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "Nam")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox2.Checked = true;
            }
            //phong ban
            comboBox1.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            //muc luong
            textBox4.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();





        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //add  cac phong ban vao
            comboBox1.Items.Add("Kinh Doanh");
            comboBox1.Items.Add("Nhan Su");
            comboBox1.Items.Add("Ke Toan");
            comboBox1.Items.Add("Ky Thuat");
            comboBox1.Items.Add("Thu Ngan");
            comboBox1.Items.Add("Bao Ve");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //them nhan vien
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string query = "INSERT INTO NhanVien (MaNV, TenNV, SoDT, GioiTinh, PhongBan, MucLuong) VALUES (@MaNV, @TenNV, @SoDT, @GioiTinh, @PhongBan, @MucLuong)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MaNV", textBox1.Text);
            command.Parameters.AddWithValue("@TenNV", textBox2.Text);
            command.Parameters.AddWithValue("@SoDT", textBox3.Text);
            if (checkBox1.Checked == true)
            {
                command.Parameters.AddWithValue("@GioiTinh", "Nam");
            }
            else
            {
                command.Parameters.AddWithValue("@GioiTinh", "Nu");
            }
            command.Parameters.AddWithValue("@PhongBan", comboBox1.Text);
            command.Parameters.AddWithValue("@MucLuong", textBox4.Text);
            command.ExecuteNonQuery();
            connection.Close();
            Form_Load();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // luu anh tu picturebox vao database
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imageBytes = ms.ToArray();

            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string query = "update NhanVien set TenNV=@TenNV,SoDT=@SoDT,GioiTinh=@GioiTinh,PhongBan=@PhongBan,MucLuong=@MucLuong,Anh=@Anh where MaNV=@MaNV";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MaNV", textBox1.Text);
            command.Parameters.AddWithValue("@TenNV", textBox2.Text);
            command.Parameters.AddWithValue("@SoDT", textBox3.Text);
            if (checkBox1.Checked == true)
            {
                command.Parameters.AddWithValue("@GioiTinh", "Nam");
            }
            else
            {
                command.Parameters.AddWithValue("@GioiTinh", "Nu");
            }
            command.Parameters.AddWithValue("@PhongBan", comboBox1.Text);
            command.Parameters.AddWithValue("@MucLuong", textBox4.Text);
            command.Parameters.AddWithValue("@Anh", imageBytes);
            command.ExecuteNonQuery();
            connection.Close();
            Form_Load();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            //xoa nhan vien
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string query = "delete from NhanVien where MaNV=@MaNV";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MaNV", textBox1.Text);
            command.ExecuteNonQuery();
            connection.Close();
            Form_Load();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //thoat chuong trin (buttons == MessageBoxButtons.YesNo)


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //khi click khi panel1 se mo openfiledialog va tai anh len panel1
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
            }
            //mo file anh


        }
        private void DisplayImage(byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                pictureBox1.Image = Image.FromStream(ms);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //hien thi anh
            int i;
            i = dataGridView1.CurrentRow.Index;
            byte[] imageBytes = (byte[])dataGridView1.Rows[i].Cells[6].Value;
            DisplayImage(imageBytes);
        }
    }
}
