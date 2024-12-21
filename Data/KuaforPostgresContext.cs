using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class KuaforPostgressContext : IdentityDbContext
{
    public KuaforPostgressContext(DbContextOptions<KuaforPostgressContext> options) : base(options) { }
    public DbSet<Barber> Barbers { get; set; }

}