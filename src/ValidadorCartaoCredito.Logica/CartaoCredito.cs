using System;
using System.Linq;

namespace ValidadorCartaoCredito.Logica
{
    /*
     *  Tipo de Cartão	começa com	Número Comprimento
     *  AMEX	         34 ou 37	15
     *  Discover	        6011	16
     *  MasterCard	       51-55	16
     *  Visa	               4	13 ou 16
     */
    public class CartaoCredito
    {
        public CartaoCredito(string numero)
        {
            if(string.IsNullOrEmpty(numero))
                throw new ArgumentNullException(nameof(numero));

            Numero = numero.Replace("-", "").Replace(" ", "");
            TipoCartao = ObterTipoDoCartao();
        }

        public EnumTipoCartao TipoCartao { get; private set; }
        public string Numero { get; private set; }

        private EnumTipoCartao ObterTipoDoCartao()
        {
            if (string.IsNullOrEmpty(Numero))
                return EnumTipoCartao.Desconhecido;

            if (Numero.StartsWith("60"))
            {
                var digitos = Numero.Substring(0, 4);

                if (digitos == "6011" && Numero.Length == 16)
                    return EnumTipoCartao.Discover;

                return EnumTipoCartao.Desconhecido;
            }

            if (Numero.StartsWith("4") && (Numero.Length <= 16 && Numero.Length >= 13))
                return EnumTipoCartao.Visa;

            if (Numero.StartsWith("5"))
            {
                var digitos = Numero.Substring(0, 2);

                if (int.TryParse(digitos, out var convertido))
                {
                    if (convertido >= 51 || convertido <= 55 && Numero.Length == 16)
                        return EnumTipoCartao.MasterCard;
                }

                return EnumTipoCartao.Desconhecido;
            }

            var doisDigitos = Numero.Substring(0, 2);

            if ((doisDigitos == "34" || doisDigitos == "37") && Numero.Length == 15)
                return EnumTipoCartao.Amex;

            return EnumTipoCartao.Desconhecido;
        }


        public bool EhValido()
        {
            if (string.IsNullOrEmpty(Numero))
                return false;

            var checkSoma = default(int);
            var digitoPar = false;

            foreach (var digito in Numero.Reverse())
            {
                if (digito < '0' || digito > '9')
                    return false;

                var valorDoDigito = (digito - '0') * (digitoPar ? 2 : 1);
                digitoPar = !digitoPar;

                while (valorDoDigito > 0)
                {
                    checkSoma += valorDoDigito % 10;
                    valorDoDigito /= 10;
                }
            }

            return (checkSoma % 10) == 0;
        }
    }
}