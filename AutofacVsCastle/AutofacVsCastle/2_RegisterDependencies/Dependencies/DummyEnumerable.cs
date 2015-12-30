using System.Collections.Generic;

namespace AutofacVsCastle
{
    public class DummyEnumerable
    {
        private readonly IEnumerable<IDummy> dummies;

        public IEnumerable<IDummy> Dummies
        {
            get
            {
                return this.dummies;
            }
        }

        public DummyEnumerable(IEnumerable<IDummy> dummies)
        {
            this.dummies = dummies;
        }
    }
}
