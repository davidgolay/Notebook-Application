using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Cette classe représente un examen qui associe une professeur (nom)
    /// a une date d'exam qui a donné, 
    /// un examen possède un coefficient, 
    /// une note qui porte sur un Module
    /// </summary>
    [DataContract]
    public class Exam
    {
        #region Attributs
        [DataMember]
        private String teacher;
        [DataMember]
        private DateTime dateExam = DateTime.Now;
        [DataMember]
        private float coef;
        [DataMember]
        private bool isAbsent = false;
        [DataMember]
        private float score;
        [DataMember]
        private Module module;
        #endregion

        #region Proprieties
        public String Teacher
        {
            get => teacher;
            set
            {
                if (value == "") throw new Exception("Le champ professeur ne peut pas être vide");
                teacher = value;
            }
        }


        public DateTime DateExam { 
            get => dateExam;
            set => dateExam = value;
        }


        public float Coef
        {
            get => coef;
            set
            {
                if (value <= 0) throw new Exception("Entrez un coefficient supérieur à 0");
                coef = value;
            }
        }

        public bool IsAbsent
        {
            get => isAbsent;
            set { isAbsent = value; }
        }


        public float Score
        {
            get => score;
            set
            {
                if (value < 0 || value > 20) throw new Exception("Entrez une note entre 0 et 20");
                score = value;
            }
        }

        public Module Module
        {
            get => module;
            set
            {
                if (value == null) throw new Exception("Ce module selectionné n'existe pas");
                module = value;       
            }
        }
        #endregion

        #region Construction

        public Exam()
        {
            this.dateExam = DateTime.Now;
            this.coef = 1;
            this.isAbsent = true;
            this.score = 0;
            this.module = new Module();
            this.teacher = "";
        }

        #endregion

        #region Methodes
        public override bool Equals(object obj)
        {
            return obj is Exam exam &&
                   teacher == exam.teacher &&
                   dateExam.Year == exam.dateExam.Year &&
                   dateExam.Month == exam.dateExam.Month &&
                   dateExam.Day == exam.dateExam.Day &&
                   dateExam.Hour == exam.dateExam.Hour &&
                   dateExam.Minute == exam.dateExam.Minute &&
                   dateExam.Second == exam.dateExam.Second &&
                   coef == exam.coef &&
                   isAbsent == exam.isAbsent &&
                   score == exam.score &&
                   module.Equals(exam.module);
        }
        #endregion
    }


}
