using back_project.Entities;
using Microsoft.EntityFrameworkCore;

namespace back_project.Data
{
    public class VehicleRepository : IRepositoryGeneric<Vehicle>
    {
        private readonly AppDbContext _context;

        public VehicleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Vehicle entity)
            => await _context.Vehicles.AddAsync(entity);

        public async Task Delete(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id)
                ?? throw new Exception($"record with {id} not found!");

            _context.Vehicles.Remove(vehicle);
        }

        public void Dispose()
            => _context.Dispose();

        public async Task<IEnumerable<Vehicle>> GetAll()
            => await _context.Vehicles.ToListAsync();

        public async Task<Vehicle> GetById(int id)
        {
            var vehicle = await _context.Vehicles.Include(o => o.Routes)
                .FirstOrDefaultAsync(e => e.Id == id )
              ?? throw new Exception($"record with {id} not found!");

            return vehicle;
        }

        public async Task Save()
            => await _context.SaveChangesAsync();

        public void Update(Vehicle entity)
            => _context.Vehicles.Update(entity);
    }
}
