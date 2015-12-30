using System;

namespace AutofacVsCastle
{
    public class DummyFunc : IDummyFunc
    {
        private readonly IDummy dummy;

        public DummyFunc(Func<IDummy> factory)
        {
            this.dummy = factory();
        }
    }
}
