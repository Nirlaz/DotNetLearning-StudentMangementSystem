using Microsoft.EntityFrameworkCore;
using StudentsMangement.Models.Entitles;


namespace StudentsMangement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> students { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }

}
