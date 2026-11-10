namespace ModuleWork1
{
    public class Truck : Transport
    {
        public Truck(string name) : base(name)
        {
        }

        public override decimal CalculateCost(Order order)
        {
            return 200 + 15 * order.Distance + 0.5m * order.Weight;
        }
    }
}