using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        Account CurrentAccount { get; }
        bool IsLoggedIn { get; }
        Task<RegistrationResult> Register(string email, string userName, string password, string confirmPassword);
        Task<bool> Login(string userName, string password);
        void LogOut();

    }
}
