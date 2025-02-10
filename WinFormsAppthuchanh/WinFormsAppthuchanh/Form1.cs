using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using System;
using System.Data.SqlClient;
namespace WinFormsAppthuchanh
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=CONGKC\\SQLEXPRESS;Initial Catalog=KetNoiCSDL;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Persons";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                string tenmonhoc = reader.GetString(1);
                int sotinchi = reader.GetInt32(0);
                int diem = reader.GetInt32(2);
                ListViewItem item = new ListViewItem(tenmonhoc);
                item.SubItems.Add(sotinchi.ToString());
                item.SubItems.Add(diem.ToString());
                listView1.Items.Add(item);
            }
            connection.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //them vao listview
            string sotinchi = SoTinChi.Text;
            string tenmonhoc = TenMonHoc.Text;
            string diem = Diem.Text;
            //
            ListViewItem item = new ListViewItem(tenmonhoc);
            item.SubItems.Add(sotinchi);
            item.SubItems.Add(diem);
            // Add the item to the ListView
            listView1.Items.Add(item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tính tổng số tín chỉ và tổng số điểm
            int tongSoTinChi = 0;
            double tongSoDiem = 0;

            foreach (ListViewItem item in listView1.Items)
            {
                int sotinchi = int.Parse(item.SubItems[1].Text);
                double diem = double.Parse(item.SubItems[2].Text);

                tongSoTinChi += sotinchi;
                tongSoDiem += diem;
            }

            // Hiển thị kết quả vào TextBox
            textBox1.Text = tongSoTinChi.ToString();
            textBox2.Text = tongSoDiem.ToString();
            textBox3.Text = (tongSoDiem / tongSoTinChi).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show("Bạn có muốn thoát không?", "Thong Bao", buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
            {
                return;
            }
            ListViewItem ls= listView1.SelectedItems[0];
            if (ls != null) { 
                TenMonHoc.Text = ls.Text;
                SoTinChi.Text = ls.Text;
                Diem.Text = ls.Text;
            }

        }

        private void TenMonHoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int index = listView1.CheckedItems.IndexOf(e.Item);
            ListViewItem item = listView1.Items[index];
            TenMonHoc.Text = item.SubItems[0].Text;
            SoTinChi.Text = item.SubItems[0].Text;
            Diem.Text = item.SubItems[0].Text;
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hit = listView1.HitTest(e.Location);
            ListViewItem item = hit.Item;
            ListViewItem.ListViewSubItem subItem = hit.SubItem;

            if (item != null && subItem != null)
            {
                int subItemIndex = item.SubItems.IndexOf(subItem);

                // Display the text of the selected subitem
                switch (subItemIndex)
                {
                    case 0:
                        TenMonHoc.Text = subItem.Text;
                        break;
                    case 1:
                        SoTinChi.Text = subItem.Text;
                        break;
                    case 2:
                        Diem.Text = subItem.Text;
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
