using DocumentArchival.Models;
using DocumentArchival.Models.DTO;

namespace DocumentArchival.Repositories
{
    public interface IDesignationRepo
    {
        Task<IEnumerable<des01designation>> GetAll();
        Task<des01designation> GetById(int id);
        Task Add(des01designationModel designation);
        Task Update(int Id, des01designationModel designation);
        Task Delete(int id);
    }
}
