using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Task;
using Soenneker.Extensions.ValueTask;
using Soenneker.Stripe.Client.Abstract;
using Soenneker.Stripe.InvoiceItems.Abstract;
using Soenneker.Utils.AsyncSingleton;
using Stripe;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Stripe.InvoiceItems;

///<inheritdoc cref="IStripeInvoiceItemsUtil"/>
public sealed class StripeInvoiceItemsUtil : IStripeInvoiceItemsUtil
{
    private readonly ILogger<StripeInvoiceItemsUtil> _logger;
    private readonly AsyncSingleton<InvoiceItemService> _service;

    public StripeInvoiceItemsUtil(ILogger<StripeInvoiceItemsUtil> logger, IStripeClientUtil stripeUtil)
    {
        _logger = logger;
        _service = new AsyncSingleton<InvoiceItemService>(async (cancellationToken, _) =>
        {
            StripeClient client = await stripeUtil.Get(cancellationToken).NoSync();
            return new InvoiceItemService(client);
        });
    }

    public async ValueTask<InvoiceItem> Create(InvoiceItemCreateOptions options, RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        InvoiceItemService svc = await _service.Get(cancellationToken).NoSync();
        try
        {
            return await svc.CreateAsync(options, requestOptions, cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating invoice item {@Options}", options);
            throw;
        }
    }

    public async ValueTask<InvoiceItem> Get(string invoiceItemId, InvoiceItemGetOptions getOptions, RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        InvoiceItemService svc = await _service.Get(cancellationToken).NoSync();
        try
        {
            return await svc.GetAsync(invoiceItemId, getOptions, requestOptions, cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving invoice item {InvoiceItemId}", invoiceItemId);
            throw;
        }
    }

    public async ValueTask<InvoiceItem> Update(string invoiceItemId, InvoiceItemUpdateOptions options, RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        InvoiceItemService svc = await _service.Get(cancellationToken).NoSync();
        try
        {
            return await svc.UpdateAsync(invoiceItemId, options, requestOptions, cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating invoice item {InvoiceItemId} {@Options}", invoiceItemId, options);
            throw;
        }
    }

    public async ValueTask<InvoiceItem> Delete(string invoiceItemId, InvoiceItemDeleteOptions deleteOptions, RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        InvoiceItemService svc = await _service.Get(cancellationToken).NoSync();
        try
        {
            return await svc.DeleteAsync(invoiceItemId, deleteOptions, requestOptions, cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting invoice item {InvoiceItemId}", invoiceItemId);
            throw;
        }
    }

    public async ValueTask<StripeList<InvoiceItem>> List(InvoiceItemListOptions options, RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        InvoiceItemService svc = await _service.Get(cancellationToken).NoSync();
        try
        {
            return await svc.ListAsync(options, requestOptions, cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error listing invoice items {@Options}", options);
            throw;
        }
    }

    public void Dispose() => _service.Dispose();

    public ValueTask DisposeAsync()
    {
        return _service.DisposeAsync();
    }
}