using CivLeagueJP.API.Models;
using CivLeagueJP.API.Models.Civ6;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivLeagueJP.API.Models
{
    public class UserPlayerConnection
    {
        [Key]
        public long Id { get; set; }
        public virtual Player Civ6Player { get; set; }
        public long ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}