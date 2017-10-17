using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace YocoJack
{
    class Program
    {
        private const string Url = "https://s3-eu-west-1.amazonaws.com/yoco-testing/tests.json";
        static void Main(string[] args)
        {
            string json;
            using (var wc = new WebClient())
            {
                json = wc.DownloadString(Url);
            }

            var gameList = JsonConvert.DeserializeObject<IEnumerable<Game>>(json);

            var calculator = new Calculator();

            foreach (var game in gameList)
            {
                var playerAWins = calculator.GetResult(game);
                
                Console.Write(game);
                Console.WriteLine($"PlayerA Win Reality: {playerAWins}");
                
                    Console.WriteLine($"Test Result : {(playerAWins == game.PlayerAWins ? "CORRECT" : "WRONG")}\n");
                Console.WriteLine();
            }

            Console.Read();
        }
    }
}
