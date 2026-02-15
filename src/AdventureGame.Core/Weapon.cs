namespace AdventureGame.Core;

public class Weapon : Item //this relationship between, item and weapon 
{
    public int AttackModifier { get; private set; }
//how much damage each weapon does
    public Weapon(string name, int attackModifier) : base(name)
    {
        AttackModifier = attackModifier;
        PickupMessage = $"You picked up {name} with +{attackModifier} Attack!";
    }

 //Picking up a weapon gives you the notification  
    public override void Use(Player player)
    {
       
    }
}

