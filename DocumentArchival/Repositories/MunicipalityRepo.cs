using DocumentArchival.Data;
using DocumentArchival.Interface;
using DocumentArchival.Models;
using DocumentArchival.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace DocumentArchival.Repositories
{
    public class MunicipalityRepo : IMunicipalityRepo
    {
        private readonly ApplicationDbContext _context;
        public MunicipalityRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<set05municipalityModel>> GetAll()
        {
            try
            {
                var data = await _context.set05municipalities.Where(d => !d.set05deleted).Include(d => d.set04district).Select(d => new set05municipalityModel
                {

                    set05uin = d.set05uin,
                    set05code = d.set05code,
                    set05type=d.set05type,
                    set05title = d.set05title,
                    set05remarks = d.set05remarks,
                    set05address = d.set05address,
                    set05telphone = d.set05telphone,
                    set05status = d.set05status,
                    set05set04uin = d.set05set04uin,
                    districtTitle = d.set04district.set04title

                }).ToListAsync();
                return data;
            }
            catch (Exception e)
            {
                throw new Exception("Error occurred while fetching the municipality data", e);
            }
        }
        public async Task Create(set05municipalityModelCreateVm municipality)
        {
            try
            {
                var insertValue = new set05municipality();
                insertValue.set05code= municipality.set05code;
                insertValue.set05title = municipality.set05title;
                insertValue.set05type= municipality.set05type;
                insertValue.set05remarks= municipality.set05remarks;
                insertValue.set05address= municipality.set05address;
                insertValue.set05telphone = municipality.set05telphone;
                insertValue.set05status = true;
                insertValue.set05deleted = false;
                insertValue.set05set04uin = municipality.set05set04uin;
                insertValue.set05created_at = DateTime.Now;
                insertValue.set05created_by = "Ram";

                await _context.set05municipalities.AddAsync(insertValue);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error occurred while adding municipality data", e);
            }
        }

        public async Task Update(set05municipalityModelCreateVm municipality)
        {
            try
            {
                var existingMunicipality = await _context.set05municipalities
                                                         .Include(m => m.set04district)
                                                         .FirstOrDefaultAsync(m => m.set05uin == municipality.set05uin);
                if (existingMunicipality == null)
                {
                    throw new Exception($"Municipality with ID {municipality.set05uin} not found");
                }

                existingMunicipality.set05code = municipality.set05code;
                existingMunicipality.set05type = municipality.set05type;
                existingMunicipality.set05title = municipality.set05title;
                existingMunicipality.set05remarks = municipality.set05remarks;
                existingMunicipality.set05address = municipality.set05address;
                existingMunicipality.set05telphone = municipality.set05telphone;
                existingMunicipality.set05status = municipality.set05status;
                existingMunicipality.set05deleted = municipality.set05deleted;

                // Update the district if it has changed
                if (existingMunicipality.set05set04uin != municipality.set05set04uin)
                {
                    existingMunicipality.set05set04uin = municipality.set05set04uin;
                    existingMunicipality.set04district = await _context.set04districts
                                                                       .FindAsync(municipality.set05set04uin);
                }

                _context.set05municipalities.Update(existingMunicipality);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while updating Municipality with ID {municipality.set05uin}", ex);
            }
        }
        public async Task Delete(int id)
        {
            try
            {

                var municipality = await _context.set05municipalities.FindAsync(id);
                if (municipality == null)
                {
                    throw new Exception("Invalid data");
                }
                municipality.set05deleted = true;
                _context.set05municipalities.Update(municipality);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Error occurred while deleting municipality with ID {id}", ex);
            }
        }

    }
}
