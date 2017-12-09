using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace Practica9.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate,ISQLAzure
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //

        public MobileServiceUser usuario;

        public async Task<MobileServiceUser> Authenticate()
        {
            var message = string.Empty;
            try
            {
                //MobileServiceAuthenticationProvider: el tipo de dato con el que le damos autentyication 
                //en uwp solo se envian el provedor y el cache
                //usuario = await Practica9.Login.Cliente.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController, MobileServiceAuthenticationProvider.Facebook, "https://portal.azure.com/#resource/subscriptions/738314d0-92ec-4d5a-b881-4fcc29ddea24/resourceGroups/Practica9/providers/Microsoft.Web/sites/Practica9/authv2");
                usuario = await Practica9.Login.Cliente.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController, MobileServiceAuthenticationProvider.MicrosoftAccount, "tesh.azurewebsites.net");

                if (usuario != null)
                {
                   // message = string.Format("Usuario autenticado{0}.", usuario.UserId);
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            IUIAlertViewDelegate iUIAlert = null;
            UIAlertView avAlert = new UIAlertView("Resultado de autenticacion", message, iUIAlert, "ok", null);
            avAlert.Show();
            return usuario;
        }
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            App.Init(this);
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
