namespace Rapport.AuxiliaryTools.AspNetStoragesInClassLib
{
    using System;
    using System.Web;
    using System.Web.SessionState;

    using Rapport.AuxiliaryTools.GenericsAndTemplates;

    // пока таймаут сессии по умолчанию - 20 минут, 
    // позже, если захочется поменять, то можно сменить его 
    public class SessionStateWrapperLazy : LazyInitializer <SessionStateWrapperLazy>
    {
        private HttpSessionState _currLocalSession = null;

        public SessionStateWrapperLazy()
        {
            HttpContext ctx = HttpContext.Current;
            _currLocalSession = ctx.ApplicationInstance.Session;
        }

        public Object this[String index]
        {
            get
            {
                return _currLocalSession[index];
            }
            set
            {
                _currLocalSession[index] = value;
            }
        }

        public void Remove(String index)
        {
            _currLocalSession.Remove(index);
        }

        public Boolean IsSet(String key)
        {
            Object currValue = _currLocalSession[key];
            if (currValue == null)
                return false;
            else
                return true;
        }
    }
}
