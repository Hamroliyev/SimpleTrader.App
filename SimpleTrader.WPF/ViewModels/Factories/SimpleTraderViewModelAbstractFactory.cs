﻿using SimpleTrader.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class SimpleTraderViewModelAbstractFactory : ISimpleTraderViewModelAbstractFactory
    {
        private readonly ISimpleTraderViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly ISimpleTraderViewModelFactory<PortfolioViewModel> _portfolioViewModelFactory;

        public SimpleTraderViewModelAbstractFactory(ISimpleTraderViewModelFactory<HomeViewModel> homeViewModelFactory,
               ISimpleTraderViewModelFactory<PortfolioViewModel> portfolioViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _portfolioViewModelFactory = portfolioViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Portfolio:
                    return _portfolioViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("The viewType does not have a viewModel.",nameof(viewType));
            }
        }
    }
}
