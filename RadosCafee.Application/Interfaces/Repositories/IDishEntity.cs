using RadosCafee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Application.Interfaces.Repositories
{
    public interface IDishEntity
    {
        Task<List<Dish>> GetDishesByIngredientId(int id);
    }
}
