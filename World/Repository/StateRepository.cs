using World.Data;
using World.Models;
using World.Repository.IRepository;

namespace World.Repository
{
    public class StateRepository : GenericRepository<State>, IStateRepository
    {
        private readonly ApplicationDbContext _context;
        public StateRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task Update(State entity)
        {
            _context.States.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
