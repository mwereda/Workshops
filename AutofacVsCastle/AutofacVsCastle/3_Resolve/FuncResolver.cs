using Autofac;
using Castle.Windsor;
using Xunit;

namespace AutofacVsCastle
{
    public class FuncResolver
    {
        #region Constructor
        protected readonly RegistrationModules registration;

        public FuncResolver()
        {
            this.registration = new RegistrationModules();
        }
        #endregion

        [Fact]
        public void Autofac()
        {
            IContainer autofacContainer = this.registration.RegisterAutofac();
            
            var dummy = autofacContainer.Resolve<IDummyFunc>();

            Assert.NotNull(dummy);
        }

        [Fact]
        public void Castle()
        {
            WindsorContainer windsorContainer = this.registration.RegisterCastle();

            var dummy = windsorContainer.Resolve<IDummyFunc>();

            Assert.NotNull(dummy);
        }
    }
}
