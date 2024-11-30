using System.ComponentModel.DataAnnotations;

namespace CeuDeGraos.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public required string Email { get; set; }
    }
}