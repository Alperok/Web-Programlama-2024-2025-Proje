using System;
using System.Collections.Generic;
public class Barber
{
    public int Id {get; set;}
    public string Name {get; set;}

    public double Latitude {get; set;}
    public double Longtitude {get; set;}
    public string VerbalLocation { get; set; }

    public List<string> Websites { get; set; } = new List<string>();
    public string PhoneNumber { get; set; } 

    public TimeOnly OpeningHour { get; set; }
    public TimeOnly ClosingHour { get; set; }

    public string ThumbnailUrl { get; set; }

    public ICollection<Personel> PersonelList {get; set;} = new List<Personel>();
}