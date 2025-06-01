using Interfaces;

namespace VendingMachineStates;

public class ReceivePaymentState : IVendingMachineState
{
    private VendingMachine.Core.VendingMachine VendingMachine { get; set; }
    private IPaymentStrategy PaymentStrategy { get; set; }

    public ReceivePaymentState(VendingMachine.Core.VendingMachine vendingMachine, IPaymentStrategy paymentStrategy)
    {
        this.VendingMachine = vendingMachine;
        this.PaymentStrategy = paymentStrategy;
    }

    public bool SelectItem(int slot)
    {
        Console.WriteLine($"Item in slot {VendingMachine.SelectItem} is already selected. Please proceed with payment.");
        return false;
    }

    public bool AddMoney(int amount)
    {
        VendingMachine.AmountDeposited += amount;
        int itemPrice = VendingMachine.GetItemPrice(VendingMachine.CurrentSlot);

        if (VendingMachine.AmountDeposited >= itemPrice)
        {
            Console.WriteLine($"Payment of {amount} accepted. Total deposited: {VendingMachine.AmountDeposited}");
            VendingMachine.SetState(VendingMachine.GetDispenseProductState());
            return true;
        }
        else
        {
            Console.WriteLine($"Insufficient amount. Please deposit more money. Total deposited: {VendingMachine.AmountDeposited}, expected total : {itemPrice}");
            return false;
        }
    }

    public bool DispenseItem()
    {
        Console.WriteLine("Please complete the payment before dispensing the item.");
        return false;
    }

    public bool DispenseChange()
    {
        Console.WriteLine("Please complete the payment before dispensing the item.");
        return false;
    }

    public bool CancelTransaction()
    {
        VendingMachine.AmountDeposited = 0;
        VendingMachine.CurrentSlot = -1;
        VendingMachine.SetState(VendingMachine.GetIdleState());
        Console.WriteLine("Transaction cancelled. Returning to idle state.");
        return true;
    }
}