using System;

namespace SeleniumTests.Base
{
    public class Basic
    {
        public Basic CurrentPage { get; set; }
        protected static TPage GetInstance<TPage>() where TPage : BasicPage, new()
        {
            return (TPage) Activator.CreateInstance(typeof(TPage));
        }

        public TPage As<TPage>() where TPage : BasicPage
        {
            return (TPage)this;
        }
    }
}
