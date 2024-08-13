using DocumentArchival.Models;
using DocumentArchival.Models.DTO;

namespace DocumentArchival.Repositories
{
    public interface IEmployee_levelRepo
    {
        Task<IEnumerable<lvl01employee_level>> GetAll();
        Task<lvl01employee_level> GetById(int id);
        Task Add(lvl01employee_levelModel employeeLevel);
        Task Update(int Id,lvl01employee_levelModel employeeLevel);
        Task Delete(int id);
    }
}
