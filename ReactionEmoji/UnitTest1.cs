using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReactionEmoji.Entity;
using ReactionEmoji.Service;

namespace ReactionEmoji
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// A sender can send message
        /// </summary>
        [TestMethod]
        public void SenderSendMessage()
        {
            var newSender = new Sender() { Id = 1, Name = "Tony" };
            var newMessage = new Message() { Id = 1, Content = "Hello, Danny!", CreatedDate = DateTime.Now };

            var result = newSender.SendMessage(newMessage);
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// A user can have 1 or many messages
        /// </summary>
        [TestMethod]
        public void GetMessageFromUserTest()
        {
            var newUser = new User()
            { Id = 2, Name = "Danny" };
            newUser.Messages = new HashSet<Message>() {
                new Message() { Id = 1, Content ="Hi there, Tony!", CreatedDate= DateTime.Now },
                new Message() { Id = 2, Content = "How are you?", CreatedDate = DateTime.Now }
            };

            //Checking if the user have many messages
            var result = newUser.Messages;
            Assert.IsNotNull(result.Count);
            var userService = new UserService(newUser);
        }

        /// <summary>
        /// A receiver can be a user or a group of user
        /// </summary>
        [TestMethod]
        public void IdentifyReceiverTest()
        {
            var newUser = new User() { Id = 3, Name = "John", Receiver = new Receiver() };

            //Checking if the receiver is whether a user or not
            var result = newUser.Receiver == null ? true : false;
            //Assert.IsTrue(result);

            //Checking if the receiver is whether a group or not
            var newGroup = new Group() { Id = 1, Name = "Test group", Receiver = new Receiver() };

            var result2 = newGroup.Receiver == null ? true : false;

            Assert.IsTrue(result2);
        }

        /// <summary>
        /// Test case: a message can have 1 or multiple replies
        /// </summary>
        [TestMethod]
        public void SendReplyTest()
        {
            var newUser = new User()
            { Id = 1, Name = "John" };
            var newUser1 = new User()
            { Id = 2, Name = "Dave" };
            var newMessage = new Message()
            { Id = 1, Content = "Hello, world!", CreatedDate = DateTime.Now, Owner = newUser };
            var newReply = new Message()
            { Id = 2, Content = "Hi there!", CreatedDate = DateTime.Now, Owner = newUser1 };

            newMessage.Replies.Add(newReply);

            Assert.IsTrue(newMessage.Replies.Count > 0);
        }

        /// <summary>
        /// Test case: Reactor can react on message
        /// </summary>
        [TestMethod]
        public void ReactOnMessageTest()
        {
            //create a new creator
            var newReactor = new Reactor()
            { Id = 1, Name = "John" };
            //create a new message
            var newMessage = new Message()
            { Id = 1, Content = "Hello, David", CreatedDate = DateTime.Now };
            //create a new emoji
            var newEmoji = new Emoji()
            { Name = "Happy", CharCode = "\uD83D\uDE01" };
            //add emoji to the message and reactor
            //newMessage.Emojis.Add(newEmoji);
            //newReactor.Emojis.Add(newEmoji);

            ////checking if the newMessage has a reaction on it
            //Assert.IsTrue(newMessage.Emojis.Count > 0);
            //checking if the owner of the reaction is the same reactor
            Assert.AreEqual(newEmoji.CharCode, newReactor);
        }

        /// <summary>
        /// Test case: a sender can edit there own message
        /// </summary>
        [TestMethod]
        public void EditMessageTest()
        {
            //create a new user
            var user = new Sender()
            { Id = 1, Name = "Doan" };
            //create a message with the Owner is the user 
            var message = new Message()
            { Id = 1, Content = "Hello, David!", Owner = user };
            //Add message to user
            user.Messages.Add(message);
            //Edit content of message has id = 1
            var newContent = "Good morning, David";
            var idMessage = 1;
            //Call the function edit message
            user.EditMessage(idMessage, newContent);

            var result = user.Messages.FirstOrDefault(e => e.Id == idMessage).IsEdited;
            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// Test case: a message can be received same multiple reactions
        /// </summary>
        [TestMethod]
        public void GetTotalEachReaction()
        {
            //create sender
            var user1 = new Sender()
            { Id = 1, Name = "Dave" };
            //create reactors
            var user2 = new Reactor()
            { Id = 2, Name = "John" };
            var user3 = new Reactor()
            { Id = 3, Name = "Lang" };
            //create message
            var message = new Message()
            { Content = "Hello world!", CreatedDate = DateTime.Now, Owner = user1 };
            //create emoji
            var emoji1 = new Emoji()
            { Id = 1, Name = "Happy", CharCode = "\uD83D\uDE01" };
            var emoji2 = new Emoji()
            { Id = 2, Name = "Happy", CharCode = "\uD83D\uDE01" };

            user1.Messages.Add(message);
            //message.Emojis.Add(emoji1);
            //message.Emojis.Add(emoji2);
            //var result = message.Emojis.Where(e => e.CharCode == "\uD83D\uDE01").Count();

            //Assert.AreEqual(result, 2);
        }

        /// <summary>
        /// Test case: sort emoji by time react
        /// </summary>
        [TestMethod]
        public void SortEmojiTest()
        {
            //Create sender
            var sender = new Sender()
            { Name = "Tuan" };
            //Create message
            var message = new Message()
            { Content = "Hello there!", CreatedDate = DateTime.Now, Owner = sender };

            //Create emoji
            var emoji = new Emoji()
            { Name = "happy", CharCode = "\uD83D\uDE01"};
            var emoji1 = new Emoji()
            { Name = "evil", CharCode = "\uD83D\uDE08" };
            var emoji2 = new Emoji()
            { Name = "crying", CharCode = "\uD83D\uDE02" };
            
            //Create Reactor
            var reactor1 = new Reactor()
            { }

            //var result = message.Emojis.OrderBy(e => e.CreatedTime).ToList();
            //Assert.AreEqual(result[0], emoji2);
        }

        /// <summary>
        /// Test case: a reactor react to a message multiple times
        /// </summary>
        [TestMethod]
        public void ReactSameMessageTest()
        {
            var message = new Message()
            { Content = "Hello world!", CreatedDate = DateTime.Now };

            //Create a reactor and service for reactor
            var reactor = new Reactor()
            { Name = "John" };
            var reactorService = new UserService(reactor);
            //Create new emoji
            var emoji = new Emoji()
            { Name = "Happy", CharCode = "\uD83D\uDE01" };
            var emoji2 = new Emoji()
            { Name = "evil", CharCode = "\uD83D\uDE08" };

            //Create a new reaction
            var reaction = new Reaction()
            { Id = 1, Emoji = emoji, Reactor = reactor, CreatedTime = DateTime.Now };

            //The reactor react with the happy reaction to the message first
            reactorService.ReactToMessage(reaction, message);
            Assert.AreEqual(message.Reactions.Any(e => e.Emoji == emoji), true);

            //Create another reaction
            var reaction1 = new Reaction()
            { Id = 2, Emoji = emoji2, Reactor = reactor, CreatedTime = DateTime.Now };

            //The reactor react with the evil reaction to the message again
            reactorService.ReactToMessage(reaction1, message);
            Assert.AreEqual(message.Reactions.Any(e => e.Emoji == emoji2), true);
        }
    }
}