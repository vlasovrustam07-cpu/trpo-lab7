namespace ScholarshipApp
{
    /// <summary>
    /// Расчёт стипендии по среднему баллу.
    /// </summary>
    public class ScholarshipCalculator
    {
        /// <summary>
        /// Минимальный средний балл, при котором назначается стипендия.
        /// </summary>
        public const double MinGpaForScholarship = 4.5;

        /// <summary>
        /// Размер стипендии в рублях.
        /// </summary>
        public const int ScholarshipAmount = 3000;

        /// <summary>
        /// Рассчитывает стипендию для указанного среднего балла.
        /// </summary>
        /// <param name="gpa">Средний балл студента.</param>
        /// <returns>3000 рублей при среднем балле от 4.5, иначе 0.</returns>
        public int CalculateScholarship(double gpa)
        {
            if (gpa >= MinGpaForScholarship)
            {
                return ScholarshipAmount;
            }

            return 0;
        }

        /// <summary>
        /// Считает общий фонд стипендий для списка студентов.
        /// </summary>
        /// <param name="students">Список студентов.</param>
        /// <returns>Сумма стипендий всех студентов в рублях.</returns>
        public int CalculateTotalFund(List<Student> students)
        {
            int total = 0;
            foreach (Student student in students)
            {
                total += student.Scholarship;
            }

            return total;
        }
    }
}
