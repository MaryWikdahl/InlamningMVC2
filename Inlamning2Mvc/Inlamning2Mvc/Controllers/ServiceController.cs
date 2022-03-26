using Microsoft.AspNetCore.Mvc;

namespace InlamningMVC.Controllers
{
    public class ServiceController : Microsoft.AspNetCore.Mvc.Controller
    {
        [Route("service")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
