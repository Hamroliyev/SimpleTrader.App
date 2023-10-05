using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTrader.Domain.Exceptions;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services
{
    public interface IStockPriceService
    {
        /// <summary>
        /// Get the share price for a symbol.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>The price of symbol.</returns>
        /// <exception cref="InvalidSymbolException">Thrown if symbol does not exist.</exception>
        /// <exception cref="Exception">Thrown if getting symbol fails.</exception>
        Task<double> GetPrice(string symbol);
    }
}
