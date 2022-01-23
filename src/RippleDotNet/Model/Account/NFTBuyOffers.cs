using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RippleDotNet.Json.Converters;

namespace RippleDotNet.Model.Account
{
    public class NFTSellOffers
    {

        [JsonProperty("offers")]
        public List<NFTOffer> Offers { get; set; }

        [JsonProperty("tokenid")]
        public string TokenId { get; set; }
    }

    // public class NFTOffer...
}
