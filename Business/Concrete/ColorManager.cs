using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colordal;

        public ColorManager(IColorDal colordal)
        {
            _colordal = colordal;
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colordal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colordal.Get(p=>p.ColorId == id));
        }

        public IResult AddColor(Color color)
        {
            _colordal.Add(color);
            return new SuccessResult("Color added successfully.");
        }


        public IResult DeleteColor(Color color)
        {
            _colordal.Delete(color);
            return new SuccessResult("Color deleted successfully.");
        }

        public IResult UpdateColor(Color color)
        {
            _colordal.Update(color);
            return new SuccessResult("Color updated successfully.");
        }
    }
}
