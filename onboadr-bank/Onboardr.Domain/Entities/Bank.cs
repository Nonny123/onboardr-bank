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




    //response structure@@(ARRAY OF OBJECTS)
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
    //End structure@@








    //response structure@@
    //{
    //  "month": "8",
    //  "num": 2659,
    //  "link": "",
    //  "year": "2022",
    //  "news": "",
    //  "safe_title": "Unreliable Connection",
    //  "transcript": "",
    //  "alt": "NEGATIVE REVIEWS MENTION: Unreliable internet. POSITIVE REVIEWS MENTION: Unreliable internet.",
    //  "img": "https://imgs.xkcd.com/comics/unreliable_connection.png",
    //  "title": "Unreliable Connection",
    //  "day": "15"
    //}

    //model structure
    //public class ComicModel
    //{
    //    //public string month { get; set; }
    //    public int num { get; set; }
    //    //public string link { get; set; }
    //    //public string year { get; set; }
    //    //public string news { get; set; }
    //    //public string safe_title { get; set; }
    //    //public string transcript { get; set; }
    //    //public string alt { get; set; }
    //    public string img { get; set; }
    //    //public string title { get; set; }
    //    //public string day { get; set; }
    //}
    //End structure@@








    //response structure@@
    //{
    //  "results": {
    //    "sunrise": "10:10:52 AM",
    //    "sunset": "12:01:55 AM",
    //    "solar_noon": "5:06:23 PM",
    //    "day_length": "13:51:03",
    //    "civil_twilight_begin": "9:42:40 AM",
    //    "civil_twilight_end": "12:30:06 AM",
    //    "nautical_twilight_begin": "9:06:36 AM",
    //    "nautical_twilight_end": "1:06:11 AM",
    //    "astronomical_twilight_begin": "8:27:48 AM",
    //    "astronomical_twilight_end": "1:44:59 AM"
    //  },
    //  "status": "OK"
    //}

    ////model structure
    //public class SunResultModel
    //{
    //    public SunModel results { get; set; }
    //    public string status { get; set; }
    //}

    //public class SunModel
    //{
    //    public string sunrise { get; set; }
    //    public string sunset { get; set; }
    //    //public string solar_noon { get; set; }
    //    //public string day_length { get; set; }
    //    //public string civil_twilight_begin { get; set; }
    //    //public string civil_twilight_end { get; set; }
    //    //public string nautical_twilight_begin { get; set; }
    //    //public string nautical_twilight_end { get; set; }
    //    //public string astronomical_twilight_begin { get; set; }
    //    //public string astronomical_twilight_end { get; set; }
    //}
    //End structure@@






    //response structure@@
    //    {
    //    "result": {
    //        "elements": [
    //            {
    //                "mailingListId": "CG_2TME9ELkWc7YH3Z",
    //                "name": "Premium Services 2022",
    //                "ownerId": "UR_79D5kKMLA6Acu46",
    //                "lastModifiedDate": 1642158717069,
    //                "creationDate": 1642083333701,
    //                "contactCount": 77025
    //            },
    //            {
    //    "mailingListId": "CG_2D15GJxjIq60ZrK",
    //                "name": "TCR",
    //                "ownerId": "UR_79D5kKMLA6Acu46",
    //                "lastModifiedDate": 1660644114615,
    //                "creationDate": 1660644114615,
    //                "contactCount": 2
    //            },
    //            {
    //    "mailingListId": "CG_2riMemOrwldirkG",
    //                "name": "Premium Services Cases",
    //                "ownerId": "UR_79D5kKMLA6Acu46",
    //                "lastModifiedDate": 1642599801371,
    //                "creationDate": 1642599801371,
    //                "contactCount": 1543
    //            },
    //            {
    //    "mailingListId": "CG_2TNLb11HiM2VZ9F",
    //                "name": "Branch Experience",
    //                "ownerId": "UR_79D5kKMLA6Acu46",
    //                "lastModifiedDate": 1657114144788,
    //                "creationDate": 1657114144788,
    //                "contactCount": 0
    //            },
    //            {
    //    "mailingListId": "CG_2Vkg9vNv1yFPMdD",
    //                "name": "FirstContact",
    //                "ownerId": "UR_79D5kKMLA6Acu46",
    //                "lastModifiedDate": 1642580455193,
    //                "creationDate": 1642580455193,
    //                "contactCount": 585985
    //            },
    //            {
    //    "mailingListId": "CG_1MWdo863uxSrCrR",
    //                "name": "Diaspora Banking",
    //                "ownerId": "UR_79D5kKMLA6Acu46",
    //                "lastModifiedDate": 1642591199770,
    //                "creationDate": 1642591199770,
    //                "contactCount": 0
    //            }
    //        ],
    //        "nextPage": null
    //    },
    //    "meta": {
    //    "httpStatus": "200 - OK",
    //        "requestId": "fbcc54ee-ca7a-44ec-b0a0-c454e040554f"
    //    }
    //}

    //////model structure
    //public class MailingListResult
    //{
    //    public MailingListModel result { get; set; }
    //    public Meta meta { get; set; }
    //}

    //public class MailingListModel
    //{
    //    public Element[] elements { get; set; }
    //    public object nextPage { get; set; }
    //}

    //public class Element
    //{
    //    public string mailingListId { get; set; }
    //    public string name { get; set; }
    //    public string ownerId { get; set; }
    //    public long lastModifiedDate { get; set; }
    //    public long creationDate { get; set; }
    //    public int contactCount { get; set; }
    //}

    //public class Meta
    //{
    //    public string httpStatus { get; set; }
    //    public string requestId { get; set; }
    //}
    ////End structure@@
 







    //response structure@@

    ////End structure@@


}
