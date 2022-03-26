using Microsoft.AspNetCore.Mvc;

namespace InlamningMVC.Controllers
{
    public class _404Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
