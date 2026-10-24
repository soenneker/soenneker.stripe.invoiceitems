using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Stripe.Client;
using Soenneker.Stripe.Client.Abstract;
using Soenneker.Stripe.OpenApiClient.Models;
using Soenneker.Stripe.InvoiceItems.Abstract;

namespace Soenneker.Stripe.InvoiceItems;

public sealed class StripeInvoiceItemsUtil(IStripeClientUtil client) : IStripeInvoiceItemsUtil
{
    public async ValueTask<Invoiceitem> Create(PostInvoiceitemsXWwwFormUrlencodedRequest options, StripeRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        var api = await client.Get(cancellationToken);
        return await api.V1.Invoiceitems.PostAsync(options, c => requestOptions?.Apply(c.Headers), cancellationToken)
            ?? throw new InvalidOperationException("Stripe returned an empty response.");
    }

    public async ValueTask<Invoiceitem> Get(string id, Soenneker.Stripe.OpenApiClient.V1.Invoiceitems.Item.WithInvoiceitemItemRequestBuilder.WithInvoiceitemItemRequestBuilderGetQueryParameters options, StripeRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        var api = await client.Get(cancellationToken);
        return await api.V1.Invoiceitems[id].GetAsync(new(), c => { c.QueryParameters = options; requestOptions?.Apply(c.Headers); }, cancellationToken)
            ?? throw new InvalidOperationException("Stripe returned an empty response.");
    }

    public async ValueTask<Invoiceitem> Update(string id, PostInvoiceitemsInvoiceitemXWwwFormUrlencodedRequest options, StripeRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        var api = await client.Get(cancellationToken);
        return await api.V1.Invoiceitems[id].PostAsync(options, c => requestOptions?.Apply(c.Headers), cancellationToken)
            ?? throw new InvalidOperationException("Stripe returned an empty response.");
    }

    public async ValueTask<DeletedInvoiceitem> Delete(string id, DeleteInvoiceitemsInvoiceitemXWwwFormUrlencodedRequest options, StripeRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        var api = await client.Get(cancellationToken);
        return await api.V1.Invoiceitems[id].DeleteAsync(options, c => requestOptions?.Apply(c.Headers), cancellationToken)
            ?? throw new InvalidOperationException("Stripe returned an empty response.");
    }

    public async ValueTask<InvoicesItemsList> List(Soenneker.Stripe.OpenApiClient.V1.Invoiceitems.InvoiceitemsRequestBuilder.InvoiceitemsRequestBuilderGetQueryParameters options, StripeRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        var api = await client.Get(cancellationToken);
        return await api.V1.Invoiceitems.GetAsync(new(), c => { c.QueryParameters = options; requestOptions?.Apply(c.Headers); }, cancellationToken)
            ?? throw new InvalidOperationException("Stripe returned an empty response.");
    }

    public void Dispose() { }
    public ValueTask DisposeAsync() => ValueTask.CompletedTask;
}
