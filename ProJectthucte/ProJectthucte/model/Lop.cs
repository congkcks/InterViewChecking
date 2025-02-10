using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProJectthucte.model
{
    public class Lop
    {
        public string malop {  get; set; }
        public string tenlop { get; set; }
        public string giaoviencovan {  get; set; }
        public Khoa khoachuquan { get; set; }
        public Dictionary<string,SinhVien> sinhvien { get; set; }
        public Lop()
        {
            sinhvien = new Dictionary<string, SinhVien>();
        }
        public override string ToString()
        {
            return tenlop;
        }
    }
}
