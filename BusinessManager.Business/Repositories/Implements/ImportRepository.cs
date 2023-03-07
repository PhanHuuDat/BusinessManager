using AutoMapper;
using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.DataAccess.DAOs;
using BusinessManager.DataAccess.Data;
using BusinessManager.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BusinessManager.Business.Repositories.Implements
{
    public class ImportRepository : Repository<ImportDTO, Import>, IImportRepository
    {
        public ImportRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {

        }

        public override async Task<bool> CreateAsync(ImportDTO entity)
        {
            var obj = _mapper.Map<Import>(entity);

            try
            {
                _db.Import.Add(obj);
                await _db.SaveChangesAsync();

                var updateBook = await UpdateBookQuantityAsync(obj.BookId, obj.Quantity);

                if (!updateBook)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }


        public async Task<bool> UpdateAsync(ImportDTO entity)
        {
            try
            {
                var obj = await _db.Import.FirstOrDefaultAsync(cost => cost.Id == entity.Id);

                if (obj != null)
                {
                    var updateBook = await UpdateBookQuantityAsync(entity.BookId, entity.Quantity - obj.Quantity);
                    if (!updateBook)
                    {
                        return false;
                    }

                    obj.Cost = entity.Cost;
                    obj.Quantity = entity.Quantity;
                    obj.ImportDate = entity.ImportDate ?? DateTime.Now;
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

        private async Task<bool> UpdateBookQuantityAsync(int bookId, int quantity)
        {
            try
            {
                var book = await _db.Book.FirstOrDefaultAsync(book => book.Id == bookId);
                if (book == null)
                {
                    return false;
                }
                if (book.Quantity + quantity < 0)
                {
                    return false;
                }
                book.Quantity += quantity;
                _db.Update(book);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }
    }
}
