using DocumentArchival.Models;
using DocumentArchival.Models.DTO;

namespace DocumentArchival.Interface
{
    public interface IEmployeeRepo
    {
        Task<IEnumerable<emp01employee>> GetAll();
        Task Create(emp01employeeModel employee);
        Task Update(int id,emp01employeeModel employee);
        Task Delete(int id);
    }
}
