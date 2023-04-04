using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_PK.Model
{
    public class autopartinorder
    {
        public autopartinorder() { }
        public autopartinorder(int Order_ID, int Autopart_Id, int Count) { 
        this.Autopart_Id = Autopart_Id;
            this.Order_ID = Order_ID;
            this.Count = Count;
        }
        public int ID { get; set; }
        public int Count { get; set; }
        public int Autopart_Id { get; set; }
        public int Order_ID { get; set; }
    }
}
