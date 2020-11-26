using Microsoft.EntityFrameworkCore;
using PoC.Models;

namespace PoC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Servico> Servico { get; set; }
    }
}