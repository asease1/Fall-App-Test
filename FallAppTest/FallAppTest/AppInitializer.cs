using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Utils;

namespace FallAppTest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            return Xamarin.UITest.ConfigureApp.Android
                .ApkFile("Debug.apk")
                .WaitTimes(new WaitTimes())
                .StartApp();

        }
        public class WaitTimes : IWaitTimes
        {
            TimeSpan IWaitTimes.GestureWaitTimeout
            {
                get { return TimeSpan.FromMinutes(1); }
            }
            TimeSpan IWaitTimes.WaitForTimeout
            {
                get { return TimeSpan.FromMinutes(1); }
            }

            TimeSpan IWaitTimes.GestureCompletionTimeout
            {
                get { return TimeSpan.FromMinutes(1); }
            }

            //            public TimeSpan GestureCompletionTimeout => throw new NotImplementedException();
        }
    }
}

