using Microsoft.EntityFrameworkCore;
using pensamentoAPI.Model;

namespace pensamentoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<PensamentoModel> Pensamentos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
