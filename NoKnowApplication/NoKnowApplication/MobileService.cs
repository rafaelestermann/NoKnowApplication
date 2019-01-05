using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;

namespace NoKnowApplication
{
    public static class MobileService
    {
        private static MobileServiceClient _mobileServiceClient;

        public static MobileServiceClient MobileServiceClient
        {
            get
            {
                if (_mobileServiceClient != null)
                {
                    return _mobileServiceClient;
                }
                else
                {
                   return _mobileServiceClient = new MobileServiceClient(
                        "https://noknow.azurewebsites.net"
                    );
                }
            }
        }
    }
}
