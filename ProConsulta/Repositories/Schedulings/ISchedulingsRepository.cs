using ProConsulta.Models;

namespace ProConsulta.Repositories.Schedulings
{
    public interface ISchedulingsRepository
    {
        Task AddAsync(Scheduling scheduling);
        Task<List<Scheduling>> GetAllAsync();
        Task DeleteByIdAsync(int id);
        Task<Scheduling?> GetByIdAsync(int id);
        Task<List<AnnualSchedules>> GetReportAsync();
    }
}
