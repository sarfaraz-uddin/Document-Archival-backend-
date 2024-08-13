using DocumentArchival.Models;
using DocumentArchival.Models.DTO;

namespace DocumentArchival.Interface
{
    public interface IMunicipalityRepo
    {
        Task<IEnumerable<set05municipalityModel>> GetAll();
        Task Create(set05municipalityModelCreateVm municipality);
        Task Update(set05municipalityModelCreateVm municipality);
        Task Delete(int id);
    }
}
