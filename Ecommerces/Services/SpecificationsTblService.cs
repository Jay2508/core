using Ecommerces.Entity;
using Ecommerces.Entity.Model;
using Ecommerces.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerces.Services
{
    public class SpecificationsTblService : ISpecificationsTblService, IDisposable
    {
        private readonly EntityDbContext db;

        public SpecificationsTblService(EntityDbContext db)
        {
            this.db = db;
        }

        public async Task<ApiHttpResponsecs> Add(SpecificationsTbl Model)
        {
            try
            {
                if (Model == null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.ModelNull, ResponseStatus.Nodata, 404);

                }
                var Data = await db.SpecificationsTbls.Where(m => m.SpecificationName == Model.SpecificationName).FirstOrDefaultAsync();
                if (Data != null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.AllReadyExist, ResponseStatus.Conflict, 404);
                }
                db.SpecificationsTbls.Add(Model);
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
                var Data = await db.SpecificationsTbls.FindAsync(id);
                if (Data == null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.NoData, ResponseStatus.Nodata, 404);
                }
                db.SpecificationsTbls.Remove(Data);
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
                var Data = await db.SpecificationsTbls.FindAsync(id);

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
                var Data = await db.SpecificationsTbls.ToListAsync();
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
        public async Task<ApiHttpResponsecs> Update(SpecificationsTbl Model, int id)
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
                var Data = await db.SpecificationsTbls.FindAsync(id);
                Data.SpecificationName = Model.SpecificationName;
                Data.SpecificationType = Model.SpecificationType;
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

    public interface ISpecificationsTblService
    {

        Task<ApiHttpResponsecs> Add(SpecificationsTbl Model);
        Task<ApiHttpResponsecs> Update(SpecificationsTbl Model, int id);
        Task<ApiHttpResponsecs> List();
        Task<ApiHttpResponsecs> GetByid(int id);
        Task<ApiHttpResponsecs> DeleteByid(int id);
    }
}
