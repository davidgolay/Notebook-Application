using System;
using Xunit;
using Logic;
using System.Collections.Generic;

namespace TestLogic
{
    public class TestModule
    {
        [Fact]
        public void TestComputeAverage()
        {
            List<Exam> list = new List<Exam>();
            Exam e1 = new Exam();
            Exam e2 = new Exam();
            Exam e3 = new Exam();
            Module m = new Module();
            AvgScore a = m.ComputeAverage(list.ToArray());
            Assert.Null(a);

            list.Add(e1);
            a = m.ComputeAverage(list.ToArray());
            Assert.Null(a);

            //assignation à un module
            e1.Module = m;
            e1.Coef = 1.5f;
            e1.Score = 15f;
            a = m.ComputeAverage(list.ToArray());
            float expected = a.Average;
            Assert.Equal(15f, expected );

            e1.Module = m;
            e2.Module = m;
            e3.Module = m;

            e1.Coef = 1;
            e2.Coef = 1;
            e3.Coef = 2;

            e1.Score = 0;
            e2.Score = 20;
            e3.Score = 15;

            list.Add(e2);
            list.Add(e3);

            a = m.ComputeAverage(list.ToArray());
            expected = a.Average;
            Assert.Equal(12.5f, expected);
        }
    }
}
