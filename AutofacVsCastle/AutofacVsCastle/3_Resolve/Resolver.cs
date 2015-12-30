using Autofac;
using Castle.Windsor;
using Xunit;

namespace AutofacVsCastle
{
    public class Resolver
    {
        #region Constructor
        protected readonly Registration registration;

        public Resolver()
        {
            this.registration = new Registration();
        }
        #endregion

        [Fact]
        public void Autofac()
        {
            IContainer autofacContainer = this.registration.RegisterAutofac();

            var dummy = autofacContainer.Resolve<IDummy>();

            Assert.NotNull(dummy);
        }

        [Fact]
        public void Castle()
        {
            WindsorContainer windsorContainer = this.registration.RegisterCastle();

            var dummy = windsorContainer.Resolve<IDummy>();

            Assert.NotNull(dummy);
        }        
    }
}
