using Braintree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamzaIndividueelProject
{
    public class Employees
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EmployeeDate { get; set; }
        public string Departement { get; set; }

        //public string InitiateUser(string username, string password)
        //{
        //   return Hasher.Hash(username + password + "SuperSecretValueToMakeTheHASHMoreUniqueAndComplex");
        //}
        public Employees (int id, string firstname, string lastname, string departement)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Departement = departement;
        }
    }
}
