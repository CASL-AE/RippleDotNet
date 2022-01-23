﻿using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ripple.Core.Types;
using RippleDotNet.Model;
using RippleDotNet.Requests.Ledger;

namespace RippleDotNet.Tests
{
    [TestClass]
    public class LedgerTests
    {
        private static IRippleClient client;
        private static IRippleClient xls20client;

        private static string serverUrl = "wss://s1.ripple.com:443";
        //private static string serverUrl = "wss://s.altnet.rippletest.net:51233";
        private static string xls20Url = "wss://xls20-sandbox.rippletest.net:51233";

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            client = new RippleClient(serverUrl);
            client.Connect();

            xls20client = new RippleClient(xls20Url);
            xls20client.Connect();
        }

        [TestMethod]
        public async Task CanGetLedger()
        {
            var request = new LedgerRequest {LedgerIndex = new LedgerIndex(LedgerIndexType.Validated), Transactions = true, Expand = true, Binary = true};

            var ledger = await client.Ledger(request);

            Assert.AreNotEqual(ledger.LedgerEntity.Transactions.Count, 0);
            Assert.IsNotNull(ledger);
        }

        [TestMethod]
        public async Task CanGetClosedLedger()
        {
            var ledger = await client.ClosedLedger();
            Assert.IsNotNull(ledger);
        }

        [TestMethod]
        public async Task CanGetCurrentLedger()
        {
            var ledger = await client.CurrentLedger();
            Assert.IsNotNull(ledger);
        }

        [TestMethod]
        public async Task CanGetLedgerData()
        {
            var closedLedger = await client.ClosedLedger();
            LedgerDataRequest request = new LedgerDataRequest();
            request.LedgerHash = closedLedger.LedgerHash;
            var ledgerData = await client.LedgerData(request);
            Assert.IsNotNull(ledgerData);
        }

        [TestMethod]
        public async Task CanGetLedgerDataAsBinary()
        {
            var closedLedger = await client.ClosedLedger();
            LedgerDataRequest request = new LedgerDataRequest();
            request.LedgerHash = closedLedger.LedgerHash;
            request.Binary = true;
            var ledgerData = await client.LedgerData(request);
            //ledgerData.State;
            Assert.IsNotNull(ledgerData);
        }

        [TestMethod]
        public void CanDecodeBinary()
        {
            string binary =
                "1100722200210000250178D1CA37000000000000000038000000000000028355C0C37CE200B509E0A529880634F7841A9EF4CB65F03C12E6004CFAD9718D66946280000000000000000000000000000000000000004743420000000000000000000000000000000000000000000000000166D6071AFD498D000000000000000000000000000047434200000000002599D1D255BCA61189CA64C84528F2FCBE4BFC3867800000000000000000000000000000000000000047434200000000006EEBB1D1852CE667876A0B3630861FB6C6AB358E";

            var obj = StObject.FromHex(binary);
            Assert.IsNotNull(obj);
        }       
    }
}
