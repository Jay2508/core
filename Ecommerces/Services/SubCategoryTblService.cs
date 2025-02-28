using Ecommerces.Entity;
using Ecommerces.Entity.Model;
using Ecommerces.Helpers;
using Ecommerces.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace Ecommerces.Services
{
    public class SubCategoryTblService : ISubCategoryTblService, IDisposable
    {
        private readonly EntityDbContext db;

        public SubCategoryTblService(EntityDbContext db)
        {
            this.db = db;
        }

        public async Task<ApiHttpResponsecs> Add(SubCategoryTbl Model)
        {
            try
            {
                if (Model == null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.ModelNull, ResponseStatus.Nodata, 404);

                }
                var Data = await db.SubCategoryTbls.Where(m => m.SubCategory == Model.SubCategory).FirstOrDefaultAsync();
                if (Data != null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.AllReadyExist, ResponseStatus.Conflict, 404);
                }
                db.SubCategoryTbls.Add(Model);
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
                var Data = await db.SubCategoryTbls.FindAsync(id);
                if (Data == null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.NoData, ResponseStatus.Nodata, 404);
                }
                db.SubCategoryTbls.Remove(Data);
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
                var Data = await db.SubCategoryTbls.FindAsync(id);

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
                //var Data = await db.SubCategoryTbls.ToListAsync();
                var Data = (from Scat in db.SubCategoryTbls
                            join cat in db.CategoryTbls
                            on Scat.CatId equals cat.CatId
                            select new SubCategoryTblDto
                            {
                                SubCatId = Scat.SubCatId,
                                CatId = cat.CatId,
                                Category = cat.Category,
                                SubCategoryIcon = Scat.Icon,
                                SubCategory = Scat.SubCategory,
                                Status = Scat.Status
                            }).ToList();
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
        public async Task<ApiHttpResponsecs> Update(SubCategoryTbl Model, int id)
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
                var Data = await db.SubCategoryTbls.FindAsync(id);
                Data.CatId = Model.CatId;
                Data.SubCategory = Model.SubCategory;
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
        public async Task<ApiHttpResponsecs> SubCatList(int CatId)
        {
            try
            {
                var Data = await db.SubCategoryTbls.Where(M => M.CatId == CatId).ToListAsync();

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

    public interface ISubCategoryTblService
    {

        Task<ApiHttpResponsecs> Add(SubCategoryTbl Model);
        Task<ApiHttpResponsecs> Update(SubCategoryTbl Model, int id);
        Task<ApiHttpResponsecs> List();
        Task<ApiHttpResponsecs> CatList();
        Task<ApiHttpResponsecs> SubCatList(int CatId);

        Task<ApiHttpResponsecs> GetByid(int id);
        Task<ApiHttpResponsecs> DeleteByid(int id);
    }
}

