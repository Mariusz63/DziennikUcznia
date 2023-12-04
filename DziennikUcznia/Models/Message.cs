namespace DziennikUcznia.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string AddedBy { get; set; }
        public string message { get; set; }
        public int MessageGroupID { get; set; }
    }
}
