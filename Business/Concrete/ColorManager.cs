using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colordal;

        public ColorManager(IColorDal colordal)
        {
            _colordal = colordal;
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colordal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colordal.Get(p => p.ColorId == id));
        }

        //[SecuredOperation("color.delete,editor,admin")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult AddColor(Color color)
        {
            IResult result = BusinessRules.Run(CheckIfColorAlreadyExists(color.ColorName));
            if (result != null)
            {
                return result;
            }
            _colordal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        //[SecuredOperation("color.delete,editor,admin")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult DeleteColor(Color color)
        {
            _colordal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        //[SecuredOperation("color.delete,editor,admin")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult UpdateColor(Color color)
        {
            _colordal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }

        //Business Codes
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
