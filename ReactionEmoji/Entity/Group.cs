using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactionEmoji.Entity
{
    internal class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<User> Members { get; set; }
        public HashSet<Message> Messages { get; set; }
        public Receiver? Receiver { get; set; }

        public Group()
        {
            Members = new HashSet<User>();
            Messages = new HashSet<Message>();
        }
    }
}
