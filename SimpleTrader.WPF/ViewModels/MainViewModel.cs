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
        public MainViewModel(INavigator navigator)
        {
            Navigator = navigator;
            Navigator.UpdateCurentViewModelCommand.Execute(ViewType.Login);
        }
    }
}
