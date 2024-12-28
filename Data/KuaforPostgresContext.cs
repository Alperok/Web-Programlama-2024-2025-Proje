using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class KuaforPostgressContext : IdentityDbContext
{
    public KuaforPostgressContext(DbContextOptions<KuaforPostgressContext> options) : base(options) { }
    public DbSet<Barber> Barbers {get; set;}
    public DbSet<Personel> Personel {get; set;}
    public DbSet<BarberService> BarberServices { get; set; }
    public DbSet<PersonelService> PersonelServices { get; set; }
    public DbSet<Randevu> Randevu { get; set; }
}

