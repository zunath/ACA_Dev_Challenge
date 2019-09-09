using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ACA.Development.Project
{
    // American Credit Acceptance Developer Challenge
    // Programmer: Tyler Watson
    // Date: 2019-09-09

    public class Program
    {
        /// <summary>
        /// Main entry point to the application.
        /// Read input files to identify classes, students, and grades.
        /// Then print the following to an output file named "Results.txt":
        ///     - The highest performing class
        ///     - The averages for all classes.
        ///     - For each class:
        ///         1.) Total number of students within the class.
        ///         2.) The number of students used to calculate the class average
        ///         3.) The names of any students who were discarded from consideration.
        /// </summary>
        private static void Main()
        {
            // Instantiate objects. Normally we'd use an IOC container and inject the dependencies
            // but I feel that over-engineers this particular problem.
            var reader = new DataReader();
            var calculator = new ClassCalculator();
            var reportBuilder = new ReportBuilder();

            // Build class information from the input files.
            var classes = reader.ReadInputFiles("./Input/");

            // Process results for each class.
            var classResults = new List<ClassResult>();
            foreach (var @class in classes)
            {
                var result = calculator.CalculateClassResult(@class);
                classResults.Add(result);
            }

            // Generate the report.
            string outputFileName = reportBuilder.GenerateReport(classResults);

            Console.WriteLine($"Report file {outputFileName} has been created.");
            Console.WriteLine("Process completed. Press any key to end.");
            Console.ReadKey();
        }
    }
}
