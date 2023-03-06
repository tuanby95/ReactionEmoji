namespace ReactionEmoji
{
    internal class Receiver : IReceiver
    {

        private IReceiver _receiver;

        public Receiver(IReceiver receiver)
        {
            _receiver = receiver;
        }

        public string GetName()
        {
            return _receiver.GetName();
        }

        public string GetReceiverType()
        {
            return _receiver.GetReceiverType();
        }
    }
}