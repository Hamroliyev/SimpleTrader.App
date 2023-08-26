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
            using (FinancilaModelingPrepHttpClient client = new FinancilaModelingPrepHttpClient())
            {
                string uri = "otc/real-time-price/" + symbol;

                StockPriceResult stockPriceResult = await client.GetAsync<StockPriceResult>(uri);
                return stockPriceResult.Price;
            }
        }
    }
}
