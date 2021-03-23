using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<RentalDetailsDto>> GetAllRentalsDto();
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailsDto>> GetRentalsDto(int carId);
        IDataResult<Rental> GetByRentalId(int id);
        IResult CheckReturnDate(int carId);
        IResult AddRental(Rental rental);
        IResult UpdateRental(Rental rental);
        IResult DeleteRental(Rental rental);
    }
}
