using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RadosCafee.Application.Interfaces.Repositories;
using RadosCafee.Domain.Entities;
using RadosCafee.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Application.Features.Meals.Queries.GetAllMeals
{
    public record GetAllMealsQuery : IRequest<Result<List<GetAllMealsDto>>>;

    internal class GetAllMealsQueryHandler : IRequestHandler<GetAllMealsQuery, Result<List<GetAllMealsDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllMealsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<List<GetAllMealsDto>>> Handle(GetAllMealsQuery query, CancellationToken cancellationToken)
        {
            var meals = await _unitOfWork.Repository<Meal>().Entities.ProjectTo<GetAllMealsDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return await Result<List<GetAllMealsDto>>.SuccessAsync(meals);
        }
    }
}
