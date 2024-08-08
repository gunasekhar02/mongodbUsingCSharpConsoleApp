using MongoDBConnectionConsoleApp;
using MongoDB.Driver;
using Amazon.Auth.AccessControlPolicy;
using System;

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

var response = await collection.FindAsync(_ => true);

foreach (var emp in response.ToList())
{
    Console.WriteLine( $"Employee ID: {emp.EmpId},    Employee Name: {emp.EmpName}, Company: {emp.Company}     Designation: {emp.Designation}     Years of Experience:   {emp.YearsOfExp}");
}


// Respone will look like 
/*
Employee ID: 66b444a3bd40bbc5a089969b, Employee Name: Guna, Company: Gep Worldwide     Designation: Software Developer     Years of Experience:   2
Employee ID: 66b444a3bd40bbc5a089969c, Employee Name: Sekhar, Company: IBM Designation: Senior Software Developer     Years of Experience:   4
Employee ID: 66b444a3bd40bbc5a089969d, Employee Name: Nick, Company: Verizon Designation: Principal Software Developer     Years of Experience:   8
Employee ID: 66b445f186050a1be1c0842d, Employee Name: andreas, Company: Wipro Designation: Junior Software Engineer     Years of Experience:   1
Employee ID: 66b445f186050a1be1c0842e, Employee Name: Jonathan, Company: Mindtree Designation: associate Software Developer     Years of Experience:   2
Employee ID: 66b445f186050a1be1c0842f, Employee Name: Ovidu, Company: Gep World Wide     Designation: Senior Devops Engineer     Years of Experience:   5*/