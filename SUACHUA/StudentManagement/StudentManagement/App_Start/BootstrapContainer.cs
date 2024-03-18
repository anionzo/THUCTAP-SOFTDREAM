using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StudentManagement.App_Start
{
    public class BootstrapContainer : IContainerAccessor,IDisposable
    {
        readonly IWindsorContainer _container;

        BootstrapContainer(IWindsorContainer container)
        {
            this._container = container;
        }

        public IWindsorContainer Container
        {
            get { return _container; }
        }

        public static BootstrapContainer Bootstrap()
        {
            var container = new WindsorContainer()
                .Install(FromAssembly.This());
            return new BootstrapContainer(container);
        }

        public void Dispose()
        {
            Container.Dispose();
        }

    }
}