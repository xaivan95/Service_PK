using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_PK.Model
{
    public class autopartinwarehouse
    {
        public autopartinwarehouse() { }
        public autopartinwarehouse(int autopart_Id, int warehouse_ID)
        {
            Autopart_Id = autopart_Id;
            Warehouse_ID = warehouse_ID;
            Count = 0;
        }

        public int ID { get; set; }
        public int Count { get; set; }
        public int Autopart_Id { get; set; }
        public int Warehouse_ID { get; set; }
    }
}
