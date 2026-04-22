using Soenneker.Stripe.InvoiceItems.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Stripe.InvoiceItems.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class StripeInvoiceItemsUtilTests : HostedUnitTest
{
    private readonly IStripeInvoiceItemsUtil _util;

    public StripeInvoiceItemsUtilTests(Host host) : base(host)
    {
        _util = Resolve<IStripeInvoiceItemsUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
