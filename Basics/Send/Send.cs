using RabbitMQ.Client;
using System;
using System.Text;

namespace Send
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "Hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    string message = "Hello Kumar";
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", "Hello", null, body);
                    Console.WriteLine("[x] sent {0}", message);
                }
            }
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}