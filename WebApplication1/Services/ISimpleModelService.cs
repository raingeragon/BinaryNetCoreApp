using BinaryNetCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryNetCoreApp.Services
{
    public interface ISimpleModelService
    {
        Task<List<SimpleModel>> GetAllAsync();
        Task<SimpleModel> GetByIdAsync(int id);
        Task CreateAsync(SimpleModel item);
        Task DeleteAsync(int id);
        Task EditAsync(SimpleModel item);
        Task SaveAsync();
        Task DeleteAllAsync();
    }
}
