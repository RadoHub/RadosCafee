using Microsoft.EntityFrameworkCore;
using RadosCafee.Application.Interfaces.Repositories;
using RadosCafee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Persistence.Repositories
{
    public class MealRepository : IMealRepository
    {
        private readonly IGenericRepository<Meal> _repository;
        public MealRepository(IGenericRepository<Meal> repository)
        {
            _repository = repository;
        }
        public async Task<List<Meal>> GetLast5Meals()
        {
            return await _repository.Entities.OrderByDescending(x=> x.CreatedDate).Take(5).ToListAsync();
        }

        public Task<Meal> GetMealByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Meal>> GetMealsByDishCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Meal>> GetMealsByDishId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Meal>> GetMealsByPromotions()
        {
            throw new NotImplementedException();
        }
    }
}
