using activemq_publisher.Models;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;
using System.Text.Json;

namespace activemq_subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            while (SubscribeJsonMessage())
            {
                Console.WriteLine("Successfully read message");
            }

            Console.WriteLine("Finished");
        }

        static bool SubscribeMessage()
        {
            string queueName = "TextQueue";

            string brokerUri = $"activemq:tcp://localhost:61616";
            IConnectionFactory factory = new ConnectionFactory(brokerUri);

            using (IConnection connection = factory.CreateConnection())
            {
                connection.Start();
                using (ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge))
                using (IDestination dest = session.GetQueue(queueName))
                using (IMessageConsumer consumer = session.CreateConsumer(dest))
                {
                    IMessage msg = consumer.Receive();
                    if (msg is ITextMessage)
                    {
                        ITextMessage txtMsg = msg as ITextMessage;
                        string body = txtMsg.Text;

                        Console.WriteLine($"Received message: {txtMsg.Text}");

                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Unexpected message type: " + msg.GetType().Name);
                    }
                }
            }

            return false;
        }

        static bool SubscribeJsonMessage()
        {
            string queueName = "JsonQueue";

            string brokerUri = $"activemq:tcp://localhost:61616";
            IConnectionFactory factory = new ConnectionFactory(brokerUri);

            using (IConnection connection = factory.CreateConnection())
            {
                connection.Start();
                using (ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge))
                using (IDestination dest = session.GetQueue(queueName))
                using (IMessageConsumer consumer = session.CreateConsumer(dest))
                {
                    IMessage msg = consumer.Receive();
                    IObjectMessage jsonMsg = msg as IObjectMessage;
                    if (jsonMsg != null)
                    {
                        var user = jsonMsg.Body as User;
                        var body = jsonMsg.Body.ToString();
                        Console.WriteLine($"Received message: {body}");
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
