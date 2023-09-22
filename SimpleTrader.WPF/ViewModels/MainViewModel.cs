using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleTrader.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ISimpleTraderViewModelFactory _viewModelFactory;
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;
        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;
        public ICommand UpdateCurentViewModelCommand { get; }

        public MainViewModel(INavigator navigator,ISimpleTraderViewModelFactory viewModelFactory, IAuthenticator authenticator)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;

            _navigator.StateChanged += _navigator_StateChanged;
            _authenticator.StateChanged += _authenticator_StateChanged;
            UpdateCurentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurentViewModelCommand.Execute(ViewType.Login);
        }

        private void _authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        private void _navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
