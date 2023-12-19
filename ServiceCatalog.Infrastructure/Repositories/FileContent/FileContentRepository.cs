using Microsoft.EntityFrameworkCore;
using ServiceCatalog.Application.Inrefaces.FileContent;
using ServiceCatalog.Domain.Entity.File;
using ServiceCatalog.Infrastructure.Data.Contex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Infrastructure.Repositories.FileContent
{
    public class FileContentRepository:IFileContentRepository
    {// Класс для создания и удаления записей

        private readonly AppDbContext _context;

        public FileContentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Domain.Entity.File.FileContent obj)
        {
           
            _context.FileContents.Add(obj);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int fileId)
        {
            var entityToDelete = _context.FileContents.Find(fileId);

            if (entityToDelete != null)
            {
                _context.FileContents.Remove(entityToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteByFileName(string fileName)
        {
            var entityToDelete = await _context.FileContents.FirstOrDefaultAsync(x=>x.FileName==fileName);

            if (entityToDelete != null)
            {
                _context.FileContents.Remove(entityToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Domain.Entity.File.FileContent>> GetAll() =>
            _context.FileContents.AsNoTracking();

        public async Task<Domain.Entity.File.FileContent> GetById(int Id) =>
             _context.FileContents.FirstOrDefault(obj => obj.Id == Id);
        

        public async Task GetByName(string fileName)=>
            _context.FileContents.FirstOrDefault(obj => obj.FileName == fileName);

    }
}