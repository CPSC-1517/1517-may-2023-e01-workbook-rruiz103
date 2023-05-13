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
            //      determine if the date is accessible

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


    } // End Employment Class

} //  End NameSpace


