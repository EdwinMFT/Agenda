using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Practica9
{
    public partial class App : Application
    {

        public static ISQLAzure Autenticator { get; private set; }

        public static void Init(ISQLAzure auntenticator)
        {
            Autenticator = auntenticator;
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new Practica9.MenuDatos();
            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
