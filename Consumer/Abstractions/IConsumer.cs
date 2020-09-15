using System;
using System.Threading.Tasks;

namespace Consumer.Abstractions
{
    public interface IConsumer
    {
        Task SubscribeAsync(string topic, Action<string> message);
    }
}
