namespace DeliveryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Delivery = new Delivery
            {
                Id = 1,
                CustomerName = "Ahmed Abdulrahman",
                Address = "Dar El-Salam",
                DeliveryStatus = DeliveryStatus.SHIPPED ,
            };
            var Order = new DeliveryController();
            Order.Start(Delivery);
        }
    }
}