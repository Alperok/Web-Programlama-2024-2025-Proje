using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Runtime.CompilerServices;

public class HomeController : Controller
{
    private readonly KuaforPostgressContext _context;
    public HomeController(KuaforPostgressContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        var kuaforler = _context.Barbers.ToList();
        return View(kuaforler);
    }
}