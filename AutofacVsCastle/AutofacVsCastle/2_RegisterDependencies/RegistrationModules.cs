using Autofac;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
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
                builder.RegisterType<DummyDummy>().As<IDummy>();
                builder.RegisterType<DummyFunc>().As<IDummyFunc>();
                builder.RegisterType<DummyEnumerable>();
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
                container.Register(Component.For<IDummy>().ImplementedBy<DummyDummy>());
                container.Register(Component.For<IDummyFunc>().ImplementedBy<DummyFunc>());
                container.Register(Component.For<DummyEnumerable>());
            }
        }

        public WindsorContainer RegisterCastle()
        {
            var container = new WindsorContainer();
            container.AddFacility<TypedFactoryFacility>();
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            container.Install(new Installer());

            return container;
        }

        #endregion
    }
}
