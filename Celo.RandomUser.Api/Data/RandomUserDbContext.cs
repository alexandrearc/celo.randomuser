using Microsoft.EntityFrameworkCore;

namespace Celo.RandomUser.Data
{
    public class RandomUserDbContext : DbContext
    {
        public RandomUserDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<FirstNameFemaleSeed> FemaleNames { get; set; }
        public DbSet<FirstNameMaleSeed> MaleNames { get; set; }
        public DbSet<LastNameSeed> LastNames { get; set; }
    }
}
