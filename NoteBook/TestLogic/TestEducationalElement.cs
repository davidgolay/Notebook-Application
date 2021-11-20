using System;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestEducationalElement
    {

        /// <summary>
        /// Test si une execption est lancée si l'attribut coef de educationalElement est inférieur ou égal à zero
        /// </summary>
        [Fact]
        public void TestCoef()
        {
            EducationalElement e = new EducationalElement();
            Assert.Throws<Exception>(() => { e.Coef = -10; });
            Assert.Throws<Exception>(() => { e.Coef = 0; });

            e.Coef = 3;
            Assert.Equal(3f, e.Coef, 2);
            e.Name = "TestModificationNom";
            Assert.Equal("TestModificationNom", e.Name);
        }


        
        /// <summary>
        /// Test si une exception est lancée quand un nom d'element pedagogique est vide
        /// </summary>
        [Fact]
        public void TestName()
        {
            EducationalElement e = new EducationalElement();
            Assert.Throws<Exception>(() => { e.Name = ""; });
        }
    }
}
