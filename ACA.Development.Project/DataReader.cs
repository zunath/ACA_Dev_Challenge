using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ACA.Development.Project
{
    /// <summary>
    /// Responsible for reading input files and processing them into data types later used in the report builder.
    /// </summary>
    public class DataReader
    {
        /// <summary>
        /// Reads ".csv" files located in the Input folder found with the application.
        /// </summary>
        public List<Class> ReadInputFiles(string folderPath)
        {
            var files = Directory.GetFiles(folderPath, "*.csv");
            var classes = new List<Class>();

            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);
                string className = Path.GetFileNameWithoutExtension(file);
                List<string> lines;

                try
                {
                    lines = File.ReadLines(file).ToList();
                }
                catch
                {
                    Console.WriteLine("Unable to read file '" + fileName + "'.");

                    // A real application would have better error handling.
                    continue;
                }

                var @class = new Class(className);

                // Skip the header by starting at index 1.
                for (int index = 1; index < lines.Count; index++)
                {
                    var line = lines.ElementAt(index);
                    var student = ProcessStudentLine(line);

                    @class.Students.Add(student);
                }

                classes.Add(@class);
            }

            return classes;
        }

        /// <summary>
        /// Takes an input line, splits it based on the comma delimiter, and builds a Student record with the floored grade.
        /// </summary>
        /// <param name="line">The raw input line found in the input file.</param>
        /// <returns>The student record with a floored grade.</returns>
        private Student ProcessStudentLine(string line)
        {
            var data = line.Split(',');
            var name = data[0];

            // Grades come in as doubles, business rule says drop any fractional number to lower whole number.
            var rawGrade = Convert.ToDouble(data[1]);
            rawGrade = Math.Floor(rawGrade);

            var grade = Convert.ToInt32(rawGrade);
            var student = new Student(name, grade);

            return student;
        }
    }
}
