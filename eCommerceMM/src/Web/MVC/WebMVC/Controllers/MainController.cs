using Core.Communication;
using WebMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers;


public class MainController : Controller
{
    protected bool ResponsePossuiErros(ResponseResult resposta)
    {
        if (resposta != null && resposta.Errors.Mensagens.Any())
        {
            foreach (var mensagem in resposta.Errors.Mensagens)
            {
                ModelState.AddModelError(string.Empty, mensagem);
            }

            return true;
        }

        return false;
    }

    protected void AdicionarErroValidacao(string mensagem)
    {
        ModelState.AddModelError(string.Empty, mensagem);
    }

    protected bool OperacaoValida()
    {
        return ModelState.ErrorCount == 0;
    }
}
