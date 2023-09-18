using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.AuthenticationServices;
using SimpleTrader.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.State.Authenticators
{
    public class Authenticator : ObservableObject, IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        private Account _currentAccount;

        public Account CurrentAccount
        {
            get { return _currentAccount; }
            private set 
            { 
                _currentAccount = value;
                OnPropertyChanged(nameof(CurrentAccount));
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }


        public bool IsLoggedIn => CurrentAccount != null;

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
