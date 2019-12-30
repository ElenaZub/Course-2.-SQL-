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

namespace Shop_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Book> bookList = new ObservableCollection<Book>();

        private int bookId = 0;

        public MainWindow()
        {
            InitializeComponent();

            this.bookList = new ObservableCollection<Book>();       
            DataGrid.ItemsSource = this.bookList;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (BookCheck())
            {
                decimal price = Convert.ToDecimal(Price.Text);
                string author = Author.Text;
                string title = Title.Text;
                string genre = Genre.Text;

                this.bookList.Add(new Book(this.bookId, author, title, genre, price));
                this.bookId++;
                ClearField();
            }
            else
                MessageBox.Show("There are empty fields.");
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            int index = DataGrid.SelectedIndex;

            if (DataGrid.SelectedCells.Count > 0)
            {
                this.bookList[index] = new Book(this.bookList[index].Id, Author.Text, Title.Text, Genre.Text, Convert.ToDecimal(Price.Text));
                ClearField();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Book book = this.DataGrid.SelectedItem as Book;

            this.bookList.Remove(book);
        }

        private void Clear_all_Click(object sender, RoutedEventArgs e)
        {
            this.bookList.Clear();

            this.bookId = 0;
        }

        private void ClearField()
        {
            Author.Clear();
            Title.Clear();
            Genre.Clear();
            Price.Clear();
        }

        private bool BookCheck()
        {
            Decimal.TryParse(this.Price.Text, out decimal price);

            if (!String.IsNullOrEmpty(Author.Text) && !String.IsNullOrEmpty(Title.Text) && !String.IsNullOrEmpty(Genre.Text) && !String.IsNullOrEmpty(Price.Text))
                return true;
            else
                return false;
        }
    }
}
