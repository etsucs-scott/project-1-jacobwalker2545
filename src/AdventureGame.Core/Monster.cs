using System;
namespace AdventureGame.Core;

public class Monster : ICharacter
		     {
			     public string Name {get; private set;}
			     public int Health {get; private set;}

			     private static Random _rand = new Random();


			     public Monster(string name) //gives the monster health and name

{ 

        Name = name; 

        Health = _rand.Next(30, 51); 
//max health between 30 and 51

} 

        public void TakeDamage(int amount)  
//amount of damage taken from monster
{ 

        Health-= amount; 

        if (Health < 0) 

                Health = 0; 

} 
//if you kill monster
        public bool IsAlive() 

{ 

        return Health > 0;

}
public int AttackPower => 10;
}
//how much damage the monster deals to player
