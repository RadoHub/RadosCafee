using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadosCafee.Application.Features.Meals.Commands;
using RadosCafee.Application.Features.Meals.Queries.GetAllMeals;
using RadosCafee.Shared.Concrete;

namespace RadosCafee.WebAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private IMediator _mediator;
        public MealController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllMealsDto>>>> GetMeals()
        {
            return await _mediator.Send(new GetAllMealsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateMealCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
