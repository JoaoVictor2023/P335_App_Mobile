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
        [RelayCommand]
        private async void DeleteBook(BookEntry book)
        {
            if (book == null)
                return;

            books.Remove(book);

            using (var context = new AppDbContext())
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }
        }

        [RelayCommand]
        private async void EditBook(BookEntry book)
        {
            // Exemplo de edição: pode abrir uma nova page ou exibir um popup para editar os dados
            await Shell.Current.DisplayAlert("Modifier", $"Tu veux modifier: {book.Title}", "OK");

            // Aqui tu pode abrir uma tela de edição passando o livro como parâmetro
            // Ex: await Shell.Current.GoToAsync($"editpage?bookId={book.Id}");
        }

        public async void ReloadBooks()
        {
            Books.Clear();

            using (var context = new AppDbContext())
            {
                var existingBooks = await context.Books.ToListAsync();
                foreach (var book in existingBooks)
                {
                    Books.Add(book);
                }
            }
        }


    }
}
