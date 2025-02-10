using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeThua
{
    public class Class2 : Interface1
    {
        public int hamcong(int a, int b)
        {

           string c = Interface1.name;
           int kieutrave=Convert.ToInt32(c);
           return kieutrave;   
        }

        public void hamindaubuoi()
        {
            throw new NotImplementedException();
        }
    }
}
