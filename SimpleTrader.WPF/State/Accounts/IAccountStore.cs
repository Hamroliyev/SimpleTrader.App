using SimpleTrader.Domain.Models;
using System;

namespace SimpleTrader.WPF.State.Accounts
{
    public interface IAccountStore
    {
        Account CurrentAccount { get; set; }
        event Action StateChanged; 
    }
}
