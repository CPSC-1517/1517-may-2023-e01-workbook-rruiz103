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