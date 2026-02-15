namespace AdventureGame.Core;

//Item, going to be a little different since it's not a character
public abstract class Item
{
	public string Name { get; protected set; }
//adding pickup message string
	public string PickupMessage{ get; protected set;}

	protected Item (string name)
	{
		Name=name;
		PickupMessage = $"You picked up {name}";
	}
	 //this will apply the item to the player or the effect
	 public abstract void Use(Player player);
}
