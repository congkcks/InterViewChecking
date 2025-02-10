using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeThua
{
    abstract class ProDuct
    {
        public  double price = 0;
        public abstract void ProDuctInfo();
        public void TestProduct()
        {
            this.ProDuctInfo();
        }
    }
}
