using Newtonsoft.Json;

namespace RippleDotNet.Requests.Account
{
    public class NFTBuyOffersRequest : BaseLedgerRequest
    {
        public NFTBuyOffersRequest(string tokenid)
        {
            TokenId = tokenid;
            Command = "nft_sell_offers";
        }

        [JsonProperty("tokenid")]
        public string TokenId { get; set; }
    }
}
