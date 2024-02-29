using RadosCafee.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Domain.Entities
{
    public class DishCategory : AuditableEntity
    {
        public string Name { get; set; }

        public ICollection<Dish> Dishes { get; set; }
    }
}
