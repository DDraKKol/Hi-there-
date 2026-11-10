namespace ModuleWork1
{
    public class Bike : Transport
    {
        private const decimal MaxDistance = 10;

        public Bike(string name) : base(name)
        {
        }

        public override decimal CalculateCost(Order order)
        {
            return 20 + 5 * order.Distance;
        }

        public override bool CanTake(Order order)
        {
            return order.Distance <= MaxDistance;
        }
    }
}