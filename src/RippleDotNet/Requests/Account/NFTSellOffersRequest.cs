using Newtonsoft.Json;

namespace RippleDotNet.Requests.Account
{
    public class NFTSellOffersRequest : BaseLedgerRequest
    {
        public NFTSellOffersRequest(string tokenid)
        {
            TokenId = tokenid;
            Command = "nft_sell_offers";
        }

        [JsonProperty("tokenid")]
        public string TokenId { get; set; }
    }
}
