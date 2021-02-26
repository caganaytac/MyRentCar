using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Contants;
using Core.Utilities.Business;
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
            return new SuccessDataResult<Color>(_colordal.Get(p => p.ColorId == id));
        }

        public IResult AddColor(Color color)
        {
            IResult result = BusinessRules.Run(CheckIfColorAlreadyExists(color.ColorName), CheckIfColorLimitExceeded());
            if (result != null)
            {
                return result;
            }
            _colordal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }


        public IResult DeleteColor(Color color)
        {
            _colordal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IResult UpdateColor(Color color)
        {
            _colordal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }

        private IResult CheckIfColorLimitExceeded()
        {
            var result = _colordal.GetAll().Count;
            if (result > 10)
            {
                return new ErrorResult(Messages.ColorCountLimitExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfColorAlreadyExists(string name)
        {
            var result = _colordal.GetAll(b => b.ColorName == name).Any();
            if (result)
            {
                return new ErrorResult(Messages.ColorNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
