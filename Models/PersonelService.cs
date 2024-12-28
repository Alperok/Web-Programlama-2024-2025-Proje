public class PersonelService
{
    public int Id { get; set; }
    public int PersonelId { get; set; }
    public int ServiceId { get; set; }

    public Personel Personel { get; set; }
    public BarberService BarberService { get; set; }
}
