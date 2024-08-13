using DocumentArchival.Data;
using DocumentArchival.Interface;
using DocumentArchival.Models;
using DocumentArchival.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DocumentArchival.Repositories
{
    public class DistrictRepo:IDistrictRepo
    {
        private readonly ApplicationDbContext _context;
        public DistrictRepo(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<IEnumerable<set04districtModel>> GetAll()
        {
            try
            {
                var hello= await _context.set04districts.Where(d => !d.set04deleted).Include(d => d.set03province).Select(d => new set04districtModel { 
                
                    set04uin=d.set04uin,
                    set04code=d.set04code,
                    set04title=d.set04title,
                    set04remarks=d.set04remarks,
                    set04status=d.set04status,
                    set04set03uin=d.set04set03uin,
                    provinceTitle =d.set03province.set03title
                
                
                }).ToListAsync();
                return hello;
                
            }
            catch (Exception e)
            {
                throw new Exception("Error occurred while fetching the district data", e.InnerException);
            }
        }
        public async Task Create(set04districtModelCreateVm district)
        {
            try
            {
                var insertValue = new set04district();
                insertValue.set04code = district.set04code;
                insertValue.set04title = district.set04title;
                insertValue.set04remarks = district.set04remarks;
                insertValue.set04status = true;
                insertValue.set04deleted = false;
                insertValue.set04set03uin = district.set04set03uin;
                insertValue.set04created_at = DateTime.Now;
                insertValue.set04created_by = "Ram";

                await _context.set04districts.AddAsync(insertValue);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error occurred while adding district data", e);
            }

        }

        public async Task Update(set04districtModelCreateVm district)
        {
            try
            {
                var existingDistrict = await _context.set04districts
                                                     .Include(d => d.set03province)
                                                     .FirstOrDefaultAsync(d => d.set04uin == district.set04uin);
                if (existingDistrict == null)
                {
                    throw new Exception($"District with ID {district.set04uin} not found");
                }

                existingDistrict.set04code = district.set04code;
                existingDistrict.set04title = district.set04title;
                existingDistrict.set04remarks = district.set04remarks;
                existingDistrict.set04status = district.set04status;
                existingDistrict.set04deleted = district.set04deleted;

                // Update the province if it has changed
                if (existingDistrict.set04set03uin != district.set04set03uin)
                {
                    existingDistrict.set04set03uin = district.set04set03uin;
                    existingDistrict.set03province = await _context.set03provinces
                                                                   .FindAsync(district.set04set03uin);
                }

                _context.set04districts.Update(existingDistrict);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while updating District with ID {district.set04uin}", ex);
            }
        }
        public async Task Delete(byte id)
        {
            try
            {

                var district = await _context.set04districts.FindAsync(id);
                if (district == null)
                {
                    throw new Exception("Invalid data");  
                }
                district.set04deleted = true;
                _context.set04districts.Update(district);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Error occurred while deleting district with ID {id}", ex);
            }
        }
    }
}
