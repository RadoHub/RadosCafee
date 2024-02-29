using RadosCafee.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NotUtc =>  DateTime.UtcNow;
    }
}
