using DocumentArchival.Data;
using DocumentArchival.Models;
using DocumentArchival.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DocumentArchival.Repositories
{
    public class BranchesRepo : IBranchesRepo
    {
        private readonly ApplicationDbContext _context;
        public BranchesRepo(ApplicationDbContext context) {  _context = context; }

        public async Task Create(bra01branchesModelCreateVm branches)
        {
            try
            {
                var insertValue = new bra01branches();
                insertValue.bra01name = branches.bra01name;
                insertValue.bra01status = branches.bra01status;
                insertValue.bra01address = branches.bra01address;
                insertValue.bra01telephone = branches.bra01telephone;
                insertValue.bra01code = branches.bra01code;
                insertValue.bra01created_at = DateTime.Now;
                insertValue.bra01created_by = "Ram";
                insertValue.bra01is_head_office = branches.bra01is_head_office;
                insertValue.bra01set05uin_muncipality = branches.bra01set05uin_muncipality;

                
                await _context.bra01branches.AddAsync(insertValue);
                await _context.SaveChangesAsync();
            }
            catch(Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var item = await _context.bra01branches.FindAsync(id);
                if(item == null)
                {
                    throw new Exception("Invalid data");
                }
                item.bra01deleted = true;
                _context.bra01branches.Update(item);
                await _context.SaveChangesAsync();
            }catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<bra01branchesModel>> GetAll()
        {
            try
            {
                var data = await _context.bra01branches.Where(d => !d.bra01deleted).Include(d => d.set05municipality).Select(d => new bra01branchesModel
                {

                    bra01uin = d.bra01uin,
                    bra01name=d.bra01name,
                    bra01code = d.bra01code,
                    bra01address = d.bra01address,
                    bra01telephone = d.bra01telephone,
                    bra01status = d.bra01status,
                    bra01is_head_office = d.bra01is_head_office,
                    bra01set05uin_muncipality = d.bra01set05uin_muncipality,
                    municipalityTitle = d.set05municipality.set05title

                }).ToListAsync();
                return data;
            }
            catch(Exception e) {
                Console.WriteLine(e);
                throw new Exception("Error occurred while fetching the municipality data", e);
            }
        }

        public async Task Update(bra01branchesModelCreateVm branchesModel)
        {
            try
            {
                var existingBranch = await _context.bra01branches
                                                         .Include(m => m.set05municipality)
                                                         .FirstOrDefaultAsync(m => m.bra01uin == branchesModel.bra01uin);
                if (existingBranch == null)
                {
                    throw new Exception($"Municipality with ID {branchesModel.bra01uin} not found");
                }

                existingBranch.bra01name = branchesModel.bra01name;
                existingBranch.bra01code = branchesModel.bra01code;
                existingBranch.bra01telephone = branchesModel.bra01telephone;
                existingBranch.bra01address = branchesModel.bra01address;
                existingBranch.bra01is_head_office = branchesModel.bra01is_head_office;
                existingBranch.bra01status = branchesModel.bra01status;
                existingBranch.bra01deleted = branchesModel.bra01deleted;

                // Update the district if it has changed
                if (existingBranch.bra01set05uin_muncipality != branchesModel.bra01set05uin_muncipality)
                {
                    existingBranch.bra01set05uin_muncipality = branchesModel.bra01set05uin_muncipality;
                    existingBranch.set05municipality = await _context.set05municipalities
                                                                       .FindAsync(branchesModel.bra01set05uin_muncipality);
                }

                _context.bra01branches.Update(existingBranch);
                await _context.SaveChangesAsync();
            }catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<IEnumerable<DropdownDTO>> GetBranchesIdAndName()
        {
            return await _context.dep01departments
                            .Select(m => new DropdownDTO
                            {
                                Id = m.dep01uin,
                                Title = m.dep01title
                            })
                            .ToListAsync();
        }

    }
}
