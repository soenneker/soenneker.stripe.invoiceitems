[![](https://img.shields.io/nuget/v/soenneker.stripe.invoiceitems.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.stripe.invoiceitems/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.stripe.invoiceitems/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.stripe.invoiceitems/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.stripe.invoiceitems.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.stripe.invoiceitems/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.stripe.invoiceitems/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.stripe.invoiceitems/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Stripe.InvoiceItems

Create, retrieve, update, list, and delete Stripe invoice items through an injectable, lazily initialized Stripe.net service.

## Installation

```bash
dotnet add package Soenneker.Stripe.InvoiceItems
```

## Configuration

```json
{
  "Stripe": {
    "SecretKey": "sk_test_..."
  }
}
```

## Usage

```csharp
using Soenneker.Stripe.InvoiceItems.Abstract;
using Soenneker.Stripe.InvoiceItems.Registrars;
using Stripe;

services.AddStripeInvoiceItemsUtilAsScoped();

InvoiceItem created = await invoiceItemsUtil.Create(
    new InvoiceItemCreateOptions
    {
        Customer = "cus_...",
        Amount = 2500,
        Currency = "usd",
        Description = "Additional services"
    },
    cancellationToken: cancellationToken);

StripeList<InvoiceItem> pending = await invoiceItemsUtil.List(
    new InvoiceItemListOptions
    {
        Customer = "cus_...",
        Pending = true,
        Limit = 25
    },
    cancellationToken: cancellationToken);
```

`Delete` permanently deletes the selected invoice item. Stripe API errors are logged and rethrown so callers can handle them normally.
