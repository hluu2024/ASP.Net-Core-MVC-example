using Lab_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5.Services
{
    public interface ICityService
    {
        List<City> GetCities();

        City GetCity(int id);
        void AddCity(City e);

        void SaveChanges();
    }
    public class CityService : ICityService
    {
        private readonly AppDbContext _db;

        public CityService(AppDbContext db)
        {
            _db = db;
        }

        public List<City> GetCities()
        {
            return _db.Cities.ToList();
        }

        public City GetCity(int id)
        {
            return _db.Cities.Where(e => e.Id == id).SingleOrDefault();
        }
        public void AddCity(City e)
        {
            _db.Cities.Add(e);
            _db.SaveChanges();
        }

        public void SaveChanges() => _db.SaveChanges();
    }

}