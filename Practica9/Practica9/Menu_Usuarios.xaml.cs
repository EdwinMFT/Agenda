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
    public partial class Menu_Usuarios : ContentPage
    {

        public ObservableCollection<_13090352> Items { get; set; }
        public ObservableCollection<Tareas_Edwin> ItemsT { get; set; }
        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<_13090352> Tabla;
        public static MobileServiceUser usuario;

        public Menu_Usuarios()
        {
            InitializeComponent();
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            await Navigation.PushModalAsync(new SelectPageTareas(e.SelectedItem as Tareas_Edwin));
        }
        private async void leerMatricula()
        {
            IEnumerable<Tareas_Edwin> elementos = await Login.TablaTareas.IncludeDeleted().ToEnumerableAsync();
            ItemsT = new ObservableCollection<Tareas_Edwin>(elementos);
            BindingContext = this;
            string dt = UserD.Text;
            Lista.ItemsSource = ItemsT.Where(dato => dato.Matricula == UserD.Text);

        }
        private void ButtonBuscar_Clicked(object sender, EventArgs e)
        {
            leerMatricula();
        }
    }
}