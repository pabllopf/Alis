# Alis.Extension.Payment.Stripe

tags:
  - presentation,application,extension,documentation

## Overview

The **Alis.Extension.Payment.Stripe** project provides a comprehensive Stripe payment gateway integration for ALIS applications, supporting checkout sessions, payment intents, and refunds.

**Type**: Extension  
**Framework**: net8.0/netstandard2.0  
**Files**: 15 source files

## Purpose

This extension enables secure payment processing through Stripe API, providing a unified interface for e-commerce transactions, subscription management, and refund operations.

## Components

### Core Classes

| Class | Description | Lines |
|-------|-------------|-------|
| `StripeGatewayClient` | Main Stripe API adapter | 333 |
| `StoreManager` | Store management system | - |
| `IStoreManager` | Store manager interface | - |
| `IStripeGatewayClient` | Stripe gateway interface | - |

### Request/Response DTOs

| Type | Description |
|------|-------------|
| `StripeCheckoutSessionRequest` | Checkout session parameters |
| `StripeCheckoutSessionResponse` | Session result with URL |
| `StripePaymentIntentRequest` | Payment intent parameters |
| `StripePaymentIntentResponse` | Payment result |
| `StripeRefundRequest` | Refund parameters |
| `StripeRefundResponse` | Refund result |
| `StoreProduct` | Product definition |
| `StoreConfiguration` | Store settings |

## Architecture

### Design Pattern

Implements **Gateway Pattern** for Stripe API abstraction:

```csharp
public class StripeGatewayClient : IStripeGatewayClient
{
    private string _configuredApiKey;
    
    public void Configure(string secretApiKey)
    {
        StripeConfiguration.ApiKey = secretApiKey;
    }
}
```

### Validation Strategy

Comprehensive input validation for all requests:

```csharp
private static void ValidateCheckoutRequest(StripeCheckoutSessionRequest request)
{
    // Validates all required fields
    // Throws ArgumentException for invalid input
}
```

### Async/Await Pattern

All Stripe API calls are asynchronous:

```csharp
public async Task<StripeCheckoutSessionResponse> CreateCheckoutSessionAsync(...)
public async Task<StripePaymentIntentResponse> CreatePaymentIntentAsync(...)
```

## Public API

### Configuration

```csharp
var stripeClient = new StripeGatewayClient();
stripeClient.Configure("sk_test_your_secret_key");
```

### Checkout Sessions

```csharp
var checkoutRequest = new StripeCheckoutSessionRequest
{
    ProductName = "Premium Package",
    ProductDescription = "Full game access",
    Currency = "usd",
    UnitAmount = 999, // $9.99 in cents
    Quantity = 1,
    SuccessUrl = new Uri("https://game.com/success"),
    CancelUrl = new Uri("https://game.com/cancel"),
    CustomerEmail = "player@example.com",
    Metadata = new Dictionary<string, string>
    {
        { "userId", "12345" },
        { "orderId", "ORD-67890" }
    }
};

var session = await stripeClient.CreateCheckoutSessionAsync(checkoutRequest);
// Redirect user to session.Url
```

### Payment Intents

```csharp
var paymentRequest = new StripePaymentIntentRequest
{
    Amount = 1999, // $19.99
    Currency = "usd",
    Description = "In-game purchase",
    CustomerId = "cus_abc123", // Optional
    EnableAutomaticPaymentMethods = true,
    Metadata = new Dictionary<string, string>
    {
        { "itemId", "ITEM_001" }
    }
};

var paymentIntent = await stripeClient.CreatePaymentIntentAsync(paymentRequest);
// Use paymentIntent.ClientSecret for Stripe.js confirmation
```

### Refunds

```csharp
var refundRequest = new StripeRefundRequest
{
    PaymentIntentId = "pi_abc123",
    Amount = 500, // Partial refund of $5.00
    Reason = RefundReasons.Fraudulent
};

var refund = await stripeClient.CreateRefundAsync(refundRequest);
```

## Dependencies

```xml
<Project Sdk="Microsoft.NET.Sdk">
    <Import Project="$(SolutionDir).config/Config.props"/>
</Project>
```

**External Dependencies**:
- `Stripe.net` - Official Stripe SDK

**Internal Dependencies**:
- None (pure payment gateway)

## Validation Rules

### Checkout Session

- `ProductName` - Required, non-empty
- `Currency` - Required, valid ISO code
- `UnitAmount` - Must be > 0 (in cents)
- `Quantity` - Must be > 0
- `SuccessUrl` + `CancelUrl` - Both required

### Payment Intent

- `Amount` - Must be > 0 (in cents)
- `Currency` - Required, valid ISO code

### Refund

- `PaymentIntentId` - Required
- `Amount` - Optional (full refund if omitted)
- `Reason` - Optional, must match Stripe enum values

## Usage Example

```csharp
// Initialize Stripe
var storeManager = new StoreManager();
var stripeClient = new StripeGatewayClient();
stripeClient.Configure(Environment.GetEnvironmentVariable("STRIPE_SECRET_KEY"));

// Create checkout for in-game purchase
var request = new StripeCheckoutSessionRequest
{
    ProductName = "Gold Pack",
    ProductDescription = "1000 gold coins",
    Currency = "usd",
    UnitAmount = 499, // $4.99
    Quantity = 1,
    SuccessUrl = new Uri("https://game.com/payment/success"),
    CancelUrl = new Uri("https://game.com/payment/cancel"),
    CustomerEmail = player.Email,
    Metadata = new Dictionary<string, string>
    {
        { "playerId", player.Id.ToString() },
        { "packType", "gold_1000" }
    }
};

var session = await stripeClient.CreateCheckoutSessionAsync(request);

// Redirect player to Stripe checkout
player.RedirectTo(session.Url);

// After payment, verify payment intent
var payment = await stripeClient.GetPaymentIntentAsync(session.PaymentIntentId);

if (payment.Status == "succeeded")
{
    player.GainCoins(1000);
}
```

## Testing

**Test Project**: `Alis.Extension.Payment.Stripe.Test`  
**Sample Project**: `Alis.Extension.Payment.Stripe.Sample`

## Security Considerations

⚠️ **API Key Management**:
- Never expose secret key in client code
- Use server-side only for payment creation
- Store keys in secure configuration (environment variables, Azure Key Vault)

⚠️ **Webhook Verification**:
- Verify webhook signatures in production
- Handle idempotency for duplicate events

⚠️ **PCI Compliance**:
- Use Stripe.js or Payment Element for card data
- Never handle raw card numbers in your backend

## Status

| Aspect | Status |
|--------|--------|
| Implementation | ✓ Complete |
| Documentation | ✓ Documented |
| Tests | ✓ Unit tests exist |
| Samples | Pending |

## Related Projects

- [[projects/1_Presentation/Alis.Extension.Security]] - Secure data handling
- [[Alis.Core.Aspect.Logging]] - Logging system

## TODO

- [ ] Add webhook endpoint handling
- [ ] Implement subscription management
- [ ] Create sample e-commerce game
- [ ] Add integration tests with Stripe test mode
