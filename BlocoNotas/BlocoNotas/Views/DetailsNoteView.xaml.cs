using BlocoNotas.Models;
using BlocoNotas.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlocoNotas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsNoteView : ContentPage
    {
        public DetailsNoteView(Note selectedNote = null)
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new DetailsNoteViewModel(selectedNote);
        }
    }
}