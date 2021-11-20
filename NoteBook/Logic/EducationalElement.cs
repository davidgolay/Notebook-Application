using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Classe abstraite permettant de représenter les fondations de matières et de modules
    /// </summary>
    [DataContract]
    [KnownType(typeof(Module))]
    [KnownType(typeof(Unit))]
    public class EducationalElement
    {
        #region Attributs

        [DataMember]
        private String name;

        [DataMember]
        private float coef;
        #endregion

        #region Propreties
        public String Name
        {
            get => name;
            set
            {
                if (value == "") throw new Exception("Vous devez renseigner un intitulé");
                name = value;
            }
        }

        public float Coef
        {
            get => coef;
            set
            {
                if (value <= 0) throw new Exception("Vous devez entrer un coeficient supérieur à zero");
                coef = value;
            }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Renvoit le nom suivi du coefficient de l'élement pédagogique
        /// Les champs sont séparés par un ":" et le coeficient est entre parenthèse
        /// </summary>
        public override String ToString()
        {
            String txt1 = name;
            String txt2 = " (Coef. " + coef + ")";
            return txt1 + txt2;
        }

        public override bool Equals(object obj)
        {
            return obj is EducationalElement element &&
                   name == (element.name) &&
                   coef == element.coef;
        }

        #endregion
    }
}