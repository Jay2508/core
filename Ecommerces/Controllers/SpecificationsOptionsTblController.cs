using Ecommerces.Entity.Model;
using Ecommerces.Models;
using Ecommerces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerces.Controllers
{
    public class SpecificationsOptionsTblController : Controller
    {
        private readonly ISpecificationsOptionsTblService Db;

        public SpecificationsOptionsTblController(ISpecificationsOptionsTblService Db)
        {
            this.Db = Db;
          
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SpecificationsOptionsForm(int id)
        {
            var Data = await Db.SpeList();
            var SpeciData = Data.Data as List<SpecificationsTbl>;
            ViewBag.Data = new SelectList(SpeciData, "SpeId", "SpecificationName");


            var SpeData = await Db.GetByid(id);
            var SModel = SpeData.Data as SpecificationsOptionsTbl;
            //return View(CatData.Data);

            var Model = new SpecificationsOptionsTblDto();

            if (SModel != null)
            {
                Model.SpecificationsId = SModel.SpecificationsId;

                Model.SpeId = SModel.SpeId;
                Model.Value = SModel.Value;
                Model.Status = SModel.Status;
            }
            return View(Model);

        
        }



        public async Task<IActionResult> SpecificationsOptionsManage()
        {
            var SPeCatData = await Db.List();
            var Data = SPeCatData.Data;
            ViewData["SPeCatData"] = Data;
           


            return View();
        }




        public async Task<IActionResult> Delete(int id)
        {
            var Data = await Db.DeleteByid(id);
            ViewBag.Msg = Data.Massage;
            return RedirectToAction("SpecificationsOptionsManage", "SpecificationsOptionsTbl");

        }








        [HttpPost]
        public async Task<IActionResult> SpecificationsOptionsForm(SpecificationsOptionsTblDto SModel, int id)
        {
            SpecificationsOptionsTbl Model = new SpecificationsOptionsTbl()
            {
                SpeId = SModel.SpeId,
                Value = SModel.Value,
                Status = SModel.Status
            };
            if (id > 0)
            {
                var SpecData = await Db.Update(Model, id);
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
