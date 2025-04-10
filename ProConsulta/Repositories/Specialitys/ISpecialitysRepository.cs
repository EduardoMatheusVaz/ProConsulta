using ProConsulta.Models;

namespace ProConsulta.Repositories.Specialitys
{
    public interface ISpecialitysRepository
    {
        Task<List<Speciality>> GetAllAsync();
    }
}
