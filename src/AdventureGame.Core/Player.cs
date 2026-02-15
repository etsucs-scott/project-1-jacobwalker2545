using System.Collections.Generic;

namespace AdventureGame.Core;

public class Player : ICharacter
{
    public string Name { get; private set; }
    public int Health { get; private set; }
//this all relates to ICharacter
    public List<Item> Inventory { get; } = new();
//shows if you pick up an item, it goes to inventory
    public Player(string name)
    {
        Name = name;
        Health = 100;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;

        if (Health < 0)
            Health = 0;
    }
//affects on health 
    public void Heal(int amount)
    {
        Health += amount;
    }

    public bool IsAlive()
    {
        return Health > 0;
    }
//this shows how much damage the player does
    public int AttackPower
    {
        get
        {
            int highestModifier = 0;

            foreach (var item in Inventory)
            {
                if (item is Weapon weapon)
                {
                    if (weapon.AttackModifier > highestModifier)
                        highestModifier = weapon.AttackModifier;
                }
            }

            return 10 + highestModifier;
        }
    }
}
// these modifeiers change the damage of each weapon, also how it changes health values
