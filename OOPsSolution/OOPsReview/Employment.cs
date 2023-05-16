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
                        throw new ArgumentOutOfRangeException("value");
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

    } // End Employment Class

} //  End NameSpace


