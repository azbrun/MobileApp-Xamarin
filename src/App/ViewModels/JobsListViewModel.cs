﻿using App.Models;
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
    class JobsListViewModel : INotifyPropertyChanged
    {
        //public AppConstant ServiceConstant = new AppConstant();
        public JobListModel JobsList { get; set; }
        public Command CallDetailScreenCommand { get; set; }
        public INavigation Navigation { get; set; }
        public JobsListViewModel(INavigation navshell)
        {
            this.Navigation = navshell;
            CallDetailScreenCommand = new Command<string>(async (string Link) => await OpenDetailViewAsync(Link));
            new Action(async () => await LoadDataAsync())();

            
        }

        public async Task LoadDataAsync()
        {
            
            var Cards = await AppConstant.ApiUrl
                .AppendPathSegment(AppConstant.ApiEndPoint)
                .SetQueryParams(new { pagesize = AppConstant.PageSize, page = 1 })
                .WithHeader("Ocp-Apim-Subscription-Key", AppConstant.AppSecrets)
                .GetJsonAsync<JobListModel>();
            JobsList = Cards;

        }

        public async Task OpenDetailViewAsync(string link) {
            
            await Navigation.PushAsync(new JobDetailView(link));
        
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
