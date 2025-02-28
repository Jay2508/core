using Ecommerces.Entity;
using Ecommerces.Entity.Model;
using Ecommerces.Helpers;
using Ecommerces.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Ecommerces.Services
{
    public class SpecificationsOptionsTblService : ISpecificationsOptionsTblService
    {
        private readonly EntityDbContext db;

        public SpecificationsOptionsTblService(EntityDbContext db)
        {
            this.db = db;
        }

        public async Task<ApiHttpResponsecs> Add(SpecificationsOptionsTbl Model)
        {
            try
            {
                if (Model == null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.ModelNull, ResponseStatus.Nodata, 404);

                }
                var Data = await db.SpecificationsOptionsTbls.Where(m => m.Value == Model.Value).FirstOrDefaultAsync();
                if (Data != null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.AllReadyExist, ResponseStatus.Conflict, 404);
                }
                db.SpecificationsOptionsTbls.Add(Model);
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
                var Data = await db.SpecificationsOptionsTbls.FindAsync(id);
                if (Data == null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.NoData, ResponseStatus.Nodata, 404);
                }
                db.SpecificationsOptionsTbls.Remove(Data);
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
                var Data = await db.SpecificationsOptionsTbls.FindAsync(id);

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
                var Data = (from Scat in db.SpecificationsOptionsTbls
                            join cat in db.SpecificationsTbls
                            on Scat.SpeId equals cat.SpeId
                            select new SpecificationsOptionsTblDto
                            {
                                SpecificationsId = Scat.SpecificationsId,
                                SpecificationName = cat.SpecificationName,
                                 Value = Scat.Value,
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
        public async Task<ApiHttpResponsecs> SpeList()
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
        public async Task<ApiHttpResponsecs> Update(SpecificationsOptionsTbl Model, int id)
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
                var Data = await db.SpecificationsOptionsTbls.FindAsync(id);
           
                Data.SpeId = Model.SpeId;
                Data.Value = Model.Value;
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
    public interface ISpecificationsOptionsTblService
    {

        Task<ApiHttpResponsecs> Add(SpecificationsOptionsTbl Model);
        Task<ApiHttpResponsecs> Update(SpecificationsOptionsTbl Model, int id);
        Task<ApiHttpResponsecs> List();
        Task<ApiHttpResponsecs> SpeList();
        Task<ApiHttpResponsecs> SubCatList(int CatId);

        Task<ApiHttpResponsecs> GetByid(int id);
        Task<ApiHttpResponsecs> DeleteByid(int id);
    }
}
