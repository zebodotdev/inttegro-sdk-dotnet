## [Unreleased]

## [3.0.0] - 2026-09-03

- Breaking: resource methods now return concrete domain objects and pages instead of the generic transport response.
- Breaking: removed the public response wrapper and renamed payment result status constants to `PaymentResultStatus`.

## [2.0.0] - 2026-09-02

- Breaking: moved public request, response, enum, and domain types from `Inttegro.Models` to `Inttegro`.

## [1.0.0] - 2026-09-01

- Breaking: renamed the package, namespaces, client, response, and exception types to `Inttegro`.
- Aligned package metadata, examples, and the transport user agent with the public Inttegro service name.
