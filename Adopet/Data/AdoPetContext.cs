using Adopet.Models;
using Microsoft.EntityFrameworkCore;

namespace Adopet.Data;

public class AdoPetContext : DbContext
{
    public AdoPetContext(DbContextOptions<AdoPetContext> opts) : base(opts)
    {
        
    }

    public DbSet<Tutor> Tutores { get; set; }
}
