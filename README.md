# HTTP Partial Content 206

Examples of sending Partial Content in different stacks (without streams).

## Quirks

1. Browsers cache text response, if you wanna see immediate response, set `Contetn-Type: application/json`
2. Some stacks require `206` Partial Content Status
