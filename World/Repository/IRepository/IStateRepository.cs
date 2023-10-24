using World.Models;

namespace World.Repository.IRepository
{
    public interface IStateRepository : IGenericRepository<State>
    {
        Task Update(State entity);
    }
}
