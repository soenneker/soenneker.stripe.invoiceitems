using System;
using System.Threading;
using System.Threading.Tasks;
using Stripe;

namespace Soenneker.Stripe.InvoiceItems.Abstract;

/// <summary>
/// Defines utility methods for managing Stripe invoice items.
/// </summary>
public interface IStripeInvoiceItemsUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Creates a new <see cref="InvoiceItem"/> in Stripe.
    /// </summary>
    /// <param name="options">
    /// The <see cref="InvoiceItemCreateOptions"/> to use when creating the invoice item.
    /// </param>
    /// <param name="requestOptions">
    /// Optional <see cref="RequestOptions"/> to control the Stripe API request.
    /// </param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> to cancel the operation.
    /// </param>
    /// <returns>
    /// The newly created <see cref="InvoiceItem"/>.
    /// </returns>
    ValueTask<InvoiceItem> Create(InvoiceItemCreateOptions options, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an existing <see cref="InvoiceItem"/> by its identifier.
    /// </summary>
    /// <param name="invoiceItemId">
    /// The identifier of the invoice item to retrieve.
    /// </param>
    /// <param name="getOptions">
    /// The <see cref="InvoiceItemGetOptions"/> to apply when fetching the item.
    /// </param>
    /// <param name="requestOptions">
    /// Optional <see cref="RequestOptions"/> to control the Stripe API request.
    /// </param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> to cancel the operation.
    /// </param>
    /// <returns>
    /// The requested <see cref="InvoiceItem"/>.
    /// </returns>
    ValueTask<InvoiceItem> Get(string invoiceItemId, InvoiceItemGetOptions getOptions, RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing <see cref="InvoiceItem"/> in Stripe.
    /// </summary>
    /// <param name="invoiceItemId">
    /// The identifier of the invoice item to update.
    /// </param>
    /// <param name="options">
    /// The <see cref="InvoiceItemUpdateOptions"/> specifying the changes.
    /// </param>
    /// <param name="requestOptions">
    /// Optional <see cref="RequestOptions"/> to control the Stripe API request.
    /// </param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> to cancel the operation.
    /// </param>
    /// <returns>
    /// The updated <see cref="InvoiceItem"/>.
    /// </returns>
    ValueTask<InvoiceItem> Update(string invoiceItemId, InvoiceItemUpdateOptions options, RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an existing <see cref="InvoiceItem"/> from Stripe.
    /// </summary>
    /// <param name="invoiceItemId">
    /// The identifier of the invoice item to delete.
    /// </param>
    /// <param name="deleteOptions">
    /// The <see cref="InvoiceItemDeleteOptions"/> to apply when deleting the item.
    /// </param>
    /// <param name="requestOptions">
    /// Optional <see cref="RequestOptions"/> to control the Stripe API request.
    /// </param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> to cancel the operation.
    /// </param>
    /// <returns>
    /// The deleted <see cref="InvoiceItem"/>.
    /// </returns>
    ValueTask<InvoiceItem> Delete(string invoiceItemId, InvoiceItemDeleteOptions deleteOptions, RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists <see cref="InvoiceItem"/> objects according to the given filter.
    /// </summary>
    /// <param name="options">
    /// The <see cref="InvoiceItemListOptions"/> used to filter the list.
    /// </param>
    /// <param name="requestOptions">
    /// Optional <see cref="RequestOptions"/> to control the Stripe API request.
    /// </param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> to cancel the operation.
    /// </param>
    /// <returns>
    /// A <see cref="StripeList{InvoiceItem}"/> containing the matching invoice items.
    /// </returns>
    ValueTask<StripeList<InvoiceItem>> List(InvoiceItemListOptions options, RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default);
}