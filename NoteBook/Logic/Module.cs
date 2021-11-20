using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Un module est un element pédagogique racine
    /// </summary>
    public class Module : EducationalElement
    {
        #region Methods
        public AvgScore ComputeAverage(Exam[] exams)
        {
            AvgScore avg = null;
            //si la liste d'exam n'est pas vide
            if (exams.Length > 0)
            {            
                float sum = 0;
                float sumCoef = 0;
                float average = 0;
                bool moduleHasMatchingExam = false;

                //on parcourt la liste des examens
                foreach (Exam exam in exams)
                {
                    //si le module de l'exam est le même que le module courant
                    if ( exam.Module.Equals(this) && (Coef != float.NaN) )
                    {
                        moduleHasMatchingExam = true;
                        sum += exam.Score * exam.Coef;
                        sumCoef += exam.Coef;
                    }
                }
                //si le module a au moins un exam correspondant
                if(moduleHasMatchingExam)
                {
                    //Calcul de la moyenne du module 
                    average = sum / sumCoef;
                    //creation d'un object Moyenne
                    avg = new AvgScore(average, this);
                }
            }
            return avg;
        }

        public override bool Equals(object obj)
        {
            return obj is Module module &&
                   base.Equals(module);
        }

        #endregion

    }
}
