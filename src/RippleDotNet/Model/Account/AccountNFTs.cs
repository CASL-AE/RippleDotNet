using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RippleDotNet.Model.Account
{
    public class AccountNFTs
    {
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("account_nfts")]
        public List<NFT> NFTs { get; set; }

        [JsonProperty("ledger_current_index")]
        public uint? LedgerCurrentIndex { get; set; }

        [JsonProperty("validated")]
        public bool Validated { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        [JsonProperty("marker")]
        public object Marker { get; set; }
    }

    public class NFT
    {
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("token_id")]
        public string TokenID { get; set; }

        [JsonProperty("token_taxon")]
        public string TokenTaxon { get; set; }

        [JsonProperty("nft_serial")]
        public string NFTSerial { get; set; }
    }
}
