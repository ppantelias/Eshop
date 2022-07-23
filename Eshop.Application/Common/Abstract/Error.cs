using System.Text.Json.Serialization;

namespace Eshop.Application.Common.Abstract
{
    public class Error
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Errors { get; set; }
    }
}