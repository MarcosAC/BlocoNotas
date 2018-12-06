using BlocoNotas.Models;
using BlocoNotas.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlocoNotas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsNoteView : ContentPage
    {
        private Note _selectedNote;

        public DetailsNoteView(Note selectedNote)
        {
            InitializeComponent();

            _selectedNote = selectedNote;

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new DetailsNoteViewModel(selectedNote);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new DetailsNoteViewModel(_selectedNote);
        }
    }
}