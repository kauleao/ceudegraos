using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CeuDeGraos.Models;
using CeuDeGraos.Data;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CeuDeGraos.Controllers;

public class CadastroController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly BancoContext _dbContext;
    public CadastroController(ILogger<HomeController> logger, BancoContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Formulario()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Cadastrar(UserViewModel formulario)
    {
        _logger.LogInformation(formulario.ToString());
        if (ModelState.IsValid)
        {
            bool emailExists = await _dbContext.Usuarios.AnyAsync(u => u.Email == formulario.Email);
            if (emailExists)
            {
                ModelState.AddModelError("Email", "Este email já está cadastrado.");
                return View("Formulario", formulario);
            }
            
            bool cpfCnpjExists = await _dbContext.Usuarios.AnyAsync(u => u.CPF_CNPJ == formulario.CPF_CNPJ);
            if (cpfCnpjExists)
            {
                ModelState.AddModelError("CPF_CNPJ", "Este CPF/CNPJ já está cadastrado.");
                return View("Formulario", formulario);
            }

            // Hash da senha
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(formulario.Senha);

            var usuario = new Usuario
            {
                Nome = formulario.Nome,
                Email = formulario.Email,
                CPF_CNPJ = Regex.Replace(formulario.CPF_CNPJ, @"\D", ""),
                Senha = hashedPassword,
                DataCadastro = DateTime.Now,
                Endereco = formulario.Endereco,
                TipoUsuario = formulario.TipoUsuario,
                Ativo = true
            };

            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("ConfirmacaoCadastro", "Cadastro");
        }

        return View("Formulario", formulario);
    }

    public IActionResult ConfirmacaoCadastro()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}