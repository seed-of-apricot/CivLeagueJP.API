using System.ComponentModel.DataAnnotations.Schema;
using CivLeagueJP.API.ValueHandlers;

namespace CivLeagueJP.API.Models.Civ6
{
    [Table("Cities")]
    public class City
    {
        public int Id { get; set; }
        public Match Match { get; set; }
        public int Turn { get; set; }
        [NotMapped]
        public virtual EFIntArrayList Locations { get; set; }
        [NotMapped]
        public virtual EFIntList GovernedByIds { get; set; }
        [NotMapped]
        public virtual EFStringList DisplayNames { get; set; }
        [NotMapped]
        public virtual EFIntList Populations { get; set; }
        [NotMapped]
        public virtual EFIntList Productions { get; set; }
    }
}
