using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

public class BarberService
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public TimeSpan Duration { get; set; }
    public decimal Price { get; set; }

    public int BarberId { get; set; }
    public Barber Barber { get; set; }
}
