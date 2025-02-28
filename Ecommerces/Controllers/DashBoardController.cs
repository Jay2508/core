using Microsoft.AspNetCore.Mvc;

namespace Ecommerces.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DashboardManage()
        {
            return View();
        }
    }
}
