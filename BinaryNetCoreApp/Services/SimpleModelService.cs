using BinaryNetCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void Add(SimpleModel item)
        {
            db.SimpleModels.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            SimpleModel item = db.SimpleModels.Find(id);
            if (item != null)
                db.SimpleModels.Remove(item);
            Save();
        }

        public void Edit(SimpleModel item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public List<SimpleModel> GetAll()
        {
            return db.SimpleModels.ToList();
        }

        public SimpleModel GetById(int id)
        {
            return db.SimpleModels.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!dispose)
            {
                if (disposing)
                {
                    db.Dispose();
                }

               dispose = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
