namespace ModuleWork1
{
    public interface IPaymentMethod
    {
        string Name { get; }

        void Pay(decimal amount);
    }
}