using ENT;
using UI.ViewModels;

namespace UI
{
    public partial class MainPage : ContentPage
    {
        private PersonaVM vm;

        public MainPage()
        {
            InitializeComponent();
            vm = new PersonaVM();
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            vm.CargarPersonas(); // Llama al método del ViewModel
        }
    }

}
