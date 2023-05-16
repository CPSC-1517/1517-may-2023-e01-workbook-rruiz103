using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public static class Utilities
    {
        // static class are not instantiated by the outside user (developer/code)
        // static class items are referenced using: classname.xxxx
        // methods within this class have the keyword static in their signature
        // static means shared / it is shared between all outside users at the same time
        // do not consider saving data within a static class because you cannot be certain 
        // it will be there when you use the class again
        // use-only type of class
        // consider placing generic re-usable methods with a static class

        // Sample of a generic method: numeric is a zero or positive value

        public static bool IsZeroOrPositive(double value)
        {
            // a structure method (apply to loops, etc) will have a single entry point 
            // and a single exit point
            // in this course you will avoid where possible multiple returns from a method
            // in this course you will avoid using a break to exit a loop structure or if structure

            bool valid = true;
            if (value < 0.0) 
            { 
                valid = false;
            }
            return valid;

        } // End of IsZeroOrPositive Method

        // overload the IsZeroOrPositive so that it uses integers or decimals

        public static bool IsZeroOrPositive(int value)
        {
            // a structure method (apply to loops, etc) will have a single entry point 
            // and a single exit point
            // in this course you will avoid where possible multiple returns from a method
            // in this course you will avoid using a break to exit a loop structure or if structure

            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;

        } // End of IsZeroOrPositive Method

        public static bool IsZeroOrPositive(decimal value)
        {
            // a structure method (apply to loops, etc) will have a single entry point 
            // and a single exit point
            // in this course you will avoid where possible multiple returns from a method
            // in this course you will avoid using a break to exit a loop structure or if structure

            bool valid = true;
            if (value < 0.0m)
            {
                valid = false;
            }
            return valid;

        } // End of IsZeroOrPositive Method

    }
}
