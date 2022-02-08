using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace lesson1
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/response";
            if (!Directory.Exists(docPath))
            {
                Directory.CreateDirectory(docPath);
            }

            string documentContents; //Переменная для хранения строк запросов;

            for (int i = 1; i < 4; i++) {
                try
                {
                    /*

                    HttpResponseMessage response = await client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{i}");

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    var responseBody1 = await response.Content.ReadAsStreamAsync();
                    */

                    string responseBody = await client.GetStringAsync($"https://jsonplaceholder.typicode.com/posts/{i}");

                    Console.WriteLine(responseBody);

                    /*
                    using (StreamReader input = new StreamReader(responseBody1))
                    {
                        documentContents = input.ReadToEnd();
                    }

                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "response" + i + ".txt"), true))
                    {
                        outputFile.WriteLine(documentContents);
                    }
                    */
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
        }
    }
}
