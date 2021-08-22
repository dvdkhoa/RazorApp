using CRUD_DbContext_RazorApp.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_DbContext_RazorApp
{
    public class MyDbContext : DbContext
    {
        public MyDbContext( DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Article> Articles { get; set; }
    }
}
