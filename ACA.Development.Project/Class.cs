using System;
using System.Collections.Generic;
using System.Text;

namespace ACA.Development.Project
{
    /// <summary>
    /// Represents a group of students associated with a class.
    /// </summary>
    public class Class
    {
        public List<Student> Students { get; set; }
        public string ClassName { get; set; }

        public Class(string className)
        {
            Students = new List<Student>();
            ClassName = className;

            if (string.IsNullOrWhiteSpace(ClassName))
                ClassName = string.Empty;
        }
    }
}
