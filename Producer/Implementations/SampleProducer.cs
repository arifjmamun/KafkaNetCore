using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Producer.Abstractions;

namespace Producer.Implementations
{
    public class SampleProducer : IProducer
    {
        public async Task<string> PublishAsync(string topic, string message)
        {
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };
            using (var p = new ProducerBuilder<string, string>(producerConfig).Build())
            {
                var msg = new Message<string, string> { Key = null, Value = message };
                DeliveryResult<string, string> a = await p.ProduceAsync(topic, msg);
                return a.Key;
            }
            throw new NotImplementedException();
        }
    }
}
