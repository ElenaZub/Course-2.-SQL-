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

            this.AuthorsList = new ObservableCollection<Author>();
            this.BookList = new ObservableCollection<Book>();
            this.BookListSecond = new ObservableCollection<Book>();

            this.AuthorListView.DataContext = this.AuthorsList;

            AuthorsList.Add(new Author(false, "Mark", "Twain", DateTime.Today, Model.Country.USA, Model.Language.English, "Florida, Missouri", BookList));
            AuthorsList.Add(new Author(false, "O.", "Henry", DateTime.Today, Model.Country.USA, Model.Language.English, "Kharkiv", BookListSecond));

            BookListSecond.Add(new Book(false, "Some 1 book", 500, new DateTime(2001, 12, 2)));
            BookListSecond.Add(new Book(false, "Some 2 book", 600, new DateTime(2001, 12, 2)));
            BookListSecond.Add(new Book(false, "Some 3 book", 700, new DateTime(2001, 11, 2)));

            BookList.Add(new Book(false, "Title 1", 20, DateTime.Today));
            BookList.Add(new Book(false, "Title 2", 20, DateTime.Today.AddDays(-2)));
        }

        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int selectedAuthorId = AuthorListView.SelectedIndex;
            var source = e.Source;


            if ((source == NewAuthorMenu) || (source  == NewAuthorButton))
            {
                Author addedAuthor = new Author();
                ChangeAuthor addAuthor = new ChangeAuthor(addedAuthor);

                var res = addAuthor.ShowDialog();

                if (res == true)
                {
                    addedAuthor.IsNew = false;
                    this.AuthorsList.Add(addedAuthor);
                }
            }
            else if (source == NewBookMenu || source == NewBookButton)
            {
                Book addedBook = new Book();
                ChangeBook addBook = new ChangeBook(addedBook);

                var res = addBook.ShowDialog();

                if (res == true)
                    addedBook.IsNew = false;
                    this.AuthorsList[selectedAuthorId].BooksList.Add(addedBook);
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
            var selectedBook = this.BookDataGrid.SelectedItem as Book;

            var selectedAuthor = this.AuthorListView.SelectedItem as Author;
            var authorIndex = this.AuthorListView.SelectedIndex;
            this.AuthorsList[authorIndex].IsNew = false;

            if (e.Source is Button)
            { 
                var source = e.Source as Button;
                Debug.WriteLine(source.Name);

                if (source.Name == "ChangeAuthorButton")
                {
                    ChangeAuthor changeAuthor = new ChangeAuthor(selectedAuthor);

                    changeAuthor.ShowDialog();
                    this.AuthorListView.Items.Refresh();
                    this.BookDataGrid.Items.Refresh();

                }
                else if (source.Name == "ChangeBookButton")
                {
                    ChangeBook changeBook = new ChangeBook(selectedBook);

                    changeBook.ShowDialog();
                    //this.AuthorListView.Items.Refresh();
                    this.AuthorListView.Items.Refresh();
                    this.BookDataGrid.Items.Refresh();
                }
            }
            if (e.Source is MenuItem)
            {
                var source = e.Source as MenuItem;
                Debug.WriteLine(source.Name);
                if (source.Name == "ChangeAuthorMenu")
                {
                    ChangeAuthor changeAuthor = new ChangeAuthor(selectedAuthor);

                    changeAuthor.ShowDialog();
                    this.AuthorListView.Items.Refresh();
                    this.BookDataGrid.Items.Refresh();
                }
                else if (source.Name == "ChangeBookMenu")
                {
                    ChangeBook changeBook = new ChangeBook(selectedBook);

                    changeBook.ShowDialog();
                    //this.AuthorListView.Items.Refresh();
                    this.AuthorListView.Items.Refresh();
                    this.BookDataGrid.Items.Refresh();
                }
            }
        }

        private void CanExecuteCustom_Command(object sender, CanExecuteRoutedEventArgs e)
        {
            var source = e.Source;

            if (source == ChangeAuthorButton)
            {
                if (this.AuthorListView.SelectedItem == null)
                    e.CanExecute = false;
                else
                    e.CanExecute = true;
            }
            if (source == ChangeAuthorMenu)
            {
                if (this.AuthorListView.SelectedItem == null)
                    e.CanExecute = false;
                else
                    e.CanExecute = true;
            }
            if (source == ChangeBookButton)
            {
                if (this.BookDataGrid.SelectedItem == null)
                    e.CanExecute = false;
                else
                    e.CanExecute = true;
            }
            if (source == ChangeBookMenu)
            {
                if (this.BookDataGrid.SelectedItem as Book== null)
                    e.CanExecute = false;
                else
                    e.CanExecute = true;

            }
        }

        private void Delete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var source = e.Source;

            if (source == DeleteAuthorButton)
            {
                if (this.AuthorsList.Count != 0)
                    this.AuthorsList.RemoveAt(this.AuthorListView.SelectedIndex);
            }
            if (source == DeleteAuthorMenu)
            {
                if (this.AuthorsList.Count != 0)
                    this.AuthorsList.RemoveAt(this.AuthorListView.SelectedIndex);
            }
            if (source == DeleteBookButton)
            {
                if (this.AuthorsList[this.AuthorListView.SelectedIndex].BooksList.Count != 0)
                    this.AuthorsList[this.AuthorListView.SelectedIndex].BooksList.RemoveAt(this.BookDataGrid.SelectedIndex);
            }

            if (source == DeleteBookMenu)
            {
                if (this.AuthorsList[this.AuthorListView.SelectedIndex].BooksList.Count != 0)
                    this.AuthorsList[this.AuthorListView.SelectedIndex].BooksList.RemoveAt(this.BookDataGrid.SelectedIndex);
            }
        }
    }
}
