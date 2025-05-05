using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P_Passion_Lecture.Models;
using Microsoft.EntityFrameworkCore;



namespace P_Passion_Lecture.ViewModels
{
    public sealed partial class CrudViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddBookCommand))]
        private string titleEntry = "";

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddBookCommand))]
        private string authorEntry = "";

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddBookCommand))]
        private string editeurEntry = "";

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddBookCommand))]
        private int anneeEntry;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddBookCommand))]
        private int nbPagesEntry;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddBookCommand))]
        private string resumeEntry = "";

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddBookCommand))]
        public string imageURLEntry = "";

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddBookCommand))]
        private string extraitEntry = "";

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddBookCommand))]
        private string categorieEntry = "";


        [ObservableProperty]
        private ObservableCollection<BookEntry> books = new ObservableCollection<BookEntry>();

        private int _nextId = 1;

        public CrudViewModel()
        {
            Init();
        }

        private async void Init()
        {
            // Load existing cards from the database
            using (var context = new AppDbContext())
            {
                var existingBooks = await context.Books.ToListAsync();
                foreach (var book in existingBooks)
                {

                    books.Add(book);
                }

            }
        }

        [RelayCommand(CanExecute = nameof(CanAddBoth))]
        private async void AddBook()
        {

            var newBook = new BookEntry()
            {
                Title = titleEntry,
                Author = authorEntry,
                Editeur = editeurEntry,
                Annee = anneeEntry,
                NbPages = nbPagesEntry,
                Resume = resumeEntry,
                ImageURL = imageURLEntry,
                Extrait = extraitEntry,
                Categorie = categorieEntry
            };


            books.Add(newBook);

            using (var context = new AppDbContext())
            {
                context.Books.Add(newBook);
                context.SaveChanges();
            }

        }

        private bool CanAddBoth()
        {
            return !string.IsNullOrWhiteSpace(titleEntry) &&
                   !string.IsNullOrWhiteSpace(authorEntry) &&
                   !string.IsNullOrWhiteSpace(editeurEntry) &&
                       anneeEntry > 0 &&
                       nbPagesEntry > 0 &&
                   !string.IsNullOrWhiteSpace(resumeEntry) &&
                   !string.IsNullOrWhiteSpace(extraitEntry) &&
                   !string.IsNullOrWhiteSpace(categorieEntry);
        }
    }
}
