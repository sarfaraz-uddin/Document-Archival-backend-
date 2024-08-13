using DocumentArchival.Models;
using DocumentArchival.Models.DTO;

namespace DocumentArchival.Repositories
{
    public interface IProvinceRepo
    {
        Task<List<set03province>> GetAllAsync();
        Task AddAsync(set03province set03Province);
        Task UpdateAsync(byte Id, set03provinceModel set03ProvinceModel);
        Task DeleteAsync(byte Id);
    }
}
