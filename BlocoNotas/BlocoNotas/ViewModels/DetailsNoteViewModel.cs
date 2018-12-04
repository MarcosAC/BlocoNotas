using BlocoNotas.Models;
using BlocoNotas.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlocoNotas.ViewModels
{
    public class DetailsNoteViewModel : BaseViewModel
    {
        private readonly INoteRepository _noteRepository;
        private readonly INavigationService _navigationService;

        private Note _note;

        public DetailsNoteViewModel(Note selectedNote = null)
        {
            _noteRepository = new NoteRepository();
            _navigationService = new NavigationService();

            _note = new Note
            {
                NoteId = selectedNote.NoteId,
                TitleNote = selectedNote.TitleNote,
                TextNote = selectedNote.TextNote
            };
        }

        public string TitleNote
        {
            get => _note.TitleNote;
            set
            {
                _note.TitleNote = value;
            }
        }

        public string TextNote
        {
            get => _note.TextNote;
            set
            {
                _note.TextNote = value;
            }
        }

        private Command _BackListNotesCommand;
        public Command BackListNotesCommand => _BackListNotesCommand ?? (_BackListNotesCommand = new Command(async () => await ExecuteBackListNotesCommand()));

        private async Task ExecuteBackListNotesCommand() => await _navigationService.PopAsync();
    }
}
