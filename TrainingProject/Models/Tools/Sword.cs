namespace TrainingProject.Models.Tools;

public class Sword
{
    public int Attack { get; set; }
    public int Endurance { get; set; }
    public bool IsBroken { get; set; }

    public Sword(int attack)
    {
        Attack = attack;
        Endurance = 120;
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

    public void Repair()
    {
        Endurance = 100;
        
        if (Endurance == 0)
            IsBroken = true;
        else
            IsBroken = false;
    }
}