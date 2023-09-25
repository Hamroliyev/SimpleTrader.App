using SimpleTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.State.Accounts
{
    public class AccountStore : IAccountStore
    {
        private Account _currentAccount;

        public Account CurrentAccount
        {
            get { return _currentAccount; }
            set
            {
                _currentAccount = value;
                StateChanged?.Invoke();
            }
        }



        public event Action StateChanged;
    }
}
