using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Consumer.Abstractions;

namespace Consumer.Implementations
{
    public class SampleConsumer : IConsumer
    {
        public Task SubscribeAsync(string topic, Action<string> message)
        {
            var consumerConfig = new ConsumerConfig
            {
                GroupId = "test-consumer-group",
                BootstrapServers = "localhost:9092"
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build())
            {
                consumer.Subscribe(topic);
                var cancellationToken = new CancellationTokenSource();

                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true;
                    cancellationToken.Cancel();
                };

                try
                {
                    while (true)
                    {
                        try
                        {
                            var cr = consumer.Consume(cancellationToken.Token);
                            message(cr.Message.Value);
                        }
                        catch (ConsumeException ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
                catch (Exception)
                {
                    consumer.Close();
                }
            }

            return Task.CompletedTask;
        }
    }
}
