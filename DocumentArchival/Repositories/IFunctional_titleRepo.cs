using DocumentArchival.Models;
using DocumentArchival.Models.DTO;

namespace DocumentArchival.Repositories
{
    public interface IFunctional_titleRepo
    {
        Task<IEnumerable<des02functional_title>> GetAll();
        Task<des02functional_title> GetById(int id);
        Task Add(des02functional_titleModel functionalTitle);
        Task Update(int Id,des02functional_titleModel functionalTitle);
        Task Delete(int id);
    }
}
