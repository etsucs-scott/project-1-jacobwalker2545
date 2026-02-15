namespace AdventureGame.Core;

//this is making ICharacter, where it inflicts damage on players and monsters
public interface ICharacter // Making the class, string 
{
	string Name { get; }
	int Health { get; } //number for health
	int AttackPower { get; }

	void TakeDamage (int amount); //amount of damage that will be taken
	bool IsAlive(); //did you die or survive
}
