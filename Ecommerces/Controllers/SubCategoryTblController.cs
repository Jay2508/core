using Ecommerces.Entity.Model;
using Ecommerces.Helpers;
using Ecommerces.Models;
using Ecommerces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Ecommerces.Controllers
{
    public class SubCategoryTblController : Controller
    {
        private readonly ISubCategoryTblService Db;

        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;

        public SubCategoryTblController(ISubCategoryTblService Db, Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment)
        {
            this.Db = Db;
            this.Environment = Environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SubCategoryForm(int id)
        {
            var Data = await Db.CatList();
            var CategoryData = Data.Data as List<CategoryTbl>;
            ViewBag.Data = new SelectList(CategoryData, "CatId", "Category");


            var SubCatData = await Db.GetByid(id);
            var SModel = SubCatData.Data as SubCategoryTbl;


            var Model = new SubCategoryTblDto();

            if (SModel != null)
            {
                Model.SubCatId = SModel.SubCatId;
                Model.CatId = SModel.CatId;
                Model.SubCategory = SModel.SubCategory;
                Model.SubCategoryIcon = SModel.Icon;
                Model.Status = SModel.Status;
            }
            return View(Model);

        }



        public async Task<IActionResult> SubCategoryManage()
        {
            var SubCatData = await Db.List();
            var Data = SubCatData.Data;
            ViewData["SubCatData"] = Data;
            return View();
        }


        public async Task<IActionResult> Delete(int id)
        {
            var Data = await Db.DeleteByid(id);
            ViewBag.Msg = Data.Massage;
            return RedirectToAction("SubCategoryManage", "SubCategoryTbl");
        }










        [HttpPost]
        public async Task<IActionResult> SubCategoryForm(SubCategoryTblDto Model, int id)
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
            SubCategoryTbl SModel = new SubCategoryTbl()
            {
                CatId = Model.CatId,
                SubCategory = Model.SubCategory,
                Icon = FileName,
                Status = Model.Status
            };


            if (id > 0)
            {
                var SubCatData = await Db.Update(SModel, id);
                if (SubCatData != null)
                {
                    ViewBag.Msg = SubCatData.Massage;
                }

            }
            else
            {
                var SubCatData = await Db.Add(SModel);
                if (SubCatData != null)
                {
                    ViewBag.Msg = SubCatData.Massage;
                }


            }

            

            return View();


        }

    }
}
