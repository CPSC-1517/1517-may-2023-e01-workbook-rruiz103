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
        public void Create_an_Instance_With_First_And_Last_Name_Residence_With_NO_List_Of_Employment()
        {
            // Arrange Area (setup)
            string firstname = "Don";
            string lastname = "Welch";
            Residence address = new Residence(123,"Maple St.","Edmonton","AB","T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";

            // Act Area (execution) ------ SUT means subject under test
            Person sut = new Person(firstname,lastname,address,null);

            // Assert Area (testing of the action)
            sut.FirstName.Should().Be(firstname);
            sut.LastName.Should().Be(lastname);
            sut.Address.ToString().Should().Be(expectedaddress);
            sut.EmploymentPositions.Count().Should().Be(0);

        } // End of Create_an_Instance_With_First_And_Last_Name_Residence_With_NO_List_Of_Employment Test

        [Fact]
        public void Create_an_Instance_Using_Default_Constructos()
        {
            // Arrange Area (setup)


            // Act Area (execution) ------ SUT means subject under test
            Person sut = new Person();

            // Assert Area (testing of the action)
            sut.FirstName.Should().BeNull();
            sut.LastName.Should().BeNull();
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count().Should().Be(0);

        } // End of Create_an_Instance_With_First_And_Last_Name_Residence_With_NO_List_Of_Employment Test







    }    // End of Person_Should Class
} // End of TDDUnitTestDemo namespace