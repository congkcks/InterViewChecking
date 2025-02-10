using System.Windows.Forms;

namespace BaiLAm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadForm();
        }
        public void LoadForm()
        {
            // add vao combo 1 ,3,6,12
            for (int i = 1; i <= 12; i++)
            {
                if (i == 1 || i == 3 || i == 6 || i == 12)
                {
                    comboBox1.Items.Add(i);
                }
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string chuoi = textBox1.Text;
            label7.Text = "";
            if (chuoi.Length == 0)
            {
                label7.Text = "Chưa Nhập Mã Khách Hàng";
                return;
            }
            if (chuoi.Length != 6)
            {
                label7.Text = "Mã Khách Hàng Phải Đủ 6 Chữ Số";
                return;
            }
            if (chuoi[0] == '0')
            {
                label7.Text = "Mã Khách Hàng Hợp Lệ";
                return;
            }

            foreach (char c in chuoi)
            {
                if (!char.IsDigit(c))
                {
                    label7.Text = "Mã Khách Khàng Không Hợp lệ";
                    return;
                }
            }
            label7.Text = "Mã Khách Hàng Hợp Lệ";

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string chuoi = textBox4.Text;
            label8.Text = "";
            if (chuoi.Length == 0)
            {
                label8.Text = "Chua Nhap So Tien";
                return;
            }

            if (chuoi[0] == '0')
            {
                label8.Text = "Số tiền không hợp lệ";
                return;
            }

            foreach (char c in chuoi)
            {
                if (!char.IsDigit(c))
                {
                    label8.Text = "Số tiền không hợp lệ";
                    return;
                }
            }
            label8.Text = "Sô Tiền Hợp Lệ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Khi người dùng chọn nút “Thêm mới” (hoặc ấn tổ hợp phím Alt + M) thì đặt tất cả các
            //TextBox thành rỗng, các OptionButton “Loại tiết kiệm” chưa được chọn, ComboBox
            //“Thời gian gửi” chưa có giá trị. (1 điểm)
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            comboBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maKhachHang = textBox1.Text;
            string hoTen = textBox2.Text;
            string diaChi = textBox3.Text;
            string ngayGui = textBox5.Text;
            string soTien = textBox4.Text;

            // Kiểm tra mã khách hàng có đủ 6 chữ số hay không
            if (maKhachHang.Length != 6)
            {
                MessageBox.Show("Mã Khách Hàng Phải Đủ 6 Chữ Số");
                return;
            }

            // Kiểm tra họ tên, địa chỉ khách hàng có rỗng không
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("Họ Tên và Địa Chỉ Khách Hàng Không Được Rỗng");
                return;
            }

            // Kiểm tra ngày gửi có đúng định dạng ngày tháng không
            if (!DateTime.TryParse(ngayGui, out DateTime ngayGuiDateTime))
            {
                MessageBox.Show("Ngày Gửi Không Hợp Lệ");
                return;
            }

            // Kiểm tra số tiền có hợp lệ không
            if (!decimal.TryParse(soTien, out decimal tienGui) || tienGui <= 0)
            {
                MessageBox.Show("Số Tiền Gửi Không Hợp Lệ");
                return;
            }

            // Tính tiền lãi
            decimal laiSuat = 0;
            if (comboBox1.SelectedItem != null)
            {
                int thoiGianGui = (int)comboBox1.SelectedItem;
                if (radioButton1.Checked)
                {
                    // Loại tiết kiệm Thường
                    switch (thoiGianGui)
                    {
                        case 1:
                            laiSuat = 0.06m;
                            break;
                        case 3:
                            laiSuat = 0.07m;
                            break;
                        case 6:
                            laiSuat = 0.08m;
                            break;
                        case 12:
                            laiSuat = 0.09m;
                            break;
                    }
                }
                else if (radioButton2.Checked)
                {
                    // Loại tiết kiệm Phát lộc
                    switch (thoiGianGui)
                    {
                        case 1:
                            laiSuat = 0.07m;
                            break;
                        case 3:
                            laiSuat = 0.08m;
                            break;
                        case 6:
                            laiSuat = 0.09m;
                            break;
                        case 12:
                            laiSuat = 0.1m;
                            break;
                    }
                }
            }

            // Tính tiền lãi
            decimal tienLai = tienGui * laiSuat;

            // Thêm thông tin khách hàng và số tiền lãi vào danh sách khách hàng
            string thongTinKhachHang = $"Mã Khách Hàng: {maKhachHang}\nHọ Tên: {hoTen}\nĐịa Chỉ: {diaChi}\nNgày Gửi: {ngayGui}\nSố Tiền Gửi: {tienGui}\nSố Tiền Lãi: {tienLai}";
            richTextBox1.Text += thongTinKhachHang +"";


            // Reset các trường nhập liệu
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            comboBox1.SelectedItem = null;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label9.Text = "";
            //kiem tra xem co phai dang datetime khong 
            string ngaygui = textBox5.Text;
            if(DateTime.TryParse(ngaygui, out DateTime dt) == false)
            {
                label9.Text = "Ngày Gửi Không Hợp Lệ";
                return;
            }
            else
            {
                label9.Text = "Ngày Gửi Hop Le";
            }
            label9.Text = "Ngày Gửi Hợp Lệ";
            
        }
    }
}
