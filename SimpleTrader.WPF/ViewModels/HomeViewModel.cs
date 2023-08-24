using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public MajorIndexListingViewModel MajorIndexListingViewModel { get; set; }
        public HomeViewModel(MajorIndexListingViewModel majorIndexListingViewModel)
        {
            MajorIndexListingViewModel = majorIndexListingViewModel;
        }
    }
}
