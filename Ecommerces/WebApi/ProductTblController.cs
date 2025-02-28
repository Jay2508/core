using Ecommerces.Helpers;
using Ecommerces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerces.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTblController : ControllerBase
    {

        private readonly ISubCategoryTblService SDb;
        private readonly IProductTblService Db;
        private readonly IThierdCategoryTblServicescs TDb;

        public ProductTblController(ISubCategoryTblService SDb, IProductTblService Db, IThierdCategoryTblServicescs TDb)
        {

            this.SDb = SDb;
            this.Db = Db;
            this.TDb = TDb;

        }

        [Route("/api/ProductTbl/SubCategoryList/{CatId}")]
        [HttpGet]
        public async Task<ApiHttpResponsecs> SubCategoryList(int CatID)
        {
            var SubCatData = await SDb.SubCatList(CatID);
            return (SubCatData);
        }


        [Route("/api/ProductTbl/ThierdCatList/{SubCatId}")]
        [HttpGet]
        public async Task<ApiHttpResponsecs> ThierdCatList(int SubCatID)
        {
            var ThierdCatList = await TDb.ThierdCatList(SubCatID);
            return (ThierdCatList);
        }



        //[Route("/api/ProductTbl/ThierdCatList/")]
        //[HttpGet]
        //public async Task<ApiHttpResponsecs> ThierdCatList()
        //{
        //    var ThierdCatList = await TDb.List();
        //    return (ThierdCatList);
        //}








        // GET: api/<ValuesController1>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        //// DELETE api/<ValuesController1>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
