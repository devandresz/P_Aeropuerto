namespace AeropuertoWeb.Models;

public class ModuleDashboardViewModel
{
    public bool IsAdmin { get; set; }
    public IReadOnlyList<ModuleCardViewModel> Cards { get; set; } = Array.Empty<ModuleCardViewModel>();
}

public class ModuleCardViewModel
{
    public string Area { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Controller { get; set; } = "Modules";
    public string Action { get; set; } = "Index";
}

public class ModulePageViewModel
{
    public string Title { get; set; } = string.Empty;
    public string Eyebrow { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IReadOnlyList<MetricViewModel> Metrics { get; set; } = Array.Empty<MetricViewModel>();
    public IReadOnlyList<FieldViewModel> Filters { get; set; } = Array.Empty<FieldViewModel>();
    public string? SearchAction { get; set; }
    public IReadOnlyList<string> Headers { get; set; } = Array.Empty<string>();
    public IReadOnlyList<IReadOnlyList<CellViewModel>> Rows { get; set; } = Array.Empty<IReadOnlyList<CellViewModel>>();
    public FormViewModel? AdminForm { get; set; }
    public FormViewModel? ClientForm { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsClient { get; set; }
}

public class MetricViewModel
{
    public string Label { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}

public class FieldViewModel
{
    public string Label { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Placeholder { get; set; } = string.Empty;
    public string Type { get; set; } = "text";
    public string? Value { get; set; }
    public bool ReadOnly { get; set; }
    public string SpanClass { get; set; } = string.Empty;
    public string? HelpText { get; set; }
}

public class CellViewModel
{
    public string Text { get; set; } = string.Empty;
    public string? Status { get; set; }
}

public class FormViewModel
{
    public string Anchor { get; set; } = string.Empty;
    public string ButtonText { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string SubmitText { get; set; } = "Guardar cuando exista API";
    public string? Action { get; set; }
    public IReadOnlyList<FieldViewModel> Fields { get; set; } = Array.Empty<FieldViewModel>();
}
