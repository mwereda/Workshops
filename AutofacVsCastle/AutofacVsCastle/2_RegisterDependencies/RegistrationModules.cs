using Autofac;
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
            }
        }

        public void RegisterAutofac()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AutofacModule>();

            var container = containerBuilder.Build();

            var dummy = container.Resolve<IDummy>();
        }

        #endregion

        #region Castle

        internal class Installer : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Register(Component.For<IDummy>().ImplementedBy<Dummy>());
            }
        }

        public void RegisterCastle()
        {
            var container = new WindsorContainer();
            container.Install(new Installer());

            var dummy = container.Resolve<IDummy>();
        }

        #endregion
    }
}
