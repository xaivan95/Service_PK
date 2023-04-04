using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_PK.Model
{
    public class serviceinorder
    {
        public serviceinorder() { }
        public serviceinorder(int Order_ID, int services_ID)
        {
            this.services_ID = services_ID;
            this.Order_ID = Order_ID;
        }
        public int ID { get; set; }
        public int services_ID { get; set; }
        public int Order_ID { get; set; }
    }
}
