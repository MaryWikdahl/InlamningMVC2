using Microsoft.AspNetCore.Mvc;

namespace InlamningMVC.Controllers
{
    public class ContactController : Controller
    {
        [Route("contact")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
