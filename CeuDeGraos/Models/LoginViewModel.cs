using System.ComponentModel.DataAnnotations;

namespace CeuDeGraos.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo CPF/CNPJ é obrigatório.")]
        public required string CpfCnpj { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [DataType(DataType.Password)]
        public required string Senha { get; set; }

    }
}