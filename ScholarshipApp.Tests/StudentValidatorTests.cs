using ScholarshipApp;

namespace ScholarshipApp.Tests
{
    public class StudentValidatorTests
    {
        // Баг 5: ФИО не пустое и без цифр.
        [Theory]
        [InlineData("Иванов Иван Иванович", true)]
        [InlineData("Салтыков-Щедрин Михаил", true)]
        [InlineData("123", false)]
        [InlineData("Иванов2", false)]
        [InlineData("", false)]
        [InlineData("   ", false)]
        [InlineData(null, false)]
        public void IsValidFullName_ChecksEmptyAndDigits(string? fullName, bool expected)
        {
            Assert.Equal(expected, StudentValidator.IsValidFullName(fullName));
        }

        // Баг 6: группа не может быть пустой.
        [Theory]
        [InlineData("ИСТ-21", true)]
        [InlineData("", false)]
        [InlineData("  ", false)]
        [InlineData(null, false)]
        public void IsValidGroup_RejectsEmpty(string? group, bool expected)
        {
            Assert.Equal(expected, StudentValidator.IsValidGroup(group));
        }

        // Баг 7: балл вводится и через запятую, и через точку.
        [Theory]
        [InlineData("4,5", 4.5)]
        [InlineData("4.5", 4.5)]
        [InlineData(" 5 ", 5.0)]
        [InlineData("0", 0.0)]
        public void ParseGpa_AcceptsCommaAndDot(string input, double expected)
        {
            Assert.Equal(expected, StudentValidator.ParseGpa(input), 6);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("")]
        [InlineData(null)]
        public void ParseGpa_NotANumber_ThrowsFormatException(string? input)
        {
            Assert.Throws<FormatException>(() => StudentValidator.ParseGpa(input));
        }

        // Баг 4: балл вне диапазона 0–5.
        [Theory]
        [InlineData("7")]
        [InlineData("-1")]
        [InlineData("5,01")]
        public void ParseGpa_OutOfRange_ThrowsArgumentOutOfRange(string input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => StudentValidator.ParseGpa(input));
        }
    }
}
