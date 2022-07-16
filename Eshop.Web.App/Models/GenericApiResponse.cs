using Eshop.Application.Common.Models.Enums;
using System.Net;
using System.Text.Json.Serialization;

namespace Eshop.Web.App.Models
{
    public class GenericApiResponse<T>
    {
        public bool Succeeded { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[] Errors { get; set; }
        
        [JsonIgnore]
        public HttpStatusCode HttpStatusCode { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T Result { get; set; }
        
        public GenericApiResponse()
        {

        }

        public GenericApiResponse(T result, bool succeeded = true, string[] errors = null)
        {
            Result = result;
            Succeeded = (bool)(typeof(T).GetProperty("Succeeded")?.GetValue(result) ?? succeeded);
            Errors = (string[])(typeof(T).GetProperty("Errors")?.GetValue(result) ?? errors);
            HttpStatusCode = MapFromResponseCode(result);
        }

        private static HttpStatusCode MapFromResponseCode(T result)
        {
            var responseCode = (ResponseCode?)(typeof(T).GetProperty("ResponseCode")?.GetValue(result));

            return responseCode switch
            {
                ResponseCode.Succeded => HttpStatusCode.OK,
                ResponseCode.NotFound => HttpStatusCode.NotFound,
                _ => HttpStatusCode.InternalServerError,
            };
        }
    }

    public class GenericApiResponse : GenericApiResponse<string> { }
}