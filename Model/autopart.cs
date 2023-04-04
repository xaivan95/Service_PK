using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_PK.Model
{
    public  class autopart
    {
        public autopart() { }
        public autopart(int id, int id_ware) {
            Name = "";
            Serial_number = "";
            Price = 0;
            TypeAutopart_ID = id;
            Count = 1;
            Warehouse_ID = id_ware;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Serial_number { get; set; }
        public double Price { get; set; }
        public int TypeAutopart_ID { get; set; }
        public int Count { get; set; }
        public int Warehouse_ID { get; set; }
    }
}
