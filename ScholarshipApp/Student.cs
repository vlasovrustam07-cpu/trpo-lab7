// <copyright file="Student.cs" company="rystia">
// Учебный проект по ТРПО, лабораторная работа 7.
// </copyright>

namespace ScholarshipApp
{
    /// <summary>
    /// Студент: ФИО, группа, средний балл и назначенная стипендия.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Фамилия, имя и отчество студента.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Учебная группа, например «ИСТ-21».
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Средний балл от 0 до 5.
        /// </summary>
        public double Gpa { get; set; }

        /// <summary>
        /// Размер стипендии в рублях.
        /// </summary>
        public int Scholarship { get; set; }
    }
}
