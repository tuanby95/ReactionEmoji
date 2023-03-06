namespace ReactionEmoji
{
    internal class Sender : User
    {
        public Sender()
        {
            this.Messages = new List<Message>();
        }
        
        internal List<Message> SendMessage(Message newMessage)
        {
            Messages.Add(newMessage);
            return this.Messages;
        }
    }
}