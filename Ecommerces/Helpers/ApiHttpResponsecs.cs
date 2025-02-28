
namespace Ecommerces.Helpers
{

    public enum ResponseStatus
    {
        Success,
        Failure,
        Error,
        Warning,
        Nodata,
        Conflict,
        Info

    }
    public class ApiHttpResponsecs
    {

        public object? Data { get; set; }
        public string Massage { get; set; }
        public string Status { get; set; }
        public int StatusCode { get; set; }

        ///<summary>        
        ///This is response of api 
        /// </summary>
        /// <param name="Massage"></param>
        /// <param name="Status"></param>
        /// <param name="StatusCode"></param>
        /// <returns></returns>
        ///

        public static ApiHttpResponsecs CreatResponse(string Massage, ResponseStatus Status = ResponseStatus.Success, int StatusCode = 200)
        {
            ApiHttpResponsecs responsecs = new ApiHttpResponsecs
            {
                Data = null,
                Massage = Massage,
                Status = Status.ToString(),
                StatusCode = StatusCode
            };
            return responsecs;
        }





        public static ApiHttpResponsecs CreatResponse(object Data, string Massage = "Your Data Successfully fatch" , ResponseStatus Status = ResponseStatus.Success, int StatusCode = 200)
        {
            ApiHttpResponsecs responsecs = new ApiHttpResponsecs
            {
                Data = Data,
                Massage = Massage,
                Status = Status.ToString(),
                StatusCode = StatusCode
            };
            return responsecs;
        }

        //public static implicit operator string(ApiHttpResponsecs v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}