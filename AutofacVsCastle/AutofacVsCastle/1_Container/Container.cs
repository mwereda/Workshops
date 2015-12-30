using Autofac;
using Castle.Windsor;

namespace AutofacVsCastle
{
    public class Container
    {
        public void CreateAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();

            var container = containerBuilder.Build();
        }

        public void CreateCastleContainer()
        {
            var container = new WindsorContainer();            
        }
    }
}
