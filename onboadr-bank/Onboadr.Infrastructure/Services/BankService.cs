using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Onboadr.Infrastructure.Services.Interface;
using Onboardr.Domain;

namespace Onboadr.Infrastructure.Services
{
    public class BankService : IBankService
    {
        private readonly IConfiguration _configuration;

        public BankService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       

        public BankDetails GetBankDetails()
        {
            var subscriptionKey = _configuration.GetValue<string>("Subscription_Key");
            var baseUrl = _configuration.GetValue<string>("Api_Url");


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                var url = "alat-test/api/Shared/GetAllBanks";

                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result =  response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<BankDetails>(result);

                }
                else
                {
                    return new BankDetails()
                    {
                        
                        Result = new List<Result>()
                       
                    };
                }
            }
        }
    }
}
