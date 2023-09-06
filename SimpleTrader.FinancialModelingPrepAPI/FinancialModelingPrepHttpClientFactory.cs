using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI
{
    public class FinancialModelingPrepHttpClientFactory
    {
        private readonly string apiKey;

        public FinancialModelingPrepHttpClientFactory(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public FinancialModelingPrepHttpClient CreateHttpClient()
        {
            return new FinancialModelingPrepHttpClient(apiKey: this.apiKey);
        }
    }
}
