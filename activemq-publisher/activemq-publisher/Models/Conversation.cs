using System;
using System.Collections.Generic;
using System.Text;

namespace activemq_publisher.Models
{
    public class Conversation
    {
        public int ConversationId { get; set; }
        public string Title { get; set; }
        public int CreaterId { get; set; }
        public string Type { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime RowVersionDate { get; set; }
        public string RowVersionUser { get; set; }
        public int RowVersion { get; set; }
        public User User { get; set; }
        public List<Message> Messages { get; set; }
        public List<Participant> participants { get; set; }

    }
}
