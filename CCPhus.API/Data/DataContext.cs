using Microsoft.EntityFrameworkCore;
using CCPhus.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCPhus.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Script> Scripts { get; set; }
    }
}
