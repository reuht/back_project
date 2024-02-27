using back_project.Entities;
using Microsoft.EntityFrameworkCore;

namespace back_project.Data
{
    public class DriverRepository : IRepositoryGeneric<Driver>
    {
        private readonly AppDbContext _context;

        public DriverRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Driver entity)
            => await _context.Drivers.AddAsync(entity);
        

        public async Task Delete(int id)
        {
            var driver = await _context.Drivers.FindAsync(id) 
                ?? throw new Exception($"record with {id} not found!");

            _context.Drivers.Remove(driver);    
        }

        public void Dispose()
            => _context.Dispose();

        public async Task<IEnumerable<Driver>> GetAll()
            => await _context.Drivers.ToListAsync();

        public async Task<Driver> GetById(int id)
        {
            var driver = await _context.Drivers.FindAsync(id)
              ?? throw new Exception($"record with {id} not found!");

            return driver; 
        }

        public void Update(Driver entity)
            => _context.Drivers.Update(entity);

        public async Task Save() 
            => await _context.SaveChangesAsync();
    }
}
