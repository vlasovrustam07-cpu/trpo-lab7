using ScholarshipApp;

namespace ScholarshipApp.Tests
{
    public class StudentRegistryTests
    {
        [Fact]
        public void AddStudent_ValidData_AddsStudentWithScholarship()
        {
            var registry = new StudentRegistry();

            Student student = registry.AddStudent("Иванов Иван", "ИСТ-21", 4.5);

            Assert.Single(registry.Students);
            Assert.Equal(3000, student.Scholarship);
        }

        [Fact]
        public void AddStudent_InvalidName_ThrowsAndDoesNotAdd()
        {
            var registry = new StudentRegistry();

            Assert.Throws<ArgumentException>(() => registry.AddStudent("123", "ИСТ-21", 5.0));
            Assert.Empty(registry.Students);
        }

        [Fact]
        public void AddStudent_GpaOutOfRange_ThrowsAndDoesNotAdd()
        {
            var registry = new StudentRegistry();

            Assert.Throws<ArgumentOutOfRangeException>(() => registry.AddStudent("Иванов Иван", "ИСТ-21", 7.0));
            Assert.Empty(registry.Students);
        }

        // Баг 3: у пустого списка нет деления на ноль.
        [Fact]
        public void GetAverageGpa_EmptyList_ReturnsZero()
        {
            var registry = new StudentRegistry();

            Assert.Equal(0, registry.GetAverageGpa());
        }

        [Fact]
        public void GetAverageGpa_TwoStudents_ReturnsMean()
        {
            var registry = new StudentRegistry();
            registry.AddStudent("Иванов Иван", "ИСТ-21", 5.0);
            registry.AddStudent("Сидорова Анна", "ИСТ-21", 4.0);

            Assert.Equal(4.5, registry.GetAverageGpa(), 6);
        }

        [Fact]
        public void GetTotalFund_TwoExcellentStudents_Returns6000()
        {
            var registry = new StudentRegistry();
            registry.AddStudent("Иванов Иван", "ИСТ-21", 5.0);
            registry.AddStudent("Сидорова Анна", "ИСТ-21", 4.8);

            Assert.Equal(6000, registry.GetTotalFund());
        }
    }
}
