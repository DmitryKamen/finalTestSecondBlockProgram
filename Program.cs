using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Animal> animals = new List<Animal>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Завести новое животное");
            Console.WriteLine("2. Показать все животные");
            Console.WriteLine("3. Показать команды животного");
            Console.WriteLine("4. Обучить животное новой команде");
            Console.WriteLine("5. Вывести список животных по дате рождения");
            Console.WriteLine("6. Показать общее количество созданных животных");
            Console.WriteLine("7. Выйти");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewAnimal();
                    break;
                case "2":
                    ShowAllAnimals();
                    break;
                case "3":
                    ShowAnimalCommands();
                    break;
                case "4":
                    TrainAnimalNewCommand();
                    break;
                case "5":
                    ShowAnimalsByBirthDate();
                    break;
                case "6":
                    ShowAnimalCount();
                    break;    
                case "7":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void AddNewAnimal()
    {
        try
        {
            Console.WriteLine("Введите имя животного:");
            string name = Console.ReadLine();

            Console.WriteLine("Введите дату рождения животного (гггг-мм-дд):");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите тип животного (Dog, Cat, Hamster, Horse, Camel, Donkey):");
            string type = Console.ReadLine();

            Animal animal;
            switch (type.ToLower())
            {
                case "dog":
                    animal = new Dog(name, birthDate);
                    break;
                case "cat":
                    animal = new Cat(name, birthDate);
                    break;
                case "hamster":
                    animal = new Hamster(name, birthDate);
                    break;
                case "horse":
                    animal = new Horse(name, birthDate);
                    break;
                case "camel":
                    animal = new Camel(name, birthDate);
                    break;
                case "donkey":
                    animal = new Donkey(name, birthDate);
                    break;
                default:
                    Console.WriteLine("Неверный тип животного.");
                    return;
            }

            animals.Add(animal);
            Console.WriteLine("Животное добавлено.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка ввода данных. Попробуйте снова.");
        }
    }

    static void ShowAllAnimals()
    {
        foreach (var animal in animals)
        {
            Console.WriteLine($"{animal.Name} ({animal.GetType().Name}) - Дата рождения: {animal.BirthDate.ToShortDateString()}");
        }
    }

    static void ShowAnimalCommands()
    {
        Console.WriteLine("Введите имя животного:");
        string name = Console.ReadLine();

        var animal = animals.Find(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (animal != null)
        {
            Console.WriteLine($"Команды для {animal.Name}: {string.Join(", ", animal.Commands)}");
        }
        else
        {
            Console.WriteLine("Животное не найдено.");
        }
    }

    static void TrainAnimalNewCommand()
    {
        Console.WriteLine("Введите имя животного:");
        string name = Console.ReadLine();

        var animal = animals.Find(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (animal != null)
        {
            Console.WriteLine("Введите новую команду:");
            string newCommand = Console.ReadLine();
            animal.TrainCommand(newCommand);
            Console.WriteLine($"Животное {animal.Name} обучено новой команде: {newCommand}");
        }
        else
        {
            Console.WriteLine("Животное не найдено.");
        }
    }

    static void ShowAnimalsByBirthDate()
    {
        var sortedAnimals = animals.OrderBy(a => a.BirthDate).ToList();

        foreach (var animal in sortedAnimals)
        {
            Console.WriteLine($"{animal.Name} ({animal.GetType().Name}) - Дата рождения: {animal.BirthDate.ToShortDateString()}");
        }
    }

    static void ShowAnimalCount()
    {
        Console.WriteLine($"Общее количество созданных животных: {Animal.AnimalCount}");
    }
}