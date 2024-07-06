using TrainingProject.Models.Resource;

namespace TrainingProject.Models.Tools;

public class Hammer
{
    public int Attack { get; set; }
    public int Endurance { get; set; }
    public bool IsBroken { get; set; }

    public Hammer(int attack)
    {
        Attack = attack;
        Endurance = 200;
    }
    
    public Hammer(int attack, int endurance, bool isBroken)
    {
        Attack = attack;
        Endurance = endurance;
        IsBroken = isBroken;
    }

    public void AttackAction(Person.Person unit)
    {
        if (Endurance != 0)
        {
            unit.GetDamage(Attack);
        }
        
        Endurance--;

        if (Endurance == 0)
            IsBroken = true;
        else
            IsBroken = false;
    }

    public object? Use(object ore)
    {
        if (Endurance == 0)
            return null;
        
        if (ore.GetType() == typeof(IronOre))
        {
            Endurance--;

            if (Endurance == 0)
                IsBroken = true;
            else
                IsBroken = false;
            
            return new IronIngot();
        }

        return null;
    }

    public void Repair()
    {
        Endurance = 100;
        
        if (Endurance == 0)
            IsBroken = true;
        else
            IsBroken = false;
    }

    public Hammer Copy()
    {
        return new Hammer(Attack, Endurance, IsBroken);
    }
}