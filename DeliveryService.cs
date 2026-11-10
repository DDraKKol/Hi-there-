namespace ModuleWork1
{
    public class DeliveryService
    {
        private List<Transport> _transports = new List<Transport>();
        private List<Order> _activeOrders = new List<Order>();
        private List<Order> _history = new List<Order>();

        public void AddTransport(Transport transport)
        {
            _transports.Add(transport);
            Console.WriteLine($"Додано транспорт: {transport.Name}.");
        }

        // Показує вартість доставки кожним транспортом, який може взяти замовлення
        public void ShowCosts(Order order)
        {
            Console.WriteLine($"Вартість доставки замовлення №{order.Number} ({order.Weight} кг, {order.Distance} км):");

            bool anyCanTake = false;

            foreach (Transport transport in _transports)
            {
                if (transport.CanTake(order))
                {
                    anyCanTake = true;
                    string status = transport.IsBusy ? "зайнятий" : "вільний";
                    Console.WriteLine($"  {transport.Name} ({status}): {transport.CalculateCost(order):F2} грн");
                }
                else
                {
                    Console.WriteLine($"  {transport.Name}: не може взяти це замовлення");
                }
            }

            if (!anyCanTake)
            {
                Console.WriteLine("  Жоден транспорт не може взяти це замовлення.");
            }
        }

        // Призначає замовлення на транспорт. Повертає true, якщо вдалося.
        public bool AssignOrder(Order order, Transport transport)
        {
            if (!_transports.Contains(transport))
            {
                Console.WriteLine($"Помилка: транспорт {transport.Name} не належить службі доставки.");
                return false;
            }

            if (_activeOrders.Contains(order) || _history.Contains(order))
            {
                Console.WriteLine($"Помилка: замовлення №{order.Number} вже було призначене.");
                return false;
            }

            if (!transport.CanTake(order))
            {
                Console.WriteLine($"Помилка: {transport.Name} не може взяти замовлення №{order.Number}.");
                return false;
            }

            if (transport.IsBusy)
            {
                Console.WriteLine($"Помилка: {transport.Name} зараз зайнятий.");
                return false;
            }

            decimal cost = transport.CalculateCost(order);
            transport.Occupy();
            order.Assign(transport, cost);
            _activeOrders.Add(order);

            Console.WriteLine($"Замовлення №{order.Number} призначено на {transport.Name}. Вартість: {cost:F2} грн.");
            return true;
        }

        // Доставляє замовлення з оплатою. Повертає true, якщо вдалося.
        public bool DeliverOrder(Order order, IPaymentMethod payment)
        {
            if (!_activeOrders.Contains(order))
            {
                Console.WriteLine($"Помилка: замовлення №{order.Number} не є активним (не призначене або вже доставлене).");
                return false;
            }

            payment.Pay(order.Cost);
            order.Complete(payment.Name);

            Transport? transport = order.AssignedTransport;
            if (transport != null)
            {
                transport.Release();
                Console.WriteLine($"Замовлення №{order.Number} доставлено. {transport.Name} тепер вільний.");
            }

            _activeOrders.Remove(order);
            _history.Add(order);
            return true;
        }

        public void ShowActiveOrders()
        {
            Console.WriteLine("Активні замовлення:");

            if (_activeOrders.Count == 0)
            {
                Console.WriteLine("  Немає активних замовлень.");
                return;
            }

            foreach (Order order in _activeOrders)
            {
                string transportName = order.AssignedTransport != null ? order.AssignedTransport.Name : "-";
                Console.WriteLine($"  №{order.Number} \"{order.Description}\", {order.Weight} кг, {order.Distance} км, " +
                                  $"транспорт: {transportName}, вартість: {order.Cost:F2} грн");
            }
        }

        public void ShowHistory()
        {
            Console.WriteLine("Історія доставок:");

            if (_history.Count == 0)
            {
                Console.WriteLine("  Історія порожня.");
                return;
            }

            foreach (Order order in _history)
            {
                string transportName = order.AssignedTransport != null ? order.AssignedTransport.Name : "-";
                Console.WriteLine($"  №{order.Number} \"{order.Description}\", {order.Weight} кг, {order.Distance} км, " +
                                  $"транспорт: {transportName}, сплачено: {order.Cost:F2} грн ({order.PaymentName})");
            }
        }
    }
}