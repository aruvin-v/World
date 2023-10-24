using World.Models;

namespace World.Repository.IRepository
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAll();
        Task<Country> GetByCountryId(int countryId);
        Task Create(Country entity);
        Task Update(Country entity);
        Task Delete(Country entity);
        Task Save();
        bool IsCountryExists(string countryName);
    }
}
