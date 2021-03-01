using System;
using System.Collections.Generic;
using System.Text;

namespace activemq_publisher.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserType { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime RowVersionDate { get; set; }
        public string RowVersionUser { get; set; }
        public int RowVersion { get; set; }
        public List<Conversation> Conversations { get; set; }
        public List<Message> Messages { get; set; }
        public List<Participant> Participants { get; set; }
    }
}
