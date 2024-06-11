class Program
{
    static void Main(string[] args)
    {
        AnimalView view = new AnimalView();
        AnimalController controller = new AnimalController(view);
        controller.Run();
    }
}