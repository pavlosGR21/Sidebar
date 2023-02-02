using Microsoft.EntityFrameworkCore;
using Sidebar.Data;
using Sidebar.Models;

namespace Sidebar.Data.Repositories
{
    public class CandidateRepository : IGenericRepository<Candidate>
    {
        private readonly WebAppDbContext _db;
        public CandidateRepository(WebAppDbContext context)
        {
            _db = context;
        }
        public async Task<Candidate?> GetAsync(int id)
        {
            return await _db.Candidates.FirstOrDefaultAsync(x => x.Id == id);
        }        

        public async Task<IEnumerable<Candidate>?> GetAllAsync()
        {
            return await _db.Candidates.ToListAsync<Candidate>();
        }

        public EntityState AddOrUpdate(Candidate candidate)
        {
            _db.Candidates.Update(candidate);
            return _db.Entry(candidate).State;
        }

        public void Delete(Candidate candidate)
        {
            _db.Candidates.Remove(candidate);
        }

        public async Task<bool> Exists(int id)
        {
            return await _db.Candidates.AnyAsync(e => e.Id == id);
        }
    }
}
