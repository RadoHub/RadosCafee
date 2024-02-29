using MediatR;
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
    public record  DeleteMealCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public DeleteMealCommand(int id)
        {
            Id = id;
        }
    }

    internal class DeleteMealCommandHandler : IRequestHandler<DeleteMealCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteMealCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(DeleteMealCommand command, CancellationToken cancellationToken)
        {
            var meal = await _unitOfWork.Repository<Meal>().GetByIdAsync(command.Id);

            if (meal != null) 
            {
                await _unitOfWork.Repository<Meal>().DeleteAsync(meal);
                meal.AddDomainEvent(new MealDeleteEvent(meal));

                await _unitOfWork.Save(cancellationToken);
                return await Result<int>.SuccessAsync(meal.Id, "Meal is deleted");
            }
            else { 
                return await Result<int>.FailureAsync("Meal is not found"); 
            }
        }
    }
}
