using Interfaces;
using Core;

namespace VendingMachineStates;

public class DispenseChangeState : IVendingMachineState
{
    private VendingMachine.Core.VendingMachine VendingMachine { get; set; }

    public DispenseChangeState(VendingMachine.Core.VendingMachine vendingMachine) => this.VendingMachine = vendingMachine;

    public bool SelectItem(int slot)
    {
        Console.WriteLine($"Please allow current transaction to complete.");
        return false;
    }

    public bool AddMoney(int amount)
    {
        Console.WriteLine($"Please allow current transaction to complete.");
        return false;
    }

    public bool DispenseItem()
    {
        Console.WriteLine($"Please allow current transaction to complete.");
        return false;
    }

    public bool DispenseChange()
    {
        Console.WriteLine($"Dispensing change ..");
        Thread.Sleep(100);
        Console.WriteLine($"Change of {VendingMachine.AmountDeposited} has been dispensed.");
        
        VendingMachine.AmountDeposited = 0;
        VendingMachine.CurrentSlot = -1;
        VendingMachine.SetState(VendingMachine.GetIdleState());

        return true;
    }

    public bool CancelTransaction()
    {
        Console.WriteLine("Change return is cancelled. Resetting to idle state.");

        VendingMachine.AmountDeposited = 0;
        VendingMachine.CurrentSlot = -1;
        VendingMachine.SetState(VendingMachine.GetIdleState());

        return true;
    }
}