using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetShoppp.Models
{
    public class CakeContext: DbContext
    {
        public CakeContext(DbContextOptions<CakeContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Cake> Cakes { get; set; }
    }
}
