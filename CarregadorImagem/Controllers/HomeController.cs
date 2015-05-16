using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarregadorImagem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Carregador()
        {
            ViewBag.Message = "Carregador de Imagem";

            return View();
        }

        [HttpPost]
        public ActionResult Carregador(HttpPostedFileBase arquivo)
        {
            if (arquivo == null)
            {
                ViewBag.Message = "Selecione o arquivo";
                return View();
            }

            var extensao = System.IO.Path.GetExtension(arquivo.FileName);

            if (extensao.Equals(".png", StringComparison.CurrentCultureIgnoreCase) ||
                extensao.Equals(".gif", StringComparison.CurrentCultureIgnoreCase) ||
                extensao.Equals(".jpg", StringComparison.CurrentCultureIgnoreCase))
            {
                var nomeUnico = string.Format("{0}_{1}{2}", System.IO.Path.GetFileNameWithoutExtension(arquivo.FileName),
                    DateTime.Now.Ticks, extensao);
                arquivo.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Arquivos"), nomeUnico));
                ViewBag.Message = "Carregado com sucesso.";
            }
            else
            {
                ViewBag.Message = "Somente arquivo com extensão png,gif ou jpg são permitidos.";
            }




            return View();
        }
     

    }
}