﻿namespace Merchello.Tests.Braintree.Integration.TestHelpers
{
    using System;

    using global::Braintree;

    using Merchello.Core.Persistence.UnitOfWork;
    using Merchello.Core.Services;
    using Merchello.Plugin.Payments.Braintree;
    using Merchello.Plugin.Payments.Braintree.Models;

    using NUnit.Framework;

    public abstract class BraintreeTestBase
    {
        protected BraintreeProviderSettings BraintreeProviderSettings;

        protected Guid CustomerKey = new Guid("1A6E8170-9CB9-41C0-B944-36F16B97BED2");

        protected BraintreeGateway Gateway;

        [TestFixtureSetUp]
        public virtual void TestFixtureSetup()
        {
            BraintreeProviderSettings = TestHelper.GetBraintreeProviderSettings();

            SqlSyntaxProviderTestHelper.EstablishSqlSyntax();

            var serviceContext = new ServiceContext(new PetaPocoUnitOfWorkProvider());
            
            AutoMapperMappings.CreateMappings();

            Gateway = BraintreeProviderSettings.AsBraintreeGateway();
        }
    }
}