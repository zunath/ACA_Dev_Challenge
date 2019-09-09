using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACA.Development.Project.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void Ctor_Student_ValuesShouldMatch()
        {
            // Arrange
            var student = new Student("Jon Snow", 45);

            // Act
            var name = student.Name;
            var grade = student.Grade;

            // Assert
            Assert.AreEqual("Jon Snow", name);
            Assert.AreEqual(45, grade);
        }

        [TestMethod]
        public void Ctor_InvalidData_ShouldReturnEmptyStringAndZero()
        {
            // Arrange
            var student = new Student(null, -9282);

            // Act
            var name = student.Name;
            var grade = student.Grade;

            // Assert
            Assert.AreEqual(string.Empty, name);
            Assert.AreEqual(0, grade);
        }
    }
}
