using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleTrader.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set 
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private readonly ICommand LoginCommand;
        public LoginViewModel(IAuthenticator authenticator)
        {
            LoginCommand = new LoginCommand(this, authenticator);
        }
    }
}