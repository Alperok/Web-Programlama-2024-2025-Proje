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
    public IActionResult Index()
    {
        var kuaforler = _context.kuaforListe.ToList();
        var isLoggedIn = !string.IsNullOrEmpty(HttpContext.Session.GetString("UserId"));
        ViewBag.IsLoggedIn = isLoggedIn;
        return View(kuaforler);
    }
     public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(string username, string email, string password)
    {
        if(_context.users.Any(u => u.username == username || u.email == email))
        {
            ViewBag.Error = "Kullanici adi zaten kullanilmis.";
            return View();
        }

        var user = new User
        {
            username = username,
            email = email,
            password = password
        };

        _context.users.Add(user);
        _context.SaveChanges();

        ViewBag.Message = "Giris Basarili! Lutfen giris yapin.";
        return RedirectToAction("Login");
    }
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _context.users.FirstOrDefault(u => u.username == username && u.password == password);

        if(user == null)
        {
            ViewBag.Error = "Yanlis kullanici adi yada sifre.";
            return View();
        }

        HttpContext.Session.SetString("UserId", user.id.ToString());
        HttpContext.Session.SetString("Username", user.username);

        return RedirectToAction("Index");
    }
}