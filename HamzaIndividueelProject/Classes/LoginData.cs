using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamzaIndividueelProject
{
    public class LoginData
    {
        public int Id { get; set; }
        public string Profile { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
