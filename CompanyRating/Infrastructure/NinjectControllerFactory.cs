using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Domain.Entities;
using Domain.Abstract;
using Domain.Concrete;
using CompanyRating.Infrastructure.Abstract;
using CompanyRating.Infrastructure.Concrete;

namespace CompanyRating.Infrastructure
{
    //пользовательская фабрика контроллеров
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            // создание контейнера
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            // получение объекта контроллера из контейнера используя его тип
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<IReviewRepository>().To<EFReviewRepository>();
            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}