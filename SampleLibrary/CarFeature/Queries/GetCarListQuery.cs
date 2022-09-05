using MediatR;
using SampleLibrary.Car.Data;
using SampleLibrary.Car.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary.Car.Queries
{
    //First option how to implement query - record
    public record GetCarListQuery() : IRequest<List<CarDto>>;

    //Second option how to implement query - class
    //public class GetCarListQuery : IRequst<List<CarDto>>
    //{

    //}

    //In .NET 6, the most picked option is to put handler into the same file as query/command
    //Depends of personal preference, it can still be in separate file
    public class GetCarListQueryHandler : IRequestHandler<GetCarListQuery, List<CarDto>>
    {
        private readonly IDataAccess _data;

        public GetCarListQueryHandler(IDataAccess data)
        {
            _data = data;
        }

        public Task<List<CarDto>> Handle(GetCarListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.GetAllCars());
        }
    }
}
