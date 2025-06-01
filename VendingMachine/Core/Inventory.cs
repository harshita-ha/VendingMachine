using System.Collections.Concurrent;

namespace Core;

public class Inventory
{
    private ConcurrentDictionary<int, Item> Items;
    public const int Slots = 6;

    public Inventory()
    {
        this.Items = new ConcurrentDictionary<int, Item>();
    }

    public bool AddItem(int slot, Item item)
    {
        return Items.TryAdd(slot, item);
    }

    public bool RemoveItem(int slot, int count)
    {
        if (Items.TryGetValue(slot, out var item) && item.Quantity >= count)
        {
            item.Quantity -= count;
            return true;
        }
        else
        {
            Console.WriteLine("Invalid slot or quantity");
            return false;
        }
    }

    public void DisplayInventory()
    {
        Console.WriteLine("Current Inventory:");
        foreach (var kvp in Items)
        {
            Console.WriteLine($"Slot {kvp.Key}: {kvp.Value.Name} - Price: {kvp.Value.Price} - Quantity: {kvp.Value.Quantity}");
        }
    }

    public int GetTotalSlots()
    {
        return Slots;
    }

    public int GetItemPrice(int slot)
    {
        if(Items.TryGetValue(slot, out var item))
        {
            return item.Price;
        }
        else
        {
            Console.WriteLine("Invalid slot selected.");
            return -1;
        }
    }
}