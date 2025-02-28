using Ecommerces.Entity.Model;
using Ecommerces.Helpers;
using Ecommerces.Models;
using Ecommerces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerces.Controllers
{
    public class ThierdCategoryTblController : Controller
    {
        private readonly IThierdCategoryTblServicescs Db;
        private readonly ISubCategoryTblService SDb;
        private readonly ICategoryTblService CDb;


        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;

        public ThierdCategoryTblController(IThierdCategoryTblServicescs Db, ISubCategoryTblService SDb, ICategoryTblService CDb, Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment)
        {
            this.Db = Db;
            this.SDb = SDb;
            this.CDb = CDb;

            this.Environment = Environment;
        }
        //[Route("api/ThierdCategoryTbl/CategoryList")]
        //[HttpGet]
        //public async Task<ApiHttpResponsecs> CategoryList()
        //{
        //    var CatData = await CDb.List();
        //    return (CatData);
        //}


        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ThierdCategoryForm(int id)
        {
            var Data = await SDb.CatList();
            var CategoryData = Data.Data as List<CategoryTbl>;
            ViewBag.Data = new SelectList(CategoryData, "CatId", "Category");




            var ThierdCatData = await Db.GetByid(id);
            var TModel = ThierdCatData.Data as ThierdCategoryTbl;


            var Model = new ThirdCategoryTblDto();

            if (TModel != null)
            {
                Model.SubCatId = TModel.SubCatId;
                Model.CatId = TModel.CatId;
                Model.SubCatId = TModel.SubCatId;
                Model.ThirdCategory = TModel.ThirdCategory;
                Model.ThierdCategoryIcon = TModel.Icon;
                Model.Status = TModel.Status;
            }
            return View(Model);

         
        }

        public async Task<IActionResult> ThierdCategoryManage()
        {
            var ThierdCatData = await Db.List();
            var Data = ThierdCatData.Data;
            ViewData["ThierdCatData"] = Data;
            return View();
        }




        public async Task<IActionResult> Delete(int id)
        {
            var Data = await Db.DeleteByid(id);
            ViewBag.Msg = Data.Massage;
            return RedirectToAction("ThierdCategoryManage", "ThierdCategoryTbl");
        }

        [HttpPost]
        public async Task<IActionResult> ThierdCategoryForm(ThirdCategoryTblDto Model, int id)
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
            ThierdCategoryTbl TModel = new ThierdCategoryTbl()
            {
                CatId = Model.CatId,
                SubCatId = Model.SubCatId,
                ThirdCategory = Model.ThirdCategory,
                Icon = FileName,
                Status = Model.Status
            };

            if (id > 0)
            {
                var ThierdCatData = await Db.Update(TModel, id);
                if (ThierdCatData != null)
                {
                    ViewBag.Msg = ThierdCatData.Massage;
                }
            }
            else
            {

                var ThierdCatData = await Db.Add(TModel);
                if (ThierdCatData != null)
                {
                    ViewBag.Msg = ThierdCatData.Massage;
                }
            }


            return View();
        }
    }
}
