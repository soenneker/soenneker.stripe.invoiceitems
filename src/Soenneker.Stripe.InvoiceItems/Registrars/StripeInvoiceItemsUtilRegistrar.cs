using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Stripe.Client.Registrars;
using Soenneker.Stripe.InvoiceItems.Abstract;

namespace Soenneker.Stripe.InvoiceItems.Registrars;

/// <summary>
/// A .NET typesafe implementation of Stripe's Invoice Items API
/// </summary>
public static class StripeInvoiceItemsUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IStripeInvoiceItemsUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddStripeInvoiceItemsUtilAsSingleton(this IServiceCollection services)
    {
        services.AddStripeClientUtilAsSingleton().TryAddSingleton<IStripeInvoiceItemsUtil, StripeInvoiceItemsUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IStripeInvoiceItemsUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddStripeInvoiceItemsUtilAsScoped(this IServiceCollection services)
    {
        services.AddStripeClientUtilAsSingleton().TryAddScoped<IStripeInvoiceItemsUtil, StripeInvoiceItemsUtil>();

        return services;
    }
}
