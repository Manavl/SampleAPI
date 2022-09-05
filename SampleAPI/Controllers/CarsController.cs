using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleLibrary.Car.Commands;
using SampleLibrary.Car.Dto;
using SampleLibrary.Car.Queries;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarDto>>> GetAllCars()
        {
            return Ok(await _mediator.Send(new GetCarListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetCarById(int id)
        {
            return Ok(await _mediator.Send(new GetCarByIdQuery(id)));
        }

        [HttpPost]
        public async Task<ActionResult<CarDto>> InsertCar([FromBody] CarDto car)
        {
            return Ok(await _mediator.Send(new InsertCarCommand(car)));
        }
    }
}
