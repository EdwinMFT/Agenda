using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica9
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public ObservableCollection<_13090352> Items { get; set; }
        public ObservableCollection<Tareas_Edwin> Items2 { get; set; }
        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<_13090352> Tabla;
        public static IMobileServiceTable<Tareas_Edwin> TablaTareas;

        public List<string> TItems { get; private set; }
        public static MobileServiceUser usuario;
        string datoPiker;
        public Login()
        {
            InitializeComponent();
            Cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = Cliente.GetTable<_13090352>();
            TablaTareas = Cliente.GetTable<Tareas_Edwin>();

        }
        
        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            //usuario = await App.Autenticator.Authenticate();
            //if (App.Autenticator != null)
            //{
            //    if (usuario != null)
            //    {
            //        await DisplayAlert("", "usuario autenticado" , "OK");
            //        await Navigation.PushModalAsync(new MainPage());
            //    }
            //    if (usuario == null)
            //    {
            //        //await DisplayAlert("", "usuario autenticado" + usuario.UserId, "OK");
            //        await DisplayAlert("", "usuario vacio", "OK");
            //        await Navigation.PushModalAsync(new MenuDatos());
            //    }
            //}
                               
             
                try
                {
                    if (App.Autenticator != null)
                    {

                        usuario = await App.Autenticator.Authenticate();

                        if (usuario != null)
                        {
                        if (usuario.UserId == "sid:95ca7d4ed3bc9b01cd2a4ea5b35f4db8")
                        {
                            await DisplayAlert("Usuario Autenticado","Administrador", "ok");
                            await Navigation.PushModalAsync(new MenuGeneral());
                        }
                        else
                        {
                            await DisplayAlert("Usuario Autenticado", "Usuario", "OK");
                            await Navigation.PushModalAsync(new Menu_Usuarios());
                        }
                        
                            //await Navigation.PushModalAsync(new MenuGeneral());
                    }
                    if (usuario == null)
                        {

                            await DisplayAlert("", "Usuario No Autenticado", "ok");
                        }   
                    }
                }
                catch (Exception ex)
                {
                await DisplayAlert("Error", ex.Message, "ok");
                }
            
                
        }
        

        //private async void ButtonEntrar_Clicked(object sender, EventArgs e)
        //{
            //IEnumerable<_13090352> elementos = await Login.Tabla.IncludeDeleted().ToEnumerableAsync();
            //Items = new ObservableCollection<_13090352>(elementos);
            //BindingContext = this;
            //string dt = UsuarioL.Text;
            //string us = elementos.Where(dato => dato.Nombre ==dt).ToString();

            //IMobileServiceTableQuery<_13090352> query = Tabla.CreateQuery().Select(UsuarioL => UsuarioL.Text);
            //List<string> items = await query.ToListAsync();

            //if (UsuarioL.Text == us)
            //{
            //    await DisplayAlert("Usuario Autenticado", usuario.UserId, "ok");
            //    await Navigation.PushModalAsync(new MenuGeneral());
            //}
            //else
            //{
            //    await DisplayAlert("", "Usuario No Autenticado", "ok");
            //}

            //IEnumerable<_13090352> elementos = await Login.Tabla.IncludeDeleted().ToEnumerableAsync();
            //Items = new ObservableCollection<_13090352>(elementos);
            //BindingContext = this;
            //Lista.ItemsSource = Items.Where(dato => dato.Nombre == UsuarioL.Text);
            //Lista.ItemsSource = Items.Where(dato => dato.Password == PassL.Text);


            
            
        //}

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            await Navigation.PushModalAsync(new SelectPage(e.SelectedItem as _13090352));
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                datoPiker = (string)picker.ItemsSource[selectedIndex];
            }
        }

        
    }
}