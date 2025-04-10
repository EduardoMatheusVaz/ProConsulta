using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Specialitys
{
    public class SpecialityRepository : ISpecialitysRepository
    {
        private ApplicationDbContext _context;

        public SpecialityRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Speciality>> GetAllAsync()
        {
            return await _context
                .Specialitys
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
