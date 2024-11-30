using CeuDeGraos.Data;
using CeuDeGraos.Email.Config;
using CeuDeGraos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CeuDeGraos.Controllers;

public class RecuperacaoSenhaController : Controller
{
    private readonly ILogger<RecuperacaoSenhaController> _logger;

    private readonly BancoContext _dbContext;

    private readonly IEmailSender _emailSender;

    public RecuperacaoSenhaController(ILogger<RecuperacaoSenhaController> logger,
        BancoContext dbContext, IEmailSender emailSender)
    {
        _logger = logger;
        _dbContext = dbContext;
        _emailSender = emailSender;
    }

    public IActionResult FormularioEmail()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> EnvioFormularioEmail(ForgotPasswordViewModel model)
    {
        if (ModelState.IsValid)
        {
            var usuario = _dbContext.Usuarios.FirstOrDefault(u => u.Email == model.Email);

            if (usuario != null)
            {
                var linkRedefinicao = Url.Action("FormularioNovaSenha", "RecuperacaoSenha",
                    new { email = usuario.Email }, Request.Scheme);

                await _emailSender.SendEmailAsync(usuario.Email, "Redefinição de Senha",
                    $"<p>Olá {usuario.Nome},</p>" +
                    $"<p>Clique no link abaixo para redefinir sua senha:</p>" +
                    $"<a href='{linkRedefinicao}'>Redefinir Senha</a>");

                return View("ConfirmacaoEmailEnviado", new ForgotPasswordViewModel { Email = model.Email });
            }


            ModelState.AddModelError(string.Empty,
                "Se o e-mail estiver registrado, você receberá um link para redefinição.");
        }

        return View("FormularioEmail", model);
    }
    
    public IActionResult ConfirmacaoEmailEnviado()
    {
        return View();
    }


    [HttpGet]
    public IActionResult FormularioNovaSenha(string email)
    {
        return View(new ResetPasswordViewModel { Email = email });
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> EnvioFormularioNovaSenha(ResetPasswordViewModel model)
    {
        _logger.LogInformation(ModelState.IsValid.ToString());
        if (ModelState.IsValid)
        {
            var usuario = _dbContext.Usuarios.FirstOrDefault(u => u.Email == model.Email);

            if (usuario != null)
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(model.Password);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("ConfirmacaoSenhaAlterada");
            }

            ModelState.AddModelError(string.Empty, "Usuário não encontrado.");
        }
        
        

        return View("FormularioNovaSenha", model);
    }

    public IActionResult ConfirmacaoSenhaAlterada()
    {
        return View();
    }
}