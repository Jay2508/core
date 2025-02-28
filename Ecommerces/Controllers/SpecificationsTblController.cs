using Ecommerces.Entity.Model;
using Ecommerces.Models;
using Ecommerces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerces.Controllers
{
    public class SpecificationsTblController : Controller
    {
        private readonly ISpecificationsTblService Db;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;

        public SpecificationsTblController(ISpecificationsTblService Db, Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment)
        {
            this.Db = Db;
            this.Environment = Environment;
        }

        public IActionResult Index()
        {
            return View();
        }
  

        public async Task<IActionResult> SpecificationManage()
        {
            var SpeData = await Db.List();
            var Data = SpeData.Data;
            ViewData["SpecificationList"] = Data;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SpecificationForm(int id)
        {
            var SpeData = await Db.GetByid(id);
            var SModel = SpeData.Data as SpecificationsTbl;
            //return View(CatData.Data);

            var Model = new SpecificationsTblDto();

            if (SModel != null)
            {

                Model.SpeId = SModel.SpeId;
                Model.SpecificationName = SModel.SpecificationName;
                Model.SpecificationType = SModel.SpecificationType;
                Model.Status = SModel.Status;
            }
            return View(Model);


        }


        public async Task<IActionResult> Delete(int id)
        {
            var Data = await Db.DeleteByid(id);
            ViewBag.Msg = Data.Massage;
            return RedirectToAction("SpecificationManage", "SpecificationsTbl");
            
        }
        [HttpPost]
        public async Task<IActionResult> SpecificationForm(SpecificationsTblDto SModel, int id)
        {
            SpecificationsTbl Model = new SpecificationsTbl()
            {
                SpecificationName = SModel.SpecificationName,
                SpecificationType = SModel.SpecificationType,
                Status = SModel.Status
            };
            if (id > 0)
            {
                var SpecData = await Db.Update(Model , id);
                if (SpecData != null)
                {
                    ViewBag.Msg = SpecData.Massage;
                }
            }
            else
            {
                var SpecData = await Db.Add(Model);
                if (SpecData != null)
                {
                    ViewBag.Msg = SpecData.Massage;
                }
            }
          
            return View();
        }


    }
}
