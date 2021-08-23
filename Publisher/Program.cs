using System;
using System.Threading.Tasks;
using Abstractions;
using CloudEventsMessageFormatting;
using SNSMessaging;

namespace Publisher
{
    class Program
    {
        static async Task Main(String[] args)
        {
            IMessageFormatter<String, String> formatter = new CloudEventsMessageFormatter<String>();
            
            IPublisher<String, Task> publisher = new SNSMessagePublisher(formatter);

            String message = "This is a test from the .NET Publisher at " + DateTime.Now;

            await publisher.Publish(message);

            Console.WriteLine("Message Sent: " + message);

            Console.ReadLine();
        }
    }
}