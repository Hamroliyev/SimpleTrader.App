using SimpleTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        Task<bool> Register(string email, string userName, string password, string confirmPassword);
        Task<Account> Login(string userName, string password);
    }
}
