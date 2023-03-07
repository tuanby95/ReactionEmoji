namespace ReactionEmoji.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<Message>? Messages { get; set; }
        public Receiver? Receiver { get; set; }

        //public string GetName()
        //{
        //    return Name; 
        //}

        //public string GetReceiverType()
        //{
        //    return "User";
        //}
    }
}