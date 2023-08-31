using SimpleTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services.TransactionService
{
    public interface IBuyStuckService
    {
        Task<Account> BuyStock(Account buyer, string symbol, int shares);
    }
}
