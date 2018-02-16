using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivLeagueJP.API.Models.Civ6
{
    [Table("Civ6ActorBases")]
    public abstract class ActorBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        [MaxLength(50)]
        public string DisplayName { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<ActorCurrentStatus> CurrentStatuses { get; set; }
    }

    [Table("Civ6ActorBases")]
    public class Player : ActorBase
    {
        public Player()
        {
            Attendances = new List<Attendance>();
            Achievements = new HashSet<AchievementBase>();
        }
        public virtual List<Attendance> Attendances { get; set; }
        public virtual ICollection<AchievementBase> Achievements { get; set; }
    }

    [Table("Civ6ActorBases")]
    public class Civilization : ActorBase
    {
        public Civilization()
        {
            Attendances = new List<Attendance>();
        }
        
        public virtual List<Attendance> Attendances { get; set; }
    }

    public class Region
    {
        public int Id { get; set; }
        public string RegionName { get; set; }
        public string RegionColor { get; set; }
        public virtual List<ActorBase> Players { get; set; }

        public Region()
        {
            Players = new List<ActorBase>();
        }
    }

    public abstract class ActorStatus
    {
        public ActorStatus()
        {
            Rate = 1500;
            RD = 350;
            Volatility = 0.06;
        }
        public long Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:####}", ApplyFormatInEditMode = true)]
        public double Rate { get; set; }
        [DisplayFormat(DataFormatString = "{0:####}", ApplyFormatInEditMode = true)]
        public double RD { get; set; }
        public double Volatility { get; set; }
    }

    public class ChangeInActorStatus : ActorStatus
    {
        public virtual Attendance Attendance { get; set; }
        public TargetActorType TargetActorType { get; set; }

    }

    public enum TargetActorType
    {
        player,
        civilization
    }

    public class ActorCurrentStatus : ActorStatus
    {
        public LeagueRegulation Regulation { get; set; }
        [DisplayFormat(DataFormatString = "{0:####}", ApplyFormatInEditMode = true)]
        public double RecentRateChange { get; set; }
        public virtual ActorBase ActorBase { get; set; }
        public string SpecialStatus { get; set; }

    }
}