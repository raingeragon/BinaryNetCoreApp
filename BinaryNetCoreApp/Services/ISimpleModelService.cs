using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BinaryNetCoreApp.Models;

namespace BinaryNetCoreApp.Services
{
    public interface ISimpleModelService : IDisposable
    {
        List<SimpleModel> GetAll();
        SimpleModel GetById(int id);
        void Add(SimpleModel item);
        void Delete(int id);
        void Edit(SimpleModel item);
        void Save();
    }
}
