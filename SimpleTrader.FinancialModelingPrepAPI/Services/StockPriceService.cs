using Newtonsoft.Json;
using SimpleTrader.Domain.Exceptions;
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
        private readonly FinancialModelingPrepHttpClient _httpClient;

        public StockPriceService(FinancialModelingPrepHttpClient httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }
        public async Task<double> GetPrice(string symbol)
        {
           
                string uri = "otc/real-time-price/" + symbol;

                StockPriceResult stockPriceResult = await _httpClient.GetAsync<StockPriceResult>(uri);

                if (stockPriceResult.Price == 0)
                {
                    throw new InvalidSymbolException(symbol);
                }

                return stockPriceResult.Price;
            
        }
    }
}
