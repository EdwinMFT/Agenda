﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace Practica9.Droid
{
    [Activity(Label = "Practica9", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ISQLAzure
    {

        private MobileServiceUser usuario;
        public async Task<MobileServiceUser> Authenticate()
        {
            var message = string.Empty;
            try
            {
                //usuario = await Practica9.Login.Cliente.LoginAsync(this, MobileServiceAuthenticationProvider.Facebook, "https://portal.azure.com/#resource/subscriptions/738314d0-92ec-4d5a-b881-4fcc29ddea24/resourceGroups/Practica9/providers/Microsoft.Web/sites/Practica9/authv2");
                usuario = await Practica9.Login.Cliente.LoginAsync(this, MobileServiceAuthenticationProvider.MicrosoftAccount, "tesh.azurewebsites.net");
                if (usuario != null)
                {
                    //message = string.Format("usuario autenticado{0}.", usuario.UserId);
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle("Resultado de Autenticacion");
            builder.Create().Show();
            return usuario;

        }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            App.Init((ISQLAzure)this);
            LoadApplication(new App());
        }
    }
}

