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
    [Table("Teams")]
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public ApplicationUser User { get; set; }
        public virtual ICollection<PlayersTeams> PlayersTeams { get; set; }
        public Team() { }
        public Team(string name, ApplicationUser user)
        {
            Name = name;
            User = user;
        }
        public double Score
        {
            get
            {
                if (this.PlayersTeams != null)
                {
                    double teamScore = 0.00;
                    foreach (var player in this.PlayersTeams)
                    {
                        teamScore += player.Player.FantasyPoints;
                    }
                    return Math.Round(teamScore, 2);
                }
                else
                {
                    return 0;
                }
            }
        }



    }
}
