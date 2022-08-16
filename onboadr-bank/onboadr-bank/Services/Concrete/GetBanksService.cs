using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using onboadr_bank.Services.Interface;
using Onboardr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace onboadr_bank.Services.Concrete
{
    public class GetBanksService : IGetBanksService
    {
        private readonly IConfiguration _configuration;

        public GetBanksService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<BankDetails> GetBankDetails()
        {
            var subscriptionKey = _configuration.GetValue<string>("Subscription_Key");
            var baseUrl = _configuration.GetValue<string>("Api_Url");


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                var url = "alat-test/api/Shared/GetAllBanks";

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<BankDetails>(result);

                }
                else
                {
                    //return new BankDetails()
                    //{

                    //    result = new Bank[0]

                    //};

                    throw new Exception(response.ReasonPhrase);
                }
            }
        }




        //public async Task<Post[]> GetPosts()
        //{

        //    //var baseUrl = _configuration.GetValue<string>("Api_Url");
        //     var baseUrl = "https://my-json-server.typicode.com/";

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(baseUrl);

        //        var url = "typicode/demo/posts";

        //        HttpResponseMessage response = await client.GetAsync(url);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = await response.Content.ReadAsStringAsync();

        //            return JsonConvert.DeserializeObject<Post[]>(result);

        //        }
        //        else
        //        {
        //            return new Post[0];
        //            throw new Exception(response.ReasonPhrase);

        //        }
        //    }
        //}





        //public async Task<ComicModel> GetComic()
        //{
        //    var baseUrl = "https://xkcd.com/";

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(baseUrl);

        //        var url = "info.0.json";

        //        HttpResponseMessage response = await client.GetAsync(url);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = await response.Content.ReadAsStringAsync();

        //            return JsonConvert.DeserializeObject<ComicModel>(result);

        //        }
        //        else
        //        {
        //            throw new Exception(response.ReasonPhrase);

        //        }
        //    }
        //}




        //public async Task<SunResultModel> GetSunRise()
        //{
        //    var baseUrl = "https://api.sunrise-sunset.org/";

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(baseUrl);

        //        var url = "json?lat=41.494804&lng=-75.536852&date=today";

        //        HttpResponseMessage response = await client.GetAsync(url);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = await response.Content.ReadAsStringAsync();

        //            return JsonConvert.DeserializeObject<SunResultModel>(result);

        //        }
        //        else
        //        {
        //            throw new Exception(response.ReasonPhrase);

        //        }
        //    }
        //}


        //public async Task<MailingListResult> GetMailingLists()
        //{
        //    //var apiToken = _configuration.GetValue<string>("API_TOKEN");
        //    var apiToken = "sFQpE4hDQTvofo4NTP6sh8AeJdSv5K1IxcFX2z0e";
        //    var baseUrl = "https://fra1.qualtrics.com/API/v3/directories/";

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(baseUrl); 
        //        client.DefaultRequestHeaders.Add("X-API-TOKEN", apiToken);

        //        var url = "POOL_3nbW7wEg1IbxVrn/mailinglists";

        //        HttpResponseMessage response = await client.GetAsync(url);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = await response.Content.ReadAsStringAsync();

        //            return JsonConvert.DeserializeObject<MailingListResult>(result);

        //        }
        //        else
        //        {
        //            throw new Exception(response.ReasonPhrase);

        //        }
        //    }
        //}
    }
}
