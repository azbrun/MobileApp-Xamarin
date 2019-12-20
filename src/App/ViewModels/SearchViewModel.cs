using App.Models;
using App.Services;
using App.Views;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App.ViewModels
{
   public class SearchViewModel : INotifyPropertyChanged
    {
        public string title;
        public string jobType;
        public bool isRemote;

        public Command Buscar { get; set; }
        public JobListModel Jobss { get; set; }
        public Command LlenarListaCommand { get; set; }
        public INavigation Navigation { get; set; }
        public SearchViewModel(INavigation navigation)
        {
            this.Navigation = navigation;

            Buscar = new Command(async () => await GoJobsList());
            new Action(async () => await LoadData())();
        }

        private async Task GoJobsList()
        {
            await Navigation.PushAsync(new JosbListView(Title, JobCards, IsRemote));
        }

        public async Task LoadData()
        {
            var Cards = await AppConstant.ApiUrl
                .AppendPathSegment(AppConstant.ApiEndPoint)
                .SetQueryParams(new { pagesize = AppConstant.PageSize, page = 1 })
                .WithHeader("Ocp-Apim-Subscription-Key", AppConstant.AppSecrets)
                .GetJsonAsync<JobListModel>();

            Jobss = Cards;
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string JobCards
        {
            get { return jobType; }
            set { jobType = value; }
        }
        public bool IsRemote
        {
            get { return isRemote; }
            set { isRemote = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
