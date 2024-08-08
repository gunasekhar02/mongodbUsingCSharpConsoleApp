using MongoDBConnectionConsoleApp;
using MongoDB.Driver;

// initializing
var connectionString = "mongodb://localhost:27017/?directConnection=true";
var dataBaseName = "GunasDB";
var collectionName = "Employee";

//get db and collection from mongodb
var mongodbClient=new MongoClient(connectionString);
var db = mongodbClient.GetDatabase(dataBaseName);
var collection = db.GetCollection<Employee>(collectionName);

//creating employee data
var empList= new List<Employee> { new Employee { EmpName = "andreas", Designation = "Junior Software Engineer", Company = "Wipro", YearsOfExp = 1 },
new Employee { EmpName = "Jonathan", Designation = "associate Software Developer", Company = "Mindtree", YearsOfExp = 2 },
new Employee { EmpName = "Ovidu", Designation = "Senior Devops Engineer", Company = "Gep World Wide", YearsOfExp = 5 }};

//inserting data
await collection.InsertManyAsync(empList);

//printing data
var response = await collection.FindAsync(_ => true);

foreach (var emp in response.ToList())
{
    Console.WriteLine( $"Employee ID: {emp.EmpId},    Employee Name: {emp.EmpName}, Company: {emp.Company}     Designation: {emp.Designation}     Years of Experience:   {emp.YearsOfExp}");
}

