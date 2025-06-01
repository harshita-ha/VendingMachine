namespace Interfaces;

public interface IPaymentStrategy
{
    bool MakePayment(int amount);
}