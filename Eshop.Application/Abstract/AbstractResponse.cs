using System.Text.Json.Serialization;

namespace Eshop.Application.Abstract
{
    public abstract class AbstractResponse
    {
        [JsonIgnore]
        public bool Succeeded { get; set; }

        [JsonIgnore]
        public string[] Errors { get; set; }

        [JsonIgnore]
        public ResponseCode? ResponseCode { get; set; }
    }
}