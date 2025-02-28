using Ecommerces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerces.Controllers
{
    public class HomeIndexController : Controller
    {
        private readonly ICategoryTblService Db;

        public HomeIndexController(ICategoryTblService Db)
        {
            this.Db = Db;
        
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HOMEIndex()
        {
            return View();
        }

        public async Task<IActionResult> MenuPartitalView()
        {
            var CatData = await Db.List();

          
            ViewData["CategoryData"] = CatData.Data;
           
            return PartialView("_MenuPartitalView");
        }
    }
}
