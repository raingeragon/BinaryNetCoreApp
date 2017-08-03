using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryNetCoreApp.Models
{
    public class SimpleModelContext : DbContext
    {
        public DbSet<SimpleModel> SimpleModels { get; set; }
        public SimpleModelContext(DbContextOptions<SimpleModelContext> options) : base(options)
        {

        }
    }
}
