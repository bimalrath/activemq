using Apache.NMS;
using System;
using Apache.NMS.ActiveMQ;
using System.Reflection.Metadata;
using activemq_publisher.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace activemq_publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "Test Message";
            var user = new User {
                UserId = 1,
                UserType = "Type1",
                IsActive = true,
                IsBlocked = false,
                RowVersionDate = DateTime.Now,
                RowVersionUser = "User 1",
                RowVersion = 1,
                Conversations = new List<Conversation>(),
                Messages=new List<Message>(),
                Participants=new List<Participant>()
            };

            //PublishMessage(text);

            PublishJson(user);
        }

        private static void PublishMessage(string text)
        {
            string queueName = "TextQueue";

            Console.WriteLine($"Adding message to queue : {queueName}");

            string brokerUri = $"activemq:tcp://localhost:61616"; 
            IConnectionFactory factory = new ConnectionFactory(brokerUri);

            using (IConnection connection = factory.CreateConnection())
            {
                connection.Start();

                using (ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge))
                using (IDestination dest = session.GetQueue(queueName))
                using (IMessageProducer producer = session.CreateProducer(dest))
                {
                    producer.DeliveryMode = MsgDeliveryMode.NonPersistent;

                    producer.Send(session.CreateTextMessage(text));
                    Console.WriteLine($"Sent {text} messages");
                }
            }
        }

        private static void PublishJson<T>(T message)
        {
            var serialized = JsonSerializer.Serialize(message);

            string queueName = "JsonQueue";

            Console.WriteLine($"Adding message to queue : {queueName}");

            string brokerUri = $"activemq:tcp://localhost:61616";
            IConnectionFactory factory = new ConnectionFactory(brokerUri);

            using (IConnection connection = factory.CreateConnection())
            {
                connection.Start();

                using (ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge))
                using (IDestination dest = session.GetQueue(queueName))
                using (IMessageProducer producer = session.CreateProducer(dest))
                {
                    producer.DeliveryMode = MsgDeliveryMode.NonPersistent;

                    producer.Send(session.CreateObjectMessage(serialized));
                    Console.WriteLine($"Sent messages");
                }
            }
        }
    }
}
