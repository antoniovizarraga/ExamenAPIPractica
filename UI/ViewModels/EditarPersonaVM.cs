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
    [QueryProperty(nameof(PersonaEditar), "editarPersona")]
    public class EditarPersonaVM : INotifyPropertyChanged
    {
        private Persona personaEditar;
        public DelegateCommand editarPersonaCommand { get; set; }
        public Persona PersonaEditar
        {
            get { return personaEditar; }
            set
            {
                personaEditar = value;
                NotifyPropertyChanged("PersonaEditar");
                editarPersonaCommand.RaiseCanExecuteChanged();
            }
        }
        public EditarPersonaVM()
        {
            editarPersonaCommand = new DelegateCommand(editarPersonaExecute);
        }


        private async void editarPersonaExecute()
        {
            bool res = await ApiResponse.ActualizarObj(personaEditar);
            if (res)
            {
                Application.Current.MainPage.DisplayAlert("Persona actualizada", "La persona ha sido actualizada correctamente", "Aceptar");
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Persona no actualizada", "La persona no se ha podido actualizar", "Aceptar");
            }
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
