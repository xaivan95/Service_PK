using Service_PK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_PK.Control
{
    public class Authorization
    {
        public static employee Authorizations(string login, string password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var employees = db.employees.Where(x=>x.Login.ToLower().Equals(login.ToLower())).Where(x=>x.Password.Equals(password)).ToList();
                if (employees.Count > 0) return employees.First();
            }
            return null;
        }
    }
}
