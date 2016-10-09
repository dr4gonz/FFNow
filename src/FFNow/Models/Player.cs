using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace FFNow.Models
{
    [Table("Players")]
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Team { get; set; }
        public int Played { get; set; }
        public int Started { get; set; }
        //statistics
        public float PassingAttempts { get; set; }
        public float PassingCompletions { get; set; }
        public float PassingYards { get; set; }
        public float PassintCompletionPercentage { get; set; }
        public float PassingTouchdowns { get; set; }
        public float PassingInterceptions { get; set; }
        public float PassingRating { get; set; }
        //rushing
        public float RushingAttempts { get; set; }
        public float RushingYards { get; set; }
        public float RushingYardsPerAttempt { get; set; }
        public float RushingTouchdowns { get; set; }
        //receiving
        public float ReceivingTargets { get; set; }
        public float Receptions { get; set; }
        public float ReceivingYards { get; set; }
        public float RecevingYardsPerReception { get; set; }
        public float ReceivingTouchdowns { get; set; }
        //Errors
        public float Fumbles { get; set; }
        public float FumblesLost { get; set; }
        public float FantasyPoints { get; set; }
        public int? TeamId { get; set; }
        public virtual Team UserTeam { get; set; }
        public virtual ICollection<PlayersTeams> PlayersTeams { get; set; }
        public Player() { }
        public static List<Player> GetPlayers()
        {

            var client = new RestClient("https://api.fantasydata.net/v3/nfl/stats/JSON/PlayerSeasonStats");
            var request = new RestRequest("2016REG", Method.GET);
            client.AddDefaultHeader(EnvironmentVariables.Key, EnvironmentVariables.Token);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JArray responseJson = JArray.Parse(response.Content);
            List<Player> players = new List<Player>();
            foreach (var jPlayer in responseJson)
            {
                JObject player = jPlayer as JObject;
                var playerPosition = player["Position"].ToString();
                var playerPositionCat = player["PositionCategory"].ToString();
                if (playerPositionCat == "OFF" && ((playerPosition == "QB") || (playerPosition == "WR") || (playerPosition == "RB") || (playerPosition == "TE")))
                {
                    Player newPlayer = player.ToObject<Player>();
                    players.Add(newPlayer);
                }
            }
            return players;
        }

        private static Task<IRestResponse> GetResponseContentAsync(RestClient client, RestRequest request)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(request, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
        //public static Player GetPlayerStats(int playerId)
        //{

        //    var client = new RestClient("https://api.fantasydata.net/v3/nfl/stats/JSON/Player/");
        //    var request = new RestRequest(playerId.ToString(), Method.GET);
        //    client.AddDefaultHeader(EnvironmentVariables.Key, EnvironmentVariables.Token);
        //    var response = new RestResponse();
        //    Task.Run(async () =>
        //    {
        //        response = await GetResponseContentAsync(client, request) as RestResponse;
        //    }).Wait();
        //    JObject responseJson = JObject.Parse(response.Content);
        //    List<Player> players = new List<Player>();
        //    foreach (var jPlayer in responseJson)
        //    {
        //        JObject player = jPlayer as JObject;
        //        var playerPosition = player["Position"].ToString();
        //        var playerPositionCat = player["PositionCategory"].ToString();
        //        if (playerPositionCat == "OFF" && ((playerPosition == "QB") || (playerPosition == "WR") || (playerPosition == "RB") || (playerPosition == "TE")))
        //        {
        //            Player newPlayer = player.ToObject<Player>();
        //            players.Add(newPlayer);
        //        }
        //    }
        //    return players;
        //}
    }
}
