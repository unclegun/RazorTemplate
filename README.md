# RazorTemplate

This repository now contains a native ASP.NET Core Razor Pages design-system foundation with layered CSS, reusable Tag Helpers, an example design-system page, and a static GitHub Pages documentation site.

## Quick start

```bash
dotnet build
dotnet run
```

## Example usage

```razor
<ui-card title="Study Summary">
    <ui-card-body>
        <ui-field asp-for="Input.StudyName" />
    </ui-card-body>

    <ui-card-footer>
        <ui-button variant="Secondary" asp-page="./Index">
            Cancel
        </ui-button>

        <ui-button variant="Primary" type="submit">
            Save
        </ui-button>
    </ui-card-footer>
</ui-card>
```

## Notes

- The static GitHub Pages content lives in [docs](docs).
- The workflow for deployment is in [.github/workflows/pages.yml](.github/workflows/pages.yml).
- Migration guidance is in [MIGRATION.md](MIGRATION.md).
