﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class PortfolioViewModelFactory : ISimpleTraderViewModelFactory<PortfolioViewModel>
    {
        public PortfolioViewModel CreateViewModel()
        {
            return new PortfolioViewModel();
        }
    }
}
