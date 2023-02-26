using AutoMapper;
using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.DataAccess.DAOs;
using BusinessManager.DataAccess.Data;
using BusinessManager.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Business.Repositories.Implements
{
    public class ImportRepository : Repository<ImportDTO, Import>, IImportRepository
    {
        public ImportRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {

        }
        public async Task<bool> UpdateAsync(ImportDTO entity)
        {
            try
            {
                var obj = await _db.Import.FirstOrDefaultAsync(cost => cost.Id == entity.Id);
                
                if (obj != null)
                {
                    obj.Cost = entity.Cost;
                    obj.Quantity = entity.Quantity;
                    obj.ImportDate = entity.ImportDate;
                    obj.BookId = entity.BookId;
                    obj.UpdatedDate = DateTime.Now;
                    _db.Update(obj);
                    await _db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }
    }
}
