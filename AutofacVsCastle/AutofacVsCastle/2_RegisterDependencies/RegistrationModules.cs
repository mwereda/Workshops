using System;
using Autofac;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AutofacVsCastle
{
    public class RegistrationModules
    {
        #region Autofac

        internal class AutofacModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<Dummy>().As<IDummy>();
                builder.RegisterType<DummyFunc>().As<IDummyFunc>();
            }
        }

        public IContainer RegisterAutofac()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AutofacModule>();

            var container = containerBuilder.Build();

            return container;
        }

        #endregion

        #region Castle

        internal class Installer : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Register(Component.For<IDummy>().ImplementedBy<Dummy>());
                container.Register(Component.For<IDummyFunc>().ImplementedBy<DummyFunc>());
            }
        }

        public WindsorContainer RegisterCastle()
        {
            var container = new WindsorContainer();
            container.AddFacility<TypedFactoryFacility>();
            container.Install(new Installer());

            return container;
        }

        #endregion
    }
}
