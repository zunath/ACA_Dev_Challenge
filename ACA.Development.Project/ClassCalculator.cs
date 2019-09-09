using System;
using System.Collections.Generic;
using System.Text;

namespace ACA.Development.Project
{
    /// <summary>
    /// Handles calculating class result information.
    /// </summary>
    public class ClassCalculator
    {
        /// <summary>
        /// Builds a class result using a given Class object.
        /// </summary>
        /// <param name="class">The class to calculate results for</param>
        /// <returns>A result containing details about averages, number of students, etc.</returns>
        public ClassResult CalculateClassResult(Class @class)
        {
            var classResult = new ClassResult
            {
                TotalStudents = @class.Students.Count,
                ClassName = @class.ClassName
            };

            float scoreTotal = 0.0f;
            foreach (var student in @class.Students)
            {
                // Is this student excluded from calculations?
                if (student.Grade <= 0)
                {
                    classResult.ExcludedStudentNames.Add(student.Name);
                }
                else
                {
                    classResult.StudentCountUsedForCalculations++;
                    scoreTotal += student.Grade;
                }
            }

            // Account for the possibility for an empty class.
            if(classResult.StudentCountUsedForCalculations > 0)
                classResult.Average = scoreTotal / classResult.StudentCountUsedForCalculations;

            return classResult;
        }
    }
}
