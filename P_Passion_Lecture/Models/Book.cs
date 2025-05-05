using CommunityToolkit.Mvvm.ComponentModel;

namespace P_Passion_Lecture.Models
{
    public partial class BookEntry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Editeur { get; set; }
        public int Annee { get; set; }
        public int NbPages { get; set; }
        public string Resume { get; set; }
        public string ImageURL { get; set; }
        public string Extrait { get; set; }
        public string Categorie { get; set; }

    }
}
