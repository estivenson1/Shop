namespace Shop.UIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Shop.UIForms.Views;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        #region Attributes

        #endregion


        #region Properties

        #endregion


        #region Constructors

        #endregion


        #region Methods	

        #endregion


        #region Commands
        public ICommand LoginCommand => new RelayCommand(Login);

        private async void Login()
        {
            if (String.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email",
                    "Accept");
                return;
            }

            if (String.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an password",
                    "Accept");
                return;
            }

            //await Application.Current.MainPage.DisplayAlert(
            //       "Ok",
            //       "Hola Mundo",
            //       "Accept");

            MainViewModel.GetInstance().Products = new ProductsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());
        }
        #endregion
    }
}
