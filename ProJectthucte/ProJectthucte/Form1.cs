using ProJectthucte.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProJectthucte
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<string, Khoa> CSDL = new Dictionary<string, Khoa>();

        private void Form1_Load(object sender, EventArgs e)
        {
            LamGiaDuLieu();
            HienThiLenTreeView();
        }

        public void HienThiLenTreeView()
        {
            tvKhoa.Nodes.Clear();
            foreach (KeyValuePair<string, Khoa> item in CSDL)
            {
                Khoa kh = item.Value;
                TreeNode nodeKhoa = new TreeNode(kh.tenkhoa);
                nodeKhoa.Tag = kh;
                tvKhoa.Nodes.Add(nodeKhoa);
                foreach (KeyValuePair<string, Lop> item1 in kh.lop)
                {
                    Lop lop1 = item1.Value;
                    TreeNode nodelop = new TreeNode(lop1.tenlop);
                    nodelop.Tag = lop1;
                    nodeKhoa.Nodes.Add(nodelop);
                }
            }
            tvKhoa.ExpandAll();
        }

        public void LamGiaDuLieu()
        {
            Khoa cntt = new Khoa() { tenkhoa = "CNTT", makhoa = "01" };
            Khoa dientu = new Khoa() { tenkhoa = "DIENTU", makhoa = "02" };
            Lop lop1 = new Lop() { tenlop = "CNTT1", malop = "04", khoachuquan = cntt};
            Lop lop2 = new Lop() { tenlop = "DienTu1", malop = "05", khoachuquan = dientu };
            Lop lop3 = new Lop() { tenlop = "DienTu2", malop = "06", khoachuquan = dientu };
            cntt.lop.Add(lop1.malop, lop1);
            dientu.lop.Add(lop2.malop, lop2);
            dientu.lop.Add(lop3.malop, lop3);
            CSDL.Add(cntt.makhoa, cntt);
            CSDL.Add(dientu.makhoa, dientu);
            SinhVien sv1 = new SinhVien()
            {
                ma = "SV001",
                ten = "John Doe",
                NamSinh = new DateTime(1990, 1, 1),
                gioitinh = true
            };

            SinhVien sv2 = new SinhVien()
            {
                ma = "SV002",
                ten = "Jane Smith",
                NamSinh = new DateTime(1995, 5, 10),
                gioitinh = false
            };

            SinhVien sv3 = new SinhVien()
            {
                ma = "SV003",
                ten = "David Johnson",
                NamSinh = new DateTime(1992, 12, 15),
                gioitinh = true
            };
            lop1.sinhvien.Add(sv1.ma, sv1);
            lop2.sinhvien.Add(sv2.ma, sv2);
            lop3.sinhvien.Add(sv3.ma, sv3);
        }

        private void tvKhoa_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Level == 1)
                {
                   Lop lop = e.Node.Tag as Lop;
                    hienthisinhvientheolop(lop);
                }
                else
                {
                    lvSinhVien.Items.Clear();//xoa di vi khong xem danh sach sinh vien
                }
            }

        }
        private void hienthisinhvientheolop(Lop lop)
        {

           lvSinhVien.Items.Clear();
            foreach (KeyValuePair<string, SinhVien> item in lop.sinhvien)
            {
                SinhVien sv = item.Value;
                ListViewItem lvi = new ListViewItem(sv.ma);
                lvi.SubItems.Add(sv.ten);
                lvi.SubItems.Add(sv.NamSinh.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(sv.gioitinh ? "Nam" : "Nu");
                lvi.SubItems.Add("dau buoi");
                lvSinhVien.Items.Add(lvi);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create new instances
            Khoa khoa = new Khoa();
            Lop lop = new Lop() { tenlop = "CNTT1", malop = "04", khoachuquan = khoa };
            SinhVien sinhVien = new SinhVien();

            // Set properties from text boxes
            khoa.makhoa = textBox4.Text;
            sinhVien.ma = textBox1.Text;
            sinhVien.ten = textBox2.Text;
            sinhVien.NamSinh = Convert.ToDateTime("26/06/2004");

            // Set gender based on radio button selection
            sinhVien.gioitinh = radioButton1.Checked;

            // Add student to class
            lop.sinhvien.Add(sinhVien.ma, sinhVien);

            // Check if the class key already exists
            if (!khoa.lop.ContainsKey(lop.malop))
            {
                khoa.lop.Add(lop.malop, lop);
            }
            else
            {
                MessageBox.Show("The class key 'malop' already exists.");
            }

            // Check if the department key already exists
            if (!CSDL.ContainsKey(khoa.makhoa))
            {
                CSDL.Add(khoa.makhoa, khoa);
            }
            else
            {
                MessageBox.Show("The department key 'makhoa' already exists.");
            }

            // Refresh the TreeView
            HienThiLenTreeView();
        }
    }
}
