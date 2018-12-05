using BlocoNotas.Models;
using BlocoNotas.Services;
using BlocoNotas.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlocoNotas.ViewModels
{
    class EditNoteViewModel : BaseViewModel
    {
        private readonly INoteRepository _noteRepository;
        private readonly INavigationService _navigationService;

        private bool Edit = false;
        private Note _note;
        

        public EditNoteViewModel(Note selectedNote)
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
                OnPropertyChanged();
            }
        }

        public string TextNote
        {
            get => _note.TextNote;
            set
            {
                _note.TextNote = value;
                OnPropertyChanged();
            }
        }

        private Command _CancelEditNoteCommand;
        public Command CancelEditNoteCommand => _CancelEditNoteCommand ?? (_CancelEditNoteCommand = new Command(async () => await ExecuteCancelEditNoteCommand()));

        private async Task ExecuteCancelEditNoteCommand() => await _navigationService.PushAsync(new ListNoteView());

        private Command _EnableFieldsCommand;
        public Command EnableFieldsCommand => _EnableFieldsCommand ?? (_EnableFieldsCommand = new Command(() => ExecuteEnableFieldsCommand()));

        private void ExecuteEnableFieldsCommand()
        {
            Edit = true;
        }

        private Command _UpDateSelectedNoteCommand;
        public Command UpDateSelectedNoteCommand => _UpDateSelectedNoteCommand ?? (_UpDateSelectedNoteCommand = new Command(async () => await ExecuteUpDateSelectedNoteCommand()));

        private async Task ExecuteUpDateSelectedNoteCommand()
        {
            try
            {
                _noteRepository.UpDate(_note);
                await App.Current.MainPage.DisplayAlert("Editar", "Nota editada com sucesso.", "OK");
            }
            catch (Exception erro)
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Erro ao editar nota => " + erro, "OK");
            }

            await _navigationService.PushAsync(new ListNoteView());
        }
    }
}
