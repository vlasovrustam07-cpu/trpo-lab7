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
        /// Получает или задает фамилию, имя и отчество студента.
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Получает или задает учебную группу, например «ИСТ-21».
        /// </summary>
        public string Group { get; set; } = string.Empty;

        /// <summary>
        /// Получает или задает средний балл от 0 до 5.
        /// </summary>
        public double Gpa { get; set; }

        /// <summary>
        /// Получает или задает размер стипендии в рублях.
        /// </summary>
        public int Scholarship { get; set; }
    }
}
