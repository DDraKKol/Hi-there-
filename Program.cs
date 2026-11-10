using System.Text;

namespace ModuleWork1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            DeliveryService service = new DeliveryService();

            Console.WriteLine("=== 1. Створення транспорту ===");
            Bike bike = new Bike("Велосипед");
            Car car = new Car("Автомобіль");
            Truck truck = new Truck("Вантажівка");
            service.AddTransport(bike);
            service.AddTransport(car);
            service.AddTransport(truck);

            Console.WriteLine();
            Console.WriteLine("=== 2. Створення замовлень ===");
            Order order1 = new Order(1, "Документи", 1, 3);
            Order order2 = new Order(2, "Коробка з книгами", 15, 8);
            Order order3 = new Order(3, "Шафа", 120, 25);
            Order order4 = new Order(4, "Піца", 2, 5);
            Console.WriteLine("Створено 4 замовлення: №1 (1 кг, 3 км), №2 (15 кг, 8 км), №3 (120 кг, 25 км), №4 (2 кг, 5 км).");

            Console.WriteLine();
            Console.WriteLine("=== 3. Перевірка можливості перевезення (CanTake) ===");
            Console.WriteLine($"Велосипед може взяти замовлення №1 (3 км)? {bike.CanTake(order1)}");
            Console.WriteLine($"Велосипед може взяти замовлення №3 (25 км)? {bike.CanTake(order3)}");
            Console.WriteLine($"Автомобіль може взяти замовлення №3 (25 км)? {car.CanTake(order3)}");

            Console.WriteLine();
            Console.WriteLine("=== 4. Розрахунок вартості різними видами транспорту ===");
            service.ShowCosts(order1);
            service.ShowCosts(order2);
            service.ShowCosts(order3);

            Console.WriteLine();
            Console.WriteLine("=== 5. Транспорт не може взяти замовлення (велосипед, 25 км) ===");
            service.AssignOrder(order3, bike);

            Console.WriteLine();
            Console.WriteLine("=== 6. Успішне призначення замовлень ===");
            service.AssignOrder(order1, bike);
            service.AssignOrder(order2, car);
            service.AssignOrder(order3, truck);

            Console.WriteLine();
            Console.WriteLine("=== 7. Транспорт зайнятий ===");
            service.AssignOrder(order4, bike);
            service.ShowCosts(order4);

            Console.WriteLine();
            Console.WriteLine("=== 8. Активні замовлення ===");
            service.ShowActiveOrders();

            Console.WriteLine();
            Console.WriteLine("=== 9. Доставка з оплатою карткою ===");
            service.DeliverOrder(order1, new CardPayment());

            Console.WriteLine();
            Console.WriteLine("=== 10. Доставка з оплатою готівкою ===");
            service.DeliverOrder(order3, new CashPayment());

            Console.WriteLine();
            Console.WriteLine("=== 11. Спроба доставити замовлення повторно ===");
            service.DeliverOrder(order1, new CashPayment());

            Console.WriteLine();
            Console.WriteLine("=== 12. Велосипед звільнився: призначаємо замовлення №4 ===");
            service.AssignOrder(order4, bike);

            Console.WriteLine();
            Console.WriteLine("=== 13. Активні замовлення ===");
            service.ShowActiveOrders();

            Console.WriteLine();
            Console.WriteLine("=== 14. Історія доставок ===");
            service.ShowHistory();
        }
    }
}