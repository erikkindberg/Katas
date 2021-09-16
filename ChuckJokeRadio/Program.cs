using System;
using System.Net.Http;

namespace ChuckJokeRadio
{
    class Program
    {
        //TODO plocka även ut och visa datumet för när skämtet skapades/senast uppdaterades
        /* Exempel på ett svar från servern
            {
              "categories": [],
              "created_at": "2020-01-05 13:42:23.484083",
              "icon_url": "https://assets.chucknorris.host/img/avatar/chuck-norris.png",
              "id": "cRcjbqJpQ-GMzIawRcvVlA",
              "updated_at": "2020-01-05 13:42:23.484083",
              "url": "https://api.chucknorris.io/jokes/cRcjbqJpQ-GMzIawRcvVlA",
              "value": //"The only time Chuck Norris felt sadness was when he read Nuck Chorris' jokes."
            }
        */
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

                string created = json.Substring(createdStart, createdEnd - createdStart);
                
                Console.WriteLine(joke);

                Console.WriteLine();
                Console.Write("Press enter for another joke");
                Console.ReadLine();

                Console.Clear();
            }
        }
    }
}
