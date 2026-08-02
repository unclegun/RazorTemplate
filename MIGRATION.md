# Migration guide

The native design system preserves the existing visual identity while moving to semantic HTML and modern CSS.

## Class mapping

| Old class | New class |
| --- | --- |
| `button-config` | `button` |
| `button-primary` | `button--primary` |
| `button-secondary` | `button--secondary` |
| `button-go` | `button--success` or `button--primary` |
| `button-stop` | `button--danger` |
| `button-yield` | `button--warning` |
| `site-card` | `card` |
| `site-card-header` | `card__header` |
| `site-card-body` | `card__body` |
| `container-input` | `form-field` |
| `text-align-center` | `u-text-center` |

## Compatibility approach

Temporary aliases are defined in the overrides layer in [wwwroot/css/site.css](wwwroot/css/site.css). These exist to support incremental migration and should be removed once existing views have been updated.
