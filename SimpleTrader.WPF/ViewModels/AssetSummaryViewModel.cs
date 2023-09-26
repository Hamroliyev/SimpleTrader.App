using SimpleTrader.WPF.State.Assets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.ViewModels
{
    public class AssetSummaryViewModel : ViewModelBase
    {
        private readonly AssetStore _assetStore;
        private readonly ObservableCollection<AssetViewModel> _assets;

        public double AccountBalance => _assetStore.AccountBalance;
        public IEnumerable<AssetViewModel> Assets => _assets;
        public AssetSummaryViewModel(AssetStore assetStore)
        {
            _assetStore = assetStore;
            _assets = new ObservableCollection<AssetViewModel>();
            _assetStore.StateChanged += AssetStore_StateChanged;
            ResetAssets();
        }
        private void ResetAssets()
        {
            IEnumerable<AssetViewModel> assetViewModels = _assetStore.AssetTransactions
                .GroupBy(g => g.Asset.Symbol)
                .Select(g => new AssetViewModel(g.Key, g.Sum(a => a.IsPurchase ? a.Shares : -a.Shares)));

            _assets.Clear();
            foreach (AssetViewModel assetViewModel in assetViewModels)
            {
                _assets.Add(assetViewModel);
            }
        }
        private void AssetStore_StateChanged()
        {
            OnPropertyChanged(nameof(AccountBalance));
            ResetAssets();
        }

    }
}
