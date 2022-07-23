using System.Text.Json.Serialization;

namespace Eshop.Application.Common.Abstract
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Error Error { get; set; }
    }
}