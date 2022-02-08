using System.Collections.Generic;

namespace lesson1
{
    public class Message: IMessage
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public List<string> MessageInList()
        {
            List<string> listWithRowsOfMessage = new();
            listWithRowsOfMessage.Add(UserId.ToString());
            listWithRowsOfMessage.Add(Id.ToString());
            listWithRowsOfMessage.Add(Title);
            listWithRowsOfMessage.Add(Body);

            return listWithRowsOfMessage;
        }

    }
}