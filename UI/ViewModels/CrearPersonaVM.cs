using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using DTO;
using ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class CrearPersonaVM : INotifyPropertyChanged
    {
        private string nombre;
        private string apellidos;
        public DelegateCommand crearPersonaCommand { get; set; }
        public DelegateCommand volver { get; set; }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                NotifyPropertyChanged("Nombre");
                crearPersonaCommand.RaiseCanExecuteChanged();
            }
        }
        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                apellidos = value;
                NotifyPropertyChanged("Apellidos");
                crearPersonaCommand.RaiseCanExecuteChanged();
            }
        }

        public CrearPersonaVM()
        {
            crearPersonaCommand = new DelegateCommand(createPersonaExecute, canExecute);
            volver = new DelegateCommand(volverExecute);
        }


        private async void createPersonaExecute()
        {
            List<Persona> lista = await ApiResponse.ObtenerListadoMAUI();
            int id = lista.Count + 1;
            Persona persona = new Persona(id, nombre, apellidos);
            await ApiResponse.InsertarObjMAUI(persona);
            await Application.Current.MainPage.DisplayAlert("Persona creada", "La persona ha sido creada correctamente", "Aceptar");
            nombre = "";
            apellidos = "";
            NotifyPropertyChanged("Nombre");
            NotifyPropertyChanged("Apellidos");
        }
        private bool canExecute()
        {
            return !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(apellidos);
        }

        private async void volverExecute()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }

        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")

        {

            PropertyChanged?.Invoke(this, new
            PropertyChangedEventArgs(propertyName));

        }
        #endregion
    }
}
