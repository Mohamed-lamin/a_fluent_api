namespace CreateAminimalAPI.Data;
using Microsoft.EntityFrameworkCore;




public class DataDbContext:DbContext
{

    public DataDbContext(DbContextOptions<DataDbContext> options):

        base(options)
    {
        
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Toy> Toys => Set<Toy>();

}

