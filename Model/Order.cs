using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_PK.Model
{
    public class Order
    {
        public int ID { get; set; }
        public string? Note { get; set; }
        public string? Start_date { get; set; }
        public string? End_date { get; set; }
        public double? Price { get; set; }

        public int Pay_type_ID { get; set; }

        public Order()
        {
            Pay_type_ID = 1;
            Price = 0;
        }
    }
}
