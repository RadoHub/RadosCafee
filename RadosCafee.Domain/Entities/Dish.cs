using RadosCafee.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Domain.Entities
{
    public class Dish: AuditableEntity
    {
        public string Name { get; set; }
        public bool Visible { get; set; } = false;
        public decimal Price { get; set; }
        public string Description { get; set; }

        public int DishCategoryId { get; set; }
        public DishCategory DishCategory { get; set; }

        public int MealId { get; set; }
        public Meal MealDish { get; set; }

        public virtual ICollection<DishIngredient> DishIngredients { get; set; }
    }
}
