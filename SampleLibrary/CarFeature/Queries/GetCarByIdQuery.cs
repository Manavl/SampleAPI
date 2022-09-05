using MediatR;
using SampleLibrary.Caching;
using SampleLibrary.Car.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary.Car.Queries
{
    //First option => record
    public record GetCarByIdQuery(int Id) : IRequest<CarDto>, ICacheable
    {
        public string CacheKey => $"GetCarById-{Id}";
        public DateTime? Expiration => DateTime.Now.AddHours(1);
    }


    //Second option => class
    //public class GetCarByIdQuery : IRequest<CarDto>
    //{
    //    public int Id { get; set; }

    //    public GetCarByIdQuery(int id)
    //    {
    //        Id = id;
    //    }
    //}

    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarDto>
    {
        private readonly IMediator _mediator;
        public GetCarByIdQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CarDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var cars = await _mediator.Send(new GetCarListQuery());
            var car = cars.FirstOrDefault(x => x.Id == request.Id);

            return car;
        }
    }
}
