using System;
using System.Collections.Generic;
using System.Text;

namespace activemq_publisher.Models
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        public int ConversationId { get; set; }
        public int UserId { get; set; }
        public int Counter { get; set; }
        public DateTime DeletionDateTime { get; set; }
        public Conversation Conversation { get; set; }
        public User User { get; set; }
    }
}
