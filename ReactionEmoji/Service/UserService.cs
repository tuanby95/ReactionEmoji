using ReactionEmoji.Entity;
using System.Linq;

namespace ReactionEmoji.Service
{
    internal class UserService
    {
        private User _user;

        public UserService(User newUser)
        {
            this._user = newUser;
        }
        public UserService(Reactor newReactor)
        {
            this._user = newReactor;
        }
        public UserService(Sender newSender)
        {
            this._user = newSender;
        }

        internal void ReactToMessage(Reaction reaction, Message message)
        {
            var result = message.Reactions.FirstOrDefault(e => e.Reactor == reaction.Reactor);
            if (result != null)
            {
                ReplaceReaction(reaction, message);
            }
            else
                message.Reactions.Add(reaction);
        }

        private void ReplaceReaction(Reaction reaction, Message message)
        {
            message.Reactions.FirstOrDefault(e => e.Reactor == reaction.Reactor).Emoji = reaction.Emoji;
        }
    }
}