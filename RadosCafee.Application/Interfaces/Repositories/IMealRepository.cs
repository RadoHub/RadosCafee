using RadosCafee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Application.Interfaces.Repositories
{
    public  interface IMealRepository
    {
        Task<List<Meal>> GetLast5Meals();
        Task<List<Meal>> GetMealsByDishId(int id);
        Task<List<Meal>> GetMealsByPromotions();
        Task<List<Meal>> GetMealsByDishCategory(int id);
        Task<Meal> GetMealByNameAsync(string name);
    }
}
