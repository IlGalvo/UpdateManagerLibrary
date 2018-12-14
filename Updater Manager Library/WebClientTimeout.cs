using System;
using System.Net;

namespace UpdaterManagerLibrary
{
    internal sealed class WebClientTimeout : WebClient
    {
        private int? connectionTimeout;

        public WebClientTimeout()
        {
            connectionTimeout = null;
        }

        public WebClientTimeout(int connectionTimeout)
        {
            this.connectionTimeout = connectionTimeout;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest webRequest = base.GetWebRequest(address);

            if (connectionTimeout != null)
            {
                webRequest.Timeout = ((int)connectionTimeout);
            }

            return webRequest;
        }
    }
}
