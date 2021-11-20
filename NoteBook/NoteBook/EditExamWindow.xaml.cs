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
using Logic;
using Storage;

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour EditExamWindow.xaml
    /// </summary>
    public partial class EditExamWindow : Window
    {

        private Logic.NoteBook notebook;

        private IStorage storage;

        private Logic.Exam exam;
        public EditExamWindow(Logic.NoteBook notebook, IStorage storage)
        {
            InitializeComponent();
            this.notebook = notebook;
            this.storage = storage;
            this.exam = new Logic.Exam();
            initFields();
            DrawModules(notebook.ListModules());
        }

        /// <summary>
        /// Cette méthode initialise le contenu des champs IHM 
        /// </summary>
        private void initFields()
        {
            textBoxTeacher.Text = exam.Teacher.ToString();
            textBoxScore.Text = exam.Score.ToString();
            datePicker.SelectedDate = exam.DateExam;
            checkBoxAbsent.IsChecked = exam.IsAbsent;
        }

        /// <summary>
        /// Cette methode permet de lister tout les modules dans la listbox associée
        /// </summary>
        private void DrawModules(Module[] modules)
        {
            comboBoxModules.Items.Clear();
            foreach (Module m in modules)
            {
                comboBoxModules.Items.Add(m);
            }
        }

        private void Validate(object sender, RoutedEventArgs e)
        {
            try
            {
                exam.Module = (Module)comboBoxModules.SelectedItem; //cast direct, gestion par exception
                exam.Teacher = textBoxTeacher.Text;
                exam.Score = float.Parse(textBoxScore.Text);
                exam.DateExam = datePicker.DisplayDate;
                exam.IsAbsent = checkBoxAbsent.IsEnabled;

                notebook.AddExam(exam);

                //MAJ Stockage si storage existe
                if (storage != null)
                {
                    storage.SaveNotebook(notebook);
                }


                Close();
            } 
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
