using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace FFNow.Models
{
    [Table("NflGames")]
    public class NflGame
    {
        [Key]
        public int Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string HomeScore { get; set; }
        public string AwayScore { get; set; }
        public string HomeScoreQuarter1 { get; set; }
        public string HomeScoreQuarter2 { get; set; }
        public string HomeScoreQuarter3 { get; set; }
        public string HomeScoreQuarter4 { get; set; }
        public string HomeScoreOvertime { get; set; }
        public string AwayScoreQuarter1 { get; set; }
        public string AwayScoreQuarter2 { get; set; }
        public string AwayScoreQuarter3 { get; set; }
        public string AwayScoreQuarter4 { get; set; }
        public string AwayScoreOvertime { get; set; }
        public string StadiumName { get; set; }
        public string Week { get; set; }
        public bool IsInProgress { get; set; }
        public string QuarterDescription { get; set; }
        public string Quarter { get; set; }
        public string TimeRemaining { get; set; }
        public bool IsOver { get; set; }
        public bool HasStarted { get; set; }
        public DateTime Date { get; set; }
        public NflGame() { }
        public static List<NflGame> GetGames(string week)
        {
            var client = new RestClient("https://api.fantasydata.net/v3/nfl/scores/JSON/ScoresByWeek/2016REG");
            var request = new RestRequest(week, Method.GET);
            client.AddDefaultHeader(EnvironmentVariables.Key, EnvironmentVariables.Token);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JArray responseJson = JArray.Parse(response.Content);
            List<NflGame> games = new List<NflGame>();
            foreach (var jGame in responseJson)
            {
                JObject game = jGame as JObject;
                NflGame newGame = game.ToObject<NflGame>();
                games.Add(newGame);
            }
            return games;
        }

        private static Task<IRestResponse> GetResponseContentAsync(RestClient client, RestRequest request)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(request, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
