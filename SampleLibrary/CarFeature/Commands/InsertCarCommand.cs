using MediatR;
using SampleLibrary.Car.Data;
using SampleLibrary.Car.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary.Car.Commands
{
    //First option => record
    public record InsertCarCommand(CarDto car) : IRequest<CarDto>;

    //Second option => class
    //public class InsertCarCommand : IRequest<CarDto>
    //{
    //    private CarDto _car;

    //    public InsertCarCommand(CarDto car)
    //    {
    //        _car = car;
    //    }
    //}

    public class InsertCarCommandHandler : IRequestHandler<InsertCarCommand, CarDto>
    {
        private readonly IDataAccess _data;

        public InsertCarCommandHandler(IDataAccess data)
        {
            _data = data;
        }

        public Task<CarDto> Handle(InsertCarCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.InsertNewCar(request.car.Brand, request.car.Model, request.car.Price));
        }
    }
}
