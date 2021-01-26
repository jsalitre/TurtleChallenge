namespace TurtleChallenge.Domain.EventArgs
{
    public class NotificationEventArgs
    {
        public string Message { get; private set; }

        protected NotificationEventArgs(string message)
        {
            this.Message = message;    
        }


        public static NotificationEventArgs Create(string message) {
            return new NotificationEventArgs(message);
        }
    }
}