using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleTrader.WPF.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
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
        private string _password;

        public string Password
        {
            get { return _password; }
            set 
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private string _confirmPassword;

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set 
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        public ICommand RegisterCommand { get; }

        public ICommand ViewLoginCommand { get; }

        public MessageViewModel ErrorMessageViewModel { get; }
        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }
        public RegisterViewModel()
        {
            ErrorMessageViewModel = new MessageViewModel();
        }


    }
}
