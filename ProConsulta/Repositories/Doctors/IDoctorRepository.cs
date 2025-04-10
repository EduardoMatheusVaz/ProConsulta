using ProConsulta.Models;

namespace ProConsulta.Repositories.Doctors
{
    public interface IDoctorRepository
    {
        Task AddAsync(Doctor doctor);
        Task UpdateAsync(Doctor doctor);
        Task<List<Doctor>> GetAllAsync();
        Task DeleteByIdAsync(int id);
        Task<Doctor?> GetByIdAsync(int id);
    }
}
