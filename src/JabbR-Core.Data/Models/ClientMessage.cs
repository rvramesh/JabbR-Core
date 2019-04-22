namespace JabbR_Core.Data.Models
{
    public class ClientMessage
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string Room { get; set; }
        public ClientMessage(string id,string content,string room):base()
        {
            this.Id = id;
            this.Content = content;
            this.Room = room;
        }
        public ClientMessage()
        {

        }
    }
}