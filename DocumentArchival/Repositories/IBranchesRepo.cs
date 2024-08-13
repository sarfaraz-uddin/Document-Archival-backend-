using DocumentArchival.Models;
using DocumentArchival.Models.DTO;


namespace DocumentArchival.Repositories
{
    public interface IBranchesRepo
    {
        public Task<IEnumerable<bra01branchesModel>> GetAll();
        public Task Create(bra01branchesModelCreateVm branches);
        public Task Update(bra01branchesModelCreateVm branchesModel);
        public Task Delete(int id);
        public Task<IEnumerable<DropdownDTO>> GetBranchesIdAndName();


    }
}
