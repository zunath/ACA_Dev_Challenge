using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACA.Development.Project.Tests
{
    [TestClass]
    public class ClassTests
    {
        [TestMethod]
        public void Ctor_ClassNameValid_ShouldBeEqual()
        {
            // Arrange
            Class myClass = new Class("My Class");

            // Act
            string name = myClass.ClassName;

            // Assert
            Assert.AreEqual("My Class", name);
        }

        [TestMethod]
        public void Ctor_ClassNameInvalid_ShouldBeEmptyString()
        {
            // Arrange
            Class myClass1 = new Class(null);
            Class myClass2 = new Class("            ");

            // Act
            string name1 = myClass1.ClassName;
            string name2 = myClass2.ClassName;

            // Assert
            Assert.AreEqual(string.Empty, name1);
            Assert.AreEqual(string.Empty, name2);
        }

        [TestMethod]
        public void Ctor_Students_ShouldNotBeNull()
        {
            // Arrange
            Class myClass = new Class("My Class");

            // Act
            var students = myClass.Students;

            // Assert
            Assert.IsNotNull(students);
        }
    }
}
