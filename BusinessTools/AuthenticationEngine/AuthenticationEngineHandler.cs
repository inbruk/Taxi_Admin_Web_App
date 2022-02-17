namespace Rapport.BusinessTools.AuthenticationEngine
{
    using System;

    public static class AuthenticationEngineHandler
    {
        private static AuthenticationEngine _currAE = null;
        public static AuthenticationEngine Get()
        {
            if (_currAE == null)
            {
                _currAE = new AuthenticationEngine();
            }

            return _currAE;
        }
    }
}
