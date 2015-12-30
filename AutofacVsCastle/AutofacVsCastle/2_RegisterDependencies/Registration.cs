using Autofac;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace AutofacVsCastle
{
    public class Registration
    {
        public void RegisterAutofac()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<Dummy>().As<IDummy>();

            var container = containerBuilder.Build();

            var dummy = container.Resolve<IDummy>();
        }

        public void RegisterCastle()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IDummy>().ImplementedBy<Dummy>());

            var dummy = container.Resolve<IDummy>();
        }
    }
}
