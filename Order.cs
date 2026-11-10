namespace ModuleWork1
{
    public class Order
    {
        private int _number;
        private string _description;
        private decimal _weight;
        private decimal _distance;

        private Transport? _assignedTransport;
        private decimal _cost;
        private string _paymentName = "";

        public int Number => _number;
        public string Description => _description;
        public decimal Weight => _weight;
        public decimal Distance => _distance;

        public Transport? AssignedTransport => _assignedTransport;
        public decimal Cost => _cost;
        public string PaymentName => _paymentName;

        public Order(int number, string description, decimal weight, decimal distance)
        {
            _number = number;
            _description = description;
            _weight = weight;
            _distance = distance;
        }

        public void Assign(Transport transport, decimal cost)
        {
            _assignedTransport = transport;
            _cost = cost;
        }

        public void Complete(string paymentName)
        {
            _paymentName = paymentName;
        }
    }
}