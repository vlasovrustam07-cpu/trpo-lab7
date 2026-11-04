// <copyright file="StudentValidator.cs" company="rystia">
// Учебный проект по ТРПО, лабораторная работа 7.
// </copyright>

namespace ScholarshipApp
{
    using System.Globalization;

    /// <summary>
    /// Проверка данных студента, введённых пользователем.
    /// </summary>
    public static class StudentValidator
    {
        /// <summary>
        /// Проверяет ФИО: строка не пустая и не содержит цифр.
        /// </summary>
        /// <param name="fullName">ФИО студента.</param>
        /// <returns><c>true</c>, если ФИО корректно.</returns>
        public static bool IsValidFullName(string? fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return false;
            }

            // В ФИО допускаются буквы, пробелы и дефис, но не цифры.
            foreach (char symbol in fullName)
            {
                if (char.IsDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Проверяет, что название группы не пустое.
        /// </summary>
        /// <param name="group">Название группы.</param>
        /// <returns><c>true</c>, если группа указана.</returns>
        public static bool IsValidGroup(string? group) => !string.IsNullOrWhiteSpace(group);

        /// <summary>
        /// Проверяет, что средний балл находится в диапазоне от 0 до 5.
        /// </summary>
        /// <param name="gpa">Средний балл.</param>
        /// <returns><c>true</c>, если балл от 0 до 5 включительно.</returns>
        public static bool IsValidGpa(double gpa) => gpa >= 0 && gpa <= 5;

        /// <summary>
        /// Преобразует введённую строку в средний балл. Дробную часть можно отделять
        /// и запятой, и точкой, поэтому ввод не зависит от языковых настроек Windows.
        /// </summary>
        /// <param name="input">Строка, введённая пользователем.</param>
        /// <returns>Средний балл от 0 до 5.</returns>
        /// <exception cref="FormatException">Строка не является числом.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Число вне диапазона от 0 до 5.</exception>
        public static double ParseGpa(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new FormatException("Средний балл не введён.");
            }

            string normalized = input.Trim().Replace(',', '.');
            double gpa = double.Parse(normalized, NumberStyles.Float, CultureInfo.InvariantCulture);
            if (!IsValidGpa(gpa))
            {
                throw new ArgumentOutOfRangeException(nameof(input), gpa, "Средний балл должен быть от 0 до 5.");
            }

            return gpa;
        }
    }
}
