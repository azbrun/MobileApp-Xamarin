
using System;
using LaunchDarkly.Client;
using LaunchDarkly.Xamarin;

namespace App.Services
{
    public static class Features
    {
        public static readonly string CanShowCategoryTags = "show-category-tags";
    }

    public static class FeatureManager
    {
        public static LdClient FeatureFlagClient;
        private static bool isInialized;

        public  static void Init()
        {
            if (isInialized) return;

            var user = User.WithKey(AppConstant.UserKey);
            var timeSpan = TimeSpan.FromSeconds(5);
            FeatureFlagClient = LdClient.Init(AppConstant.LaunchDarklyKey, user, timeSpan);
            isInialized = true;
        }

        public static bool IsEnabled(string slug)
        {
            if (!isInialized) Init();
            return FeatureFlagClient.BoolVariation(slug);
        }
    }
}
