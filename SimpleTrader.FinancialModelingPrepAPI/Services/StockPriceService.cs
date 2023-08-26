using Newtonsoft.Json;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        public async Task<double> GetPrice(string symbol)
        {
            using (HttpClient client = new HttpClient())
            {
                string uri = "https://financialmodelingprep.com/api/v3/otc/real-time-price/" + symbol;
                HttpResponseMessage response = await client.GetAsync(uri);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                StockPriceResult stockPriceResult = JsonConvert.DeserializeObject<StockPriceResult>(jsonResponse);

                return stockPriceResult.Price;
            }
        }
    }
}
