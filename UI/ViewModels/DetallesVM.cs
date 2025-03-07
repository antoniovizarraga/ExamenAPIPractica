using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
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
    [QueryProperty(nameof(PersonaDetalles), "DetallesPersona")]
    public class DetallesVM : INotifyPropertyChanged
    {
        private Persona persona;
        public DelegateCommand volverCommand { get; set; }

        public Persona PersonaDetalles
        {
            get { return persona; }
            set
            {
                persona = value;
                NotifyPropertyChanged("PersonaDetalles");
            }
        }
        public DetallesVM()
        {
            volverCommand = new DelegateCommand(volverExecute);
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
