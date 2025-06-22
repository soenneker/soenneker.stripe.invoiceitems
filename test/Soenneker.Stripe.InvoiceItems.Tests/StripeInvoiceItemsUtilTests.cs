using Soenneker.Stripe.InvoiceItems.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Stripe.InvoiceItems.Tests;

[Collection("Collection")]
public sealed class StripeInvoiceItemsUtilTests : FixturedUnitTest
{
    private readonly IStripeInvoiceItemsUtil _util;

    public StripeInvoiceItemsUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IStripeInvoiceItemsUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
