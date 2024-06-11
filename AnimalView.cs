public class AnimalView
{
    public void DisplayMenu()
    {
        Console.WriteLine("Меню:");
        Console.WriteLine("1. Завести новое животное");
        Console.WriteLine("2. Показать все животные");
        Console.WriteLine("3. Показать команды животного");
        Console.WriteLine("4. Обучить животное новой команде");
        Console.WriteLine("5. Вывести список животных по дате рождения");
        Console.WriteLine("6. Показать общее количество созданных животных");
        Console.WriteLine("7. Выйти");
    }

    public void DisplayAnimal(Animal animal)
    {
        Console.WriteLine($"{animal.Name} ({animal.GetType().Name}) - Дата рождения: {animal.BirthDate.ToShortDateString()}");
    }

    public void DisplayAnimals(List<Animal> animals)
    {
        foreach (var animal in animals)
        {
            DisplayAnimal(animal);
        }
    }

    public void DisplayAnimalCommands(Animal animal)
    {
        Console.WriteLine($"Команды для {animal.Name}: {string.Join(", ", animal.Commands)}");
    }

    public void DisplayAnimalCount(int count)
    {
        Console.WriteLine($"Общее количество созданных животных: {count}");
    }
}