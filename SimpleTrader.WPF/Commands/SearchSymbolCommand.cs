using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public class SearchSymbolCommand : ICommand
    {
        private readonly BuyViewModel _buyViewModel;
        private readonly IStockPriceService _stockPriceService;

        public SearchSymbolCommand(BuyViewModel buyViewModel, IStockPriceService stockPriceService)
        {
            _buyViewModel = buyViewModel;
            _stockPriceService = stockPriceService;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                double stockPrice = await _stockPriceService.GetPrice(_buyViewModel.Symbol);
                _buyViewModel.SearchResultSymbol = _buyViewModel.Symbol.ToUpper();
                _buyViewModel.StockPrice = stockPrice;
            }
            catch (InvalidSymbolException)
            {
                _buyViewModel.ErrorMessage = "Symbol does not exist.";
            }
            catch (Exception)
            {
                _buyViewModel.ErrorMessage = "Failed to get symbol information";
            }
        }
    }
}
