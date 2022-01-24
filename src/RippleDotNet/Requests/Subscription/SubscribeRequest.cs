using Newtonsoft.Json;

namespace RippleDotNet.Requests.Subscription
{
    public class SubscribeRequest : RippleRequest
    {
        public SubscribeRequest()
        {
            Command = "subscribe";
        }
    }
}
