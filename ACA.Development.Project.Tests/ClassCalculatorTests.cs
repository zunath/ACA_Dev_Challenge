using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACA.Development.Project.Tests
{
    [TestClass]
    public class ClassCalculatorTests
    {
        [TestMethod]
        public void CalculateClassResult_OneStudent_ShouldReturnValidClassResult()
        {
            // Arrange
            var calculator = new ClassCalculator();
            var @class = new Class("my class");
            @class.Students.Add(new Student("John Doe", 50));

            // Act
            var result = calculator.CalculateClassResult(@class);

            // Assert
            Assert.AreEqual(50, result.Average);
            Assert.AreEqual("my class", result.ClassName);
            Assert.AreEqual(0, result.ExcludedStudentNames.Count);
            Assert.AreEqual(1, result.TotalStudents);
            Assert.AreEqual(1, result.StudentCountUsedForCalculations);
        }

        [TestMethod]
        public void CalculateClassResult_ZeroStudents_ShouldReturnValidClassResult()
        {
            // Arrange
            var calculator = new ClassCalculator();
            var @class = new Class("my empty class");

            // Act
            var result = calculator.CalculateClassResult(@class);

            // Assert
            Assert.AreEqual(0, result.Average);
            Assert.AreEqual("my empty class", result.ClassName);
            Assert.AreEqual(0, result.ExcludedStudentNames.Count);
            Assert.AreEqual(0, result.TotalStudents);
            Assert.AreEqual(0, result.StudentCountUsedForCalculations);
        }

        [TestMethod]
        public void CalculateClassResult_AllExcludedStudents_ShouldReturnValidClassResult()
        {
            // Arrange
            var calculator = new ClassCalculator();
            var @class = new Class("my class");
            @class.Students.Add(new Student("excluded 1", 0));
            @class.Students.Add(new Student("excluded 2", 0));

            // Act
            var result = calculator.CalculateClassResult(@class);

            // Assert
            Assert.AreEqual(0, result.Average);
            Assert.AreEqual("my class", result.ClassName);
            Assert.AreEqual(2, result.ExcludedStudentNames.Count);
            Assert.AreEqual(2, result.TotalStudents);
            Assert.AreEqual(0, result.StudentCountUsedForCalculations);
        }

        [TestMethod]
        public void CalculateClassResult_VariedStudents_ShouldReturnValidAverage()
        {
            // Arrange
            var calculator = new ClassCalculator();
            var @class = new Class("my class");
            @class.Students.Add(new Student("valid 1", 50));
            @class.Students.Add(new Student("valid 2", 25));
            @class.Students.Add(new Student("excluded 1", 0));

            // Act
            var result = calculator.CalculateClassResult(@class);

            // Assert
            Assert.AreEqual(37.5f, result.Average);
        }
    }
}
