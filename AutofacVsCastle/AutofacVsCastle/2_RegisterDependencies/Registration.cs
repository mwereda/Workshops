using Autofac;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace AutofacVsCastle
{
    public class Registration
    {
        public IContainer RegisterAutofac()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<Dummy>().As<IDummy>();

            var container = containerBuilder.Build();

            return container;
        }

        public WindsorContainer RegisterCastle()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IDummy>().ImplementedBy<Dummy>());

            return container;
        }
    }
}
