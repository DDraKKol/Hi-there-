namespace ModuleWork1
{
    public class Car : Transport
    {
        public Car(string name) : base(name)
        {
        }

        public override decimal CalculateCost(Order order)
        {
            return 50 + 8 * order.Distance + 1 * order.Weight;
        }
    }
}