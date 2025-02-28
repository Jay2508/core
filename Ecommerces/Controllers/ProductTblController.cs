using System.Drawing.Drawing2D;
using System.IO;
using Ecommerces.Entity.Model;
using Ecommerces.Helpers;
using Ecommerces.Models;
using Ecommerces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Ecommerces.Controllers
{
    public class ProductTblController : Controller
    {
        private readonly IProductTblService Db;
        private readonly IBrandTblService Bs;


        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;

        public ProductTblController(IProductTblService Db, IBrandTblService Bs, Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment)
        {
            this.Db = Db;
            this.Environment = Environment;
            this.Bs = Bs;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ProductManage()
        {
            var ProductData = await Db.List();
            var Data = ProductData.Data;
            ViewData["ProductData"] = Data;
            return View();


        }



        public async Task<IActionResult> Delete(int id)
        {
            var Data = await Db.DeleteByid(id);
            ViewBag.Msg = Data.Massage;
            return RedirectToAction("ProductManage", "ProductTbl");
        }










        public async Task<IActionResult> ProductForm(int id)
        {
            var Data = await Db.CatList();
            var CategoryData = Data.Data as List<CategoryTbl>;
            ViewBag.Data = new SelectList(CategoryData, "CatId", "Category");



            var BrandData = await Bs.List();
            var BrandTblData = BrandData.Data as List<BrandTbl>;
            ViewBag.BrandData = new SelectList(BrandTblData, "BrandId", "Brand");




            var ProducatData = await Db.GetByid(id);
            var PModel = ProducatData.Data as ProductTbl;

            var Model = new ProductTblDto();

            if (PModel != null)
            {

                Model.Name = PModel.Name;
                Model.Price = PModel.Price;
                Model.CatId = PModel.CatId;
                Model.SubCatId = PModel.SubCatId;
                Model.ThierdCatId = PModel.ThierdCatId;
                Model.BrandId = PModel.BrandId;
                Model.ProPhoto = PModel.Photo;
                Model.Description = PModel.Description;
                Model.Status = PModel.Status;
            }

            return View(Model);





        }










        [HttpPost]
        public async Task<IActionResult> ProductForm(ProductTblDto Model, int id)
        {
            string FileName = "";
            string WWWRootPath = Path.Combine(Environment.WebRootPath);
            string path = Path.Combine(WWWRootPath, "img");
            string icon = "img\\";

            if (Model.Photo != null)
            {
                string FileExt = Model.Photo.FileName;
                icon = Path.Combine(icon, FileExt);
                FileStream stream = new FileStream(Path.Combine(path, FileExt), FileMode.Create);
                Model.Photo.CopyTo(stream);
                FileName = icon;
            }
            ProductTbl TModel = new ProductTbl()
            {
                Name = Model.Name,
                Price = Convert.ToDecimal(Model.Price),
                CatId = Model.CatId,
                SubCatId = Model.SubCatId,
                ThierdCatId = Model.ThierdCatId,
                BrandId = Model.BrandId,
                Photo = FileName,
                Description = Model.Description,
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

                var ProdataData = await Db.Add(TModel);
                if (ProdataData != null)
                {
                    ViewBag.Msg = ProdataData.Massage;
                }
            }


            return View();
        }
    }


}