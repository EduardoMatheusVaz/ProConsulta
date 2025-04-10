using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Doctors
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Doctor doctor)
        {
            try
            {
                await _context.Doctors.AddAsync(doctor);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _context.ChangeTracker.Clear();
                throw;
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var delete = await GetByIdAsync(id);
            _context.Doctors.Remove(delete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            var doctors = await _context
                .Doctors
                .Include(d => d.Specialty)
                .AsNoTracking()
                .ToListAsync();
            return doctors;
        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
            var doctor = await _context.Doctors.SingleOrDefaultAsync(d => d.Id == id);
            return doctor; 
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            try
            {
                _context.Update(doctor);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                throw;
            }
        }
    }
}
