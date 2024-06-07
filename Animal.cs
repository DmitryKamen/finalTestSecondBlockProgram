public abstract class Animal
{
    public static int AnimalCount { get; private set; } = 0;
    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public List<string> Commands { get; private set; }

    protected Animal(string name, DateTime birthDate)
    {
        Name = name;
        BirthDate = birthDate;
        Commands = new List<string>();
        AnimalCount++;
    }

    public void TrainCommand(string command)
    {
        Commands.Add(command);
    }
}

