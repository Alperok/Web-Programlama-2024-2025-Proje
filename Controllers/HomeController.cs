using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class HomeController : Controller
{
    private readonly KuaforPostgressContext _context;
    public HomeController(KuaforPostgressContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var kuaforler = _context.KuaforListe.ToList();
        return View(kuaforler);
    }
    public IActionResult Register()
    {
        return View();
    }
    public IActionResult Login()
    {
        return View();
    }
}