using System;
using System.Collections.Generic;
using System.Text;

namespace ACA.Development.Project
{
    /// <summary>
    /// Represents class result information for use in the report builder.
    /// </summary>
    public class ClassResult
    {
        public int TotalStudents { get; set; }
        public int StudentCountUsedForCalculations { get; set; }
        public List<string> ExcludedStudentNames { get; set; }
        public float Average { get; set; }
        public string ClassName { get; set; }

        public ClassResult()
        {
            ExcludedStudentNames = new List<string>();
        }
    }
}
