using System;

namespace ACA.Development.Project
{
    public class Student
    {
        public string Name { get; set; }
        public int Grade { get; set; }

        public Student(string name, int grade)
        {
            Name = name;
            Grade = grade;

            if (string.IsNullOrWhiteSpace(Name))
                Name = string.Empty;
            if (Grade < 0) Grade = 0;
        }
    }
}
