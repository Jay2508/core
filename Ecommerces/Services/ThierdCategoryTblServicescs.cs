using Ecommerces.Entity;
using Ecommerces.Entity.Model;
using Ecommerces.Helpers;
using Ecommerces.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Ecommerces.Services
{
    public class ThierdCategoryTblServicescs : IThierdCategoryTblServicescs
    {
        private readonly EntityDbContext db;

        public ThierdCategoryTblServicescs(EntityDbContext db)
        {
            this.db = db;
        }

        public async Task<ApiHttpResponsecs> Add(ThierdCategoryTbl Model)
        {
            try
            {
                if (Model == null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.ModelNull, ResponseStatus.Nodata, 404);

                }
                var Data = await db.ThirdCategoryTbls.Where(m => m.ThirdCategory == Model.ThirdCategory).FirstOrDefaultAsync();
                if (Data != null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.AllReadyExist, ResponseStatus.Conflict, 404);
                }
                db.ThirdCategoryTbls.Add(Model);
                var RowCount = db.SaveChanges();
                if (RowCount > 0)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.SuccessStore);
                }
                else
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.NotStore, ResponseStatus.Error, 500);
                }

            }
            catch (Exception Ex)
            {

                return ApiHttpResponsecs.CreatResponse(Ex.ToString(), ResponseStatus.Error, 500);
            }
        }

        public async Task<ApiHttpResponsecs> DeleteByid(int id)
        {
            try
            {
                if (id == 0)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.NoId, ResponseStatus.Error, 404);
                }
                var Data = await db.ThirdCategoryTbls.FindAsync(id);
                if (Data == null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.NoData, ResponseStatus.Nodata, 404);
                }
                db.ThirdCategoryTbls.Remove(Data);
                int Rowcount = db.SaveChanges();
                if (Rowcount > 0)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.DeleteMessage);
                }
                else
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.NotDelete, ResponseStatus.Error, 505);

                }
            }
            catch (Exception Ex)
            {

                return ApiHttpResponsecs.CreatResponse(Ex.ToString(), ResponseStatus.Error, 500);
            }
        }


        public async Task<ApiHttpResponsecs> GetByid(int id)
        {
            try
            {
                if (id == 0)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.NoId, ResponseStatus.Error, 404);

                }
                var Data = await db.ThirdCategoryTbls.FindAsync(id);

                if (Data == null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.NoData, ResponseStatus.Error, 404);
                }
                return ApiHttpResponsecs.CreatResponse(Data);
            }
            catch (Exception Ex)
            {
                return ApiHttpResponsecs.CreatResponse(Ex.ToString(), ResponseStatus.Error, 500);

            }
        }

        public async Task<ApiHttpResponsecs> List()
        {
            try
            {
                var Data = await (from tc in db.ThirdCategoryTbls
                                  join SCt in db.SubCategoryTbls on tc.SubCatId equals SCt.SubCatId
                                  join Ct in db.CategoryTbls on tc.CatId equals Ct.CatId
                                  select new ThirdCategoryTblDto
                                  {
                                      ThierdCatId = tc.ThierdCatId,
                                      Category = Ct.Category,
                                      SubCategory = SCt.SubCategory,
                                      ThirdCategory = tc.ThirdCategory,
                                      ThierdCategoryIcon = tc.Icon,
                                      Status = tc.Status
                                  }).ToListAsync();
                if (Data == null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.NoData, ResponseStatus.Nodata, 404);
                }
                return ApiHttpResponsecs.CreatResponse(Data);
            }
            catch (Exception Ex)
            {

                return ApiHttpResponsecs.CreatResponse(Ex.ToString(), ResponseStatus.Error, 500);
            }
        }
        public async Task<ApiHttpResponsecs> CatList()
        {
            try
            {
                var Data = await db.CategoryTbls.ToListAsync();

                if (Data == null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.NoData, ResponseStatus.Nodata, 404);
                }
                return ApiHttpResponsecs.CreatResponse(Data);
            }
            catch (Exception Ex)
            {

                return ApiHttpResponsecs.CreatResponse(Ex.ToString(), ResponseStatus.Error, 500);
            }
        }
        public async Task<ApiHttpResponsecs> Update(ThierdCategoryTbl Model, int id)
        {
            try
            {
                if (Model == null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.ModelNull, ResponseStatus.Nodata, 404);
                }
                if (id == 0)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.NoId, ResponseStatus.Error, 404);
                }
                var Data = await db.ThirdCategoryTbls.FindAsync(id);
                Data.CatId = Model.CatId;
                Data.SubCatId = Model.SubCatId;
                Data.ThirdCategory = Model.ThirdCategory;
                Data.Icon = Model.Icon;
                Data.Status = Model.Status;
                db.Entry(Data).State = EntityState.Modified;

                int RowCount = db.SaveChanges();
                if (RowCount > 0)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.UpdateMessage);
                }
                else
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.NotUpdate, ResponseStatus.Error, 500);
                }
            }
            catch (Exception Ex)
            {

                return ApiHttpResponsecs.CreatResponse(Ex.ToString(), ResponseStatus.Error, 500);
            }
        }
        public async Task<ApiHttpResponsecs> ThierdCatList(int SubCatId)
        {
            try
            {
                var Data = await db.ThirdCategoryTbls.Where(M => M.SubCatId == SubCatId).ToListAsync();

                if (Data == null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.NoData, ResponseStatus.Error, 404);
                }
                return ApiHttpResponsecs.CreatResponse(Data);
            }
            catch (Exception Ex)
            {

                return ApiHttpResponsecs.CreatResponse(Ex.ToString(), ResponseStatus.Error, 500);
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }

    public interface IThierdCategoryTblServicescs
    {

        Task<ApiHttpResponsecs> Add(ThierdCategoryTbl Model);
        Task<ApiHttpResponsecs> Update(ThierdCategoryTbl Model, int id);
        Task<ApiHttpResponsecs> List();
        Task<ApiHttpResponsecs> CatList();
        Task<ApiHttpResponsecs> GetByid(int id);
        Task<ApiHttpResponsecs> DeleteByid(int id);
        Task<ApiHttpResponsecs> ThierdCatList(int SubCatId);
    }
}

