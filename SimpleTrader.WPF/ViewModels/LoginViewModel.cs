using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using System.Windows.Input;

namespace SimpleTrader.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
		private string _userName = "Ahmadjon";
		public string UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				_userName = value;
				OnPropertyChanged(nameof(UserName));
				OnPropertyChanged(nameof(CanLogin));
			}
		}

		private string _password;
		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
				OnPropertyChanged(nameof(Password));
				OnPropertyChanged(nameof(CanLogin));
			}
		}

		public bool CanLogin => !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);

		public MessageViewModel ErrorMessageViewModel { get; }

		public string ErrorMessage
		{
			set => ErrorMessageViewModel.Message = value;
		}

		public ICommand LoginCommand { get; }
		public ICommand ViewRegisterCommand { get; }

		public LoginViewModel(IAuthenticator authenticator, IRenavigator loginRenavigator, IRenavigator registerRenavigator)
		{
			ErrorMessageViewModel = new MessageViewModel();

			LoginCommand = new LoginCommand(this, authenticator, loginRenavigator);
			ViewRegisterCommand = new RenavigateCommand(registerRenavigator);
		}

		public override void Dispose()
		{
			ErrorMessageViewModel.Dispose();

			base.Dispose();
		}
	}
}