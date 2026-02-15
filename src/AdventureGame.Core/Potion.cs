namespace AdventureGame.Core;

public class Potion : Item
{ private int HealAmount = 20;
//Amount of health healed from the potion picked up
    public Potion(string name) : base(name)
    {
        PickupMessage = $"You found a {name}! You heal {HealAmount} HP!";
    }
//announces that you have picked up the potion 
    public override void Use(Player player)
    {
        player.Heal(HealAmount);
	Console.WriteLine (PickupMessage);
    }
}
// This overrides the characters health to increase it
