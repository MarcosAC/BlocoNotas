using BlocoNotas.Models;
using BlocoNotas.Services;
using BlocoNotas.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlocoNotas.ViewModels
{
    public class ListNotesViewModel : BaseViewModel
    {
        private readonly INoteRepository _noteRepository;
        private readonly INavigationService _navigationService;

        public ObservableCollection<Note> listNotes { get; }        

        public ListNotesViewModel()
        {
            _noteRepository = new NoteRepository();
            _navigationService = new NavigationService();

            listNotes = new ObservableCollection<Note>(ListNote());
        }

        private async Task ExecuteGoAddNoteCommand() => await _navigationService.PushAsync(new AddNoteView());

        private Command _GoAddNoteCommand;
        public Command GoAddNoteCommand => _GoAddNoteCommand ?? (_GoAddNoteCommand = new Command(async () => await ExecuteGoAddNoteCommand()));

        private Command _SelectNoteCommand;
        public Command SelectNoteCommand => _SelectNoteCommand ?? (_SelectNoteCommand = new Command<Note>(async n => await ExecuteSelectNoteCommand(n)));

        private async Task ExecuteSelectNoteCommand(Note selectedNote)
        {
            if (selectedNote == null)
                return;

            await _navigationService.PushAsync(new DetailsNoteView(selectedNote));
        }

        private List<Note> ListNote()
        {
            return _noteRepository.GetAll();
        }
    }
}
