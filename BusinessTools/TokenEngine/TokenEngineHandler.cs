namespace Rapport.BusinessTools.TokenEngine
{
    using System;

    public static class TokenEngineHandler
    {
        private static TokenEngineController _currTE = null;
        public static TokenEngineController Get(String waUrl, String auURLPart, String loURLPart)
        {
            if( _currTE==null )
            {
                _currTE = new TokenEngineController(waUrl, auURLPart, loURLPart);
            }

            return _currTE;
        }
    }
}
