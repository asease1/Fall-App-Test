using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FallAppTest
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        private void LogInCitizenUser()
        {
            app.EnterText(c => c.Marked("UserName"), "a");
            app.EnterText(c => c.Marked("Password"), "b");
            app.Tap(c => c.Marked("LogInButton"));
        }

        private void LogInContactUser()
        {
            app.EnterText(c => c.Marked("UserName"), "b");
            app.EnterText(c => c.Marked("Password"), "a");
            app.Tap(c => c.Marked("LogInButton"));
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void LoginIn()
        {
            //app.Repl();
            LogInCitizenUser();

            AppResult[] resualt = app.WaitForElement(c => c.Marked("helpButton"), "Did not see the success message.",
                new TimeSpan(0, 0, 0, 90, 0));

            Assert.IsTrue(resualt.Length == 1);
        }



        [Test]
        public void CallForHelpCancel()
        {
            LogInCitizenUser();

            AppResult[] helpButton = app.WaitForElement(c => c.Marked("helpButton"), "Did not see the success message.",
                new TimeSpan(0, 0, 0, 90, 0));

            app.Tap(c => c.Marked("helpButton"));

            AppResult[] respons = app.WaitForElement(c => c.Marked("NoHelp"), "Did not see the success message.",
                new TimeSpan(0, 0, 0, 90, 0));

            app.Tap(c => c.Marked("NoHelp"));

            AppResult[] resualt = app.WaitForElement(c => c.Marked("helpButton"), "Did not see the success message.",
                new TimeSpan(0, 0, 0, 90, 0));

            Assert.IsTrue(resualt.Length == 1);
        }

        /*[Test]
        public void CallForHelpCancel()
        {
            //app.Repl();

            app.EnterText(c => c.Id("NoResourceEntry-4"), "a");
            app.EnterText(c => c.Id("NoResourceEntry-5"), "b");
            app.Tap(c => c.All().Text("Log på"));

            app.Screenshot("First screen.");

            AppResult[] helpButton = app.WaitForElement(c => c.Marked("NoResourceEntry-7"), "Did not see the success message.",
                new TimeSpan(0, 0, 0, 90, 0));

            app.Tap(c => c.Id("NoResourceEntry-7"));

            AppResult[] respons = app.WaitForElement(c => c.Marked("NoResourceEntry-8"), "Did not see the success message.",
                new TimeSpan(0, 0, 0, 90, 0));

            app.Tap(c => c.Id("NoResourceEntry-8"));

            AppResult[] resualt = app.WaitForElement(c => c.Marked("NoResourceEntry-7"), "Did not see the success message.",
                new TimeSpan(0, 0, 0, 90, 0));

            app.Repl();
        }*/

        [Test]
        public void LogInAsContactPerson()
        {
            LogInContactUser();

            AppResult[] helpButton = app.WaitForElement(c => c.Marked("ContactList"), "Did not see the success message.",
                new TimeSpan(0, 0, 0, 90, 0));

            Assert.IsTrue(helpButton.Length == 1);
        }
    }
}

