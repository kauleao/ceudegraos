using System.ComponentModel.DataAnnotations;

namespace CeuDeGraos.Models
{
    public class ClienteViewModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail não é válido.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "A confirmação de senha é obrigatória.")]
        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        public required string ConfirmPassword { get; set; }

        public string? Cpf { get; set; }

        public DateOnly? DtNasc { get; set; }

        public string? NmCliente { get; set; }

        public string? Cnpj { get; set; }

        public string? RazaoSocial { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        public required string Telefone { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        public required string CEP { get; set; }

        public override string ToString()
        {
            return $"ClienteViewModel:\n" +
                   $"Email: {Email}\n" +
                   $"Password: {Password}\n" +
                   $"ConfirmPassword: {ConfirmPassword}\n" +
                   $"Cpf: {Cpf ?? "N/A"}\n" +
                   $"DtNasc: {DtNasc?.ToString() ?? "N/A"}\n" +
                   $"NmCliente: {NmCliente ?? "N/A"}\n" +
                   $"Cnpj: {Cnpj ?? "N/A"}\n" +
                   $"RazaoSocial: {RazaoSocial ?? "N/A"}\n" +
                   $"Telefone: {Telefone}\n" +
                   $"CEP: {CEP}";
        }
    }




}
