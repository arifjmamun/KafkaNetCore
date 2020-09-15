using System;
using System.Threading.Tasks;
using Producer.Implementations;

namespace Producer
{
    class Program
    {
        private const string topic = "kafka-sample";
        public static async Task Main(string[] args)
        {
            Console.Title = "Kafka sample producer";
            Console.WriteLine("Kafka Sample Producer");
            Console.WriteLine("Enter your message. Enter q for quitting...");
            string message;
            while ((message = Console.ReadLine()) != "q")
            {
                var producer = new SampleProducer();
                await producer.PublishAsync(topic, message);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
