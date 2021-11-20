using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Une unité contient des modules et est un élément pédagogique
    /// </summary>
    [DataContract]
    public class Unit : EducationalElement
    {
        #region Attributs
        [DataMember]
        private List<Module> modules = new List<Module>(); //listes des modules de l'unité
        #endregion

        #region Methods
        /// <summary>
        /// Cette methode renvoit la liste des modules de l'unité
        /// </summary>
        /// <returns></returns>
        public Module[] ListModules()
        {
            return this.modules.ToArray();
        }

        /// <summary>
        /// Cette méthode ajoute le module passé en paramètre à la liste des modules de l'unit
        /// </summary>
        /// <param name="m">Module à ajouter à la liste des modules</param>
        public void Add(Module m)
        {
            if (!modules.Contains(m)) modules.Add(m);
        }

        /// <summary>
        /// Cette méthode supprime le module passé en paramètre de la list des modules de l'unit
        /// </summary>
        /// <param name="module">Le module à supprimer</param>
        public void Remove(Module module)
        {
            if (modules.Contains(module))
            {
                int index = modules.IndexOf(module);
                modules.RemoveAt(index);
            }
        }

        /// <summary>
        /// Calcule la moyenne de toute l'unité (moyenne calculée à partir de tout les modules appartenant à cette unité)
        /// </summary>
        /// <param name="exams">liste de tout les examens de l'unité</param>
        /// <returns>moyenne de l'unité</returns>
        public AvgScore ComputeAverage(Exam[] exams)
        {
            AvgScore avg = null;
            //si la liste d'exam n'est pas vide
            if (ListModules().Length > 0)
            {
                float sumScoreModule = 0; // notes cumulées des exams d'un module
                float sumCoefModule  = 0;  // coefficients cumulé des exams d'un module
                float moduleAverage  = 0;  // moyenne calculé d'un module

                bool moduleHasMatchingExam = false; 

                //on parcourt la liste des modules
                foreach (Module m in ListModules())
                {
                    AvgScore a = m.ComputeAverage(exams);
                    //si il y existe des examens pour ce module
                    if ( (a != null ) && (this.Coef != float.NaN) && (a.Average != float.NaN) )
                    {
                        moduleHasMatchingExam = true;
                        sumScoreModule += a.Average * m.Coef;
                        sumCoefModule += m.Coef;
                    }
                }
                //si le module a au moins un exam correspondant
                if (moduleHasMatchingExam)
                {
                    //Calcul de la moyenne du module 
                    moduleAverage = sumScoreModule / sumCoefModule;
                    //creation d'un object Moyenne
                    avg = new AvgScore(moduleAverage, this);
                }
            }
            return avg;
        }

        /// <summary>
        /// Cette méthode retourne la liste des moyennes de chaque Module de l'unité
        /// </summary>
        /// <returns>moyennes de chaque Unité</returns>
        public List<AvgScore> ComputeModuleAverages(Exam[] exams)
        {
            List<AvgScore> avg = new List<AvgScore>();
            if (modules.Count > 0)
            {
                foreach (Module m in modules)
                {
                    AvgScore a = m.ComputeAverage(exams);
                    if ((a != null) && (m.Coef != float.NaN) && (a.Average != float.NaN))
                    {
                        avg.Add(a);
                    }
                }
            }
            return avg;
        }

        public override bool Equals(object obj)
        {
            return obj is Unit unit &&
                   base.Equals(unit) &&
                   modules.All(unit.modules.Contains);
        }

        #endregion

    }
}
