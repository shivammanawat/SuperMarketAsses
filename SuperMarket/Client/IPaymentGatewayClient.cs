using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Client
{
   public interface IPaymentGatewayClient
    {
        Task<HttpResponseMessage> GetAsync( string requestUri);
    }
}
