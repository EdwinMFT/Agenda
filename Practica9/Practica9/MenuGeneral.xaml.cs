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
    public partial class MenuGeneral : TabbedPage
    {
        string datoPiker, datopikersem, datopikerUs, datopikerStatus, datopikerDep, datopikerTareasDep, datopikerUsAdd;
        //public ObservableCollection<_13090352> Items { get; set; }
        //public static MobileServiceClient Cliente;
        //public static IMobileServiceTable<_13090352> Tabla;
        //public static MobileServiceUser usuario;
        public ObservableCollection<Tareas_Edwin> Items { get; set; }
        public ObservableCollection<_13090352> Items2 { get; set; }
        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<Tareas_Edwin> Tabla2;
        public static MobileServiceUser usuario;

        public MenuGeneral ()
        {
            InitializeComponent();
            
            
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
                    //User = datopikerUs,
                    Password=Entry_Pass.Text,
                    TipoUsuario= datopikerUs
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

            Navigation.PushModalAsync(new Login());
        }
        
        private void ButtonVerUs_Clicked(object sender, EventArgs e)
        {                        
            Navigation.PushModalAsync(new MenuDatos());
            
        }

        private async void BuscarTareasUs_Clicked(object sender, EventArgs e)
        {
            //VerTareasUsuarios();
            
            IEnumerable<Tareas_Edwin> elementos = await Login.TablaTareas.IncludeDeleted().ToEnumerableAsync();
            Items = new ObservableCollection<Tareas_Edwin>(elementos);
            BindingContext = this;
            Lista.ItemsSource = Items.Where(dato => dato.Matricula == VerTar.Text);

        }
        async void ListViewTareas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            await Navigation.PushModalAsync(new SelectPageTareas(e.SelectedItem as Tareas_Edwin));
        }              

        private async void AddTarea_Clicked(object sender, EventArgs e)
        {


            var datos = new Tareas_Edwin
            {
                
                Titulo =Tit.Text,
                Descripcion=Des.Text,
                Matricula= Usu.Text,
                Prioridad=Prio.Text,
                Fecha_entrega=Calen.Date.ToString(),
                Dependencia= datopikerTareasDep,
                UsuarioDepen=userDep.Text,
                TareaDepen = tarearDep.Text,
                Desarrollo =Desarro.Text,
                Tarea=Tar.Text,
                Status=datopikerStatus               
            };

            if (Tit.Text==null)
            {
                await DisplayAlert("", "Agregar un Titulo", "ok");
            }else if (Des.Text==null)
            {
                await DisplayAlert("", "Agregar una Descripcion", "ok");
            }
            else if(Usu.Text==null)
            {
                await DisplayAlert("", "Agregar Matricula", "ok");
            }
            else if(Prio.Text==null)
            {
                await DisplayAlert("", "Agregar Prioridad", "ok");
            }else if (datopikerTareasDep==null)
            {
                await DisplayAlert("", "Seleccion Si hay Dependencia", "ok");
            }
            else
            {
                await Login.TablaTareas.InsertAsync(datos);
                await DisplayAlert("", "Tarea agregada", "ok");
            }
            

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
        private void PickerUserAdd_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                datopikerUsAdd = (string)picker.ItemsSource[selectedIndex];
            }
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
        private void PickerSem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                datopikersem = (string)picker.ItemsSource[selectedIndex];
            }
        }
        
        //private void PickerDependencia_SelectedIndexChanged_1(object sender, EventArgs e)
        //{
        //    var picker = (Picker)sender;
        //    int selectedIndex = picker.SelectedIndex;

        //    if (selectedIndex != -1)
        //    {
        //        datopikerDep = (string)picker.ItemsSource[selectedIndex];
        //    }
        //}        
        private void PickerTareas_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                datopikerTareasDep = (string)picker.ItemsSource[selectedIndex];
            }
            if (datopikerTareasDep == "Si")
            {
                tarearDep.IsEnabled = true;
                userDep.IsEnabled = true;
            }
            else
            {
                tarearDep.IsEnabled = false;
                userDep.IsEnabled = false;
            }                      
        }
    }
}
