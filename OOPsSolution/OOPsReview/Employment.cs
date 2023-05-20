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
            return $"{Title},{Level},{StartDate.ToString("MMM dd, yyyy")},{Years}";

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




    } // End Employment Class

} //  End NameSpace


