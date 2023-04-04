using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_PK.Model
{

    public class carinorder
    {
        public int ID { get; set; }
        public int Order_ID { get; set; }
        public int Car_ID { get; set;}

        public carinorder() { }

        public carinorder(int Order_ID, int Car_ID)
        {
            this.Order_ID = Order_ID;
            this.Car_ID = Car_ID;
        }
    }
}
