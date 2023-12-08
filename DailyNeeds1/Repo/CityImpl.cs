using DailyNeeds1.Entities;
using DailyNeeds1.Repo;
using DailyNeeds1.DTO;
using DailyNeeds1.Entities;

namespace DailyNeeds1.Repo
{
    public class CityImpl : IRepo<CityDTO>
    {
        DailyNeedsDbContext context;
        public CityImpl(DailyNeedsDbContext ctx)
        {
            context = ctx;

        }
        public bool Add(CityDTO item)
        {
            City cityNew = new City();
            cityNew.CityName = item.CityName;
            context.Cities.Add(cityNew);
            //context.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            var cityDelete = context.Cities.Find(Id);

            if (cityDelete == null)
                return false;

            context.Cities.Remove(cityDelete);
            //context.SaveChanges();
            return true;
        }

        public List<CityDTO> GetAll()
        {
            var Res = context.Cities.Select(c => new CityDTO() { CityId = c.CityId, CityName = c.CityName }).ToList();
            return Res;
        }

        public bool Update(CityDTO item)
        {
            var cityUpdate = context.Cities.Find(item.CityId);

            if (cityUpdate == null)
                return false;

            cityUpdate.CityName = item.CityName;
            //context.SaveChanges();

            return true;
        }
    }
}