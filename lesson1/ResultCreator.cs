using System.IO;

namespace lesson1
{
    internal class ResultCreator
    {
        private static readonly string fileName = "result.txt";

        public static void CreateFile(IMessage message)
        {
            File.AppendAllLines(fileName, message.MessageInList());
            File.AppendAllText(fileName, "\n");
        }
    }
}
