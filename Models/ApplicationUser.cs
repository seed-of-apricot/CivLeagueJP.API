using System.Collections.Generic;
using CivLeagueJP.API.Models;
using Microsoft.AspNetCore.Identity;

namespace CivLeagueJP.API.Models
{
    public class ApplicationUser : IdentityUser<long>
    {
        public virtual string UserProfileImageAddress { get; set; }
        public virtual byte[] UserProfileImage { get; set; }
        public virtual ICollection<UserPlayerConnection> UserPlayerConnection { get; set; }
        public virtual long SteamID { get; set; }
    }

    public class ApplicationRole : IdentityRole<long>
    {
    }

}
