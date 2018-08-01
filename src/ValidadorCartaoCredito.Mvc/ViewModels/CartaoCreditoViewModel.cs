using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ValidadorCartaoCredito.Logica;

namespace ValidadorCartaoCredito.Mvc.ViewModels
{
    public class CartaoCreditoViewModel
    {
        [DisplayName("Número")]
        [Required(ErrorMessage = "Informe o número do cartão de crédito")]
        public string Numero { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Tipo Do Cartão")]
        public EnumTipoCartao TipoCartao { get; set; }
    }
}