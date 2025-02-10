using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeThua
{
    class Iphone : ProDuct
    {
        public Iphone() {
            price= 0;
        }
        public override void ProDuctInfo()
        {
            Console.WriteLine("Day La Dien Thoai IPhone");
        }

    }

}
