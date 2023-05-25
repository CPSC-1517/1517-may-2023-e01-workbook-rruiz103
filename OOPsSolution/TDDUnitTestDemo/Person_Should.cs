using FluentAssertions;
using OOPsReview;
namespace TDDUnitTestDemo
{
    public class Person_Should
    {
        // Attribute Title 
        // 1. Fact = which does one test and is usually set up and coded within the test
        // 2. Theory = allows for multiple test data strings apply to the same test
        [Fact]
        public void Create_an_Instance_With_First_And_Last_Name()
        {
            // Arrange Area (setup)
            string firstname = "Don";
            string lastname = "Welch";

            // Act Area (execution) ------ SUT means subject under test
            Person sut = new Person(firstname,lastname);

            // Assert Area (testing of the action)
            sut.FirstName.Should().Be(firstname);
            sut.LastName.Should().Be(lastname);

        }
    }   
}