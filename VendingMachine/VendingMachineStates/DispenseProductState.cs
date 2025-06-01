using Interfaces;
using Core;

namespace VendingMachineStates;

public class DispenseProductState : IVendingMachineState
{
    private VendingMachine.Core.VendingMachine VendingMachine { get; set; }

    public DispenseProductState(VendingMachine.Core.VendingMachine vendingMachine) => this.VendingMachine = vendingMachine;

    public bool SelectItem(int slot)
    {
        Console.WriteLine($"Mid-transaction. Dispensing product at slot no. {VendingMachine.CurrentSlot}.");
        return false;
    }

    public bool AddMoney(int amount)
    {
        Console.WriteLine($"Mid-transaction. Payment for product at slot no. {VendingMachine.CurrentSlot} is already completed.");
        return false;
    }

    public bool DispenseItem()
    {
        if(VendingMachine.RemoveItem(VendingMachine.CurrentSlot, 1))
        {
            Console.WriteLine($"Item at slot no {VendingMachine.CurrentSlot} successfully dispensed.");
            VendingMachine.AmountDeposited -= VendingMachine.GetItemPrice(VendingMachine.CurrentSlot);
            VendingMachine.SetState(VendingMachine.GetDispenseChangeState());
            return true;
        }
        else
        {
            Console.WriteLine($"Unable to dispense item. Returning deposited amount.");
            return false;
        }
    }

    public bool DispenseChange()
    {
        Console.WriteLine($"Mid-transaction, will dispense change once item dispense is successful.");
        return false;
    }

    public bool CancelTransaction()
    {
        VendingMachine.SetState(VendingMachine.GetDispenseChangeState());
        Console.WriteLine("Item dispense cancelled. Returning the deposited amount.");
        return true;
    }
}