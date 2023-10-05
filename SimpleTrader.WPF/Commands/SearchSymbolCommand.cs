using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public class SearchSymbolCommand : AsyncCommandBase
    {
        private readonly BuyViewModel _buyViewModel;
        private readonly IStockPriceService _stockPriceService;

        public SearchSymbolCommand(BuyViewModel viewModel, IStockPriceService stockPriceService)
        {
            _buyViewModel = viewModel;
            _stockPriceService = stockPriceService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _buyViewModel.ErrorMessage = string.Empty;
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
                _buyViewModel.ErrorMessage = "Failed to get symbol information.";
            }
        }
    }
}
