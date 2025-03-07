using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using DTO;
using ENT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class PersonaVM : INotifyPropertyChanged
    {
        private ObservableCollection<Persona> listaPersonas = new ObservableCollection<Persona>();
        private Persona personaSeleccionada;
        public DelegateCommand crearPersona { get; }
        public DelegateCommand actualizarLista { get; }
        public DelegateCommand editarCommand { get; }
        public DelegateCommand borrarCommand { get; }
        public DelegateCommand detallesCommand { get; }

        public ObservableCollection<Persona> ListaPersonas
        {
            get { return listaPersonas; }
            set
            {
                listaPersonas = value;
                NotifyPropertyChanged("ListaPersonas");
            }
        }
        public Persona PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set
            {
                personaSeleccionada = value;
                editarCommand.RaiseCanExecuteChanged();
                borrarCommand.RaiseCanExecuteChanged();
                detallesCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("PersonaSeleccionada");
            }
        }
        public PersonaVM()
        {
            crearPersona = new DelegateCommand(createPersonaExecute);
            actualizarLista = new DelegateCommand(CargarPersonas);
            editarCommand = new DelegateCommand(editarExecute, canEditarPersona);
            borrarCommand = new DelegateCommand(eliminarPersonaExecute, canExecuteEliminar);
            detallesCommand = new DelegateCommand(detallesExecute, canExecuteDetalles);
        }



        public async void CargarPersonas()
        {
            List<Persona> lista = await ApiResponse.ObtenerListadoMAUI();
            listaPersonas.Clear();
            listaPersonas = new ObservableCollection<Persona>(lista);
            NotifyPropertyChanged("ListaPersonas");
        }

        private async void createPersonaExecute()
        {
            await Shell.Current.GoToAsync("//CreatePage");
        }


        private async void editarExecute()
        {
            Dictionary<string, object> editarPersona = new Dictionary<string, object>
            {
                {"editarPersona", personaSeleccionada }
            };

            await Shell.Current.GoToAsync("//EditarPage", editarPersona);

        }

        private bool canEditarPersona()
        {
            bool res = false;
            if (personaSeleccionada != null)
            {
                res = true;
            }
            return res;

        }

        private async void eliminarPersonaExecute()
        {
            bool confirmado;
            bool eliminar = await Application.Current.MainPage.DisplayAlert(
                       "Eliminar",
                       $"¿Estás seguro que quieres eliminar a {personaSeleccionada.Nombre}?",
                       "Sí",
                       "No"
                   );
            if (eliminar)
            {
                confirmado = await ApiResponse.EliminarObj(personaSeleccionada.Id);
                if (confirmado)
                {
                    await Application.Current.MainPage.DisplayAlert("Confirmado", "Persona eliminada con exito", "OK");
                    CargarPersonas();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("ERROR", "No se pudo eliminar a la persona", "vaya :[");
                }
            }
        }

        private bool canExecuteEliminar()
        {
            bool res = false;
            if (personaSeleccionada != null)
            {
                res = true;
            }
            return res;
        }

        private async void detallesExecute()
        {
            Dictionary<string, object> detalles = new Dictionary<string, object>
            {
                { "DetallesPersona",personaSeleccionada }
            };

            await Shell.Current.GoToAsync("//DetallesPage", detalles);
        }

        private bool canExecuteDetalles()
        {
            bool res = false;
            if (personaSeleccionada != null)
            {
                res = true;
            }
            return res;
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
