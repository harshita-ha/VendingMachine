using Core;

namespace VendingMachine
{
    public class VendingMachineDemo
    {
        public VendingMachineDemo()
        {

        }

        public void Run()
        {
            VendingMachine.Core.VendingMachine vendingMachine = VendingMachine.Core.VendingMachine.GetInstance();

            // Encapsulation
            vendingMachine.AddItem(1, new Item("Soda", 150, 10));
            vendingMachine.AddItem(2, new Item("Chips", 100, 5));
            vendingMachine.AddItem(3, new Item("Candy", 50, 20));
            vendingMachine.AddItem(4, new Item("Juice", 200, 8));
            vendingMachine.AddItem(5, new Item("Water", 80, 15));
            vendingMachine.AddItem(6, new Item("Coffee", 120, 12));

            vendingMachine.DisplayInventory();

            // Item selection
            vendingMachine.SelectItem(1);

            // Making payment - state based design pattern.
            vendingMachine.AddMoney(50);
            vendingMachine.AddMoney(200);

            // Dispensing item
            vendingMachine.DispenseItem();

            // Dispensing change
            vendingMachine.DispenseChange();

            vendingMachine.DisplayInventory();
        }
    }
}
