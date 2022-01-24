using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ripple.Core.Types;
using Ripple.TxSigning;
using RippleDotNet.Extensions;
using RippleDotNet.Json.Converters;
using RippleDotNet.Model;
using RippleDotNet.Model.Account;
using RippleDotNet.Model.Transaction;
using RippleDotNet.Model.Transaction.Interfaces;
using RippleDotNet.Model.Transaction.TransactionTypes;
using RippleDotNet.Requests.Ledger;
using RippleDotNet.Requests.Transaction;
using RippleDotNet.Responses.Transaction.Interfaces;
using Currency = RippleDotNet.Model.Currency;

namespace RippleDotNet.Tests
{
    [TestClass]
    public class SubscribeTests
    {
        private static IRippleClient xls20client;
        private static JsonSerializerSettings serializerSettings;

        private static string xls20Url = "wss://xls20-sandbox.rippletest.net:51233";


        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {

            xls20client = new RippleClient(xls20Url);
            xls20client.Connect();

            serializerSettings = new JsonSerializerSettings();
            serializerSettings.NullValueHandling = NullValueHandling.Ignore;
            serializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            serializerSettings.Converters.Add(new TransactionConverter());
        }


        [TestMethod]
        public async Task CanSubscribe()
        {
            var closedLedger = await xls20client.Subscribe();
            Assert.IsNotNull(closedLedger);
        }
    }
}
