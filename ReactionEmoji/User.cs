namespace ReactionEmoji
{
    public class User : IReceiver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Message>? Messages { get; set; }

        public string GetName()
        {
            return Name; 
        }

        public string GetReceiverType()
        {
            return "User";
        }
    }
}