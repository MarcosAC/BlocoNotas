using BlocoNotas.Models;
using Realms;
using System.Collections.Generic;
using System.Linq;

namespace BlocoNotas.Services
{
    public class NoteRepository : INoteRepository
    {
        protected Realm RealmDb;

        public NoteRepository()
        {
            RealmDb = Realm.GetInstance();
        }

        public void Delete(Note note)
        {
            var noteData = RealmDb.Find<Note>(note.NoteId);

            RealmDb.Write(() => RealmDb.Remove(noteData));
        }

        public void DeleteAll()
        {
            RealmDb.Write(() => RealmDb.RemoveAll());
        }

        public void UpDate(Note note)
        {
            var noteData = RealmDb.Find<Note>(note.NoteId);            

            RealmDb.Write(() => {
                noteData.TitleNote = note.TitleNote;
                noteData.TextNote = note.TextNote;
                RealmDb.Add(noteData,true);
            });
        }

        public Note Get(int id)
        {
            return RealmDb.Find<Note>(id);
        }

        public List<Note> GetAll()
        {
            return RealmDb.All<Note>().ToList();
        }

        public void Insert(Note note)
        {
            var notes = RealmDb.All<Note>().ToList();
            var maxNotaId = 0;

            if (notes.Count != 0)
            {
                maxNotaId = notes.Max(n => n.NoteId);
            }

            note.NoteId = maxNotaId + 1;

            RealmDb.Write(() => note = RealmDb.Add(note));
        }
    }
}
