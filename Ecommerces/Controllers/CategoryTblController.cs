using System.Drawing.Drawing2D;
using System.IO;
using Ecommerces.Entity.Model;
using Ecommerces.Helpers;
using Ecommerces.Models;
using Ecommerces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecommerces.Controllers
{
    public class CategoryTblController : Controller
    {
        private readonly ICategoryTblService Db;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;

        public CategoryTblController(ICategoryTblService Db, Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment)
        {
            this.Db = Db;
            this.Environment = Environment;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryForm()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CategoryForm(int id)
        {
            var CatData = await Db.GetByid(id);
            var CModel = CatData.Data as CategoryTbl;
            //return View(CatData.Data);

            var Model = new CategoryTblDto();

            if (CModel != null)
            {

                Model.CatId = CModel.CatId;
                Model.Category = CModel.Category;
                Model.CategoryIcon = CModel.icon;
                Model.Status = CModel.Status;
            }
            return View(Model);


        }


        public async Task<IActionResult> CategoryManage()
        {
            var CatData = await Db.List();
            var Data = CatData.Data;
            ViewData["CategoryList"] = Data;
            return View();
        }


        public async Task<IActionResult> Delete(int id)
        {
            

            var Data = await Db.DeleteByid(id);
            ViewBag.Msg = Data.Massage;

            return RedirectToAction("CategoryManage", "CategoryTbl");

        }

        [HttpPost]
        public async Task<IActionResult> CategoryForm(CategoryTblDto Model, int id)
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
            CategoryTbl EModel = new CategoryTbl()
            {
                Category = Model.Category,
                icon = FileName,
                Status = Model.Status
            };

            if (id > 0)
            {
                var CatData = await Db.Update(EModel, id);
                if (CatData != null)
                {
                    ViewBag.Msg = CatData.Massage;
                }

            }
            else
            {
                var CatData = await Db.Add(EModel);
                if (CatData != null)
                {
                    ViewBag.Msg = CatData.Massage;
                }


            }

            return View();


        }

    }
}


