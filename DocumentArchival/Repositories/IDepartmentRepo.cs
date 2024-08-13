using DocumentArchival.Models;
using DocumentArchival.Models.DTO;

namespace DocumentArchival.Repositories
{
    public interface IDepartmentRepo
    {
        public Task<IEnumerable<dep01department>> GetAll();
        public Task Create(dep01department department);
        public Task Update(dep01departmentModel department);
        public Task Delete(int id);
        public Task<IEnumerable<DropdownDTO>> GetDepartmentsIdAndName();
    }
}
