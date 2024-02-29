using MediatR;
using RadosCafee.Application.Features.Meals.Commands;
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
    public record UpdateMealCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string MealCategory { get; set; }
        public bool HasPromotion { get; set; } = false;
    }
}

internal class UpdateMealCommandHandler : IRequestHandler<UpdateMealCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateMealCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<int>> Handle(UpdateMealCommand command, CancellationToken cancellationToken)
    {
        var meal = await _unitOfWork.Repository<Meal>().GetByIdAsync(command.Id);
        if (meal != null) 
        { 
            meal.Name = command.Name;
            meal.Description = command.Description;
            meal.Price = command.Price;
            meal.MealCategory = command.MealCategory;
            meal.HasPromotion = command.HasPromotion;

            await _unitOfWork.Repository<Meal>().UpdateAsync(meal);
            meal.AddDomainEvent(new MealUpdateEvent(meal));
            await _unitOfWork.Save(cancellationToken);
            return await Result<int>.SuccessAsync(command.Id, "meal is updated");
        }
        else
        {
            return await Result<int>.FailureAsync("Meal has not found");
        }
    }
}
