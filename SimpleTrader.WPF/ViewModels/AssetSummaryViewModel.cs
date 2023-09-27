using SimpleTrader.WPF.State.Assets;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SimpleTrader.WPF.ViewModels
{
    public class AssetSummaryViewModel : ViewModelBase
    {
        private readonly AssetStore _assetStore;
        private readonly ObservableCollection<AssetViewModel> _topAssets;

        public double AccountBalance => _assetStore.AccountBalance;
        public IEnumerable<AssetViewModel> TopAssets => _topAssets;
        public AssetSummaryViewModel(AssetStore assetStore)
        {
            _assetStore = assetStore;
            _topAssets = new ObservableCollection<AssetViewModel>();
            _assetStore.StateChanged += AssetStore_StateChanged;
            ResetAssets();
        }
        private void ResetAssets()
        {
            IEnumerable<AssetViewModel> assetViewModels = _assetStore.AssetTransactions
                .GroupBy(g => g.Asset.Symbol)
                .Select(g => new AssetViewModel(g.Key, g.Sum(a => a.IsPurchase ? a.Shares : -a.Shares)))
                .Where(a => a.Shares > 0);

            _topAssets.Clear();
            foreach (AssetViewModel assetViewModel in assetViewModels)
            {
                _topAssets.Add(assetViewModel);
            }
        }
        private void AssetStore_StateChanged()
        {
            OnPropertyChanged(nameof(AccountBalance));
            ResetAssets();
        }

    }
}
