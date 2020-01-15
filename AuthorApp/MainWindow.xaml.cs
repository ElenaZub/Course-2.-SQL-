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
        private ObservableCollection<Author> AuthorsList { get; set; }

        private ObservableCollection<Book> BookListFirst { get; set; }

        private ObservableCollection<Book> BookListSecond { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.AuthorsList = new ObservableCollection<Author>();
            this.BookListFirst = new ObservableCollection<Book>();
            this.BookListSecond = new ObservableCollection<Book>();

            this.AuthorListView.DataContext = this.AuthorsList;

            this.BookListSecond.Add(new Book("Some 1 book", 500, new DateTime(2001, 12, 2), false));
            this.BookListSecond.Add(new Book("Some 2 book", 600, new DateTime(2001, 12, 2), false));
            this.BookListSecond.Add(new Book("Some 3 book", 700, new DateTime(2001, 11, 2), false));

            this.BookListFirst.Add(new Book("Roughing It", 500, new DateTime(1872, 3, 2), false));
            this.BookListFirst.Add(new Book("The Gilded Age", 200, new DateTime(1873, 6, 12), false));
            this.BookListFirst.Add(new Book("The Adventures of Tom Sawyer", 20, new DateTime(1873, 2, 12), false));
            this.BookListFirst.Add(new Book("The Adventures of Huckleberry Finn", 420, new DateTime(1884, 1, 12), false));
            this.BookListFirst.Add(new Book("A Connecticut Yankee in King Arthur’s Court", 700, new DateTime(1889, 10, 12), false));
            this.BookListFirst.Add(new Book("The Tragedy Of Pudd'nhead Wilson and Those Extraordinary Twins", 6000, new DateTime(1894, 9, 12), false));
            this.BookListFirst.Add(new Book("Following the Equator", 90, new DateTime(1897, 7, 12), false));
            this.BookListFirst.Add(new Book("The Mysterious Stranger", 870, new DateTime(1916, 8, 12), false));

            this.AuthorsList.Add(new Author("Mark", "Twain", new DateTime(1835, 11, 30), Model.Country.USA, Model.Language.English, "Florida, Missouri", this.BookListFirst, false));
            this.AuthorsList.Add(new Author("O.", "Henry", new DateTime(1862, 9, 11), Model.Country.USA, Model.Language.English, "NY", this.BookListSecond, false));
        }

        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //var source = e.Source;

            //if (source is MenuItem)
            //{
            //     if (source == AuthorListView)
            //    {
            //        AddAuthor();
            //    }
            //    else if (source == BookDataGrid)
            //    {
            //        AddBook();
            //    }
            //}
            //if (source is ListView)
            //{
            //    if (source == AuthorListView)
            //    {
            //        AddAuthor();
            //    }
            //}
            //else if (source is DataGrid)
            //{
            //    if (source == BookDataGrid)
            //    {
            //        AddBook();
            //    }
            //}
            //if (source is Button)
            //{
            //    Button buttonSource = source as Button;

            //    if (buttonSource.Name == "NewAuthorButton")
            //    {
            //        AddAuthor();
            //    }
            //    else if (buttonSource.Name == "NewBookButton")
            //    {
            //        AddBook();
            //    }
            //}

            if (e.Source is Button)
            {
                var source = e.Source as Button;

                if (source.Name == "NewAuthorButton")
                {
                    AddAuthor();
                }
                else if (source.Name == "NewBookButton")
                {
                    AddBook();
                }
            }
            else if (e.Source is ListView)
            {
                AddAuthor();
            }
            else if (e.Source is DataGrid)
            {
                AddBook();
            }
        }

        public void AddAuthor()
        {
            Author addedAuthor = new Author();
            ChangeAuthor addAuthor = new ChangeAuthor(addedAuthor);

            var res = addAuthor.ShowDialog();

            if (res == true)
            {
                addedAuthor.Save();
                this.AuthorsList.Add(addedAuthor);
            }
        }
        public void AddBook()
        {
            int selectedAuthorId = this.AuthorListView.SelectedIndex;
            Book addedBook = new Book();
            ChangeBook addBook = new ChangeBook(addedBook);

            var res = addBook.ShowDialog();

            if (res == true)
            {
                addedBook.Save();
                this.AuthorsList[selectedAuthorId].BooksList.Add(addedBook);
            }
        }

        private void Change_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Source is Button)
            {
                var source = e.Source as Button;

                if (source.Name == "ChangeAuthorButton")
                {
                    ChangeAuthor();
                }
                else if (source.Name == "ChangeBookButton")
                {
                    ChangeBook();
                }
            }
            else if (e.Source is ListView)
            {
                ChangeAuthor();
            }
            else if (e.Source is DataGrid)
            {
                ChangeBook();
            }
        }

        public void ChangeAuthor()
        {
            var selectedAuthor = this.AuthorListView.SelectedItem as Author;

            ChangeAuthor changeAuthor = new ChangeAuthor(selectedAuthor);

            changeAuthor.ShowDialog();
            this.AuthorListView.Items.Refresh();
            this.BookDataGrid.Items.Refresh();
        }

        public void ChangeBook()
        {
            var selectedBook = this.BookDataGrid.SelectedItem as Book;

            ChangeBook changeBook = new ChangeBook(selectedBook);

            changeBook.ShowDialog();
            this.AuthorListView.Items.Refresh();
            this.BookDataGrid.Items.Refresh();
        }

        private void Change_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Source is DataGrid)
            {
                var source = e.Source as DataGrid;

                if (source.Name == "BookDataGrid")
                {
                    if (this.AuthorListView.SelectedItem == null)
                        e.CanExecute = false;
                    else
                        e.CanExecute = true;
                }
            }
            else if (e.Source is ListView)
            {
                var source = e.Source as ListView;

                if (source.Name == "AuthorListView")
                {
                    if (this.AuthorListView.SelectedItem == null)
                        e.CanExecute = false;
                    else
                        e.CanExecute = true;
                }
            }
            else if (e.Source is Button)
            {
                var source = e.Source as Button;

                if (source.Name == "ChangeAuthorButton")
                {
                    if (this.AuthorListView.SelectedItem == null)
                        e.CanExecute = false;
                    else
                        e.CanExecute = true;
                }
                else if (source.Name == "ChangeBookButton")
                {
                    if (this.BookDataGrid.SelectedItem == null)
                        e.CanExecute = false;
                    else
                        e.CanExecute = true;
                }
            }
        }

        private void Delete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var bookIndex = this.BookDataGrid.SelectedIndex;
            var authorIndex = this.AuthorListView.SelectedIndex;

            if (e.Source is Button)
            {
                var source = e.Source as Button;

                if (source.Name == "DeleteAuthorButton")
                {
                    RemoveAuthor();
                }
                else if (source.Name == "DeleteBookButton")
                {
                    RemoveBook();
                }
            }
            else if (e.Source is ListView)
            {
                var source = e.Source as ListView;

                if (source.Name == "AuthorListView")
                {
                    RemoveAuthor();
                }
            }
            else if (e.Source is DataGrid)
            {
                var source = e.Source as DataGrid;

                if (source.Name == "BookDataGrid")
                {
                    RemoveBook();
                }
            }
        }

        private void RemoveAuthor()
        {
            var authorIndex = this.AuthorListView.SelectedIndex;

            if (this.AuthorsList.Count > 0)
                this.AuthorsList.RemoveAt(authorIndex);
        }

        private void RemoveBook()
        {
            var bookIndex = this.BookDataGrid.SelectedIndex;
            var authorIndex = this.AuthorListView.SelectedIndex;

            if (this.AuthorsList[authorIndex].BooksList.Count > 0)
                this.AuthorsList[authorIndex].BooksList.RemoveAt(bookIndex);
        }

        private void Delete_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Source is DataGrid)
            {
                var source = e.Source as DataGrid;

                if (source.Name == "BookDataGrid")
                {
                    if (this.AuthorListView.SelectedItem == null)
                        e.CanExecute = false;
                    else
                        e.CanExecute = true;
                }
            }
            else if (e.Source is ListView)
            {
                var source = e.Source as ListView;

                if (source.Name == "AuthorListView")
                {
                    if (this.AuthorListView.SelectedItem == null)
                        e.CanExecute = false;
                    else
                        e.CanExecute = true;
                }
            }
            else if (e.Source is Button)
            {
                var source = e.Source as Button;

                if (source.Name == "DeleteAuthorButton")
                {
                    if (this.AuthorListView.SelectedItem == null)
                        e.CanExecute = false;
                    else
                        e.CanExecute = true;
                }
                else if (source.Name == "DeleteBookButton")
                {
                    if (this.BookDataGrid.SelectedItem == null)
                        e.CanExecute = false;
                    else
                        e.CanExecute = true;
                }
            }
        }
    }
}
