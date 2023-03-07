namespace ReactionEmoji.Entity
{
    public class Reactor : User
    {
        public List<Emoji> Emojis { get; set; }
        public Reactor()
        {
            Emojis = new List<Emoji>();
        }
    }
}