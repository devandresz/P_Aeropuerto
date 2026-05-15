namespace AeropuertoWeb.Models;

public class LoginViewModel
{
    public string SelectedRole { get; set; } = "Cliente";
    public string? ClientEmail { get; set; }
    public string? ClientPassword { get; set; }
    public string? AdminUser { get; set; }
    public string? AdminPassword { get; set; }
    public string? AdminCode { get; set; }
    public string? Message { get; set; }
}
