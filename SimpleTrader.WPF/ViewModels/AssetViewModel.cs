namespace SimpleTrader.WPF.ViewModels
{
    public class AssetViewModel
    {
        public string Symbol { get; }
        public int Shares { get; }
        public AssetViewModel(string symbol, int shares)
        {
            Symbol = symbol;
            Shares = shares;
        }

    }
}
