using BlocoNotas.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlocoNotas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListNoteView : ContentPage
	{
		public ListNoteView ()
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new ListNotesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ListNotesViewModel();
        }

        public ListNotesViewModel ViewModel
        {
            get { return BindingContext as ListNotesViewModel; }
            set => BindingContext = value;
        }

        private void OnItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                ViewModel.SelectNoteCommand.Execute(e.SelectedItem);

            listViewNotes.SelectedItem = null;
        }
    }
}