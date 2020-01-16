using AuthorApp.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace AuthorApp.Views
{
    /// <summary>
    /// Interaction logic for ChangeBook.xaml
    /// </summary>
    public partial class ChangeBook : Window
    {
        private Book bookCashed;

        private Book bookOld;

        public ChangeBook(Book book)
        {
            InitializeComponent();

            this.bookOld = book;

            this.bookCashed = new Book();
            this.DataContext = bookCashed;

            this.bookCashed.IsNew = book.IsNew;
            this.bookCashed.Title = book.Title;
            this.bookCashed.Cost = book.Cost;
            this.bookCashed.Date = book.Date;
        }


        private void ExecutedOkCustom_Command(object sender, ExecutedRoutedEventArgs e)
        {
            this.bookOld.Title = this.bookCashed.Title;
            this.bookOld.Cost = this.bookCashed.Cost;
            this.bookOld.Date = this.bookCashed.Date;

            this.DialogResult = true;
            this.Close();
        }

        private void CanExecuteOkCustom_Command(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExecutedCancelCustom_Command(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void CanExecuteCancelCustom_Command(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
