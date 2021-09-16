using System;
using System.Net.Http;

namespace ChuckJokeRadio
{
    class Program
    {
        //TODO plocka även ut och visa datumet för när skämtet skapades/senast uppdaterades
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            while (true)
            {
                string url = @"https://api.chucknorris.io/jokes/random";
                string json = client.GetStringAsync(url).Result;

                string startTag = "\"value\":\"";
                string createdAt = "\"created_at\":\"";

                int start = json.IndexOf(startTag) + startTag.Length;
                int end = json.IndexOf("\"}", start);


                int createdStart = json.IndexOf(createdAt) + createdAt.Length;
                int createdEnd = json.IndexOf("\"", createdStart);

                string joke = json.Substring(start, end - start);
                string created = json.Substring(createdStart, createdEnd - createdStart);
                
                Console.WriteLine(joke);
                Console.WriteLine(String.Format("Created: {0}", created));

                Console.WriteLine();
                Console.Write("Press enter for another joke");
                Console.ReadLine();

                Console.Clear();
            }
        }
    }
}
