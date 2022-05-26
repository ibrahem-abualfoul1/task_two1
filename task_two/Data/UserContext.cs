
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task_two.Controllers;
using task_two.Models;

namespace task_two.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        public DbSet<Account> User { get; set; }
     
        public DbSet<Category> categories { get; set; }
        public DbSet<MangePage> mangePages { get; set; }
        public DbSet<Messege> messeges { get; set; }
        public DbSet<Prodact> prodacts { get; set; }
        public DbSet<Bill> bills { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Testimonial> testimonials { get; set; }
        public DbSet<Transaction> transactions { get; set; }
    }
}
