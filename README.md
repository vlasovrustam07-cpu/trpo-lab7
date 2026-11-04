# ScholarshipApp — ЛР7: отладка, стиль кода, StyleCop

[![.NET CI](https://github.com/vlasovrustam07-cpu/trpo-lab7/actions/workflows/dotnet.yml/badge.svg)](https://github.com/vlasovrustam07-cpu/trpo-lab7/actions/workflows/dotnet.yml)

Консольное приложение на C# (.NET 8) для учёта студентов и расчёта стипендии:
ввод ФИО, группы и среднего балла, проверка данных, расчёт стипендии
(3000 руб. при среднем балле от 4.5), хранение списка в памяти и статистика.

В исходной версии были намеренно допущены ошибки. В ходе ЛР7 они найдены
с помощью отладчика, исправлены, код приведён к читаемому виду и проверен
анализатором StyleCop.

## Ветки

| Ветка | Что в ней |
|-------|-----------|
| `main` | Исправленная версия |
| [`v1-buggy`](https://github.com/vlasovrustam07-cpu/trpo-lab7/tree/v1-buggy) | Исходная версия с ошибками — для демонстрации отладки |

## Структура

```text
trpo-lab7/
├── .github/workflows/dotnet.yml        # CI: сборка (с StyleCop) и тесты
├── ScholarshipApp.sln
├── ScholarshipApp/
│   ├── Program.cs                      # меню и ввод данных
│   ├── Student.cs                      # модель студента
│   ├── StudentValidator.cs             # проверка ФИО, группы, балла
│   ├── ScholarshipCalculator.cs        # расчёт стипендии и фонда
│   ├── StudentRegistry.cs              # список студентов в памяти
│   └── stylecop.json                   # настройки StyleCop
├── ScholarshipApp.Tests/               # модульные тесты xUnit (35 проверок)
├── BUGS.md                             # таблица найденных ошибок
└── ОТЧЕТ.md                            # отчёт по ЛР7
```

## Запуск

**Visual Studio:** открыть `ScholarshipApp.sln`, запустить проект `ScholarshipApp`
(Ctrl+F5), тесты — **Тест → Запустить все тесты**.

**Командная строка:**

```bash
dotnet run --project ScholarshipApp
dotnet test
```

Пример работы:

```text
1 - добавить студента, 2 - список, 3 - статистика, 0 - выход
1
ФИО: Иванов Иван Иванович
Группа: ИСТ-21
Средний балл: 4,5
Студент добавлен. Стипендия: 3000 руб.
```
