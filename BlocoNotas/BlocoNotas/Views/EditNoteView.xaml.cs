using BlocoNotas.Models;
using BlocoNotas.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlocoNotas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditNoteView : ContentPage
	{
		public EditNoteView (Note selectedNote)
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new EditNoteViewModel(selectedNote);
        }
	}
}