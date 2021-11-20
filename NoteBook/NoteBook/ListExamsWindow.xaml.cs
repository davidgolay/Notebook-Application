using Storage;
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

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour ListExamsWindow.xaml
    /// </summary>
    public partial class ListExamsWindow : Window
    {
        private Logic.NoteBook notebook;

        public ListExamsWindow(Logic.NoteBook notebook)
        {
            InitializeComponent();
            this.notebook = notebook;
            DrawExams();
        }

        /// <summary>
        /// Cette méthode permet d'afficher toutes les moyennes calculée (général, unité)
        /// </summary>
        private void DrawExams()
        {

            //Listage des examens
            listBoxExams.Items.Clear();
            foreach (Logic.Exam e in notebook.ListExams())
            {
                listBoxExams.Items.Add(e);
            }

            //Moyennes générale
            listBoxAverages.Items.Clear();
            if (notebook.ComputeGeneralAverage() != null)
            {
                listBoxAverages.Items.Add(notebook.ComputeGeneralAverage());
            }

            //Moyennes des Unités
            if(notebook.ComputeUnitAverages() != null)
            {
                foreach (Logic.AvgScore avg in notebook.ComputeUnitAverages())
                {
                    listBoxAverages.Items.Add(avg);

                }
            }


            ////Moyennes des modules
            //if (notebook.ListModules() != null)
            //{
            //    foreach (Logic.Module module in notebook.ListModules())
            //    {
            //        Logic.AvgScore avgModule = module.ComputeAverage(notebook.ListExams());
            //        listBoxAverages.Items.Add(avgModule);
            //    }
            //}

        }
    }
}