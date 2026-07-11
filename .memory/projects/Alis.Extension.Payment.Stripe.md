---
title: Alis.Extension.Payment.Stripe
tags:
  - project
  - payment
  - stripe
  - commerce
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Extension.Payment.Stripe

## Overview

Stripe payment processing integration (Layer 1 - Extension). Provides payment processing capabilities through Stripe API.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation (Extension) |
| **Project Path** | `1_Presentation/Extension/Payment/Stripe/src/` |
| **Test Project** | `Alis.Extension.Payment.Stripe.Test` |
| **Has Samples** | Yes (`Alis.Extension.Payment.Stripe.Sample`) |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)
- **NuGet**: Stripe.net v49.2.0

## Architecture

- Flat file structure in `src/`
- Key types: `StripeGatewayClient`, `StoreManager`, `CheckoutSessionResult`

## Related

- [[Projects Index]]
