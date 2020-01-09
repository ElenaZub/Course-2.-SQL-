using AuthorApp.Model;
using AuthorApp.Tools;
using AuthorApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AuthorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Author> AuthorsList { get; set; }

        public ObservableCollection<Book> BookList { get; set; }

        public ObservableCollection<Book> BookListSecond { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            var commandBinding = new CommandBinding(CustomCommands.Change);
            commandBinding.CanExecute += CommandBinding_CanExecute;
            commandBinding.Executed += CommandBinding_Executed;
            this.CommandBindings.Add(commandBinding);

            this.AuthorsList = new ObservableCollection<Author>();
            this.BookList = new ObservableCollection<Book>();
            this.BookListSecond = new ObservableCollection<Book>();

            this.AuthorListView.DataContext = this.AuthorsList;

            BookList.Add(new Book("Title", 20, new DateTime(2010, 2, 2)));
            BookListSecond.Add(new Book("Some 1 book", 500, new DateTime(2001, 12, 2)));
            BookListSecond.Add(new Book("Some 2 book", 600, new DateTime(2001, 12, 2)));
            BookListSecond.Add(new Book("Some 3 book", 700, new DateTime(2001, 11, 2)));

            AuthorsList.Add(new Author("Mark", "Twain", DateTime.Today, "USA", "English", "Florida, Missouri", BookList));
            AuthorsList.Add(new Author("O.", "Henry", DateTime.Today, "USA", "English", "Kharkiv", BookListSecond));

            BookList.Add(new Book("Title", 20, new DateTime(2010, 02, 02)));
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var source = e.Source;
            Debug.WriteLine(source);
            string newAuthor = "New Author";
            string newBook = "New Book";

            if((source as Button).Name == "NewAuthorMenu" || (source as Button).Name == "NewAuthorButton")
            {
                ChangeAuthor changeAuthor = new ChangeAuthor();
                changeAuthor.DataContext = newAuthor;
                changeAuthor.Show();
            }
            else if (source == NewBookMenu || source == NewBookButton)
            {
                ChangeBook changeBook = new ChangeBook();
                changeBook.DataContext = newBook;
                changeBook.Show();
            }
        }

        private void Delete_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var source = e.Source;
            Debug.WriteLine(source);

            if (source == DeleteAuthorButton)
            {
                if (AuthorListView.SelectedItem == null)
                    e.CanExecute = false;
                else
                    e.CanExecute = true;
            }
            else if (source == DeleteAuthorMenu)
            {
                if (AuthorListView.SelectedItem == null)
                    e.CanExecute = false;
                else
                    e.CanExecute = true;
            }
            else if (source == DeleteBookButton)
            {
                if (BookDataGrid.SelectedItem == null)
                    e.CanExecute = false;
                else
                    e.CanExecute = true;
            }
            else if (source == DeleteBookMenu)
            {
                if (BookDataGrid.SelectedItem == null)
                    e.CanExecute = false;
                else
                    e.CanExecute = true;
            }
        }

        private void ExecutedCustom_Command(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void CanExecuteCustom_Command(object sender, CanExecuteRoutedEventArgs e)
        {
        }

        private void Delete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int selectedAuthorId = AuthorListView.SelectedIndex;

            var source = e.Source;

            if (source == DeleteAuthorButton || source == DeleteAuthorMenu)
            {
                if (AuthorsList.Count != 0)
                    AuthorsList.RemoveAt(selectedAuthorId);
            }
            else if (source == DeleteBookButton || source == DeleteBookMenu)
            {
                var selectedBook = BookDataGrid.SelectedIndex;
                if (AuthorsList[selectedAuthorId].BooksList.Count != 0)
                    AuthorsList[selectedAuthorId].BooksList.RemoveAt(selectedBook);
            }
        }
    }
}
