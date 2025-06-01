namespace Interfaces;

public interface IVendingMachineState
{
    bool SelectItem(int slot);
    bool AddMoney(int amount);
    bool DispenseItem();
    bool DispenseChange();
    bool CancelTransaction();
}