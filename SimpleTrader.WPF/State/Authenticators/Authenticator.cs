using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.AuthenticationServices;
using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.State.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountStore _accountStore;

        public Authenticator(IAuthenticationService authenticationService, IAccountStore accountStore)
        {
            _authenticationService = authenticationService;
            _accountStore = accountStore;
        }

        public Account CurrentAccount
        {
            get { return _accountStore.CurrentAccount; }
            private set 
            { 
                _accountStore.CurrentAccount = value;
                StateChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentAccount != null;

        public event Action StateChanged;

        public async Task<bool> Login(string userName, string password)
        {
            bool success = true;
            try
            {
                CurrentAccount = await _authenticationService.Login(userName, password);
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }

        public void LogOut()
        {
            CurrentAccount = null;
        }

        public async Task<RegistrationResult> Register(string email, string userName, string password, string confirmPassword)
        {
            return await _authenticationService.Register(email, userName, password, confirmPassword);
        }
    }
}
