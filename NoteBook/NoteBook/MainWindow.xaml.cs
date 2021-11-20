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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Logic;
using Storage;

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Logic.NoteBook notebook;

        private IStorage storage;

        public MainWindow()
        {
            this.notebook = new Logic.NoteBook();
            storage = new JsonStorage(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\sauvegardeNotebook");
            this.notebook = storage.LoadNotebook();
            InitializeComponent();
        }

        private void GoEditUnits(object sender, RoutedEventArgs e)
        {
            try { 
                EditUnitsWindow second = new EditUnitsWindow(notebook, storage);
                second.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void GoEditExam(object sender, RoutedEventArgs e)
        {
            try
            {
                EditExamWindow second = new EditExamWindow(notebook, storage);
                second.Show();

            } catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }

        private void GoListExamsWindow(object sender, RoutedEventArgs e)
        {
            try
            {
                ListExamsWindow second = new ListExamsWindow(notebook);
                second.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
