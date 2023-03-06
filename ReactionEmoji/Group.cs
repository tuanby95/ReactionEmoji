using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactionEmoji
{
    internal class Group : IReceiver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Members { get; set; }
        public List<Message> Messages { get; set; }

        public Group()
        {
            Members = new List<User>();
            Messages = new List<Message>();
        }

        public string GetName()
        {
            return Name;
        }

        public string GetReceiverType()
        {
            return "Group";
        }
    }
}
