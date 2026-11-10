namespace ModuleWork1
{
    public class CardPayment : IPaymentMethod
    {
        public string Name => "картка";

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата карткою: {amount:F2} грн.");
        }
    }
}