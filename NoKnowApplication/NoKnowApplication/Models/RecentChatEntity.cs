using System;

namespace NoKnowApplication.Models
{
    public class RecentChatEntity
    {
        public long ChatId { get; set; }
        public DateTime? LastInteraction { get; set; }
        public long WriterAccountId { get; set; }
        public long ReceiverAccountId { get; set; }
        public string SavedName { get; set; }
    }
}