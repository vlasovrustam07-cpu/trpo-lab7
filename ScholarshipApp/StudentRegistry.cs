namespace ScholarshipApp
{
    /// <summary>
    /// Список студентов в памяти и статистика по нему.
    /// </summary>
    public class StudentRegistry
    {
        private readonly List<Student> _students = new List<Student>();
        private readonly ScholarshipCalculator _calculator = new ScholarshipCalculator();

        /// <summary>
        /// Все добавленные студенты.
        /// </summary>
        public IReadOnlyList<Student> Students => _students;

        /// <summary>
        /// Добавляет студента в список и назначает ему стипендию.
        /// </summary>
        public Student AddStudent(string fullName, string group, double gpa)
        {
            Student student = new Student
            {
                FullName = fullName,
                Group = group,
                Gpa = gpa,
                Scholarship = _calculator.CalculateScholarship(gpa)
            };
            _students.Add(student);
            return student;
        }

        /// <summary>
        /// Возвращает средний балл по всем студентам.
        /// </summary>
        public double GetAverageGpa()
        {
            double sum = 0;
            foreach (Student student in _students)
            {
                sum += student.Gpa;
            }

            return sum / _students.Count;
        }

        /// <summary>
        /// Возвращает общий фонд стипендий в рублях.
        /// </summary>
        public int GetTotalFund() => _calculator.CalculateTotalFund(_students);
    }
}
