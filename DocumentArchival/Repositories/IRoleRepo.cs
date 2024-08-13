using DocumentArchival.Models;
using DocumentArchival.Models.DTO;

namespace DocumentArchival.Repositories
{
    public interface IRoleRepo
    {
        Task<IEnumerable<rol01role>> GetAllAsync();
        Task AddAsync(rol01roleModel rol01Role);
        Task UpdateAsync(int Id, rol01roleModel rol01Role);
        Task DeleteAsync(int Id);
        public Task<IEnumerable<DropdownDTO>> GetRolesIdAndName();

    }
}

