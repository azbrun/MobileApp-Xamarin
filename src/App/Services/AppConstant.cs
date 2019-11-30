using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App.Services
{
    public class AppConstant
    {
        public const string ApiUrl = "https://emplea-apm.azure-api.net/v1/api";
        public const string AppSecrets = "3f5b06a8cbd042a4b9963da0c41fb00e";
        public const string ApiEndPoint = "jobs";
        public const int PageSize = 50;


        public static readonly Color Background = Color.FromHex("F8F8F8");

        public static readonly string LaunchDarklyKey = "mob-257ecb8d-5bc8-43db-bd87-d1089b590167";
        public static readonly string UserKey = "claudio-sanchez";
    }
}