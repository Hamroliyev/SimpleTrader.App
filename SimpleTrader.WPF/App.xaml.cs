﻿using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.AuthenticationServices;
using SimpleTrader.Domain.Services.TransactionService;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;
using SimpleTrader.FinancialModelingPrepAPI;
using SimpleTrader.FinancialModelingPrepAPI.Services;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.State.Assets;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.Factories;
using System;
using System.Configuration;
using System.Windows;

namespace SimpleTrader.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    string apiKey = ConfigurationManager.AppSettings.Get("financeApiKey");
                    services.AddSingleton<FinancialModelingPrepHttpClientFactory>(new FinancialModelingPrepHttpClientFactory(apiKey: apiKey));

                    services.AddSingleton<SimpleTraderDbContextFactory>();
                    services.AddSingleton<IAuthenticationService, AuthenticationService>();
                    services.AddSingleton<IDataService<Account>, AccountDataService>();
                    services.AddSingleton<IAccountService, AccountDataService>();
                    services.AddSingleton<IStockPriceService, StockPriceService>();
                    services.AddSingleton<IBuyStockService, BuyStockService>();
                    services.AddSingleton<IMajorIndexService, MajorIndexService>();

                    services.AddSingleton<IPasswordHasher, PasswordHasher>();

                    services.AddSingleton<ISimpleTraderViewModelFactory, SimpleTraderViewModelFactory>();
                    services.AddSingleton<BuyViewModel>();
                    services.AddSingleton<PortfolioViewModel>();
                    services.AddSingleton<AssetSummaryViewModel>();

                    services.AddSingleton<HomeViewModel>(services => new HomeViewModel(
                        services.GetRequiredService<AssetSummaryViewModel>(),
                        MajorIndexListingViewModel.LoadMajorIndexViewModel(
                           services.GetRequiredService<IMajorIndexService>())));

                    services.AddSingleton<CreateViewModel<HomeViewModel>>(services =>
                    {
                        return () => services.GetRequiredService<HomeViewModel>();
                    });

                    services.AddSingleton<CreateViewModel<BuyViewModel>>(services =>
                    {
                        return () => services.GetRequiredService<BuyViewModel>();
                    });

                    services.AddSingleton<CreateViewModel<PortfolioViewModel>>(services =>
                    {
                        return () => services.GetRequiredService<PortfolioViewModel>();
                    });

                    services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
                    services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
                    {
                        return () => new LoginViewModel(
                            services.GetRequiredService<IAuthenticator>(),
                            services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>());
                    });

                    services.AddSingleton<INavigator, Navigator>();
                    services.AddSingleton<IAuthenticator, Authenticator>();
                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<IAccountStore, AccountStore>();
                    services.AddSingleton<AssetStore>();
                    services.AddScoped<BuyViewModel>();

                    services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
                });
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            IAuthenticationService authenticationService = serviceProvider.GetRequiredService<IAuthenticationService>();

            authenticationService.Login("HamroliyevAhmadjon","909813997");

            Window window =  serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            

            return services.BuildServiceProvider();
        }
    }
}
