using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivLeagueJP.API.Models.Civ6
{
    public class Match
    {
        public Match()
        {
            Attendances = new List<Attendance>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public MatchStatus MatchStatus { get; set; }
        public MatchSettings MatchSettings { get; set; }
        public Player Organizor { get; set; }
        public virtual List<Attendance> Attendances { get; set; }
        public string PersistentRecord { get; set; }
        public InGameInfo InGameInfo { get; set; }
    }

    public class InGameInfo
    {
        [Key]
        [ForeignKey("Match")]
        public int Id { get; set; }
        public Match Match { get; set; }
        public Map Map { get; }
        //public TechCivic TechCivic { get; }
    }
    
    public class MatchStatus
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
        public ProgressEnum MatchProgress { get; set; }
        public int? EndTurn { get; set; }
    }

    public class MatchSettings
    {
        public int Id { get; set; }
        public int NumberOfPlayers { get; set; }
        public LeagueRegulation Regulation { get; set; }
        public MapTypeEnum MapType { get; set; }
        public MapSizeEnum Mapsize { get; set; }
        public GameSpeedEnum GameSpeed { get; set; }
        public AiDifficultyEnum? AiDifficulty { get; set; }
        public MapWorldAgeEnum MapWorldAge { get; set; }
        public MapTemperatureEnum MapTemperature { get; set; }
        public MapRainfallEnum MapRainfall { get; set; }
        public MapSeaLevelEnum MapSeaLevel { get; set; }
        public MapResourceEnum MapResource { get; set; }
        public MapStartPositionEnum MapStartPosition { get; set; }
        public VictoryTypeEnum VictoryTypes { get; set; }
        public bool IfRagingBarbarian { get; set; }
        public int LimitTurn { get; set; }
    }

    public class Attendance
    {
        [Key]
        public long Id { get; set; }
        public virtual Player Player { get; set; }
        public virtual Civilization Civilization { get; set; }
        public virtual Match Match { get; set; }
        public virtual List<ChangeInActorStatus> Changes { get; set; }
        public int? Rank { get; set; }
        public bool? IsFinished { get; set; }
    }


    public enum ProgressEnum
    {
        notstarted,
        ongoing,
        suspended,
        discontinued,
        ended
    }


    public enum LeagueRegulation
    {
        none,
        _short,
        _long
    }
    public enum MapTypeEnum
    {
        pangaea,
        continent,
        fractal,
        shuffle,
        other
    }

    public enum MapSizeEnum
    {
        duel,
        tiny,
        small,
        standard,
        large,
        huge
    }

    public enum GameSpeedEnum
    {
        online,
        quick,
        standard,
        prolonged,
        malathon
    }

    public enum AiDifficultyEnum
    {
        settler,
        chieftain,
        warlord,
        prince,
        king,
        emperor,
        immortal,
        deity
    }

    public enum MapWorldAgeEnum
    {
        _new,
        standard,
        old,
        random
    }

    public enum MapTemperatureEnum
    {
        [ValueHandlers.LocalizedDescription("temperature_hot", typeof(Localization.Civ6.General))]
        hot,
        [ValueHandlers.LocalizedDescription("temperature_standard", typeof(Localization.Civ6.General))]
        standard,
        [ValueHandlers.LocalizedDescription("temperature_cold", typeof(Localization.Civ6.General))]
        cold,
        [ValueHandlers.LocalizedDescription("temperature_random", typeof(Localization.Civ6.General))]
        random
    }

    public enum MapRainfallEnum
    {
        [ValueHandlers.LocalizedDescription("rainfall_arid", typeof(Localization.Civ6.General))]
        arid,
        [ValueHandlers.LocalizedDescription("rainfall_standard", typeof(Localization.Civ6.General))]
        standard,
        [ValueHandlers.LocalizedDescription("rainfall_wet", typeof(Localization.Civ6.General))]
        wet,
        [ValueHandlers.LocalizedDescription("rainfall_random", typeof(Localization.Civ6.General))]
        random
    }

    public enum MapSeaLevelEnum
    {
        [ValueHandlers.LocalizedDescription("sealevel_low", typeof(Localization.Civ6.General))]
        low,
        [ValueHandlers.LocalizedDescription("sealevel_standard", typeof(Localization.Civ6.General))]
        standard,
        [ValueHandlers.LocalizedDescription("sealevel_high", typeof(Localization.Civ6.General))]
        high,
        [ValueHandlers.LocalizedDescription("sealevel_random", typeof(Localization.Civ6.General))]
        random
    }

    public enum MapResourceEnum
    {
        sparse,
        standard,
        abundant,
        random
    }

    public enum MapStartPositionEnum
    {
        balanced,
        standard,
        legendary
    }

    [Flags]
    public enum VictoryTypeEnum
    {
        Conquest = 1,
        Culture = 2,
        Religion = 4,
        Time = 8,
        Observed = 16,
        Unknown = 32
    }
}