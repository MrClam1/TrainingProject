using TrainingProject.Models.Resource;
using TrainingProject.Models.Tools;

namespace TrainingProject.Models.Person;

public class Person
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public bool IsAlive { get; set; }
    public object? Tool { get; set; }
    public object?[] Clothes = new object?[2];
    public PersonType Type { get; set; }

    public Person(string name)
    {
        Name = name;
        Level = 0;
    }
    
    public Person(string name, int level)
    {
        Name = name;
        Level = level;
    }
    
    public Person(string name, int level, object tool)
    {
        Name = name;
        Level = level;
        Tool = tool;
    }

    public void SetType(PersonType type)
    {
        Type = type;
    }

    public void GetDamage(int damage)
    {
        Health -= damage;

        if (Health < 0)
        {
            IsAlive = false;
        }
    }

    public void SetTool(object tool)
    {
        if (tool.GetType() != typeof(Sword) && tool.GetType() != typeof(Bow) && tool.GetType() != typeof(Hammer) && tool.GetType() != typeof(Spine))
        {
            return;
        }
        
        Tool = tool;
    }

    public void AddClothe(object clothe)
    {
        if (clothe != typeof(Shirt) || clothe != typeof(Trousers))
            return;

        for (int i = 0; i < Clothes.Length; i++)
        {
            if (Clothes[i] is null)
            {
                Clothes[i] = clothe;
            }
        }
    }

    public object? UseTool(Person person, object obj)
    {
        if (Tool == null)
            return null;

        switch (Type)
        {
            case PersonType.Worker:
                break;
            case PersonType.Soldier:
                ((Sword)Tool).AttackAction(person);
                break;
            case PersonType.Archer:
                ((Bow)Tool).AttackAction(person);
                break;
            case PersonType.Weaver:
                return ((Hammer)Tool).Use(obj);
            case PersonType.Blacksmith:
                return ((Hammer)Tool).Use(obj);
        }

        return null;
    }
    
    
}