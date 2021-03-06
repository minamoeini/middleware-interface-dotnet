﻿using fiskaltrust.ifPOS.v1;
using fiskaltrust.Middleware.Interface.Client.Shared;
using System.Threading.Tasks;

namespace fiskaltrust.Middleware.Interface.Client.Soap
{
    public static class SoapPosFactory
    {
        public static async Task<IPOS> CreatePosAsync(PosOptions options)
        {
            var connectionhandler = new SoapProxyConnectionHandler<IPOS>(options);

            if (options.RetryPolicyOptions != null)
            {
                var retryPolicyHelper = new RetryPolicyHandler<IPOS>(options.RetryPolicyOptions, connectionhandler);
                return new PosRetryProxyClient(retryPolicyHelper);
            }
            else
            {
                return await connectionhandler.GetProxyAsync();
            }
        }
    }
}
