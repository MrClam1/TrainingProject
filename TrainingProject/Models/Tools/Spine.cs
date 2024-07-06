using TrainingProject.Models.Resource;

namespace TrainingProject.Models.Tools;

public class Spine
{
    public int Attack { get; set; }
    public int Endurance { get; set; }
    public bool IsBroken { get; set; }

    public Spine(int attack)
    {
        Attack = attack;
        Endurance = 200;
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

    public object? Use(object ore, ClothesType type)
    {
        if (Endurance == 0)
            return null;
        
        if (ore.GetType() == typeof(Wool))
        {
            Endurance--;

            if (Endurance == 0)
                IsBroken = true;
            else
                IsBroken = false;
            
            if(type == ClothesType.Shirt)
                return new Shirt();
            
            if(type == ClothesType.Trousers)
                return new Trousers();
            
            return null;
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
}