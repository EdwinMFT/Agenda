using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.MobileServices;
namespace Practica9
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class unDelete : ContentPage
    {

        public ObservableCollection<_13090352> Items { get; set; }
        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<_13090352> Tabla;
        string datoPiker, datopikersem;
        public unDelete()
        {
            InitializeComponent();
            Cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = Cliente.GetTable<_13090352>();
            //Tabla.CreateQuery(Id="1");
            LeerTabla();
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

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            await Navigation.PushModalAsync(new SelectPage(e.SelectedItem as _13090352));


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
        private async void LeerTabla()
        {
            /*
            //comvierte la lista de datos a una lista enumerable
            IEnumerable<_13090352> elementos = await Login.Tabla.ToEnumerableAsync();
            Items = new ObservableCollection<_13090352>(elementos);

            //Tabla.CreateQuery("select*from toditem where deleted=true;");                      
            BindingContext = this;
            Lista.ItemsSource = Items;
            */
            //IEnumerable<_13090352> elementos = await Login.Tabla.IncludeDeleted().ToEnumerableAsync();
            //Items = new ObservableCollection<_13090352>(elementos);
            //BindingContext = this;
            //Lista.ItemsSource = Items.Where(dato => dato.Deleted == true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Login.usuario != null)
            {
                LeerTabla();
            }
        }
        //private async void LeerTabla()
        //{
        //    IEnumerable<_13090352> elementos = await Tabla.ToEnumerableAsync();
        //    Items = new ObservableCollection<_13090352>(elementos);
        //    BindingContext = this;
        //    Lista.ItemsSource = Items;
        //}

        /*private async void Button_Clicked(object sender, EventArgs e)
        {

            //IEnumerable<_13090352> elementos = await Login.Tabla.IncludeDeleted().ToEnumerableAsync();
            //Items = new ObservableCollection<_13090352>(elementos);
            //BindingContext = this;
            //Lista.ItemsSource = Items.Where(dato => dato.Deleted == true);

            //bool del = false;
            //var datos = new todoitem
            //{                
            //    Deleted=del
            //};

            //await Tabla.UndeleteAsync(datos);
            //await SelectPage.Tabla.UpdateAsync(datos);

        }*/
    }
}