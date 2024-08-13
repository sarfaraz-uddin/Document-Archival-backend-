using DocumentArchival.Models;
using DocumentArchival.Models.DTO;


namespace DocumentArchival.Interface
{
    public interface IDistrictRepo
    {
        Task<IEnumerable<set04districtModel>> GetAll();
        Task Create(set04districtModelCreateVm district);
        Task Update(set04districtModelCreateVm district);
        Task Delete(byte id);
    }
}
