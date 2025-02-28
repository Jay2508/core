using Ecommerces.Entity.Model;
using Ecommerces.Models;
using Ecommerces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using static Ecommerces.Services.RegisterTblService;

namespace Ecommerces.Controllers
{
    public class RegisterTblController : Controller
    {
        private readonly IRegisterTblService Db;
      

        public RegisterTblController(IRegisterTblService Db)
        {
            this.Db = Db;
           
        }







        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RegisterForm()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterForm(RegisterTblDto Model)
        {
            RegisterTbl RModel = new RegisterTbl()
            {
                UserName = Model.UserName,
                Email = Model.Email,
                Password = Model.Password,
                MobileNo = Model.MobileNo
      
            };
            var RegData = await Db.Add(RModel);
            if (RegData != null)
            {
                ViewBag.Msg = RegData.Massage;
            }
            return View();
        }
    }
}
