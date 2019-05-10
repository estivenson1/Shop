using Shop.Common.Models;
using Shop.Common.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Shop.UIForms.ViewModels
{
  public  class ProductsViewModel : BaseViewModel
    {
        private ApiService apiService;

        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get => this.products;
            set => this.SetValue(ref this.products, value);
        }

        private bool isRefreshing;
        public bool IsRefreshing
        {
            get => this.isRefreshing;
            set => this.SetValue(ref this.isRefreshing, value);
        }

        public ProductsViewModel()
        {
            apiService = new ApiService();
            this.LoadProducts();
        }

        private async void LoadProducts()
        {
            this.IsRefreshing = true;
            var response = await this.apiService.GetListAsync<Product>(
                "https://shopeov.azurewebsites.net",
                "/api",
                "/Products");
     

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            var myProducts = (List<Product>)response.Result;
            this.Products = new ObservableCollection<Product>(myProducts);

            this.IsRefreshing = false;
        }
    }
}
