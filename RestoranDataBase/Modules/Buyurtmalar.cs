using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDataBase.Modules
{
    public class Buyurtmalar
    {
        public int id { get; set; }
        public string vaqti { get; set; }
        public int usum { get; set; }
        
        public List<Taomlar> Btaomlar { get; set; }

        public Buyurtmalar()
        {
            Btaomlar = new List<Taomlar>();
        }
    }
}
