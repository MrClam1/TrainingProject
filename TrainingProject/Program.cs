using TrainingProject.Models.Person;
using TrainingProject.Models.Resource;
using TrainingProject.Models.Tools;

namespace TrainingProject;

public class Program
{
    static void Main()
    {
        var person = new Person("Jom");
        person.SetType(PersonType.Blacksmith);

        var hammer = new Hammer(0);
        person.SetTool(hammer);

        var ironOre = new IronOre();
        var obj = person.UseTool(null!, ironOre);

        if (obj is not null)
        {
            Console.WriteLine($"Result: {obj.GetType()}");
        }
        else
        {
            Console.WriteLine($"Cannot create material");
        }
    }
}