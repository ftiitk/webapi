using SweetShoppp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetShoppp.Repositories
{
    public interface ICakeRepository
    {
        Task<IEnumerable<Cake>> Get();
        Task<Cake> Get(int id);
        Task<Cake> Create(Cake Cake);
        Task Update(Cake Cake);
        Task Delete(int id);
    }
}
