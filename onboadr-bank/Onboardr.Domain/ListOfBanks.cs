using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Onboardr.Domain
{
    public class Result
    {
        [JsonProperty("bankName")]
        public string BankName { get; set; }

        [JsonProperty("bankCode")]
        public string BankCode { get; set; }
    }

    public class Data
    {
        [JsonProperty("result")]
        public List<Result> Result { get; set; }

        [JsonProperty("errorMessage")]
        public object ErrorMessage { get; set; }

        [JsonProperty("errorMessages")]
        public object ErrorMessages { get; set; }

        [JsonProperty("hasError")]
        public bool HasError { get; set; }

        [JsonProperty("timeGenerated")]
        public DateTime TimeGenerated { get; set; }
    }
}
