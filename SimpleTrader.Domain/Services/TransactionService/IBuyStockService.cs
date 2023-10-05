using SimpleTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTrader.Domain.Exceptions;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services.TransactionService
{
    public interface IBuyStockService
    {
        /// <summary>
        /// Purchase a stock for an account.
        /// </summary>
        /// <param name="buyer">The account of buyer</param>
        /// <param name="symbol">The symbol purchaased</param>
        /// <param name="shares">The amount of shares</param>
        /// <returns>The updated account</returns>
        /// <exception cref="InsufficientFundsException">Thrown if the account has insufficient balance.</exception>
        /// <exception cref="InvalidSymbolException">Thrown if the purchased symbol is invalid.</exception>
        /// <exception cref="Exception">Thrown if the transaction fails.</exception>

        Task<Account> BuyStock(Account buyer, string symbol, int shares);
    }
}
