using AuthorApp.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace AuthorApp.Views
{
    /// <summary>
    /// Interaction logic for ChangeAuthor.xaml
    /// </summary>
    public partial class ChangeAuthor : Window
    {
        private Author authorCashed;

        private Author authorOld;

        public ChangeAuthor(Author author)
        {
            InitializeComponent();

            this.authorOld = author;
            
            this.authorCashed = new Author();
            this.DataContext = authorCashed;

            this.authorCashed.IsNew = author.IsNew;
            this.authorCashed.FirstName = author.FirstName;
            this.authorCashed.LastName = author.LastName;
            this.authorCashed.BirthDate = author.BirthDate;
            this.authorCashed.Country = author.Country;
            this.authorCashed.Language = author.Language;
            this.authorCashed.PlaceOfBirth = author.PlaceOfBirth;
        }


        private void ExecutedOkCustom_Command(object sender, ExecutedRoutedEventArgs e)
        {
            
            this.authorOld.FirstName = this.authorCashed.FirstName;
            this.authorOld.LastName = this.authorCashed.LastName;
            this.authorOld.BirthDate = this.authorCashed.BirthDate;
            this.authorOld.Country = this.authorCashed.Country;
            this.authorOld.Language = this.authorCashed.Language;
            this.authorOld.PlaceOfBirth = this.authorCashed.PlaceOfBirth;

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
