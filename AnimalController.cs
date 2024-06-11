public class AnimalController
{
    private AnimalView view;
    private List<Animal> animals;

    public AnimalController(AnimalView view)
    {
        this.view = view;
        this.animals = new List<Animal>();
    }

    public void Run()
    {
        while (true)
        {
            view.DisplayMenu();
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

    private void AddNewAnimal()
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

    private void ShowAllAnimals()
    {
        view.DisplayAnimals(animals);
    }

    private void ShowAnimalCommands()
    {
        Console.WriteLine("Введите имя животного:");
        string name = Console.ReadLine();

        var animal = animals.Find(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (animal != null)
        {
            view.DisplayAnimalCommands(animal);
        }
        else
        {
            Console.WriteLine("Животное не найдено.");
        }
    }

    private void TrainAnimalNewCommand()
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

    private void ShowAnimalsByBirthDate()
    {
        var sortedAnimals = animals.OrderBy(a => a.BirthDate).ToList();
        view.DisplayAnimals(sortedAnimals);
    }

    private void ShowAnimalCount()
    {
        view.DisplayAnimalCount(Animal.AnimalCount);
    }
}