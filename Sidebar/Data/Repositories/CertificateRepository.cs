using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sidebar.Data;
using Sidebar.Models;

namespace Sidebar.Data.Repositories
{
    public class CertificateRepository : IGenericRepository<Certificate>
    {
        private readonly WebAppDbContext _db;
        public CertificateRepository(WebAppDbContext context)
        {
            _db = context;
        }
        public async Task<Certificate?> GetAsync(int id)
        {            
            return await _db.Certificates.FirstOrDefaultAsync(x => x.Id == id);            
        }
        
        public async Task<Certificate?> GetAsyncByTilteOfCert(string titleOfCert)
        {            
            return await _db.Certificates.FirstOrDefaultAsync(x => x.TitleOfCertificate == titleOfCert);                      
        }

        public async Task<IEnumerable<Certificate>?> GetAllAsync()
        {
            return await _db.Certificates.ToListAsync<Certificate>();
        }       

        public EntityState AddOrUpdate(Certificate certificate)
        {                      
            _db.Certificates.Update(certificate);
            return _db.Entry(certificate).State;                                     
        }

        public void Delete(Certificate certificate)
        {           
            _db.Certificates.Remove(certificate);                                        
        }

        public async Task<bool> Exists(int id)
        {
            return await _db.Certificates.AnyAsync(e => e.Id == id);
        }

        public async Task<bool> TitleExists(int id, string title)
        {
            return await _db.Certificates.AnyAsync(e => e.TitleOfCertificate == title && e.Id != id);
        }
    }
}
