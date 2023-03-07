namespace ReactionEmoji.Entity
{
    public class Reaction
    {
        public int Id { get; set; }
        public Emoji Emoji { get; set; }
        public Reactor Reactor { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}