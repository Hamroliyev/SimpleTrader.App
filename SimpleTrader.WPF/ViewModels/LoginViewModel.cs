using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
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

        public MessageViewModel ErrorMessageViewModel { get; }
        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ICommand LoginCommand { get; }
        public ICommand ViewRegisterCommand { get; }
        public LoginViewModel(IAuthenticator authenticator, IRenavigator renavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();

            LoginCommand = new LoginCommand(this, authenticator, renavigator);
        }
    }
}