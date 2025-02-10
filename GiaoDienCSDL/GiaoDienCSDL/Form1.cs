using System;
using System.Data;
using System.Data.SqlClient;
using Exel=Microsoft.Office.Interop.Excel;
namespace GiaoDienCSDL
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=CONGKC\\SQLEXPRESS;Initial Catalog=QLBanHang;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Form1()
        {
            InitializeComponent();
            Form1_Load();
        }
        //hien thi du lieu trong datagitview

        private void Form1_Load()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = "SELECT * FROM tblMatHang";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            dataGridView1.DataSource = dataTable;

        }
        //viet ham them du lieu
        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //lay du lieu tu datagridview hien thi len textbox
            int i;
            i = dataGridView1.CurrentRow.Index;
            MaSp.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            tenSp.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            NgaySx.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            NgayHH.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            DonVi.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            Gia.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            GhiChu.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();


        }

        private void tenSp_TextChanged(object sender, EventArgs e)
        {

        }

        private void TImKiem_Click(object sender, EventArgs e)
        {

            //tim kiem voi tinh nang autocomplete
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM tblMatHang WHERE MaSP LIKE @tensp";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@tensp", "%" + textBox1.Text + "%");
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            dataGridView1.DataSource = dataTable;


        }

        private void Them_Click(object sender, EventArgs e)
        {

            string masp = MaSp.Text;
            string tensp = tenSp.Text;
            string ngaysx = NgaySx.Text;
            DateTime ngaysx1 = DateTime.Parse(ngaysx);
            string ngayhh = NgayHH.Text;
            DateTime ngayhh1 = DateTime.Parse(ngayhh);
            string donvi = DonVi.Text;
            string gia = Gia.Text;
            string ghichu = GhiChu.Text;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            //tim xem ma san pham da ton tai chua neu ton tai khong cho them vao va thong bao
            string query1 = "SELECT * FROM tblMatHang WHERE MaSP=@masp";
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@masp", masp);
            SqlDataReader reader = command1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            dataGridView1.DataSource = dataTable;
            if (dataTable.Rows.Count != 0)
            {
                MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show("MaSP Da Ton Tai", "Thong bao", messageBoxButtons);
                return;
            }
            else
            {
                string query = "INSERT INTO tblMatHang VALUES(@masp,@tensp,@ngaysx,@ngayhh,@donvi,@gia,@ghichu)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@masp", MaSp.Text);
                command.Parameters.AddWithValue("@tensp", tenSp.Text);
                command.Parameters.AddWithValue("@ngaysx", ngaysx1);
                command.Parameters.AddWithValue("@ngayhh", ngayhh1);
                command.Parameters.AddWithValue("@donvi", DonVi.Text);
                command.Parameters.AddWithValue("@gia", Gia.Text);
                command.Parameters.AddWithValue("@ghichu", GhiChu.Text);
                command.ExecuteNonQuery();
                Form1_Load();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string masp = MaSp.Text;
            string tensp = tenSp.Text;
            string ngaysx = NgaySx.Text;
            DateTime ngaysx1 = DateTime.Parse(ngaysx);
            string ngayhh = NgayHH.Text;
            DateTime ngayhh1 = DateTime.Parse(ngayhh);
            string donvi = DonVi.Text;
            string gia = Gia.Text;
            string ghichu = GhiChu.Text;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "";
            if (masp == "")
            {
                // khi khong tim thay san pham thi khong duoc update san pham va thoat chuong trinh
                MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show("Vui long nhap MaSP", "Thong bao", messageBoxButtons);
                return;

            }
            string query1 = "SELECT * FROM tblMatHang WHERE MaSP=@masp";
            // khi khong tim thay san pham thi khong duoc update san pham va thoat chuong trinh
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@masp", masp);
            SqlDataReader reader = command1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            if (dataTable.Rows.Count == 0)
            {
                MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show("MaSp Chua Ton Tai Vui Long Nhan Vao Tao Them", "Thong bao", messageBoxButtons);
                return;
            }

            if (masp != null)
            {
                query = "UPDATE tblMatHang SET TenSP=@tensp,NgaySX=@ngaysx,NgayHH=@ngayhh,DonVi=@donvi,DonGia=@gia,GhiChu=@ghichu WHERE MaSP=@masp";

            }
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@masp", MaSp.Text);
            command.Parameters.AddWithValue("@tensp", tenSp.Text);
            command.Parameters.AddWithValue("@ngaysx", ngaysx1);
            command.Parameters.AddWithValue("@ngayhh", ngayhh1);
            command.Parameters.AddWithValue("@donvi", DonVi.Text);
            command.Parameters.AddWithValue("@gia", Gia.Text);
            command.Parameters.AddWithValue("@ghichu", GhiChu.Text);
            command.ExecuteNonQuery();
            Form1_Load();
        }

        private void XuatFileExxel_Click(object sender, EventArgs e)
        {
            //xuat ra file exel va dung savedalalog de luu file
            //Khai báo và khởi tạo các đối tượng
            //Khai báo và khởi tạo các đối tượng
            Exel.Application exApp = new Exel.Application();
            Exel.Workbook exBook =
           exApp.Workbooks.Add(Exel.XlWBATemplate.xlWBATWorksheet);
            Exel.Worksheet exSheet = (Exel.Worksheet)exBook.Worksheets[1];
            //Định dạng tiêu đề
            exSheet.Cells[1, 1] = "Mã SP";
            exSheet.Cells[1, 2] = "Tên SP";
            exSheet.Cells[1, 3] = "Ngày SX";
            exSheet.Cells[1, 4] = "Ngày HH";
            exSheet.Cells[1, 5] = "Đơn Vị";
            exSheet.Cells[1, 6] = "Giá";
            exSheet.Cells[1, 7] = "Ghi Chú";
            //Định dạng font chữ
            exSheet.get_Range("A1", "G1").Font.Bold = true;
            //Lấy dữ liệu từ DataGridView
            //voi dang du lieu datetime thi phai chuyen ve dang string
            for (int i = 2; i <= dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j <= dataGridView1.Columns.Count; j++)
                {
                    var cellValue = dataGridView1.Rows[i - 1].Cells[j - 1].Value;
                    exSheet.Cells[i, j] = cellValue != null ? cellValue.ToString() : string.Empty;
                }
            }

            exSheet.Columns.AutoFit();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel file|*.xlsx";
            saveFileDialog1.Title = "Save an Excel File";
            saveFileDialog1.ShowDialog();
            exBook.SaveAs(saveFileDialog1.FileName);
            //sau do mo file len 
            exApp.Visible = true;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //tim kiem voi tinh nang autocomplete
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM tblMatHang WHERE TenSP LIKE @tensp";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@tensp", "%" + textBox1.Text + "%");
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            dataGridView1.DataSource = dataTable;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //xoa cot du lieu
            string masp = MaSp.Text;
            string tensp = tenSp.Text;
            string ngaysx = NgaySx.Text;
            DateTime ngaysx1 = DateTime.Parse(ngaysx);
            string ngayhh = NgayHH.Text;
            DateTime ngayhh1 = DateTime.Parse(ngayhh);
            string donvi = DonVi.Text;
            string gia = Gia.Text;
            string ghichu = GhiChu.Text;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "";
            if (masp == "")
            {
                MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show("Vui long nhap MaSP", "Thong bao", messageBoxButtons);
                return;

            }
            string query1 = "SELECT * FROM tblMatHang WHERE MaSP=@masp";
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@masp", masp);
            SqlDataReader reader = command1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            if (dataTable.Rows.Count == 0)
            {
                MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show("MaSp Chua Ton Tai Vui Long Nhan Vao Tao Them", "Thong bao", messageBoxButtons);
                return;
            }

            if (masp != null)
            {
                query = "DELETE FROM tblMatHang WHERE MaSP=@masp";

            }
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@masp", MaSp.Text);
            command.Parameters.AddWithValue("@tensp", tenSp.Text);
            command.Parameters.AddWithValue("@ngaysx", ngaysx1);
            command.Parameters.AddWithValue("@ngayhh", ngayhh1);
            command.Parameters.AddWithValue("@donvi", DonVi.Text);
            command.Parameters.AddWithValue("@gia", Gia.Text);
            command.Parameters.AddWithValue("@ghichu", GhiChu.Text);
            command.ExecuteNonQuery();
            Form1_Load();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Ban co muon thoat khong", "Thong bao", messageBoxButtons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //tim kiem voi tinh nang autocomplete
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM tblMatHang WHERE MaSP LIKE @tensp";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@tensp", "%" + textBox2.Text + "%");
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            dataGridView1.DataSource = dataTable;
        }
        //
    }
}
