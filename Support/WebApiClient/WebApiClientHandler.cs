namespace Rapport.Support.WebApiClient
{
    public static class WebApiClientHandler
    {
        private static WebApiClient _wc = null;
        public static WebApiClient Get()
        {
            if( _wc==null )
            {
                _wc = WebApiClientBuilder.Build();
            }

            return _wc;
        }     
    }
}
