using Ecommerces.Entity.Model;
using Ecommerces.Models;
using Ecommerces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerces.Controllers
{
    public class BrandTblController : Controller
    {
        private readonly IBrandTblService Db;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;

        public BrandTblController(IBrandTblService Db, Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment)
        {
            this.Db = Db;
            this.Environment = Environment;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> BrandForm(int id)
        {

            var BrandData = await Db.GetByid(id);
            var BModel = BrandData.Data as BrandTbl;
            //return View(CatData.Data);

            var Model = new BrandTblDto();

            if (BModel != null)
            {

                Model.BrandId = BModel.BrandId;
                Model.Brand = BModel.Brand;
                Model.BrandIcon = BModel.icon;
                Model.Status = BModel.Status;
            }
            return View(Model);

        }
        public async Task<IActionResult> BrandManage()
        {
            var BrandData = await Db.List();
            var Data = BrandData.Data;
            ViewData["BrandList"] = Data;
            return View();
        }



        public async Task<IActionResult> Delete(int id)
        {
            var Data = await Db.DeleteByid(id);
            ViewBag.Msg = Data.Massage;

            return RedirectToAction("BrandManage", "BrandTbl");

        }















        [HttpPost]
        public async Task<IActionResult> BrandForm(BrandTblDto Model, int id)
        {
            string FileName = "";
            string WWWRootPath = Path.Combine(Environment.WebRootPath);
            string path = Path.Combine(WWWRootPath, "img");
            string icon = "img\\";

            if (Model.Icon != null)
            {
                string FileExt = Model.Icon.FileName;
                icon = Path.Combine(icon, FileExt);
                FileStream stream = new FileStream(Path.Combine(path, FileExt), FileMode.Create);
                Model.Icon.CopyTo(stream);
                FileName = icon;
            }
            BrandTbl EModel = new BrandTbl()
            {
                Brand = Model.Brand,
                icon = FileName,
                Status = Model.Status
            };

            if (id > 0)
            {
                var BrandData = await Db.Update(EModel, id);
                if (BrandData != null)
                {
                    ViewBag.Msg = BrandData.Massage;
                }

            }
            else
            {
                var BrandData = await Db.Add(EModel);
                if (BrandData != null)
                {
                    ViewBag.Msg = BrandData.Massage;
                }


            }

            return View();


        }
    }
}
