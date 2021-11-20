using System;
using Xunit;
using Logic;
using Storage;

namespace TestStorage
{

    public class TestStorage
    {
        [Fact]
        public void TestJsonStorage()
        {
            NoteBook n = new NoteBook();
            IStorage storage = new JsonStorage("testStorageData");

            Unit u1 = new Unit();
            u1.Name = "UE1";
            u1.Coef = 4f;

            Module m1 = new Module();
            m1.Name = "M101";
            m1.Coef = 5f;
            u1.Add(m1);

            Module m2 = new Module();
            m2.Name = "M102";
            m2.Coef = 4f;
            u1.Add(m2);

            Exam e1 = new Exam();
            e1.Coef = 3;
            e1.Score = 14;
            e1.Module = m1;


            n.AddUnit(u1);
            n.AddExam(e1);

            storage.SaveNotebook(n);

            NoteBook n2 = storage.LoadNotebook();
            Assert.Equal(n, n2);
            Assert.Equal(n.ListUnits(), n2.ListUnits());
            Assert.Equal(n.ListExams(), n2.ListExams());
        }
    }
}
