namespace TripMatch.Xplore.Platform.IAM.Domain.Models.Commands;

/// <summary>
/// Comando para iniciar sesión
/// </summary>
public class SignInCommand
{
    public string Email { get; set; }
    public string Password { get; set; }
}