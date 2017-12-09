using Microsoft.WindowsAzure.MobileServices;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace Practica9
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    
    public partial class RegistrosIUD : ContentPage
    {
        //public static MobileServiceClient Cliente;
        //public static IMobileServiceTable<_13090352> Tabla;
        //SQLiteConnection database;
        string datoPiker, datopikersem, datopikerUs;
        public RegistrosIUD()
        {
            InitializeComponent();
            //Cliente = new MobileServiceClient(AzureConnection.AzureURL);
            //Tabla = Cliente.GetTable<_13090352>();
            //string db;
            //db = DependencyService.Get<ISQLite>().GetLocalFilePath("TESHD.db");
            //database = new SQLiteConnection(db);
            //database.CreateTable<TESHDatos>();

        }


        private async void Insertar_Clicked(object sender, EventArgs e)
        {
            int t = 10;


            try
            {

                var datos = new _13090352
                {
                    // Id = Entry_IDAzure.Text,
                    Matricula = Convert.ToInt64(Entry_ID.Text),
                    Nombre = Entry_Name.Text,
                    Apellidos = Entry_Ap.Text,

                    Direccion = Entry_Dir.Text,
                    Telefono = Entry_Tel.Text,
                    //Carrera=Entry_Car.Text,
                    Carrera = datoPiker,
                    //Semestre = Entry_Sem.Text,
                    Semestre = datopikersem,
                    Correo = Entry_Cor.Text,
                    Github = Entry_Git.Text,
                    //User= datopikerUs
                };
                
                //await Navigation.PushModalAsync(new DetailPageBD());
                if (Entry_ID.Text == null)
                {
                    await DisplayAlert("", "Ingresar Matricula", "ok");
                }
                else if (Entry_Name.Text == null)
                {
                    await DisplayAlert("", "Ingrese un Nombre", "ok");
                }
                else if (Entry_Ap.Text == null)
                {
                    await DisplayAlert("", "Ingresar Apellidos", "ok");
                }
                else if (Entry_Dir.Text == null)
                {
                    await DisplayAlert("", "Ingresar una Direccion", "ok");
                }
                else if (Entry_Tel.Text == null)
                {
                    await DisplayAlert("", "Ingresar Telefono", "ok");
                }
                else if (datoPiker == null)
                {
                    await DisplayAlert("", "Ingresa una Carrera", "ok");
                }
                else if (datopikersem == null)
                {
                    await DisplayAlert("", "Ingresar un Semestre", "ok");
                }
                else if (Entry_Cor.Text == null)
                {
                    await DisplayAlert("", "Ingresar un Correo", "ok");
                }
                else if (Entry_Git.Text == null)
                {
                    await DisplayAlert("", "Ingresar una cuenta de GitHub", "ok");
                }
                else if (Entry_Tel.Text.Length != t)
                {
                    await DisplayAlert("", "El Numero Telefonico debe contener 10 Digitos", "ok");
                }
                else
                {
                    try
                    {
                        // database.Insert(datos);
                        await Login.Tabla.InsertAsync(datos);
                        await DisplayAlert("", "Registro Agregado", "ok");
                        await Navigation.PushModalAsync(new MenuDatos());
                    }
                    catch (SQLite.SQLiteException ex1)
                    {
                        await DisplayAlert("", "Error Matricula Existente SQLITE ", "ok1");
                    }

                }
            }
            catch (System.FormatException ex2)
            {
                await DisplayAlert("", "Ingresar Unicamente Numeros Valide Matricula u Telefono", "ok2");
            }    
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

        private void Cancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MenuDatos());
        }

        private void PickerUser_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                datopikerUs = (string)picker.ItemsSource[selectedIndex];
            }
        }

        private void PickerSem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                datopikersem = (string)picker.ItemsSource[selectedIndex];
            }
        }
    }
}