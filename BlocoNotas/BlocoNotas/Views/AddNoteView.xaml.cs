using BlocoNotas.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlocoNotas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNoteView : ContentPage
    {
        public AddNoteView()
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new AddNoteViewModel();
        }
    }
}