using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlocoNotas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NoteView : ContentView
	{
		public NoteView ()
		{
			InitializeComponent ();
		}
	}
}