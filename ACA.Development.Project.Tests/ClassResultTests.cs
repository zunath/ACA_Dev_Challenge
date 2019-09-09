using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACA.Development.Project.Tests
{
    [TestClass]
    public class ClassResultTests
    {
        [TestMethod]
        public void Ctor_ExcludedStudentNames_ShouldNotBeNull()
        {
            // Arrange
            var result = new ClassResult();

            // Act
            var excludedStudents = result.ExcludedStudentNames;

            // Assert
            Assert.IsNotNull(excludedStudents);
        }
    }
}
