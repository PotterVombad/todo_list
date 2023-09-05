using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace todo_list.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}