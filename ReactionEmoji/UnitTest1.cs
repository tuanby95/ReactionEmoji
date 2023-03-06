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
            var newSender = new Sender() { Id = 1, Name = "Tony"};
            var newMessage = new Message() { Id = 1, Content = "Hello, Danny!", CreatedDate = DateTime.Now};

            var result = newSender.SendMessage(newMessage);
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// A user can have 1 or many messages
        /// </summary>
        [TestMethod]
        public void GetMessageFromUserTest()
        {
            var newUser = new User() { Id = 2, Name = "Danny" };
            newUser.Messages = new List<Message>() {
                new Message() { Id = 1, Content ="Hi there, Tony!", CreatedDate= DateTime.Now },
                new Message() { Id = 2, Content = "How are you?", CreatedDate = DateTime.Now }
            };
            
            //Checking if the user have many messages
            var result = newUser.Messages;
            Assert.IsNotNull(result.Count);
        }

        /// <summary>
        /// A receiver can be a user or a group of user
        /// </summary>
        [TestMethod]
        public void IdentifyReceiverTest()
        {
            var newUser = new User() { Id = 3, Name = "John" };

            //Checking if the receiver is whether a user or not
            var newReceiver = new Receiver(newUser);
            Assert.AreEqual(newReceiver.GetReceiverType(), "User");

            var newGroup = new Group() { Id = 1, Name = "Wjpu group" };

            var newReceiver1 = new Receiver(newGroup);
            Assert.AreEqual(newReceiver1.GetReceiverType(), "Group");
        }

        /// <summary>
        /// Test case: a message can have 1 or multiple replies
        /// </summary>
        [TestMethod]
        public void SentReplyTest()
        {
            var newUser = new User() { Id = 1, Name = "John" };
            var newUser1 = new User() { Id = 2, Name = "Dave" };
            var newMessage = new Message() { Id = 1, Content = "Hello, world!", CreatedDate = DateTime.Now, Owner = newUser };
            var newReply = new Message() { Id = 2, Content = "Hi there!", CreatedDate = DateTime.Now, Owner = newUser1 };

            newMessage.Replies.Add(newReply);

            Assert.IsTrue(newMessage.Replies.Count > 0);
        }
    }
}