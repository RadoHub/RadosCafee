﻿using RadosCafee.Domain.Common;
using RadosCafee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Application.Features.Meals.Commands
{
    public class MealUpdateEvent : BaseEvent
    {
        public Meal Meal { get; set; }
        public MealUpdateEvent(Meal meal)
        {
            Meal = meal;
        }
    }
}
