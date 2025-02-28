using Ecommerces.Entity;
using Ecommerces.Entity.Model;
using Ecommerces.Helpers;
using Ecommerces.Models;
using Microsoft.EntityFrameworkCore;
using static Ecommerces.Services.RegisterTblService;

namespace Ecommerces.Services
{
    public class RegisterTblService : IRegisterTblService, IDisposable
    {
        private readonly EntityDbContext Db;

        public RegisterTblService(EntityDbContext Db)
        {
            this.Db = Db;
        }
        public async Task<ApiHttpResponsecs> Add(RegisterTbl Model)
        {
            try
            {

                if (Model == null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.ModelNull, ResponseStatus.Error, 404);
                }
                var Data = await Db.RegisterTbls.Where(m => m.Email == Model.Email && m.MobileNo == Model.MobileNo).FirstOrDefaultAsync();
                if (Data != null)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.AllReadyExist, ResponseStatus.Conflict, 404);

                }
                Db.RegisterTbls.Add(Model);
                var RowCount = Db.SaveChanges();
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<ApiHttpResponsecs> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.NoId, ResponseStatus.Error, 404);

                }
                var Data = await Db.RegisterTbls.FindAsync(id);

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

                var Data = await Db.RegisterTbls.ToListAsync();
                if (Data == null)
                {
                    ApiHttpResponsecs.CreatResponse(Massage.NoData, ResponseStatus.Nodata, 404);
                }
                return ApiHttpResponsecs.CreatResponse(Data);
            }
            catch (Exception Ex)
            {
                return ApiHttpResponsecs.CreatResponse(Ex.ToString(), ResponseStatus.Error, 500);

            }
        }

        //public async Task<ApiHttpResponsecs> LoginAdd(string Email, string Password, RegisterTbl Model)
        //{
        //    try
        //    {
        //        if (Model == null)
        //        {
        //            return ApiHttpResponsecs.CreatResponse(Massage.ModelNull, ResponseStatus.Error, 404);
        //        }
        //        var Data = await Db.RegisterTbls.SingleOrDefaultAsync(m => m.Email == Model.Email && m.Password == Model.Password);
        //        if (Data != null)
        //        {
        //            return ApiHttpResponsecs.CreatResponse(Data, Massage.SuccessLogin);
        //        }
        //        else
        //        {
        //            return ApiHttpResponsecs.CreatResponse(Massage.LoginInvalid);
        //        }

        //        //return ApiHttpResponsecs.CreatResponse(Data);
        //    }
        //    catch (Exception Ex)
        //    {
        //        return ApiHttpResponsecs.CreatResponse(Ex.ToString(), ResponseStatus.Error, 500);
        //    }

        //}

        public async Task<ApiHttpResponsecs> LoginAdd(string Email, string Password)
        {
            var Data = await Db.RegisterTbls.SingleOrDefaultAsync(m => m.Email == Email && m.Password == Password);
            if (Data != null)
            {
                return ApiHttpResponsecs.CreatResponse(Data, Massage.SuccessLogin);
            }
            else
            {
                return ApiHttpResponsecs.CreatResponse(Massage.LoginInvalid);
            }
        }

        public async Task<ApiHttpResponsecs> UserData(int id)
        {
            try
            {
                var Data = await Db.RegisterTbls.Where(m => m.RegId == id).FirstOrDefaultAsync();
                if (Data != null)
                {
                    return ApiHttpResponsecs.CreatResponse(Data, Massage.GetById);
                }
                else
                {
                    return ApiHttpResponsecs.CreatResponse(Massage.getbyid);
                }


            }
            catch (Exception Ex)
            {
                return ApiHttpResponsecs.CreatResponse(Ex.ToString(), ResponseStatus.Error, 500);
            }

        }
        public interface IRegisterTblService
        {
            Task<ApiHttpResponsecs> Add(RegisterTbl Model);
            Task<ApiHttpResponsecs> LoginAdd(string Email, string Password);
            Task<ApiHttpResponsecs> List();
            Task<ApiHttpResponsecs> UserData(int id);
            Task<ApiHttpResponsecs> GetById(int id);

        }
    }
}
