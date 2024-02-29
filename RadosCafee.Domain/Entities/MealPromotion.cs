using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Domain.Entities
{
    public  class MealPromotion
    {
        public int MealId { get; set; }
        public Meal Meal { get; set; }

        public int PromotionId { get; set; }
        public Promotion Promotion { get; set; }

    }
}
