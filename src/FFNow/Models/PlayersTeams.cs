using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FFNow.Models
{
    [Table("PlayersTeams")]
    public class PlayersTeams
    {
        [Key]
        public int Id { get; set; }
        public Player Player { get; set; }
        public Team Team { get; set; }
        public PlayersTeams() { }
    }
}
