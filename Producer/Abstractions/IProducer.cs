using System;
using System.Threading.Tasks;

namespace Producer.Abstractions
{
    public interface IProducer
    {
        /// <summary>
        /// Produce message on given topic
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task<string> PublishAsync(string topic, string message);
    }
}