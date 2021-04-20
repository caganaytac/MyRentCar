
using Core.Entities;


namespace Entities.DTOs
{
    public class CarDetailsDto : IDto
    {
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public decimal DailyPrice { get; set; }
        public string ColorName { get; set; }
        public string ModelYear { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public bool Status { get; set; }
        public int CreditScore { get; set; }
    }
}
