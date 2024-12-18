using Microsoft.EntityFrameworkCore;

public class KuaforPostgressContext : DbContext
{
    public KuaforPostgressContext(DbContextOptions<KuaforPostgressContext> options) : base(options) { }
    public DbSet<Kuafor> kuaforListe { get; set; }
    public DbSet<User> users { get; set; }

}