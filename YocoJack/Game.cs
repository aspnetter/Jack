using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace YocoJack
{
    public class Game
    {
        [JsonProperty("playerA")]
        public IEnumerable<string> PlayerACards { get; set; }

        [JsonProperty("playerB")]
        public IEnumerable<string> PlayerBCards { get; set; }

        [JsonProperty("playerAWins")]
        public bool PlayerAWins { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"Player A Cards: {string.Join(",", PlayerACards)}");
            result.AppendLine($"Player B Cards: {string.Join(",", PlayerBCards)}");
            result.AppendLine($"PlayerA Win Expectation: {PlayerAWins}");

            return result.ToString();
        }
    }
}
