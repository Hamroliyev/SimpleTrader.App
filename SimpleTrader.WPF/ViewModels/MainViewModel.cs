using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }
        public IAuthenticator Authenticator { get; set; }

        public MainViewModel(INavigator navigator, IAuthenticator authenticator)
        {
            Navigator = navigator;
            Authenticator = authenticator;
            Navigator.UpdateCurentViewModelCommand.Execute(ViewType.Login);
        }
    }
}
