using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BinaryNetCoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BinaryNetCoreApp.Services
{
    public class SimpleModelService : ISimpleModelService
    {
        private SimpleModelContext db;
        private bool dispose = false;

        public SimpleModelService(SimpleModelContext context)
        {
            db = context;
        }
        public async Task<List<SimpleModel>> GetAllAsync()
        {
            return await db.SimpleModels.ToListAsync();
        }
        public async Task<SimpleModel> GetByIdAsync(int id)
        {
            return await db.SimpleModels.FindAsync(id);
        }
        public async Task CreateAsync(SimpleModel item)
        {
            db.SimpleModels.Add(item);
            await SaveAsync();
        }
        public async Task EditAsync(SimpleModel item)
        {
            db.Entry(item).State = EntityState.Modified;
            await SaveAsync();
        }
        public async Task DeleteAsync(int id)
        {
            SimpleModel item = await db.SimpleModels.FindAsync(id);
            if (item != null)
                db.SimpleModels.Remove(item);
            await SaveAsync();
        }
        public async Task DeleteAllAsync()
        {
            db.SimpleModels.RemoveRange(db.SimpleModels);
            await SaveAsync();
        }
        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!dispose)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            dispose = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
