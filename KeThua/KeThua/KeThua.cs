using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KeThua
{
    public class KeThua
    {
        public string chuoi1;
        public string chuoi2;
        public KeThua() {
            this.chuoi1 = "dau buoi";
            this.chuoi2 = "re rach";
            Console.WriteLine("Ham Khoi Tao 1");
        }
        public void hamin(int[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

        }
            
            
        
    }
}
