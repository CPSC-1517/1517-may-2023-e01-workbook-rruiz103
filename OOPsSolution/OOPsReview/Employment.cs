using System.Text.Json.Serialization;

namespace OOPsReview
{
    public class Employment
    {
        // DATA NEMBERS

        private SupervisoryLevel _Level;
        private string _Title;
        private double _Years;

        // PROPERTIES
        // are associated with a single piece of data
        // Fully Implemented usually has additional logic to execute for the controlover the data such as validation.
        //      It will have a declared data member to store the data.
        // Auto Implemented do not have additional logic. It doesn't have a declared data member to store data instead the O/S
        //      will create on the property's behalf a storage area that is accessible only by using the property
        // A property will alwaysa have an accessor (get)
        // A property may or may not have a mutator
        // No mutator, the property is consider "read only" and is usually returning a computed value like FullName made up of 2 pieces of data which is 
        //      the FirstName and LastName
        // If with a Mutator, the property will at some point save the data to storage.
        // The mutator may be public (default) or private
        // If public: accessible by the outside users of this class
        // If private: accessible only within the class
        // A property does not have ANY declared incoming parameters list


        public string Title
        {
            // get = accessor which returns the string associated with the property

            get { return _Title; }

            // set = mutator / it is within the set that the validation of the data  is done
            //      determine if the data is accessible

            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is required");
                }
                else
                {
                    _Title = value;
                }

            }
        }

        public SupervisoryLevel Level
        { 
                get { return _Level; }
                private set
                {

                    // a private set means that the property can only be set
                    // by code within the class definition
                    // advantage of doing this is increasing the security on the
                    // field as any change is under the control of the class definition

                    // Enum
                    // Validate that the value given as an enum is actually defined
                    // A user of this class could send in an integer value that was type casted as this enum data type but have a 
                    // none defined value
                    // to test an enum value use Enum.IsDefnied(typeof()}, value)
                    // where xxx is thge name of the enum datatype

                    if (!Enum.IsDefined(typeof(SupervisoryLevel), value)) 
                    {
                        throw new ArgumentException($"Supervisory Level is invalid: {value}");
                    }
                    _Level = value;
                }
        } // End of Level Property

        // Validate the years of service in the employee position as a positive value

        public double Years
        {
                get { return _Years; } // used on the right side of an assignment statement or in an expression
                set                    // used on the left side of an assignment statement 
                {
                    // if (value < 0)      // using Utilties generic method to do this test
                    if (!Utilities.IsZeroOrPositive(value))
                    { 
                        throw new ArgumentOutOfRangeException(value.ToString());
                    }
                    _Years = value;
                }
        } // End of Years Property

        // this property is an example of an auto implemented property
        // there is no validation within the property
        // there is no private data member for this property
        // the system will generate an internal storage area for the data
        // and handle the setting and getting from that storage area
        // the property will only be able to be set via a constructor or a method
        // auto implemented properties can have either a public or private set
        // using a public or private set is a design decision

        public DateTime StartDate
        {
            get;
            private set;
        } // End of StartDate Property


        // Constructors
        // Purpose of constructor is to create an instance of your class in a known state
        // Does a class definition need a constructor? >>> NO
        // If a class definition does not have a constructor then the system will create the instance and
        // assign the system default values to each data member and/or auto implemented property
        // Default value for double/int is 0 / for string is null / for datetime is January 1, 0001 00:00:00
        // if you have no constructor, the common phrase is "using a system constructor"
        // If you code a constructor in your class, you are responsible for any and all constructors for the class

        // Default Constructor - you can apply your own literal values for your data members and/or auto implemented 
        //                       properties that differ from tghe system default values.
        //                       Why? You may have a data that is validated and using the system default values would cause an exception
        // See Sample below:

        public Employment()
        {
            // this constructor will be used on creating an instance using 
            //      Employment myInstance = new Employment();
            // A practice that I personally use is to avoid referencing my data members directly 
            // especially if the property contains validation

            Title = "Unknown";
            Level = SupervisoryLevel.TeamMember;
            StartDate = DateTime.Today;

            // optionally one could set years to zero, but that is the system default value for a numeric
            // therefore one does not need to assign a value unless you wish to

        } // End of Employment (Default Constructor)

        // Greedy Consstructor - is one that accepts a parameters list of values to assign to your instance data on creation
        //                       of the instance. Generally, your greedy constructor contains a parameter on the signature
        //                       for each data member you have in your class definition. 

        // All Default Parameters must appear after Non Default Parameter List
        // in this example, we will use Years as an optional parameter

        public Employment(string title, SupervisoryLevel level, DateTime startdate, double years = 0.0)
        { 
            Title= title;
            Level = level;
            Years = years;

            // this example is demonstrating where you can place validation for properties that are auto implemented
            // validate startdate must not exist in the future
            // validation can be done anywhere in your class
            // since the property is autoimplemented and has a private set, vaidation can be done in the constructor or a method
            // that alters the property value. If the validation is done in the property, it would not be an auto implemented proeprty 
            // but a fully implemented property
            // .Today has a time of 00:00:000 AM BUT .Now has a specific time of day at execution
            // by using the .Today.AddDays(1) you cover all times on a specific date

            if (startdate >= DateTime.Today.AddDays(1)) 
            { 
                throw new ArgumentException($"The start date {startdate} is in the future");
            }
            StartDate= startdate;

            if (years > 0.0)
            {
                Years = (double)years;
            }
            else
            {
                TimeSpan span = DateTime.Now - StartDate;
                Years = Math.Round((span.Days / 365.25), 1);
            }
        
        } // End of Employment (Greedy Constructor)


        // METHODS
        // Behaviours (a.k.a Methods)

        // A method consists of a header  Syntax: accesslevel returndatatype methodname (parameters)
        // a coding block {........}

        public void SetEmploymentResponsibilityLevel(SupervisoryLevel level)
        { 

            // the peroperty has a private set therefore the only way to assign the value to the property is either
            // via the constructor at creation time or via public method within the class
            // what about the validation of the value
            // validation can be done in multiple places
            // a.) can it be done in this method? = Yes
            // b) can tt be done in the property = Yes if proeprty is fully implemented

             Level= level;

        } // End SetEmploymentResponsibilityLevel Method

        public void CorrectStartDate(DateTime startdate)
        {
            // The StartDate property is an auto implemented property
            // The startDate property has no validation code
            // You need to do any validation on the incoming value wherever you plan to alter the existing value in the class
            if (startdate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date {startdate} is in the future");
            }
            StartDate = startdate;

        } // End of CorrectStartDate Method

        public override string ToString()
        {
            return $"{Title},{Level},{StartDate.ToString("MMM dd yyyy")},{Years}";

            // Other way to format date
            // string formattedStartDate = StartDate.ToString("MMM dd, yyyy");
            // return $"{Title},{Level},{formattedStartDate}";

        } // End of ToString Method

        public double UpdateCurrentEmploymentYearsExperience()
        {

            TimeSpan span = DateTime.Now- StartDate;
            int days = span.Days;
            // or
            Years = Math.Round((span.Days / 365.25), 1);

            return Years;

            // Other way to calculate date difference
            // TimeSpan difference = StartDate.Subtract(DateTime.Now);
            // Years = difference.TotalDays;

        } // End of UpdateCurrentEmploymentYearsExperience Mwthod

        public static Employment Parse(string str)
        {
            // Parsing attempts to change the contents of a string into another datatype
            // example:   string 55  --> int x = int.Parse(string); success
            //            string bob --> int x = int.Parse(string); failed with an exception message

            // text is a string of csv values (comma separate values)
            // separate the string of values into individual strings
            //  using .Split(delimiter)
            // a delimiter is normally some type of character
            // for a csv, the delimiter is a comma (',')
            // the .Split() method returns an array of strings
            // test the array size to determine if sufficient "parts" have be supplied
            // if not, throw a FormatException
            // if sufficient parts have been supplied you can continue your logic in 
            // creating the instance of intent

            string[] pieces = str.Split(','); 
            // This line splits the input string str into an array of substrings using a comma (',') as the delimiter.
            // The Split method divides the string wherever it encounters a comma and returns an array of strings.


            if (pieces.Length != 4)
            {
                throw new FormatException($"Record {str} not in the expected format.");
            }
            // This if statement checks if the array pieces has exactly four elements. If it doesn't, it means the input string does not have the expected number of values,
            // and a FormatException is thrown with an error message indicating the problematic record.

            // if sufficient parts have been supplied you can continue your logic in 
            // creating the instance of intent
            // create a new instance using the greedy constructor

            //  return new Employment >>> creates a new Employment instance using the constructor that takes four arguments.
            //  The arguments are extracted from the pieces array, representing different parts of the CSV data. 
            return new Employment(pieces[0],    //  used as the first argument, representing the job title.
                                  (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel),pieces[1]), // used as the second argument. It converts the string value from pieces[1] to the corresponding SupervisoryLevel enum value using the Enum.Parse method.
                                  DateTime.Parse(pieces[2]), // used as the third argument. It converts the string value from pieces[2] to a DateTime object using the DateTime.Parse method.
                                  double.Parse(pieces[3]) // used as the fourth argument. It converts the string value from pieces[3] to a double value using the double.Parse method.
                                  );

        } // End of Parse Method

        public static bool TryParse(string str, out Employment employment)
        {
            // This method takes two parameters: str, which is the incoming input string, and employment, which is an output parameter of type Employment.
            // The method returns a bool value indicating whether the parsing was successful (true) or not (false).

            //use this method to check to see if the parse could actually be done
            //the result of the attempt is
            //  a) true and the converted string value is placed into the out going variable
            //  b) false and no conversion of the string is done
            //     (optional,
            //          you can include a try/catch within the method to capture (error handling) the 
            //          Parse error so that it does not return to the program
            //          and your false value will have a meaning)

            //example   if (xxxx.TryParse(string, out myNumericvalue)) { ..... } else { .... }

            bool result = true; // assume success
            //This line initializes a bool variable named result to true.This variable will track the success or failure of the parsing attempt.

            employment = null;
            // output parameter is initialized to null.

            try
            {
                employment = Parse(str);
                // The code inside the try block attempts to parse the input string str by calling the Parse method. If the parsing is successful,
                // the resulting Employment instance is assigned to the employment output parameter.
                // If a FormatException is thrown during the parsing process, it means the string format is invalid, and the catch block is executed.
            }
            catch (FormatException ex)
            {
                result = false; // indicates failure
                // In the catch block, the result variable is set to false to indicate that the parsing failed.
            }

            return result;
            // The method returns the value of the result variable, which indicates whether the parsing was successful(true) or not(false).

            //alternative
            //if you wish to have the FormatException passed on to the calling coding
            //  the DO NOT include the try/catch within your TryParse method

            // result = false;
            // if (string.IsNullOrWhiteSpace(str))
            // {
            //    throw new ArgumentNullException("No value was supplied for parsing");
            // }
            // employment = null;
            // employment = Parse(str);
            // return true;

        }

    } // End Employment Class

} //  End NameSpace


