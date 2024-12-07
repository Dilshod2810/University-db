using System;
using University;
using University.HomeService;


var studentService = new StudentService();

while (true)
{
    Console.WriteLine("\nДобро пожаловать в систему управления университетом!");
    Console.WriteLine("Выберите действие:");
    Console.WriteLine("1. Показать всех студентов");
    Console.WriteLine("2. Найти студента по ID");
    Console.WriteLine("3. Добавить студента");
    Console.WriteLine("4. Выйти");

    string? input = Console.ReadLine();

    if (input == "1")
    {
        var students = studentService.GetAllStudent();
        foreach (var student in students)
        {
            Console.WriteLine(
                $"{student.Id}: {student.FullName} ({student.Age} лет), {student.Email}, {student.Phone}, {student.Description}");
        }
    }
    else if (input == "2")
    {
        Console.WriteLine("Введите ID студента:");
        string? idInput = Console.ReadLine();
        if (int.TryParse(idInput, out int studentId))
        {
            var student = studentService.GetStudentById(studentId);
            if (student != null)
                Console.WriteLine($"{student.Id}: {student.FullName}, {student.Age}, {student.Email}, {student.Phone}");
            else
                Console.WriteLine("Студент не найден.");
        }
        else
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
        }
    }
    else if (input == "3")
    {
        Console.WriteLine("Введите данные студента:");
        Console.Write("Имя: ");
        var name = Console.ReadLine();
        Console.Write("Возраст: ");
        string? ageInput = Console.ReadLine();
        Console.Write("Email: ");
        var email = Console.ReadLine();
        Console.Write("Телефон: ");
        var phone = Console.ReadLine();
        Console.Write("Описание: ");
        var description = Console.ReadLine();

        if (int.TryParse(ageInput, out int age))
        {
            var newStudent = new Student
            {
                FullName = name,
                Age = age,
                Email = email,
                Phone = phone,
                Description = description
            };

            if (studentService.AddStudent(newStudent))
                Console.WriteLine("Студент добавлен.");
            else
                Console.WriteLine("Ошибка при добавлении студента.");
        }
        else
        {
            Console.WriteLine("Возраст должен быть числом.");
        }
    }
    else if (input == "4")
    {
        Console.WriteLine("Выход из программы.");
        break;
    }
    else
    {
        Console.WriteLine("Неверный выбор, попробуйте снова.");
    }
}