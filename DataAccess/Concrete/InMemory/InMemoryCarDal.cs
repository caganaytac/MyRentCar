using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId = 1, BrandId = 2, ColorId = 1, ModelYear = "2015", DailyPrice = 200,Description = "Sanki kendi arabanızmış gibi rahat edeceksiniz ama unutmayın ki araba aslında sizin değil."},
                new Car{CarId = 2, BrandId = 2, ColorId = 2, ModelYear = "2010", DailyPrice = 150,Description = "Sanki kendi arabanızmış gibi rahat edeceksiniz ama unutmayın ki araba aslında sizin değil."},
                new Car{CarId = 3, BrandId = 3, ColorId = 3, ModelYear = "2007", DailyPrice = 140,Description = "Sanki kendi arabanızmış gibi rahat edeceksiniz ama unutmayın ki araba aslında sizin değil."},
                new Car{CarId = 4, BrandId = 3, ColorId = 2, ModelYear = "2003", DailyPrice = 120,Description = "Aga senin can güvenliğin yoksa benim de mal güvenliğim yok."},
                new Car{CarId = 5, BrandId = 3, ColorId = 1, ModelYear = "2001", DailyPrice = 100,Description = "Araba değil sen önemlisin canına dikkat et."},
                new Car{CarId = 6, BrandId = 1, ColorId = 5, ModelYear = "2021", DailyPrice = 1000,Description = "Küçük bir çizik dahi olursa kan dökerim.."},

            };
        }

        public InMemoryCarDal(List<Car> cars)
        {
            _cars = cars;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }



        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);

        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(p => p.CarId == carId).ToList();
        }

        void IEntityRepository<Car>.Add(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
