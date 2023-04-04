using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_PK.Model
{
    public class services
    {
        public services() { }
        public services(int id)
        {
            Note = "";
            Price = 0;
            TypeServices_ID = id;
        }

        public int ID { get; set; }
        public string Note { get; set; }
        public double Price { get; set; }
        public int TypeServices_ID { get; set; }

    }
}
