using RadosCafee.Application.Common.Mappings.Interfaces;
using RadosCafee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Application.Features.Meals.Queries.GetAllMeals
{
    public class GetAllMealsDto : IMapFrom<Meal>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string MealCategory { get; set; }
        public bool HasPromotion { get; set; } = false;

    }
}
