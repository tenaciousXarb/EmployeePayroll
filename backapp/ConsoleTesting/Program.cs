// See https://aka.ms/new-console-template for more information
using DAL2.EF;

Console.WriteLine("Hello, World!");

EpProjectDbContext db = new EpProjectDbContext();

foreach(var obj in db.Employees.ToList())
{
    Console.WriteLine("Name: " + obj.Name + "\tEmail: " + obj.Email);
}