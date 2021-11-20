using System;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestExam
    {
        //Test le range d'un examen(note entre 0 et 20 inclus)
        [Fact]
        public void TestExamException()
        {
            Exam e = new Exam();
            Assert.Throws<Exception>(() => { e.Score = -5; });
            Assert.Throws<Exception>(() => { e.Score = 26; });
            Assert.Throws<Exception>(() => { e.Score = 20.05f; });
            Assert.Throws<Exception>(() => { e.Score = -0.5f; });

            Assert.Throws<Exception>(() => { e.Coef = -5; });
            Assert.Throws<Exception>(() => { e.Coef = -0.5f; });
        }

        [Fact]
        public void TestConstructorValues()
        {
            Exam e = new Exam();
            Assert.Equal(1f, e.Coef, 2);
            Assert.True(e.IsAbsent);
            Assert.Equal(0, e.Score, 2);
            Assert.NotNull(e.Module);
            Assert.Equal(DateTime.Now, e.DateExam, TimeSpan.FromSeconds(1));
        }
    }
}
