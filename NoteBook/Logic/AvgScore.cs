using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Cette classe permet d'associer une moyenne à un élément pédagogique
    /// </summary>
    public class AvgScore
    {
        #region Attributs
        private EducationalElement educationalElement;
        private float average;
        #endregion

        #region Propreties
        public float Average { 
            get => average; 
            set => average = value;
        }

        public string ElementName {
            get => educationalElement.ToString();
        }
        #endregion

        #region Construction
        public AvgScore(float average, EducationalElement ee)
        {
            this.educationalElement = ee;
            this.average = average;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            string res = "";
            res += "Moyenne ";
            res += ElementName;
            res += ": ";
            res += average;
            return res;
        }
        #endregion
    }
}
