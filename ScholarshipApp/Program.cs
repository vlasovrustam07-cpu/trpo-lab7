namespace ScholarshipApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            ScholarshipCalculator c = new ScholarshipCalculator();
            while (true)
            {
                Console.WriteLine("1 - добавить студента, 2 - список, 3 - статистика, 0 - выход");
                string x1 = Console.ReadLine();
                if (x1 == "0") break;
                if (x1 == "1")
                {
                    Console.Write("ФИО: ");
                    string a = Console.ReadLine().Trim();
                    if (!Validator.check(a)) { Console.WriteLine("Ошибка: ФИО не может быть пустым"); continue; }
                    Console.Write("Группа: ");
                    string b = Console.ReadLine().Trim();
                    Console.Write("Средний балл: ");
                    double n2 = double.Parse(Console.ReadLine());
                    Student s = new Student();
                    s.n = a; s.g = b; s.s = n2;
                    s.st = c.calc(n2);
                    list.Add(s);
                    Console.WriteLine("Студент добавлен. Стипендия: " + s.st);
                }
                if (x1 == "2")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine(list[i].n + " | " + list[i].g + " | " + list[i].s + " | " + list[i].st);
                    }
                }
                if (x1 == "3")
                {
                    double sum = 0;
                    for (int i = 0; i < list.Count; i++) sum = sum + list[i].s;
                    double avg = sum / list.Count;
                    Console.WriteLine("Средний балл: " + avg);
                    Console.WriteLine("Фонд стипендий: " + c.total(list));
                }
            }
        }
    }
}
