using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavPet.Models
{
    public interface IStationRepository
    {
        IEnumerable<Station> GetAllStations();
        Station GetStation(string Id);
        Station AddStation(Station item);
        bool RemoveStation(string Id);
        bool UpdateStation(string Id, Station item);
    }
}
