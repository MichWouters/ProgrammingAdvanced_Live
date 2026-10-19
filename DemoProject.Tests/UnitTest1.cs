namespace DemoProject.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        [Ignore("Nog niet geimplementeerd")]
        public void SuperDuperImportantTest_IfthisTurnsGreen_MeansEverythingWorksOkay()
        {
            //throw new NotImplementedException();
            Assert.Fail();
        }

        [Test]
        public void APlusB_Equals_Result()
        {
            // Arrange => Voorzie alle nodige gegevens
            int getalA = 5;
            int getalB = 7;

            // ACT => Voer de methode die wilt testen
            int result = getalA + getalB;

            // Assert => Controleer of het resultaat van ACT gelijk is aan hetgeen je verwacht
            Assert.That(result, Is.EqualTo(12));
        }

        [TestCase(5, 2, 10)]
        [TestCase(10, 40, 400)]
        [TestCase(1, 5, 5)]
        [TestCase(5, 3, 15)]
        public void ATimesB_Equals_Result(int getalA, int getalB, int expectedResult)
        {
            // ACT => Voer de methode die wilt testen
            int result = getalA * getalB;

            // Assert => Controleer of het resultaat van ACT gelijk is aan hetgeen je verwacht
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
