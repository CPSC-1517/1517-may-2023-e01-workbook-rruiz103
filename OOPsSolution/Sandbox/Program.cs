// See https://aka.ms/new-console-template for more information
using OOPsReview;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json; // for Json serialization namespace
Console.WriteLine("Hello, World!");

// driver code
// RecordSamples();
// RefactorSample();
// FileIOCSV();


// Accessor Review Sample
AccessorReview ar = new OOPsReview.AccessorReview();
Random rnd = new Random();
for (int i = 0; i < 10; i++)
{
    ar.Number1 = rnd.Next(1, 11); // using the set in the property
    ar.Number2 = rnd.Next(1, 11); // using the set in the property
    // the get in the Add property is used to return the calculated value
    // the get in Number1 and Number2 properties are used to return the data
    Console.WriteLine($"Number1: {ar.Number1} Number2: {ar.Number2} Add: {ar.Add}");
}

// Explore JSon files writing and reading
// Create a Person instance with name, address and employments
Person me = CreatePerson();
DisplayPerson(me);
// filepath C:\Temp\PersonData.json
string filepathname = @"C:\Users\rjpr_\PersonData.json";
SaveAsJson(me, filepathname);
Person jsonMe = ReadAsJson(filepathname);
DisplayPerson(jsonMe);

Person CreatePerson()
{
    Residence myHome = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
    List<Employment> employments = Read_Employment_Collection_From_CSV();
    Person person = new Person("don","welch",myHome,employments);
    return person;
} // End of CreatePerson

void DisplayPerson(Person person)
{
    Console.WriteLine("\nPerson Data\n");
    Console.WriteLine($"Name: {person.FullName}");
    Console.WriteLine($"Residence: {person.Address.ToString()}");
    Console.WriteLine("\nEmployments");
    foreach (var item in person.EmploymentPositions)
    {
        Console.WriteLine($"\t{item.ToString()}");
    }
} // End of DisplayPerson

void SaveAsJson(Person person, string filepathname)
{
    // the term use to write Json file is called serialization
    // the classes used to are referred to serializers
    // with writing we can make the file produce more readable format
    // using indentation
    // JSon is very good at using objects and properties, HOWEVER
    // it needs help to / prompting to work better with fields
    // to help with public field within a class add an annotation (attributes title)
    // in front of the field declaration called [JsonInclude]
    // also the namespace using  System.Text.Json.Serialization;
    // example: ASsume class has a public string called FieldNotAProperty
    // [JsonInclude]
    // public string FieldNotAProperty

    // create options to use during serialization
    JsonSerializerOptions option = new JsonSerializerOptions
    {
        // during this instance creation one can refer to properties
        // within the class directly by name and assign a value to that property
        WriteIndented = true,
        IncludeFields = true // this is for the public non property fields
    };

    // remember to case the Serialized<T> to the appropriate class definition
    // this converts your instance to a Json sting
    string jsonstring = JsonSerializer.Serialize<Person>(person, option);

    // write the Json sting out to a .json text file
    File.WriteAllText(filepathname, jsonstring);


} // End of SaveAsJson

Person ReadAsJson(string filepathname)
{
    Person person = null;
    try
    {
        //bring in the json txt file
        string jsonstring = File.ReadAllText(filepathname);

        // use the deserializer to unpack the json string into the expected structure <Person>
        // it is important that the greedy constructor parameter names
        // are indentical to the attribute names used in the json string
        // they are not case sensitive 
        // they do not have to be in the same physical order as the
        // json string
        person = JsonSerializer.Deserialize<Person>(jsonstring);
    }
    catch (Exception ex)
    { 
        Console.WriteLine(ex.Message );
    }
    return person;
}

void FileIOCSV()
{

    
    // Create a collection of employment records / instances to write out data
    List<Employment> employments = new List<Employment>();
    employments.Add(new Employment("SAS Member", (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), "TeamMember"), DateTime.Parse("2015/06/14"), 3.6));
    employments.Add(new Employment("SAS Lead", (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), "TeamLeader"), DateTime.Parse("2019/01/24"), 2.8));
    employments.Add(new Employment("SAS Lead", (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), "Supervisor"), DateTime.Parse("2021/09/24"), 1.8));
    DumpEmployments(employments);
    Write_Employment_Collection_To_CSV(employments);
    List<Employment> employmentsRead = new List<Employment>();
    employmentsRead = Read_Employment_Collection_From_CSV();
    DumpEmployments(employmentsRead);
} // End of FileIOCSV

List<Employment> Read_Employment_Collection_From_CSV()
{
    // Use the File class to append text records to a file
    // by using the file class, one does not need to set up file IO stream
    // File IO streams (writer and reader) are built into methods of the file class

    // filepath C:\Temp\EmploymentData.txt
    string filepathname = @"C:EmploymentData.txt";

    // Convert List of Employment into a List<string>
    Employment employmentInstance = null;
    List<Employment> employmentCollection= new List<Employment>();

    try
    {
        //ReadAllLines
        //returns an array of all lines from a file as strings
        string[] employmentCSVStrings = File.ReadAllLines(filepathname);

        //convert each string from the CSV data into an Employment Instance
        //use the .Parse from this action

        foreach (string line in employmentCSVStrings)
        {
            try
            {
                employmentInstance = Employment.Parse(line);
                employmentCollection.Add(employmentInstance);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    return employmentCollection;


} // End of Read_Employment_Collection_From_CSV

void Write_Employment_Collection_To_CSV(List<Employment> employments)
{
    // Use the File class to append text records to a file
    // by using the file class, one does not need to set up file IO stream
    // File IO streams (writer and reader) are built into methods of the file class

    // filepath C:\Temp\EmploymentData.txt
    string filepathname = @"C:\Users\rjpr_\EmploymentData.txt";

    // Convert List of Employment into a List<string>
    List<string> employmentCollectionAsStrings = new List<string>();
    foreach (Employment employment in employments)
    { 
        employmentCollectionAsStrings.Add(employment.ToString());
    }

    // .AppendAllLines
    File.AppendAllLines(filepathname, employmentCollectionAsStrings);

}

void DumpEmployments(List<Employment> employments)
{
    Console.WriteLine("\n\t\tDump Employment Instances\n");
    for (int i=0; i < employments.Count;i++)
    {
        Console.WriteLine($"Instance {i}:\t {employments[i].ToString()}");
    }

}

void RecordSample()
{

    Residence myHome = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
    Console.WriteLine(myHome.ToString());

    //Can I change the value in the record instance?
    // myHome.Number = 321;
    // it's read only, so the answer is No.
    // To alter a value in tjhe record instance, you must create a new instance

    myHome = new Residence(321, "Maple St.", "Edmonton", "AB", "T6Y7U8");
    Console.WriteLine(myHome.ToString());

} // End of RecordSample

void RefractorSample()
{
    // Exanple of Refractoring 
    // Refractoring is the process of restructing code, while not
    // changing its original functionality. The goal is to improve internal
    // code by making small changes without altering the codes external behavior

    Residence myHome = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");

    // Original Code
    bool flag = false;
    if (myHome.Province.ToLower() == "ab")
    {
        flag = true;
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
                flag = false;
                break;
            }

    }

    //what would a person need to do if unit testing does not exists
    string firstname = "don";
    string lastname = "welch";
    Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
    Person me = new Person(firstname, lastname, address, null);

    //conside doing a loop where I make changes to the "changename", include try catch error handling
    //also need a interface of Console prompt and read lines.

    //me.FirstName = changename;

} // End of RefractorSample
