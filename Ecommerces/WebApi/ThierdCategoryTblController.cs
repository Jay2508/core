using Ecommerces.Entity.Model;
using Ecommerces.Helpers;
using Ecommerces.Models;
using Ecommerces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerces.WebApi
{

    [Route("api/[controller]")]
    [ApiController]
    public class ThierdCategoryTblController : ControllerBase
    {
        private readonly IThierdCategoryTblServicescs Db;
        private readonly ISubCategoryTblService SDb;
        private readonly ICategoryTblService CDb;
        public ThierdCategoryTblController(IThierdCategoryTblServicescs Db, ISubCategoryTblService SDb, ICategoryTblService CDb)
        {
            this.Db = Db;
            this.SDb = SDb;
            this.CDb = CDb;
        }

        [Route("/api/ThierdCateGoryTbl/SubCategoryList/{CatId}")]
        [HttpGet]
        public async Task<ApiHttpResponsecs> SubCategoryList(int CatID)
        {
            var SubCatData = await SDb.SubCatList(CatID);
            return (SubCatData);
        }
        //[Route("/api/ThierdCateGoryTbl/SubCategoryList/")]
        //[HttpGet]
        //public async Task<ApiHttpResponsecs> SubCategoryList()
        //{
        //    var SubCatData = await SDb.List();
        //    return (SubCatData);
        //}



        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ThirdCatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ThirdCatController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ThirdCatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ThirdCatController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
