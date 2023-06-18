using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class AccessorReview
    {
        // This class will be used to review the how an accessor can 
        // be used to control access to calculate a value

        // on property
        // the get returns a value to the calling client
        // the value is the data associated with the property
        // the get can have a logic to calculate the return value
        // the set receives a value from the calling client
        // the incoming value is placed into a data hold
        // the set can have logic to validate the incoming data
        public int Number1 { get; set; } // auto-implemented property
        public int Number2 { get;set; }
        public int Add
        {
            get { return Number1 + Number2; }

        }

    }
}
