using RadosCafee.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Domain.Entities
{
    public class Admin : IEntity
    {
        public string Name { get; set; }
        public int Password { get; set; }
        public int Id { get  ; set ; }
    }
}
