using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data;

public class WebDbContext : DbContext
{

    public WebDbContext(DbContextOptions<WebDbContext> options)
        : base(options)
    {


    } 

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof (WebDbContext).Assembly);
    }

    class WebDbContextFactory : IDesignTimeDbContextFactory<WebDbContext>
    {
        public WebDbContext CreateDbContext(string[]? args = null)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var optionsBuilder = new DbContextOptionsBuilder<WebDbContext>();
            optionsBuilder
                .UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

            return new WebDbContext(optionsBuilder.Options);
        }
    }
}

