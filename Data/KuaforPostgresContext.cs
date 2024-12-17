using Microsoft.EntityFrameworkCore;

public class KuaforPostgressContext : DbContext
{
    public KuaforPostgressContext(DbContextOptions<KuaforPostgressContext> options) : base(options) { }
    public DbSet<Kuafor> KuaforListe { get; set; }
}