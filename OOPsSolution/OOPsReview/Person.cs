using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        private string _FirstName;
        private string _LastName;

        // FirstName Property
        public string FirstName
        {
            get { return _FirstName; }
            set {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentNullException("First Name is required");
                    }
                    _FirstName = value;
                }
        } // End of FirstName property

        // LastName Property
        public string LastName
        {
            get { return _LastName; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last Name is required");
                }
                _LastName = value; 
                }
        } // End of LastName property

        // Address Property
        public Residence Address 
        { 
            get; set;
        } // End of Address Property

        // EmploymentPositions Property
        public List<Employment> EmploymentPositions 
        { 
            get; set;
        } // End of EmploymentPositions Property

        // Person Greedy Constructor
        public Person(string firstname, string lastname, Residence address, List<Employment> employmentpositions)
        {
            
            FirstName = firstname;
            LastName= lastname;
            Address= address;
            
            if (employmentpositions != null)
            {
                EmploymentPositions = employmentpositions; // store the list of employments
            }
            EmploymentPositions = new List<Employment>();           

        } // End of Person Greedy Constructor

        // Person Default Constructor
        public Person()
        {
            FirstName = "unknown";
            LastName = "unknown";
            EmploymentPositions = new List<Employment>(); // create an empty instance of the list
        } // End of Person Default Constructor


        // Method: ChangeName
        public void ChangeName(string firstname, string lastname)
        {
            FirstName= firstname;
            LastName= lastname;
        } // End of ChangeName Method







    } // End of Person Class
} // End of OOPsReview namespace
