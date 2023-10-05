using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.AuthenticationServices;
using System;
using SimpleTrader.Domain.Exceptions;
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
        event Action StateChanged;

        Task<RegistrationResult> Register(string email, string userName, string password, string confirmPassword);
        /// <summary>
        /// Login to the application.
        /// </summary>
        /// <param name="userName">The user's name</param>
        /// <param name="password">The user's password.</param>
        /// <exception cref="UserNotFoundException">Thrown if the user does not exist.</exception>
        /// <exception cref="InvalidPasswordException">Thrown if the password is invalid.</exception>
        /// <exception cref="Exception">Thrown if the login fails.</exception>
        Task Login(string userName, string password);
        void LogOut();

    }
}
