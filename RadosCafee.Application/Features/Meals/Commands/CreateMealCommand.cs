using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using RadosCafee.Application.Common.Mappings.Interfaces;
using RadosCafee.Application.Interfaces.Repositories;
using RadosCafee.Domain.Entities;
using RadosCafee.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Application.Features.Meals.Commands
{
    public record CreateMealCommand : IRequest<Result<int>>, IMapFrom<Meal>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string MealCategory { get; set; }
        public bool HasPromotion { get; set; } = false;
    }

    internal class CreatMealCommandHandler : IRequestHandler<CreateMealCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMealRepository _mealRepository;

        public CreatMealCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<int>> Handle(CreateMealCommand command, CancellationToken cancellationToken)
        {

             
            var meal = new Meal()
            {
                Name= command.Name,
                Description= command.Description,
                Price= command.Price,
                MealCategory= command.MealCategory,
                HasPromotion= command.HasPromotion
            };
            await _unitOfWork.Repository<Meal>().AddAsync(meal);
            meal.AddDomainEvent(new MealCreatedEvent(meal));
            await _unitOfWork.Save(cancellationToken);
            return await Result<int>.SuccessAsync(meal.Id, "Meal is created");
        }
    }
}
