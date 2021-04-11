using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        private IPaymentService _paymentService;
        public RentalsController(IRentalService rentalService, IPaymentService paymentService)
        {
            _rentalService = rentalService;
            _paymentService = paymentService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetByRentalId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getdetails")]
        public IActionResult GetDetails()
        {
            var result = _rentalService.GetAllRentalsDto();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(PaymentDto paymentDto)
        {
            var result = _rentalService.AddRental(paymentDto.Rental, paymentDto.Payment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.UpdateRental(rental);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.DeleteRental(rental);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        //[HttpPost("paymentadd")]
        //public ActionResult PaymentAdd(PaymentDto rentalPaymentDto)
        //{
        //    var paymentResult = _paymentService.Add(rentalPaymentDto.Payment);
        //    if (paymentResult.Success)
        //    {
        //        var result = _rentalService.AddRental(rentalPaymentDto.Rental);

        //        if (result.Success)
        //        {
        //            return Ok(result);
        //        }
        //        return BadRequest(result.Message);
        //    }
        //    return BadRequest(paymentResult);

        //}
    }
}
