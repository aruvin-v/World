using Microsoft.EntityFrameworkCore;
using World.Data;
using World.Models;
using World.Repository.IRepository;

namespace World.Repository
{
    public class CountryRepository : GenericRepository<Country> ,ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task Update(Country entity)
        {
            _context.Countries.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
