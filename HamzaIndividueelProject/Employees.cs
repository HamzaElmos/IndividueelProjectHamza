﻿using Braintree;
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
        public string Address { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Departement { get; set; }

        //public string InitiateUser(string username, string password)
        //{
        //   return Hasher.Hash(username + password + "SuperSecretValueToMakeTheHASHMoreUniqueAndComplex");
        //}
        
    }
}
