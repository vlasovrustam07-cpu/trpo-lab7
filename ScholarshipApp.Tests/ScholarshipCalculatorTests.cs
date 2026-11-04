using ScholarshipApp;

namespace ScholarshipApp.Tests
{
    public class ScholarshipCalculatorTests
    {
        private readonly ScholarshipCalculator calculator = new ScholarshipCalculator();

        // Баг 1: граничное значение 4.5 должно давать стипендию.
        [Theory]
        [InlineData(0.0, 0)]
        [InlineData(4.49, 0)]
        [InlineData(4.5, 3000)]
        [InlineData(5.0, 3000)]
        public void CalculateScholarship_BoundaryValues(double gpa, int expected)
        {
            Assert.Equal(expected, calculator.CalculateScholarship(gpa));
        }

        [Theory]
        [InlineData(-0.1)]
        [InlineData(5.01)]
        public void CalculateScholarship_GpaOutOfRange_Throws(double gpa)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateScholarship(gpa));
        }

        // Баг 2: фонд должен учитывать всех студентов, включая последнего.
        [Fact]
        public void CalculateTotalFund_CountsEveryStudent()
        {
            var students = new List<Student>
            {
                new Student { FullName = "Иванов Иван", Group = "ИСТ-21", Gpa = 5.0, Scholarship = 3000 },
                new Student { FullName = "Сидорова Анна", Group = "ИСТ-21", Gpa = 4.8, Scholarship = 3000 },
            };

            Assert.Equal(6000, calculator.CalculateTotalFund(students));
        }

        [Fact]
        public void CalculateTotalFund_EmptyList_ReturnsZero()
        {
            Assert.Equal(0, calculator.CalculateTotalFund(new List<Student>()));
        }
    }
}
