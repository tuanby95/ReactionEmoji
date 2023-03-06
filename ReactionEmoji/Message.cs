namespace ReactionEmoji
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public User Owner { get; set; }
        public List<Message> Replies { get; set; }
        public Message()
        {
        }
    }
}