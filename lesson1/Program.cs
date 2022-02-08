using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace lesson1
{
    internal class Program
    {
        private static readonly CancellationTokenSource cancellationToken = new(1000);
        static void Main()
        {
            var taskPool = new List<Task<Message>>();

            for (int i = 4; i <= 13; i++)
            {
                taskPool.Add(GetMessage(i, cancellationToken));
            }

            try
            {
                Task.WaitAll(taskPool.ToArray());
            }
            catch (Exception)
            {
            }

            foreach (var task in taskPool)
            {
                if (task.IsCanceled)
                {
                    continue;
                }
                ResultCreator.CreateFile(task.Result);
            }

        }

        private static async Task<Message> GetMessage(int id, CancellationTokenSource cancelToken)
        {
            using var client = new HttpClient();

            try
            {
                string response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/" + id, cancelToken.Token);
                Message message = JsonSerializer.Deserialize<Message>(response, new JsonSerializerOptions(){PropertyNameCaseInsensitive = true});

                return message;
            }

            catch (Exception)
            {
                throw;
            }
        }

    }
}
