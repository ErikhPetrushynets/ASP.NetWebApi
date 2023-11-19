using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab04WebAPI.Models;

namespace Lab04WebAPI.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        public DbSet<Hospitalmedicines> Hospitalmedicines { get; set; }
        public DbSet<Lab04WebAPI.Models.Hospitaldoctors>? Hospitaldoctors { get; set; }
    }
}
