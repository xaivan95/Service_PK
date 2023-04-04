using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_PK.Model
{
    public class employee
    {
        [Key]
        public int Service_number { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public string? Adress { get; set; }
        public string Login { get; set; }
        public int Post_ID { get; set; }
        public string Password { get; set; }

        public employee()
        {
            FIO = "";
            Phone = "";
            Login = "";
            Password = "";
            Post_ID = 1;
        }

    }
}
