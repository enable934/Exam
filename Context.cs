using Exam.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam
{
    public class Context:DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Storage> Storages { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
