using BlocoNotas.Models;
using System.Collections.Generic;

namespace BlocoNotas.Services
{
    public interface INoteRepository
    {
        List<Note> GetAll();
        Note Get(int id);
        void Insert(Note note);
        void UpDate(Note note);
        void DeleteAll();
        void Delete(Note note);
    }
}
