using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI
{
    public class FinancilaModelingPrepHttpClient: HttpClient
    {
        private readonly string apiKey;

        public FinancilaModelingPrepHttpClient(string apiKey)
        {
            this.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/");
            this.apiKey = apiKey;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage response = await GetAsync($"{uri}?apikey=6fe66fe1c6a9acc242b9b2c3cae64efe");
            string jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}
