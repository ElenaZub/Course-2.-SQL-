using AuthorApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public MainWindow()
        {
            InitializeComponent();

            this.AuthorsList = new ObservableCollection<Author>();
            this.BookList = new ObservableCollection<Book>();

            this.AuthorListView.DataContext = this.AuthorsList;

            BookList.Add(new Book("Title", 20, new DateTime(2010, 02, 02)));
            AuthorsList.Add(new Author("Mark", "Twain", DateTime.Today, "USA", "English", "Florida, Missouri", BookList));
            AuthorsList.Add(new Author("O.", "Henry", DateTime.Today, "USA", "English", "Kharkiv", BookList));

        }
    }
}
