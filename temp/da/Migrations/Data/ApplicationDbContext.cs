using StudentProjectAttempt6.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentProjectAttempt6.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
