using System;
public class Randevu
{
    public int Id { get; set; }
    public int PersonelId { get; set; }
    public int ServiceId { get; set; }
    public DateTime StartTime { get; set; }
    public string Status { get; set; } = "Pending";

    public Personel Personel { get; set; }
    public BarberService BarberService { get; set; }
}
