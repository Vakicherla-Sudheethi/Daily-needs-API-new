using DailyNeeds1.DTO;
using DailyNeeds1.Entities;
using DailyNeeds1.Repo;
using DailyNeeds1.DTO;
using DailyNeeds1.Entities;

namespace DailyNeeds1.Repo
{
    public class LocationImpl : IRepo<LocationDTO>
    {
        DailyNeedsDbContext context;
        public LocationImpl(DailyNeedsDbContext ctx)
        {
            context = ctx;

        }
        public bool Add(LocationDTO item)
        {
            Location location = new Location();
            location.LocName = item.LocName;
            location.CityId = item.CityId;
            context.Locations.Add(location);
            context.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            var locDelete = context.Locations.Find(Id);

            if (locDelete == null)
                return false;

            context.Locations.Remove(locDelete);
            //context.SaveChanges();
            return true;
        }

        public List<LocationDTO> GetAll()
        {
            var Result = context.Locations.Select(l => new LocationDTO { LocId = l.LocId, LocName = l.LocName, CityId = l.CityId }).ToList();
            return Result;
        }

        public bool Update(LocationDTO item)
        {
            var locationUpdate = context.Locations.Find(item.LocId);

            if (locationUpdate == null)
                return false;

            locationUpdate.LocName = item.LocName;
            //context.SaveChanges();

            return true;
        }
        //newly-added
        public List<LocationDTO> GetLocationsByCityId(int cityId)
        {
            var locationsByCity = context.Locations
                .Where(l => l.CityId == cityId)
                .Select(l => new LocationDTO { LocId = l.LocId, LocName = l.LocName, CityId = l.CityId })
                .ToList();

            return locationsByCity;
        }
    }
}
