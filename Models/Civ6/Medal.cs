using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CivLeagueJP.API.ValueHandlers;

namespace CivLeagueJP.API.Models.Civ6
{
    [Table("Civ6AchievementBases")]
    public abstract class AchievementBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int RefreshCycle { get; set; }
        public Grade MedalGrade { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public enum Grade
        {
            normal,
            bronze,
            silver,
            gold
        }
    }
   
    public class Medal : AchievementBase
    {
        public Medal()
        {
            Players = new HashSet<Player>();
        }
        public virtual ICollection<Player> Players { get; set; }
    }

    public class Flag : AchievementBase
    {
        public Flag()
        {
            Posessions = new List<FlagPosessions>();
        }
        public List<FlagPosessions> Posessions { get; set; }
    }

    [Table("Civ6FlagPosessions")]
    public class FlagPosessions
    {
        public FlagPosessions()
        {
            Posessionperiods = new EFDatetimeArrayList();
        }
        public int Id { get; set; }
        public ActorBase Actor { get; set; }
        [NotMapped]
        public EFDatetimeArrayList Posessionperiods { get; set; }
    }
}