using Logic;
using Xunit;
using System;
using System.Collections.Generic;

namespace TestLogic
{
    public class TestNotebook
    {
        /// <summary>
        /// Test si la liste des unités est
        /// non nulle et vide à la construction
        /// </summary>
        [Fact]
        public void TestConstruction()
        {
            NoteBook n = new NoteBook();
            Assert.NotNull(n.ListUnits());
            Assert.Empty(n.ListUnits());
        }

        /// <summary>
        /// Ce test vérifie si la liste d'units de Notebook ne comporte qu'un element qui est l'unité précédemment créée
        /// </summary>
        [Fact]
        public void TestAddUnit()
        {
            NoteBook n = new NoteBook();
            Unit u = new Unit();
            u.Name = "UE1";
            u.Coef = 2.5f;
            n.AddUnit(u);
            Assert.NotNull(n.ListUnits());
            Assert.NotEmpty(n.ListUnits()); // test si units n'est pas vide
            Assert.Single(n.ListUnits()); // test si units a 1 seul item
            Assert.Equal(n.ListUnits().GetValue(0), u); //test si l'unité ajoutée à notebook est bien l'unit précédemment créee
        }

        /// <summary>
        /// Test si une unité est correctement supprimée du NoteBook
        /// </summary>
        [Fact]
        public void TestRemoveUnit()
        {
            NoteBook n = new NoteBook();
            Unit u = new Unit();
            u.Name = "UE1";
            u.Coef = 2.5f;
            Unit u2 = new Unit();
            u.Name = "UE2";
            u.Coef = 3.5f;
            //AJOUT DE L'UNIT
            n.AddUnit(u); //la fonction AddUnit a été vérifiée
            n.AddUnit(u2); //la fonction AddUnit a été vérifiée
            //gestion des doublons
            n.AddUnit(u); //la fonction AddUnit a été vérifiée
            n.AddUnit(u2); //la fonction AddUnit a été vérifiée
            Assert.True(n.ListUnits().Length == 2); // test si units a 2 items
            Assert.Contains(u, n.ListUnits());
            Assert.Contains(u2, n.ListUnits());


            //SUPPRESSION DE L'UNIT
            n.RemoveUnit(u);
            Assert.Single(n.ListUnits()); // test si units a 1 item
            Assert.Equal(n.ListUnits().GetValue(0), u2); //test si u2 existe encore dans la liste d'unités (rang 0)
            n.RemoveUnit(u2);
            //gestion des doublons
            n.RemoveUnit(u2);
            Assert.Empty(n.ListUnits()); // test si units est vide
        }


        //Test le list module de Notebook
        [Fact]
        public void TestListModules()
        {
            NoteBook n = new NoteBook();
            Unit u = new Unit();
            Unit u2 = new Unit();
            n.AddUnit(u);
            n.AddUnit(u2);
            //AJOUT DES MODULES ET TESTS
            Module m = new Module();
            u.Add(m);
            Assert.Single(n.ListModules()); // test si units a 1 items
            Module m2 = new Module();

            u.Add(m2);
            u2.Add(m);
            u2.Add(m2);
            n.AddUnit(u);
            n.AddUnit(u2);

            //Ajout de doublons
            u.Add(m);
            u.Add(m2);
            u2.Add(m);
            u2.Add(m2);
            u2.Add(m2);         

            //Supression unit
            n.RemoveUnit(u2);
            n.RemoveUnit(u);
            Assert.Empty(n.ListModules()); // test si units a 0 item
        }

        //Test le list module de Notebook
        [Fact]
        public void TestListExam()
        {
            NoteBook n = new NoteBook();
            Exam e = new Exam();

            Assert.NotNull(n.ListExams());
            Assert.Empty(n.ListExams());

            n.AddExam(e);

            Assert.Single(n.ListExams());
            Assert.Contains(e, n.ListExams());
        }

        [Fact]
        public void TestComputeScores()
        {

        }
    }
}