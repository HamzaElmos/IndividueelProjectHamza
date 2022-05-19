using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamzaIndividueelProject
{
    public class Context : DbContext 
    {
        public DbSet<LoginData> LoginData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-GUFE3U9Q\SQLEXPRESS;Database=LoginData;Trusted_Connection=True;");
        }
    }
}
