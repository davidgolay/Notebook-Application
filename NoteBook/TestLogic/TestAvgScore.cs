using System;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestAvgScore
    {
        [Fact]
        public void testToString()
        {
            EducationalElement e = new EducationalElement();
            e.Name = "nom";
            e.Coef = 2.5f;
            AvgScore a = new AvgScore(3f, e);
            Assert.Contains("Moyenne nom", a.ToString());
        }

        [Fact]
        public void testElementName()
        {
            EducationalElement e = new EducationalElement();
            e.Name = "nom";
            AvgScore a = new AvgScore(3f, e);

            Assert.Contains("nom", a.ElementName);
        }

    }
}
