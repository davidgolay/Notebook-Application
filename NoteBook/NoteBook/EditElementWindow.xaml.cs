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

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour EditElementWindow.xaml
    /// </summary>
    public partial class EditElementWindow : Window
    {
        private EducationalElement element;

        public EditElementWindow(Logic.EducationalElement elt)
        {
            InitializeComponent();
            element = elt;
            txtBox_name.Text = element.Name;
            txtBox_coef.Text = element.Coef.ToString();
        }

        /// <summary>
        /// Cette méthode est appelée quand on clique sur valider 
        /// dans la fenetre de creation/modification d'element pedagogique
        /// </summary>
        private void Validate(object sender, RoutedEventArgs e)
        {
            try
            {
                element.Name = txtBox_name.Text;
                element.Coef = (float)Convert.ToDouble(txtBox_coef.Text);
                DialogResult = true;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void IncrementCoef(object sender, RoutedEventArgs e)
        {
            float coef = NormalizeTextToFloat(txtBox_coef.Text);
            if (coef <= 19f)
            {
                coef += 1f;
            }
            txtBox_coef.Text = coef.ToString();
        }

        private void DecrementCoef(object sender, RoutedEventArgs e)
        {
            float coef = NormalizeTextToFloat(txtBox_coef.Text);
            if (coef >= 1)
            {
                coef -= 1;
            }
            txtBox_coef.Text = coef.ToString();
        }

        private float NormalizeTextToFloat(String text)
        {
            float coef = 0;
            bool isFloat = float.TryParse(text, out float number);
            if (isFloat)
            {
                coef = number;
            }
            return coef;
        }
    }
}
