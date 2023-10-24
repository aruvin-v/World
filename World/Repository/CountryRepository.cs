using Microsoft.EntityFrameworkCore;
using World.Data;
using World.Models;
using World.Repository.IRepository;

namespace World.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Country entity)
        {
            await _context.Countries.AddAsync(entity);
            await Save();
        }

        public async Task Delete(Country entity)
        {
            _context.Countries.Remove(entity);
            await Save();
        }

        public async Task<List<Country>> GetAll()
        {
            List<Country> countries = await _context.Countries.ToListAsync();
            return countries;
        }

        public async Task<Country> GetByCountryId(int countryId)
        {
            Country country = await _context.Countries.FindAsync(countryId);
            return country;
        }

        public bool IsCountryExists(string countryName)
        {
            var result = _context.Countries.AsQueryable().Where(x=>x.CountryName.ToUpper().Trim() == countryName.ToUpper().Trim()).Any();
            return result;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Country entity)
        {
            _context.Countries.Update(entity);
            await Save();
        }
    }
}
