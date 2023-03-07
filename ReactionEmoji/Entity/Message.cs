namespace ReactionEmoji.Entity
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public User Owner { get; set; }
        public HashSet<Message> Replies { get; set; }
        public HashSet<Reaction> Reactions { get; set; }
        public bool IsEdited { get; set; }

        public Message()
        {
            IsEdited = false;
            Replies = new HashSet<Message>();
            Reactions = new HashSet<Reaction>();
        }

        //internal void React(Emoji emoji)
        //{
        //    Emoji? e = Emojis.Find(e => e.CharCode == emoji.CharCode);
        //    if (e is not null)
        //    {
        //        e.CharCode = emoji.CharCode;
        //        e.Name = emoji.Name;
        //    }
        //    else
        //    {

        //        Emojis.Add(emoji);
        //    }

        //}
    }
}