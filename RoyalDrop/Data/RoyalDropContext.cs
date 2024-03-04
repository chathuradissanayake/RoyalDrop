using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoyalDrop.Models;

namespace RoyalDrop.Data
{
    public class RoyalDropContext : DbContext
    {
        public RoyalDropContext (DbContextOptions<RoyalDropContext> options)
            : base(options)
        {
        }

        public DbSet<RoyalDrop.Models.Product> Products { get; set; } = default!;
        public DbSet<RoyalDrop.Models.User> Users { get; set; } = default!;
        public DbSet<RoyalDrop.Models.Purchase> Purchases { get; set; } = default!;
    }
}
