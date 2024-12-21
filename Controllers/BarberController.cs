using Microsoft.AspNetCore.Mvc;
using System.Linq; 

public class BarberController: Controller
{
    private readonly KuaforPostgressContext _context;

    public BarberController(KuaforPostgressContext context)
    {
        _context = context;
    }

    public IActionResult Details(int id)
    {
        var barber = _context.Barbers.FirstOrDefault(b => b.Id == id);
        if (barber == null) return NotFound();

        return View(barber);
    }
}