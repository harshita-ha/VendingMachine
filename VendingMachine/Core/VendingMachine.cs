using Core;
using Interfaces;
using PaymentStrategies;
using System.Reflection.Metadata.Ecma335;
using VendingMachineStates;
using static System.Reflection.Metadata.BlobBuilder;

namespace VendingMachine.Core
{
    public class VendingMachine
    {
        private Inventory Inventory { get; set; }
        private IVendingMachineState IdleState { get; set; }
        private IVendingMachineState ReceivePaymentState { get; set; }
        private IVendingMachineState DispenseProductState { get; set; }
        private IVendingMachineState DispenseChangeState { get; set; }
        public IVendingMachineState CurrentState { get; set; }

        public int CurrentSlot { get; set; }
        public int AmountDeposited { get; set; }

        private static VendingMachine _instance;

        private VendingMachine()
        {
            this.Inventory = new Inventory();
            this.IdleState = new IdleState(this);
            this.ReceivePaymentState = new ReceivePaymentState(this, new CurrencyPaymentStrategy());
            this.DispenseProductState = new DispenseProductState(this);
            this.DispenseChangeState = new DispenseChangeState(this);
            
            this.CurrentState = IdleState;
            this.CurrentSlot = -1;
            this.AmountDeposited = 0;
        }

        public static VendingMachine GetInstance()
        {
            if(_instance == null)
            {
                _instance = new VendingMachine();
            }

            return _instance;
        }

        public bool SelectItem(int slot)
        {
            return this.CurrentState.SelectItem(slot);
        }

        public bool AddMoney(int amount)
        {
            return this.CurrentState.AddMoney(amount);
        }

        public bool DispenseItem()
        {
            return this.CurrentState.DispenseItem();
        }

        public bool DispenseChange()
        {
            return this.CurrentState.DispenseChange();
        }

        public void SetState(IVendingMachineState state)
        {
            this.CurrentState = state;
            Console.WriteLine($"State changed to: {state.GetType().Name}");
        }

        public void DisplayInventory()
        {
            this.Inventory.DisplayInventory();
        }

        public int GetTotalSlots()
        {
            return this.Inventory.GetTotalSlots();
        }

        public bool AddItem(int slot, Item item)
        {
            return this.Inventory.AddItem(slot, item);
        }

        public bool RemoveItem(int slot, int count)
        {
            return this.Inventory.RemoveItem(slot, count);
        }

        public int GetItemPrice(int slot)
        {
            return this.Inventory.GetItemPrice(slot);
        }

        public void ChangePaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            this.ReceivePaymentState = new ReceivePaymentState(this, paymentStrategy);
        }

        public IVendingMachineState GetIdleState() => this.IdleState;
        public IVendingMachineState GetReceivePaymentState() => this.ReceivePaymentState;
        public IVendingMachineState GetDispenseProductState() => this.DispenseProductState;
        public IVendingMachineState GetDispenseChangeState() => this.DispenseChangeState;
    }
}
