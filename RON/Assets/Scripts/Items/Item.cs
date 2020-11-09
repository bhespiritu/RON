public class Item
{
	public readonly string itemName;
	public readonly int id;
	public string description;
	public int cost;

	public Item(string itemName = "", int id = 0, string description="An item.", int cost = 1)
	{
		this.itemName = itemName;
		this.id = id;
		this.description = description;
		this.cost = cost;
	}
}