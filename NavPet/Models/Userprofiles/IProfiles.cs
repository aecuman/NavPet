using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavPet.Models.Userprofiles
{
    public interface IProfilesRepository
    {
        IEnumerable<Profiles> GetAllProfiles();
        Profiles GetProfile(string Id);
        Profiles AddProfile(Profiles item);
        bool RemoveProfile(string Id);
        bool UpdateProfile(string Id, Profiles item);
    }
}