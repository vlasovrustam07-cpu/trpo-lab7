namespace ScholarshipApp
{
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
        public static bool IsValidFullName(string fullName)
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
        public static bool IsValidGroup(string group) => !string.IsNullOrWhiteSpace(group);

        /// <summary>
        /// Проверяет, что средний балл находится в диапазоне от 0 до 5.
        /// </summary>
        public static bool IsValidGpa(double gpa) => gpa >= 0 && gpa <= 5;
    }
}
