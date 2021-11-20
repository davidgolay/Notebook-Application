using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestUnit
    {
        /// <summary>
        /// Test si deux Unit sont égales (avec Assert.NotSame et equals)
        /// dans les cas où elle sont de meme valeur
        /// </summary>
        [Fact]
        public void TestUnitsAreDifferent()
        {
            // Test avec Unit après construction 
            Unit u = new Unit();
            Unit u2 = new Unit();
            Assert.NotSame(u, u2);
            Assert.NotEqual(u, u2);

            // Test avec Unit aux valeurs egales
            u.Name = u2.Name = "UE1";
            u.Coef = u2.Coef = 2.5f;
            Assert.NotSame(u, u2);
            Assert.NotEqual(u, u2);

            float coef = 2.0f;
            String name = "UE1";
            u.Name = name;
            u.Coef = coef;
            Assert.NotSame(u, u2);
            Assert.NotEqual(u, u2);
        }

        /// <summary>
        /// Test si le ListModule de Unit afin de vérifier qu'un module ajouté
        /// à la liste des modules est correctement rapporté par la fonction ListModules
        /// </summary>
        [Fact] 
        public void TestListUnits()
        {
            // Test avec Unit après construction 
            Unit u = new Unit();
            u.Name = "UE1";
            u.Coef = 2.5f;
            Module m = new Module();

            //test initial quand la liste est vide
            Assert.Empty(u.ListModules());

            //gestion des doublons
            u.Add(m);
            u.Add(m);
            u.Add(m);
            Assert.NotNull(u.ListModules());
            Assert.NotEmpty(u.ListModules());
            Assert.Single(u.ListModules());
            Assert.Equal(m, u.ListModules()[0]);

            //apres supression du module
            u.Remove(m);
            Assert.Empty(u.ListModules());
        }

        private List<Exam> GenerateListExams(Module m, float score)
        {
            List<Exam> list = new List<Exam>();
            Exam e1 = new Exam();
            Exam e2 = new Exam();
            Exam e3 = new Exam();
            e1.Coef = 1;
            e2.Coef = 1;
            e3.Coef = 1;
            e1.Score = score - 2;
            e2.Score = score;
            e3.Score = score + 2;
            e1.Module = m;
            e2.Module = m;
            e3.Module = m;
            list.Add(e1);
            list.Add(e2);
            list.Add(e3);
            
            return list;
        }

        [Fact]
        public void TestComputeAverages()
        {
        
            Module m = new Module();
            m.Coef = 1f;
            Unit u = new Unit();

            List<Exam> list = new List<Exam>();
            Exam e1 = new Exam();
            e1.Score = 15f;
            e1.Module = m;
            list.Add(e1);
            AvgScore a = u.ComputeAverage( list.ToArray() );
            Assert.Null(a);

            u.Add(m);
            a = u.ComputeAverage(list.ToArray() );
            Assert.Equal(15f, a.Average);

            Module m2 = new Module();
            m2.Coef = 3f;

            u.Add(m2);
            a = u.ComputeAverage(list.ToArray());
            Assert.Equal(15f, a.Average);

            Exam e1b = new Exam();
            e1b.Score = 5f;
            e1b.Module = m2;
            list.Add(e1b);
   
            u.Add(m2);         
            a = u.ComputeAverage( list.ToArray() );
            Assert.Equal(7.5f, a.Average);

        }
    }
}
