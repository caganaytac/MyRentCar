using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class RentalDetailsDto : IDto
    {
        public string RenterName { get; set; }
        public string RenterSurname { get; set; }
        public string CarName { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string CarDescription { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }

    }
}
