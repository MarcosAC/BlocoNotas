using Realms;

namespace BlocoNotas.Models
{
    public class Note : RealmObject
    {
        [PrimaryKey]
        public int NoteId { get; set; }
        public string TitleNote { get; set; }
        public string TextNote { get; set; }
    }
}
