using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_PK.Model
{
    public class Client
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }

        public Client()
        {
            FIO = "";
            Phone = "";
        }
    }
}
