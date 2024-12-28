using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

public class Personel
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [ForeignKey("Barber")]
    public int BarberId { get; set; } 
    public Barber Barber { get; set; }
    public List<BarberService> Services { get; set; } = new List<BarberService>();
}

