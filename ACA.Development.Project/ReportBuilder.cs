using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ACA.Development.Project
{
    /// <summary>
    /// Responsible for building a report both in the console log as well as an output file on disk.
    /// </summary>
    public class ReportBuilder
    {
        /// <summary>
        /// Builds a report based on the given list of class results.
        /// Identifies the highest performing class as well as details about individual classes.
        /// </summary>
        /// <param name="results">The calculated class results.</param>
        public string GenerateReport(List<ClassResult> results)
        {
            var highestPerformer = results.OrderByDescending(o => o.Average).First();

            string report = "============== HIGHEST PERFORMING CLASS ==============\n" +
                highestPerformer.ClassName + " Average Grade: " + highestPerformer.Average + "%\n" +
                "======================================================\n\n" +
                "Class Results: \n\n";

            int classNumber = 1;
            foreach (var result in results)
            {
                // Class header. Name and average percentage.
                report += $"{classNumber}. {result.ClassName} Average: {result.Average.ToString("0.0")}%\n";
                
                // Detailed information: Total number of students, number used for calculations, and discarded student names
                report += $"\tTotal Number of Students: {result.TotalStudents}\n";
                report += $"\tNumber of Students Used in Calculations: {result.StudentCountUsedForCalculations}\n";
                report += $"\tExcluded Student(s):\n";

                // Only print out the excluded names if there are any. Otherwise give a N/A for that field in the report.
                if (result.ExcludedStudentNames.Count > 0)
                {
                    foreach (var excluded in result.ExcludedStudentNames)
                    {
                        report += $"\t\t{excluded}\n";
                    }
                }
                else
                {
                    report += "\t\tN/A\n";
                }

                classNumber++;
            }

            // Print the report to the console output.
            Console.WriteLine(report);

            // Write the report to the disk too.
            string nowTimestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string fileName = $"Results_{nowTimestamp}.txt";
            File.WriteAllText($"./{fileName}", report);

            return fileName;
        }
    }
}
