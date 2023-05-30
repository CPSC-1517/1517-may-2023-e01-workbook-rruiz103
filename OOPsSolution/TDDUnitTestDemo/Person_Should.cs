using FluentAssertions;
using OOPsReview;
namespace TDDUnitTestDemo
{
    public class Person_Should
    {
        #region ValidData
        // Attribute Title 
        // 1. Fact = which does one test and is usually set up and coded within the test
        // 2. Theory = allows for multiple test data strings apply to the same test
        [Fact]
        public void Create_an_Instance_With_First_And_Last_Name_Residence_With_NO_List_Of_Employment()
        {
            // Arrange Area (setup)
            string firstname = "Don";
            string lastname = "Welch";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";

            // Act Area (execution) ------ SUT means subject under test
            Person sut = new Person(firstname, lastname, address, null);

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
            string expectedfirstname = "unknown";
            string expectedlastname = "unknown";

            // Act Area (execution) ------ SUT means subject under test
            Person sut = new Person();

            // Assert Area (testing of the action)
            sut.FirstName.Should().Be(expectedfirstname);
            sut.LastName.Should().Be(expectedlastname);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count().Should().Be(0);

        } // End of Create_an_Instance_With_First_And_Last_Name_Residence_With_NO_List_Of_Employment Test

        [Fact]
        public void Change_FirstName_To_New_Name()
        {
            // Arrange Area (setup)
            string firstname = "don";
            string lastname = "welch";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";
            Person me = new Person(firstname, lastname, address, null);
            string expectedfirstname = "bob";

            // Act Area (execution) ------ SUT means subject under test
            me.FirstName = expectedfirstname;

            // Assert Area (testing of the action)
            me.FirstName.Should().Be(expectedfirstname);
        } // End of Change_FirstName_To_New_Name Test

        [Fact]
        public void Change_LastName_To_New_Name()
        {
            // Arrange Area (setup)
            string firstname = "don";
            string lastname = "welch";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";
            Person me = new Person(firstname, lastname, address, null);
            string expectedlastname = "smith";

            // Act Area (execution) ------ SUT means subject under test
            me.LastName = expectedlastname;

            // Assert Area (testing of the action)
            me.LastName.Should().Be(expectedlastname);
        } // End of Change_LastName_To_New_Name Test

        [Fact]
        public void Change_Both_FirstName_And_LastName_To_New_Name()
        {
            // Arrange Area (setup)
            string firstname = "don";
            string lastname = "welch";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            Person me = new Person(firstname, lastname, address, null);
            string expectedfirstname = "pat";
            string expectedlastname = "smith";

            // Act Area (execution) ------ SUT means subject under test
            me.ChangeName(expectedfirstname,expectedlastname);

            // Assert Area (testing of the action)
            me.FirstName.Should().Be(expectedfirstname);
            me.LastName.Should().Be(expectedlastname);

        } // End of Change_Both_FirstName_And_LastName_To_New_Name Test




        #endregion ValidData


        #region InvalidData

        [Theory]
        [InlineData(null,"welch")]
        [InlineData("don",null)]
        [InlineData("","welch")]
        [InlineData("don","")]
        [InlineData("     ", "welch")]
        [InlineData("don", "     ")]
        public void Create_a_Greedy_Instance_With_No_Names_Throws_Exception(string firstname, string lastname)
        {

            // Arrange Area (setup)
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";

            // Act Area (execution) ------ SUT means subject under test
            Action action = () => new Person(firstname, lastname, address, null);

            // Assert Area (testing of the action)
            action.Should().Throw<ArgumentNullException>();

        } // End of Create_a_Greedy_Instance_With_No_Names_Throws_Exception Test

        
        // changing the firstname via the FirstName property
        // validation of firstname is required.
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
       
        public void Throw_Exception_When_setting_FirstName_To_Missing_Data(string changename)
        {
            // Arrange Area (setup)
            string firstname = "don";
            string lastname = "welch";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";
            Person me = new Person(firstname, lastname, address, null);
            

            // Act Area (execution) ------ SUT means subject under test
            // Testing will the property capture an invalid name change
            Action action = () => me.FirstName= changename;

            // Assert Area (testing of the action)
            action.Should().Throw<ArgumentNullException>().WithMessage("*First Name is required*");
        } // End of Throw_Exception_When_setting_FirstName_To_Missing_Data

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]

        public void Throw_Exception_When_setting_LastName_To_Missing_Data(string changename)
        {
            // Arrange Area (setup)
            string firstname = "don";
            string lastname = "welch";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";
            Person me = new Person(firstname, lastname, address, null);


            // Act Area (execution) ------ SUT means subject under test
            // Testing will the property capture an invalid name change
            // Action is a special unit testing datatype that records the resul;ts of the executed statement into a variable action
            Action action = () => me.LastName = changename;

            // Assert Area (testing of the action)
            action.Should().Throw<ArgumentNullException>().WithMessage("*Last Name is required*");
        } // End of Throw_Exception_When_setting_FirstName_To_Missing_Data


        [Theory]
        [InlineData(null, "welch")]
        [InlineData("don", null)]
        [InlineData("", "welch")]
        [InlineData("don", "")]
        [InlineData("     ", "welch")]
        [InlineData("don", "     ")]
        public void Throw_Exception_When_Changing_FirstName_And_LastName(string changedfirstname, string changedlastname)
        {

            // Arrange Area (setup)
            string firstname = "don";
            string lastname = "welch";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";
            Person me = new Person(firstname, lastname, address, null);


            // Act Area (execution) ------ SUT means subject under test
            Action action = () => me.ChangeName(changedfirstname, changedlastname);
        ;
            // Assert Area (testing of the action)
            action.Should().Throw<ArgumentNullException>().WithMessage("*is required*");

        } // End of Throw_Exception_When_Changing_FirstName_And_LastName Test







        #endregion InvalidData







    }    // End of Person_Should Class
} // End of TDDUnitTestDemo namespace