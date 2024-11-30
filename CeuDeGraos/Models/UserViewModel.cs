using System.ComponentModel.DataAnnotations;

namespace CeuDeGraos.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(255, ErrorMessage = "O nome pode ter no máximo 255 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Insira um email válido.")]
        [StringLength(255, ErrorMessage = "O email pode ter no máximo 255 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O CPF/CNPJ é obrigatório.")]
        [StringLength(20, ErrorMessage = "O CPF/CNPJ pode ter no máximo 20 caracteres.")]
        public string CPF_CNPJ { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(255, ErrorMessage = "A senha deve ter no máximo 255 caracteres.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "A confirmação da senha é obrigatória.")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmacaoSenha { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [StringLength(255, ErrorMessage = "O endereço pode ter no máximo 255 caracteres.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O tipo de usuário é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tipo de usuário pode ter no máximo 50 caracteres.")]
        public string TipoUsuario { get; set; } = "cliente";
        
        public override string ToString()
        {
            return $"Nome: {Nome}, Email: {Email}, CPF/CNPJ: {CPF_CNPJ}, Endereco: {Endereco}, TipoUsuario: {TipoUsuario}";
        }

        
    }





}
