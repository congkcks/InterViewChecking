using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProJectthucte.model
{
    public class Khoa
    {
        public string makhoa {  get; set; }
        public string tenkhoa { get; set; }
        public Dictionary<string,Lop> lop { get; set; }
        public Khoa()
        {
            lop = new Dictionary<string, Lop>();
        }
        public override string ToString()
        {
            return tenkhoa;
        }
    }
}
