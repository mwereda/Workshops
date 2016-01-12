using System.Linq;
using Autofac;
using Castle.Windsor;
using Xunit;

namespace AutofacVsCastle
{
    public class EnumerableResolver
    {
        #region Constructor
        protected readonly RegistrationModules registration;

        public EnumerableResolver()
        {
            this.registration = new RegistrationModules();
        }
        #endregion

        [Fact]
        public void Autofac()
        {
            IContainer autofacContainer = this.registration.RegisterAutofac();

            var dummy = autofacContainer.Resolve<DummyEnumerable>();

            Assert.NotNull(dummy);
            Assert.Equal(2, dummy.Dummies.Count());
        }

        [Fact]
        public void Castle()
        {
            WindsorContainer windsorContainer = this.registration.RegisterCastle();

            var dummy = windsorContainer.Resolve<DummyEnumerable>();

            Assert.NotNull(dummy);
            Assert.Equal(2, dummy.Dummies.Count());
        }
    }
}
