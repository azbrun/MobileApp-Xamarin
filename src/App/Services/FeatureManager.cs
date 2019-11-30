
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
        public static event EventHandler FlagHasBeenChanged = (o,e)=>{};
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

        internal static void RegisterForChange()
        {
            FeatureFlagClient.FlagChanged += FeatureFlagClient_FlagChanged;
        }

        internal static void UnregisterForChange()
        {
            FeatureFlagClient.FlagChanged -= FeatureFlagClient_FlagChanged;
        }

        private static void FeatureFlagClient_FlagChanged(object sender, FlagChangedEventArgs e)
        {
            FlagHasBeenChanged(null, null);
        }

        public static bool IsEnabled(string slug)
        {
            if (!isInialized) Init();
            return FeatureFlagClient.BoolVariation(slug);
        }
    }
}
