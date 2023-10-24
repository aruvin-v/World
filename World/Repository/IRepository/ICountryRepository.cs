using World.Models;

namespace World.Repository.IRepository
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Task Update(Country entity);
    }
}
