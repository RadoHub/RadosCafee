using RadosCafee.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Domain.Entities
{
    public class Meal : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string MealCategory { get; set; }
        public bool HasPromotion { get; set; } = false;

        public ICollection<Dish> MealDishes { get; set; }
        public ICollection<MealPromotion> MealPromotion { get; set; }
    }
}
