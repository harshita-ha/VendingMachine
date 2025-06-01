using Interfaces;

namespace PaymentStrategies;

public class CurrencyPaymentStrategy : IPaymentStrategy
{
    public bool MakePayment(int amount)
    {
        if(amount >= 0) 
        {
            Console.WriteLine($"Payment of amount: Rs. {amount} successful.");
            return true;
        }

        Console.WriteLine($"Payment unsiccessful.");
        return false;
    }
}