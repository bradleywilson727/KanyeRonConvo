using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace KanyeWest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var clientKW = new HttpClient();
            var kanyeURL = "https://api.kanye.rest/";
            var kanyeResponse = "";
            var kanyeQuote = "";

            var clientRS = new HttpClient();
            var swansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var swansonResponse = "";
            var swansonQuote = "";

            Console.WriteLine("If you'd like for Kanye and Ron to keep talking, press the 'Enter' key.\nIf you'd like for them to stop, type the word 'stop'.");
            Console.WriteLine("---------------------------------------------------------------------");
            var input = "";

            while(input != "stop")
            {
                kanyeResponse = clientKW.GetStringAsync(kanyeURL).Result;
                kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                swansonResponse = clientRS.GetStringAsync(swansonURL).Result;
                swansonQuote = JArray.Parse(swansonResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

                Console.WriteLine($"Kanye West- \"{kanyeQuote}\"");
                await Task.Delay(3000);
                Console.WriteLine("");
                Console.WriteLine($"Ron Swanson- {swansonQuote}");
                await Task.Delay(3000);
                input = Console.ReadLine();
            }
        }
    }
}
