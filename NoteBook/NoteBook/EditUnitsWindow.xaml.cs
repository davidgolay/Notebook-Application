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
    /// Logique d'interaction pour EditUnitsWindow.xaml
    /// </summary>
    public partial class EditUnitsWindow : Window
    {
        private Logic.NoteBook notebook;

        private IStorage storage;

        public EditUnitsWindow(Logic.NoteBook notebook, IStorage storage)
        {
            this.notebook = notebook;
            this.storage = storage;
            InitializeComponent();
            DrawUnits();
        }

        private void DrawUnits()
        {
            var list = notebook.ListUnits();
            units.Items.Clear();
            foreach (var item in list)
                units.Items.Add(item);
        }
        /// <summary>
        /// Cette methode permet de lister les modules d'une unité dans la listbox associée
        /// </summary>
        private void DrawModules()
        {
            if (units.SelectedItem is Unit unit)
            {
                var list = unit.ListModules();
                modules.Items.Clear();
                foreach (Module m in list)
                    modules.Items.Add(m);
            }
        }


        //Cette methode ouvre la fenetre d'édition de matière
        private void EditUnit(object sender, MouseButtonEventArgs e)
        {
            if (units.SelectedItem is Unit u)
            {
                EditElementWindow third = new EditElementWindow(u);
                if (third.ShowDialog() == true)
                {
                    storage.SaveNotebook(notebook);
                    DrawUnits();
                }
            }
        }

        //Cette methode ouvre le dialogue pour ajouter une matière
        private void CreateUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                Unit newUnit = new Unit();
                EditElementWindow third = new EditElementWindow(newUnit);
                if (third.ShowDialog() == true)
                {
                    notebook.AddUnit(newUnit);
                    storage.SaveNotebook(notebook);
                    DrawUnits();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Méthode appelée quand on clique sur "Supprimer" de la colonne des unités
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                if (units.SelectedItem is Unit unit)
                {
                    notebook.RemoveUnit(unit);
                    storage.SaveNotebook(notebook);
                    DrawUnits();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Cet méthode appelée pour redessiner les modules à partir de l'unité séléctionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectUnit(object sender, SelectionChangedEventArgs e)
        {
            DrawModules();
        }


        /// <summary>
        /// Cette methode permet de modifier un module selectionné dans la listBox modules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditModule(object sender, MouseButtonEventArgs e)
        {
            if (modules.SelectedItem is Module m)
            {
                List<Exam> examsToUpdate = notebook.ListExams().Where(exam => exam.Module.Equals(m)).ToList();
                EditElementWindow third = new EditElementWindow(m);
                if (third.ShowDialog() == true)
                {
                    examsToUpdate.ForEach(exam => exam.Module = m);
                    storage.SaveNotebook(notebook);
                    DrawModules();
                }
            }
        }

        /// <summary>
        /// Cette méthode ouvre un dialog pour créer un module et l'ajoute à l'unité precedemment séléctionnée
        /// </summary>
        private void CreateModule(object sender, RoutedEventArgs e)
        {
            try
            {
                if (units.SelectedItem is Unit unit)
                {
                    Module newModule = new Module();
                    EditElementWindow third = new EditElementWindow(newModule);
                    if (third.ShowDialog() == true)
                    {
                        unit.Add(newModule);
                        storage.SaveNotebook(notebook);
                        //DrawUnits();
                        DrawModules();
                    }
                }

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Cette méthode permet de supprimer un module d'une unité. 
        /// Elle est appelée quand l'utilisateur clique sur le bouton supprimer de la colonne Module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveModule(object sender, RoutedEventArgs e)
        {
            try
            {
                if(units.SelectedItem is Unit unit)
                {
                    if (modules.SelectedItem is Module module)
                    {
                        unit.Remove(module);
                        storage.SaveNotebook(notebook);
                        DrawModules();
                    }
                }

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

    }
}