using Microsoft.AspNetCore.Mvc;

namespace Inlamning2Mvc.Controllers
{
    public class Default : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
      
}
