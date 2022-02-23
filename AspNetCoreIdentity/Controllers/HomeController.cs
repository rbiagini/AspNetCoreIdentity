using AspNetCoreIdentity.Extensions;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View((object)"Livre");
        }

        public IActionResult Privacy()
        {
            throw new Exception("Erro");
            return View((object)"Logado");
        }

        [Authorize(Roles = "Admin, Gestor")]
        public IActionResult Segredo()
        {
            return View((object)"Roles");
        }

        [Authorize(Policy = "PodeExcluir")]
        public IActionResult SegredoClaim()
        {
            return View("Segredo", "Policy = PodeExcluir");
        }

        [Authorize(Policy = "PodeEscrever")]
        public IActionResult SegredoClaimEscrever()
        {
            return View("Segredo", "Policy = PodeEscrever");
        }

        [ClaimAuthorize("Produtos", "Ler")]
        public IActionResult ClaimCustom()
        {
            return View("Segredo", "ClaimCustom");
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();

            if(id == 500)
            {
                modelErro.Titulo = "Ocorreu um erro!";
                modelErro.Mensagem = "Ocorreu um erro. Alguem fez caca. Entre em contato com a gente pra sabermos que raios você fez!";
                modelErro.ErrorCode = id;
            }
            else if (id == 404)
            {
                modelErro.Titulo = "Página não encontrada!";
                modelErro.Mensagem = "Essa página não existe! <br />Se você está acessando um link do sistema, entre em contato conosco para avisar que alguma coisa de errado não está certo!";
                modelErro.ErrorCode = id;
            }
            else if (id == 403)
            {
                modelErro.Titulo = "Acesso negado!";
                modelErro.Mensagem = "Você não pode mexer ai! <br />Não fica fuçando no sistema, mexe só no que é pra você!";
                modelErro.ErrorCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelErro);// new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
