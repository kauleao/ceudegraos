using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CeuDeGraos.Models;

public class Usuario
{
    public int UsuarioID { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string CPF_CNPJ { get; set; }
    public string Senha { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    public string Endereco { get; set; }
    public string TipoUsuario { get; set; }
    public bool Ativo { get; set; } = true;
}