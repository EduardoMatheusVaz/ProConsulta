using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Patients
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;
        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Patient patient)
        {
            await _context.AddAsync(patient);
            await _context.SaveChangesAsync(); //aqui é onde nosso paciente é persistido no banco de dados
        }

        public async Task DeleteByIdAsync(int id)
        {
            var pacient = await GetByIdAsync(id);
            _context.Patients.Remove(pacient);
            await _context.SaveChangesAsync();  // aqui novamente segue uma persistencia dos dados
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            var patients = await _context.Patients.AsNoTracking().ToListAsync(); // AsNoTracking nao traz mapeamentos indevidos, por isso o estou utilizando aqui
            return patients;                                                    //  no caso, para ganhar perfomance
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            var patient = await _context.Patients.SingleOrDefaultAsync(p => p.Id == id);
            return patient;
        }

        public async Task UpdateAsync(Patient patient)
        {
            _context.Update(patient);
            await _context.SaveChangesAsync();

        }
    }
}
