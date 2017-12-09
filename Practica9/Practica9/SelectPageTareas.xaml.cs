using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica9
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectPageTareas : ContentPage
    {

        string datopikerStatus, datopikerDependencia;

        public SelectPageTareas(object selectedItem)
        {
            var dato = selectedItem as Tareas_Edwin;

            BindingContext = dato;
            InitializeComponent();
        }
        
        private void PickerStatus_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                datopikerStatus = (string)picker.ItemsSource[selectedIndex];
            }
        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            var dato = new Tareas_Edwin
            {
                Id=IDUSER.Text,
                Titulo = Tit.Text,
                Descripcion = Des.Text,
                Matricula = Usu.Text,
                Prioridad = Prio.Text,
                Fecha_entrega = Calen.Date.ToString(),
                Dependencia = datopikerDependencia,
                UsuarioDepen = userDep.Text,
                TareaDepen = tarearDep.Text,
                Desarrollo = Desarro.Text,
                Tarea = Tar.Text,
                Status = datopikerStatus
            };
            await DisplayAlert("","Tarea Completada","OK");
            await Login.TablaTareas.UpdateAsync(dato);
            await Navigation.PushModalAsync(new Menu_Usuarios());

            
        }

        private void btnEditar_Clicked(object sender, EventArgs e)
        {
            Tit.IsEnabled = true;
            Des.IsEnabled = true;
            Usu.IsEnabled = true;
            Prio.IsEnabled = true;
            Calen.IsEnabled = true;
            PikerDep.IsEnabled = true;
            userDep.IsEnabled = true;
            tarearDep.IsEnabled = true;
            PikerStatus.IsEnabled = true;

        }
        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        
        private void PickerDependencia_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                datopikerDependencia = (string)picker.ItemsSource[selectedIndex];
            }
        }
    }
}