using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Services;
using App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JosbListView : ContentPage
    {
        public JosbListView()
        {
            InitializeComponent();
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            FeatureManager.RegisterForChange();
            FeatureManager.FlagHasBeenChanged += FeatureManager_FlagHasBeenChanged;
        }

        private async void FeatureManager_FlagHasBeenChanged(object sender, EventArgs e)
        {
            var viewModel = this.BindingContext as JobsListViewModel;
            await viewModel.LoadData();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            FeatureManager.UnregisterForChange();
            FeatureManager.FlagHasBeenChanged -= FeatureManager_FlagHasBeenChanged;
        }
    }
}