using System;
using UsersSample.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsersSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new UserListView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
