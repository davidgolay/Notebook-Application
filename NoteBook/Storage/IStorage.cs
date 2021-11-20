using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    /// <summary>
    /// Cette Interface permettra à ses implémentations de sauvegarder et recharger un notebook.
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Methode à implémenter pour charger un notebook 
        /// (relatif au moyen de chargement des données d'un notebook)
        /// </summary>
        /// <returns></returns>
        NoteBook LoadNotebook();

        /// <summary>
        /// Methode à redefinir pour sauvegarder les données du classeur de note 
        /// </summary>
        /// <param name="n"></param>
        void SaveNotebook(NoteBook n);
    }
}