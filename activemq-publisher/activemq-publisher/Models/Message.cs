using System;
using System.Collections.Generic;
using System.Text;

namespace activemq_publisher.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int ConversationId { get; set; }
        public int SenderId { get; set; }
        public string MessageType { get; set; }
        public string ChatMessage { get; set; }
        public DateTime MessageDateTime { get; set; }
        public DateTime RowVersionDate { get; set; }
        public string RowVersionUser { get; set; }
        public int RowVersion { get; set; }
        public Conversation Conversation { get; set; }
        public User User { get; set; }
    }
}
