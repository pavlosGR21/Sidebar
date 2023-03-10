using Microsoft.EntityFrameworkCore;
using Sidebar.Models;

namespace Sidebar.Data.Repositories
{
    public class StemRepository : IGenericRepository<Stem>
    {
        private readonly WebAppDbContext _db;
        public StemRepository(WebAppDbContext context)
        {
            _db = context;
        }
        public async Task<Stem?> GetAsync(int id)
        {
            return await _db.Stems.Include(stem => stem.Topic).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Stem>?> GetAllAsync()
        {
            return await _db.Stems.Include(stem => stem.Topic).ToListAsync<Stem>();
        }

        public EntityState AddOrUpdate(Stem stem)
        {
            _db.Stems.Update(stem);
            return _db.Entry(stem).State;
        }

        public void Delete(Stem stem)
        {
            _db.Stems.Remove(stem);
        }

        public async Task<bool> Exists(int id)
        {
            return await _db.Stems.AnyAsync(e => e.Id == id);
        }
    }
}
