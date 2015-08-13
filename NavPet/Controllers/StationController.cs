using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NavPet.Models;

namespace NavPet.Controllers
{
    public class StationController : ApiController
    {
        public static readonly IStationRepository _station = new StationRepository();
        public IQueryable<Station> Get()
        {
            return _station.GetAllStations().AsQueryable();
        }
        public Station Get(string Id)
        {
            Station station = _station.GetStation(Id);
            if (station == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return station;
        }
        public Station Post(Station value)
        {
            Station station = _station.AddStation(value);
            return station;
        }
        public void Put(string Id, Station value)
        {
            if (!_station.UpdateStation(Id, value))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public void Delete(string Id)
        {
            if (!_station.RemoveStation(Id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
