using BlocoNotas.Models;
using BlocoNotas.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlocoNotas.ViewModels
{
    public class AddNoteViewModel : BaseViewModel
    {
        private readonly INoteRepository _noteRepository;
        private readonly INavigationService _navigationService;

        public AddNoteViewModel()
        {
            _noteRepository = new NoteRepository();
            _navigationService = new NavigationService();
        }

        private string _TitleNote;
        public string TitleNote
        {
            get => _TitleNote;
            set => SetProperty(ref _TitleNote, value);
        }

        private string _TextNote;
        public string TextNote
        {
            get => _TextNote;
            set => SetProperty(ref _TextNote, value);
        }

        private Command _BackListNotesCommand;
        public Command BackListNotesCommand => _BackListNotesCommand ?? (_BackListNotesCommand = new Command(async () => await ExecuteBackListNotesCommand()));

        private async Task ExecuteBackListNotesCommand() => await _navigationService.PopAsync();

        private Command _AddNoteCommand;
        public Command AddNoteCommand => _AddNoteCommand ?? (_AddNoteCommand = new Command(async () => await ExecuteAddNoteCommand()));

        private async Task ExecuteAddNoteCommand()
        {
            try
            {
                var note = new Note
                {
                    TitleNote = TitleNote,
                    TextNote = TextNote
                };

                _noteRepository.Insert(note);
                await Application.Current.MainPage.DisplayAlert("", "Nota salva com sucesso.", "OK");
            }
            catch (Exception Erro)
            {

                await Application.Current.MainPage.DisplayAlert("", "Erro ao adicionar Contato" + Erro, "Ok");
            }

            await _navigationService.PopAsync();
        }
    }
}
