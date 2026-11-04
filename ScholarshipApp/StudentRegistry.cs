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
        /// <exception cref="ArgumentException">ФИО или группа указаны неверно.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Балл вне диапазона от 0 до 5.</exception>
        public Student AddStudent(string fullName, string group, double gpa)
        {
            // Повторная проверка данных: класс можно вызвать не только из консольного меню.
            if (!StudentValidator.IsValidFullName(fullName))
            {
                throw new ArgumentException("ФИО не может быть пустым и не должно содержать цифры.", nameof(fullName));
            }

            if (!StudentValidator.IsValidGroup(group))
            {
                throw new ArgumentException("Группа не может быть пустой.", nameof(group));
            }

            if (!StudentValidator.IsValidGpa(gpa))
            {
                throw new ArgumentOutOfRangeException(nameof(gpa), gpa, "Средний балл должен быть от 0 до 5.");
            }

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
        /// <returns>Средний балл или 0, если список пуст.</returns>
        public double GetAverageGpa()
        {
            // Защита от деления на ноль: у пустого списка средний балл равен 0.
            if (this.students.Count == 0)
            {
                return 0;
            }

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
