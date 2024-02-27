using back_project.Entities;
using Microsoft.EntityFrameworkCore;

namespace back_project.Data
{
    public class RouteRepository : IRepositoryGeneric<Journey>
    {
        private readonly AppDbContext _context;

        public RouteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Journey entity)
            => await _context.Routes.AddAsync(entity);

        public async Task Delete(int id)
        {
            var route = await _context.Routes.FindAsync(id)
                ?? throw new Exception($"record with {id} not found!");

            _context.Routes.Remove(route);
        }

        public void Dispose()
            => _context.Dispose();

        public async Task<IEnumerable<Journey>> GetAll()
            => await _context.Routes.ToListAsync();

        public async Task<Journey> GetById(int id)
        {
            var route = await _context.Routes.FindAsync(id)
              ?? throw new Exception($"record with {id} not found!");

            return route;
        }

        public async Task Save()
            => await _context.SaveChangesAsync();   

        public void Update(Journey entity)
            => _context.Routes.Update(entity);
    }
}
