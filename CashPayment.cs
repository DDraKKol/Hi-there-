namespace ModuleWork1
{
    public class CashPayment : IPaymentMethod
    {
        public string Name => "готівка";

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата готівкою: {amount:F2} грн.");
        }
    }
}