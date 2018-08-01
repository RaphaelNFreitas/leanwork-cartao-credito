using System.Web.Mvc;
using ValidadorCartaoCredito.Logica;
using ValidadorCartaoCredito.Mvc.ViewModels;

namespace ValidadorCartaoCredito.Mvc.Controllers
{
    public class CartaoCreditoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CartaoCreditoViewModel cartaoCredito)
        {
            if (!ModelState.IsValid)
                return View(cartaoCredito);

            var cartaoDeCredito = new CartaoCredito(cartaoCredito.Numero);

            cartaoCredito.TipoCartao = cartaoDeCredito.TipoCartao;
            if (cartaoDeCredito.EhValido())
            {
                return PartialView("_Valido", cartaoCredito);
            }

            return PartialView("_Invalido", cartaoCredito);
        }
    }
}