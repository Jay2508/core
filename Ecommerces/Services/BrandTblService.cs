using Ecommerces.Entity;
using Ecommerces.Entity.Model;
using Ecommerces.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerces.Services
{
    public class BrandTblService : IBrandTblService , IDisposable
    {
        private readonly EntityDbContext db;

        public BrandTblService(EntityDbContext db)
        {
            this.db = db;
        }
        public async Task<ApiHttpResponsecs> Add(BrandTbl Model)
        {
            try
            {
                if (Model == null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.ModelNull, ResponseStatus.Nodata, 404);

                }
                var Data = await db.BrandTbls.Where(m => m.Brand == Model.Brand).FirstOrDefaultAsync();
                if (Data != null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.AllReadyExist, ResponseStatus.Conflict, 404);
                }
                db.BrandTbls.Add(Model);
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
                var Data = await db.BrandTbls.FindAsync(id);
                if (Data == null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.NoData, ResponseStatus.Nodata, 404);
                }
                db.BrandTbls.Remove(Data);
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
                var Data = await db.BrandTbls.FindAsync(id);

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
                var Data = await db.BrandTbls.ToListAsync();
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
        public async Task<ApiHttpResponsecs> Update(BrandTbl Model, int id)
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
                var Data = await db.BrandTbls.FindAsync(id);
                Data.Brand = Model.Brand;
                Data.icon = Model.icon;
                Data.Status = Model.Status;
                //db.Entry(Data).State = EntityState.Modified;

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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
    public interface IBrandTblService
    {

        Task<ApiHttpResponsecs> Add(BrandTbl Model);
        Task<ApiHttpResponsecs> Update(BrandTbl Model, int id);
        Task<ApiHttpResponsecs> List();
        Task<ApiHttpResponsecs> GetByid(int id);
        Task<ApiHttpResponsecs> DeleteByid(int id);
    }
}
