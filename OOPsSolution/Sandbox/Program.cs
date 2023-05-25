// See https://aka.ms/new-console-template for more information
using OOPsReview;

Console.WriteLine("Hello, World!");

Residence myHome = new Residence(123,"Maple St.","Edmonton","AB","T6Y7U8");
Console.WriteLine(myHome.ToString());

//Can I change the value in the record instance?
// myHome.Number = 321;
// it's read only, so the answer is No.
// To alter a value in tjhe record instance, you must create a new instance

myHome = new Residence(321, "Maple St.", "Edmonton", "AB", "T6Y7U8");
Console.WriteLine(myHome.ToString());

// Exanple of Refractoring 
// Refractoring is the process of restructing code, while not
// changing its original functionality. The goal is to improve internal
// code by making small changes without altering the codes external behavior

// Original Code
bool flag = false;
if (myHome.Province.ToLower() == "ab")
{ 
    flag= true;
}

if (myHome.Province.ToLower() == "bc")
{
    flag = true;
}

if (myHome.Province.ToLower() == "sk")
{
    flag = true;
}

if (myHome.Province.ToLower() == "mn")
{
    flag = true;
}

// Refractor using a switch statement

if (myHome.Province.ToLower() == "ab" || myHome.Province.ToLower() == "bc" || myHome.Province.ToLower() == "sk" || myHome.Province.ToLower() == "mn")
{
    flag = true;
}


switch (myHome.Province.ToLower())
{
    case "ab":
    case "bc":
    case "sk":
    case "mn":
        { 
            flag = true;
            break;
        }
    default:
        { 
         flag= false;
         break;
        }
     

}