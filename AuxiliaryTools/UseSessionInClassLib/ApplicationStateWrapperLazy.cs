namespace Rapport.AuxiliaryTools.AspNetStoragesInClassLib
{
    using System;
    using System.Web;
    using System.Web.SessionState;

    using Rapport.AuxiliaryTools.GenericsAndTemplates;

    public class ApplicationStateWrapperLazy : LazyInitializer<SessionStateWrapperLazy>
    {
        private HttpApplicationState _currLocalApplication = null;

        private ApplicationStateWrapperLazy()
        {
            HttpContext ctx = HttpContext.Current;
            _currLocalApplication = ctx.ApplicationInstance.Application;
        }

        public Object this[String index]
        {
            get
            {
                return _currLocalApplication[index];
            }
            set
            {
                _currLocalApplication[index] = value;
            }
        }

        public void Remove(String index)
        {
            _currLocalApplication.Remove(index);
        }

        public Boolean IsSet(String key)
        {
            Object currValue = _currLocalApplication[key];
            if (currValue == null)
                return false;
            else
                return true;
        }
    }
}
