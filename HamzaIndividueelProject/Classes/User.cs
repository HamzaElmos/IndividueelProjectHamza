using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamzaIndividueelProject.Classes
{
    public class User : Employees
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DatedJoined { get; set; }

    }
}
