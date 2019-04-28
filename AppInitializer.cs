using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MDE.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
				return ConfigureApp
					//.Android.ApkFile("C:/Users/Pranay_Sathu/Desktop/com.ecolab.envision.mde.apk").EnableLocalScreenshots()
					.Android.ApkFile("C:/Users/Pranay_Sathu/Desktop/ecolab.apk").EnableLocalScreenshots()
					.StartApp();
			}

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}

