using Interfaces;
using VendingMachine.Core;

namespace VendingMachineStates;

public class IdleState : IVendingMachineState
{
    private VendingMachine.Core.VendingMachine VendingMachine { get; set; }

    public IdleState(VendingMachine.Core.VendingMachine vendingMachine) => this.VendingMachine = vendingMachine;

    public bool SelectItem(int slot)
    {
        if(slot >= 0 && slot < this.VendingMachine.GetTotalSlots())
        {
            this.VendingMachine.CurrentSlot = slot;
            this.VendingMachine.SetState(this.VendingMachine.GetReceivePaymentState());
            return true;
        }

        Console.WriteLine("Invalid slot selected.");

        return false;
    }

    public bool AddMoney(int amount)
    {
        Console.WriteLine("Please select a valid item.");
        return false;
    }

    public bool DispenseItem()
    {
        Console.WriteLine("Please select a valid item and make the payment.");
        return false;
    }

    public bool DispenseChange()
    {
        Console.WriteLine("Please select a valid item and make the payment.");
        return false;
    }

    public bool CancelTransaction()
    {
        Console.WriteLine("No transaction has been initiated.");
        return false;
    }
}