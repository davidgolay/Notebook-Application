using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    /// <summary>
    /// Cette classe est une implémentation de IStorage 
    /// qui permet de stocker et de récupérer les données utiles d'un Notebook.
    /// A savoir tous champs d'exam, element pedagogique (et héritages)
    /// </summary>
    public class JsonStorage : IStorage
    {
        private Logic.NoteBook notebook;

        private string file;

        public JsonStorage(string file)
        {
            this.file = file;
        }

        public Logic.NoteBook LoadNotebook()
        {
            try
            {
                using (FileStream stream = new FileStream(file, FileMode.Open))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(NoteBook));
                    //lecture des données
                    notebook = serializer.ReadObject(stream) as NoteBook;
                    stream.Close();
                }
            }
            catch
            {
                notebook = new NoteBook();
            }
            return notebook;
        }

        public void SaveNotebook(NoteBook nb)
        {
            FileStream stream = new FileStream(file, FileMode.Create);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(NoteBook));

            //ecrasement des données
            serializer.WriteObject(stream, nb);
            stream.Close();
        }
    }
}