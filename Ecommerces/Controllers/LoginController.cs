using Microsoft.AspNetCore.Mvc;
using Ecommerces.Entity.Model;
using Ecommerces.Models;
using Ecommerces.Services;
using static Ecommerces.Services.RegisterTblService;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Http;

namespace Ecommerces.Controllers
{
    public class LoginController : Controller
    {
        private readonly IRegisterTblService Db;


        public LoginController(IRegisterTblService Db)
        {
            this.Db = Db;

        }
        public IActionResult Index()
        {
            return View();
        }
        public  IActionResult LoginForm()
        {
         
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginForm(string Email, string Password)
        {
            var RegData = await Db.LoginAdd(Email, Password);
            if (RegData != null)
            {
                HttpContext.Session.SetString("UserId", RegData.Data.ToString());

                ViewData["RegData"] = RegData.Data;
                 return RedirectToAction("HOMEIndex", "HomeIndex");
            }
            else
            {
                ViewBag.Msg = RegData.Massage;

                return RedirectToAction("LoginForm", "Login");
            }

           
        }
    }
}
