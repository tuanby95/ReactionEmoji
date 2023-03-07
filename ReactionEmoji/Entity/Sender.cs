namespace ReactionEmoji.Entity
{
    public class Sender : User
    {
        public List<Emoji> Emojis { get; set; }
        public Sender()
        {
            Messages = new HashSet<Message>();
        }

        internal HashSet<Message> SendMessage(Message newMessage)
        {
            Messages.Add(newMessage);
            return Messages;
        }

        internal void EditMessage(int idMessage, string newContent)
        {
            //this.Messages.ForEach(
            //    e =>
            //    {
            //        if (e.Id == idMessage)
            //        {
            //            e.IsEdited = true;
            //            e.Content = newContent;
            //        }
            //    });
        }
    }
}