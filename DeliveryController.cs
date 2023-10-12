using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp
{
    public class DeliveryController
    {
        private readonly static Random random = new Random(); 
        public void Start(Delivery delivery)
        {
            try
            {
                Process(delivery);
                Ship(delivery);
                Transit(delivery);
                Deliver(delivery);
            }
            catch (ACCIDENTEXCEPTION ex)
            {
                delivery.DeliveryStatus = DeliveryStatus.UNKNWON;
                Console.WriteLine($"{ex.Message} it is in {ex.Location}");
            }
            catch (Exception ex)
            {
                delivery.DeliveryStatus = DeliveryStatus.UNKNWON;
                Console.WriteLine($"{ex.Message} try Ordering again later we are very sorry");
            }
            finally
            {
                Console.WriteLine($"Your Data: \n{{\n   ID: {delivery.Id},\n   NAME: {delivery.CustomerName},\n   ADDERSS: {delivery.Address},\n   DeliveryStatus: {delivery.DeliveryStatus}\n}}");
            }
        }
        
        private void Process(Delivery delivery)
        {
            if (random.Next(1, 5) == 2)
            {
                throw new InvalidOperationException("Ooops , there is no marterial for your Order");
            }
            FakeIt("Processing");
            Console.WriteLine("\n");
            delivery.DeliveryStatus = DeliveryStatus.PROCESSED;
        }
        private void Ship(Delivery delivery)
        {
            if (random.Next(1, 5) == 3)
            {
                throw new InvalidOperationException("Ooops , the Order was damaged out of my desire");
            }
            FakeIt("Shipping");
            Console.WriteLine("\n");

            delivery.DeliveryStatus = DeliveryStatus.SHIPPED;
        }
        private void Transit(Delivery delivery)
        {
            if (random.Next(1, 5) == 1)
            {
                throw new ACCIDENTEXCEPTION("Elzahraa", "ACCIDENT PRAY FOR ME PLEASE");
            }
            FakeIt("On My Waaaaaay !");
            Console.WriteLine("\n");

            delivery.DeliveryStatus = DeliveryStatus.TRANSED;
        }
        private void Deliver(Delivery delivery)
        {
            if (random.Next(1, 5) == 4)
            {
                throw new INVALIDADDRESS($"{delivery.Address} is invalid address enterd");
            }
            FakeIt("belhana w elshefa");
            Console.WriteLine("\n");

            delivery.DeliveryStatus = DeliveryStatus.DELIVERED;
        }
        private void FakeIt(string title)
        {
            Console.Write(title);
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
        }
    }
}
