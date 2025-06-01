namespace Core;

public class Item
{
    public string Name;
    public int Price;
    public int Quantity;

    public Item(string name, int price, int quantity)
    {
        this.Name = name;
        this.Price = price;
        this.Quantity = quantity;
    }
}