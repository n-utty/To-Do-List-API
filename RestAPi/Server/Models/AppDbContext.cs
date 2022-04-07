using Microsoft.EntityFrameworkCore;
using RestAPi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPi.Server.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        { 

        }

        public DbSet<Item> Items { get; set; }
        
    }
}
