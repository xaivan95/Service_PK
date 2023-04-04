using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_PK.Model
{
    public class PK
    {
        public PK()
        {

        }
        public PK(int id) 
        {
            Name = "";
            Type_pk_ID = 1;
            Client_ID = id;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int Type_pk_ID { get; set; }
        public int Client_ID { get; set; }
    }
}
