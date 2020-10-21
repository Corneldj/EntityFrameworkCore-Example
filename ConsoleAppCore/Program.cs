using EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConsoleAppCore
{
    class Program
    {
        static string Connectionstring { get; set; }
        static SqlServerContext Context { get; set; }
        static void Main(string[] args)
        {
            Connectionstring = @"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;";

            var optionBuilder = new DbContextOptionsBuilder();
            Context = new SqlServerContext(optionBuilder.UseSqlServer(Connectionstring).Options);
        }
    }
}
