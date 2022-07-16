using Eshop.Application.Common.Models.Enums;
using System.Text.Json.Serialization;

namespace Eshop.Application.Common.Abstract
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