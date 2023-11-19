using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04WebAPI.Models
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        static ContextFactory()
        {
            IConfiguration config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("C:\\Users\\erikhpetrushynets\\source\\repos\\Lab04WebAPI\\Lab04WebAPI\\appsettings.json", true, true)
               .Build();

            connectionString = config["ConnectionStrings:Test1Connection"];
            Console.WriteLine("ConnectionString:" + connectionString);
        }

        static string? connectionString = null;

        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseNpgsql(
                                    connectionString,
                                    options => options.SetPostgresVersion(new Version(9, 6)));

            return new Context(optionsBuilder.Options);
        }
    }
}
