using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System;

public class BarberController: Controller
{
    private readonly KuaforPostgressContext _context;

    public BarberController(KuaforPostgressContext context)
    {
        _context = context;
    }
    

    public IActionResult Details(int id)
    {
        var barber = _context.Barbers
        .Include(b => b.PersonelList)
        .FirstOrDefault(b => b.Id == id);

        if (barber == null)
        {
            return NotFound();
        }

        foreach (var personel in barber.PersonelList)
        {
            List<BarberService> services = new List<BarberService>();

            var personelServices = _context.PersonelServices
                .Where(ps => ps.PersonelId == personel.Id)
                .ToList();

            foreach (var ps in personelServices)
            {
                var barberService = _context.BarberServices
                    .FirstOrDefault(bs => bs.Id == ps.ServiceId);

                if (barberService != null)
                {
                    services.Add(barberService);
                }
            }
            personel.Services = services;
        }

        return View(barber);
    }
}