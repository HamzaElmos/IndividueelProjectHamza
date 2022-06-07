using System;
using System.ComponentModel.DataAnnotations;

namespace HamzaIndividueelProject
{
    public class NewUser
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Departement { get; set; }
        public DateTime DateJoined { get; set; }

       
    }
}