using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_11_1.Domain.Entities;

namespace Week_11_1.Persistence.Contexts
{
    public class PerfectAppDbContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("PerfectApp");
        }





    }
}
