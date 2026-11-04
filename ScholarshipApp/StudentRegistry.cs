// <copyright file="StudentRegistry.cs" company="rystia">
// Учебный проект по ТРПО, лабораторная работа 7.
// </copyright>

namespace ScholarshipApp
{
    /// <summary>
    /// Список студентов в памяти и статистика по нему.
    /// </summary>
    public class StudentRegistry
    {
        private readonly List<Student> students = new List<Student>();
        private readonly ScholarshipCalculator calculator = new ScholarshipCalculator();

        /// <summary>
        /// Получает всех добавленных студентов.
        /// </summary>
        public IReadOnlyList<Student> Students => this.students;

        /// <summary>
        /// Добавляет студента в список и назначает ему стипендию.
        /// </summary>
        /// <param name="fullName">ФИО студента.</param>
        /// <param name="group">Учебная группа.</param>
        /// <param name="gpa">Средний балл от 0 до 5.</param>
        /// <returns>Добавленный студент с рассчитанной стипендией.</returns>
        public Student AddStudent(string fullName, string group, double gpa)
        {
            Student student = new Student
            {
                FullName = fullName,
                Group = group,
                Gpa = gpa,
                Scholarship = this.calculator.CalculateScholarship(gpa),
            };
            this.students.Add(student);
            return student;
        }

        /// <summary>
        /// Возвращает средний балл по всем студентам.
        /// </summary>
        /// <returns>Средний балл.</returns>
        public double GetAverageGpa()
        {
            double sum = 0;
            foreach (Student student in this.students)
            {
                sum += student.Gpa;
            }

            return sum / this.students.Count;
        }

        /// <summary>
        /// Возвращает общий фонд стипендий в рублях.
        /// </summary>
        /// <returns>Сумма стипендий всех студентов.</returns>
        public int GetTotalFund() => this.calculator.CalculateTotalFund(this.students);
    }
}
