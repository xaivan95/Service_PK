using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_PK.Model
{

    public class employeeinorder
    {
        public employeeinorder() { }
        public employeeinorder(int order_ID, int employee_Service_number)
        {
            Order_ID = order_ID;
            Employee_Service_number = employee_Service_number;
        }
        public int ID { get; set; }
        public int Order_ID { get; set; }
        public int Employee_Service_number { get; set; }
    }
}
