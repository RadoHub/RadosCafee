using RadosCafee.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Domain.Entities
{
    public class Promotion: AuditableEntity
    {
        public string Name { get; set; }
        public decimal  Percentage { get; set; }
        public ICollection<MealPromotion> MealPromotions { get; set; }
    }
}
