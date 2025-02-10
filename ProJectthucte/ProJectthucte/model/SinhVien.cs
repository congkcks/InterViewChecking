using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProJectthucte.model
{
    public class SinhVien
    {
        public String ma { get; set; }
        public String ten { get; set; }
        public DateTime NamSinh { get; set; }
        public bool gioitinh { get; set; }
        public override string ToString()
        {
            return ten;
        }
    }
}
