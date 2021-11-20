using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Logic
{
    /// <summary>
    /// Le notebook est la façade de la couche logique. C'est le classeur de notes
    /// </summary>
    [DataContract]
    public class NoteBook
    {
        #region Attributs
        [DataMember]
        private List<Unit> units;
        [DataMember]
        private List<Exam> exams;
        #endregion

        #region Methods
        
        
        public NoteBook()
        {
            this.units = new List<Unit>();
            this.exams = new List<Exam>();

            //Module m = new Module();
            //m.Coef = 1f;
            //m.Name = "M1";
            //Unit u = new Unit();
            //u.Coef = 1;
            //u.Name = "UE1";
            //u.Add(m);
            //units.Add(u);

            //Exam e1 = new Exam();
            //e1.Score = 15f;
            //e1.Module = m;
            //e1.Teacher = "MR COULON";
            //e1.IsAbsent = false;
            //this.AddExam(e1);
        }

        /// <summary>
        /// Cette méthode retourne la liste des unités du NoteBook
        /// </summary>
        /// <returns>Liste d'Unit</returns>
        public Unit[] ListUnits()
        {
            return this.units.ToArray();
        }

        /// <summary>
        /// Methode qui ajoute une unité passée en paramètre à la liste des unités du NoteBook
        /// </summary>
        /// <param name="unit"> unité à ajouter au NoteBook</param>
        public void AddUnit(Unit unit)
        {
            if(!units.Contains(unit)) units.Add(unit);
        }

        /// <summary>
        /// Methode qui retire l'Unit passée en paramètre à la liste d'Unit du NoteBook
        /// </summary>
        /// <param name="unit">Unit a retirer du NoteBook</param>
        public void RemoveUnit(Unit unit)
        {
            if (units.Contains(unit)) { 
                int index = units.IndexOf(unit);
                units.RemoveAt(index);
            }          
        }
        /// <summary>
        /// Cette méthode retourne la liste des modules du NoteBook
        /// </summary>
        /// <returns>Liste des modules</returns>
        public Module[] ListModules()
        {
            List<Module> allModules = new List<Module>();
            foreach(Unit unit in units)
            {
                List<Module> unitsModule = unit.ListModules().ToList();
                for (int i = 0; i < unitsModule.Count; i++)
                {
                    allModules.Add(unit.ListModules()[i]);
                }

            }
            return allModules.ToArray();
        }

        /// <summary>
        /// Methode qui ajoute un Exam à la liste des exams du NoteBook
        /// </summary>
        /// <param name="exam"></param>
        public void AddExam(Exam exam)
        {
            this.exams.Add(exam);
        }

        public Exam[] ListExams()
        {
            return exams.ToArray();
        }
        /// <summary>
        /// Cette méthode retourne la liste des moyennes de chaque Unité
        /// </summary>
        /// <returns>moyennes de chaque Unité</returns>
        public List<AvgScore> ComputeUnitAverages()
        {
            List<AvgScore> avg = new List<AvgScore>();           
            if (units.Count > 0)
            {
                foreach (Unit u in units)
                {
                    AvgScore a = u.ComputeAverage(ListExams());                  
                    if ( (a != null) && (u.Coef != float.NaN) && (a.Average != float.NaN))
                    {
                        avg.Add(a);
                    }
                }
            }
            return avg;
        }

        /// <summary>
        /// Cette méthode permet de calculer la moyenne générale
        /// </summary>
        /// <returns>moyenne générale du classeur de note</returns>
        public AvgScore ComputeGeneralAverage()
        {
            AvgScore avg = null;

            if (units.Count > 0)
            {
                float sumAverageUnit = 0; // moyennes cumulées des module d'une unité
                float sumCoefUnit = 0;  // coefficients cumulés des modules d'une unit
                float unitAverage = 0;  // moyenne calculée d'une unit

                bool unitHasAverage = false;

                foreach (Unit u in units)
                {
                    AvgScore a = u.ComputeAverage(ListExams());
                    if ((a != null) && (u.Coef != float.NaN) && (a.Average != float.NaN))
                    {
                        unitHasAverage = true;
                        sumAverageUnit += a.Average * u.Coef;
                        sumCoefUnit += u.Coef;
                    }
                }
                //si une moyenne d'unit a pu être calculée
                if (unitHasAverage)
                {
                    //Calcul de la moyenne du module 
                    unitAverage = sumAverageUnit / sumCoefUnit;
                    EducationalElement ee = new EducationalElement();
                    ee.Coef = 1;
                    ee.Name = "Moyenne Générale";
                    //creation d'un object Moyenne
                    avg = new AvgScore(unitAverage, ee);
                }
            }
            return avg;
        }

        public override bool Equals(object obj)
        {
            return obj is NoteBook book &&
                   units.SequenceEqual(book.units) &&
                   exams.SequenceEqual(book.exams);
        }


        #endregion

    }
}