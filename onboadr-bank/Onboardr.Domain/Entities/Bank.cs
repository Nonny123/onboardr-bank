using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboardr.Domain.Entities
{
    //public class Bank
    //{
    //    [JsonProperty("bankName")]
    //    public string BankName { get; set; }

    //    [JsonProperty("bankCode")]
    //    public string BankCode { get; set; }
    //}

    //public class BankDetails
    //{
    //    [JsonProperty("bank")]
    //    public List<Bank> Banks { get; set; }

    //    [JsonProperty("errorMessage")]
    //    public object ErrorMessage { get; set; }

    //    [JsonProperty("errorMessages")]
    //    public object ErrorMessages { get; set; }

    //    [JsonProperty("hasError")]
    //    public bool HasError { get; set; }

    //    [JsonProperty("timeGenerated")]
    //    public DateTime TimeGenerated { get; set; }
    //}

   
    /// ///////////////////////////////////////////////  
    //response structure
    //    {
    //  "result": [
    //    {
    //      "bankName": "ALATbyWEMA",
    //      "bankCode": "035"
    //    },
    //    {
    //    "bankName": "WEMA BANK",
    //      "bankCode": "035"
    //    },
    //    {
    //    "bankName": "ACCESS BANK",
    //      "bankCode": "044"
    //    },
    //    {
    //    "bankName": "ASO SAVINGS",
    //      "bankCode": "401"
    //    },
    //    {
    //    "bankName": "CITI BANK",
    //      "bankCode": "023"
    //    }
    //  ],
    //  "errorMessage": null,
    //  "errorMessages": null,
    //  "hasError": false,
    //  "timeGenerated": "2022-08-15T17:04:20.7822457Z"
    //}

    //model structure
    public class BankDetails
    {
        public Bank[] result { get; set; }
        public object errorMessage { get; set; }
        public object errorMessages { get; set; }
        public bool hasError { get; set; }
        public DateTime timeGenerated { get; set; }
    }

    public class Bank
    {
        public string bankName { get; set; }
        public string bankCode { get; set; }
    }
    ///////////////////////////////////////////////////////






    //response structure
    //[
    // {
    //   "id": 1,
    //   "title": "Post 1"
    // },
    // {
    //   "id": 2,
    //   "title": "Post 2"
    // },
    // {
    //"id": 3,
    //"title": "Post 3"
    // }
    //]

    //model structure
    //public class Post
    //{
    //    public int id { get; set; }
    //    public string title { get; set; }
    //}




}
