// <copyright file="Program.cs" company="rystia">
// Учебный проект по ТРПО, лабораторная работа 7.
// </copyright>

namespace ScholarshipApp
{
    /// <summary>
    /// Консольное приложение для учёта студентов и расчёта стипендии.
    /// </summary>
    internal class Program
    {
        private static readonly StudentRegistry Registry = new StudentRegistry();

        /// <summary>
        /// Точка входа: главное меню программы.
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        private static void Main(string[] args)
        {
            while (true)
            {
                PrintMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        PrintStudents();
                        break;
                    case "3":
                        PrintStatistics();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неизвестная команда, выберите пункт меню.");
                        break;
                }
            }
        }

        // Выводит пункты главного меню.
        private static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1 - добавить студента, 2 - список, 3 - статистика, 0 - выход");
        }

        // Запрашивает данные студента, проверяет их и добавляет в список.
        private static void AddStudent()
        {
            Console.Write("ФИО: ");
            string fullName = Console.ReadLine().Trim();
            if (!StudentValidator.IsValidFullName(fullName))
            {
                Console.WriteLine("Ошибка: ФИО не может быть пустым и не должно содержать цифры.");
                return;
            }

            Console.Write("Группа: ");
            string group = Console.ReadLine().Trim();
            if (!StudentValidator.IsValidGroup(group))
            {
                Console.WriteLine("Ошибка: группа не может быть пустой.");
                return;
            }

            Console.Write("Средний балл: ");
            double gpa = double.Parse(Console.ReadLine());
            if (!StudentValidator.IsValidGpa(gpa))
            {
                Console.WriteLine("Ошибка: средний балл должен быть от 0 до 5.");
                return;
            }

            Student student = Registry.AddStudent(fullName, group, gpa);
            Console.WriteLine($"Студент добавлен. Стипендия: {student.Scholarship} руб.");
        }

        // Печатает таблицу всех студентов.
        private static void PrintStudents()
        {
            if (Registry.Students.Count == 0)
            {
                Console.WriteLine("Список студентов пуст.");
                return;
            }

            foreach (Student student in Registry.Students)
            {
                Console.WriteLine($"{student.FullName} | {student.Group} | {student.Gpa:0.00} | {student.Scholarship} руб.");
            }
        }

        // Печатает средний балл и общий фонд стипендий.
        private static void PrintStatistics()
        {
            Console.WriteLine($"Средний балл: {Registry.GetAverageGpa():0.00}");
            Console.WriteLine($"Фонд стипендий: {Registry.GetTotalFund()} руб.");
        }
    }
}
