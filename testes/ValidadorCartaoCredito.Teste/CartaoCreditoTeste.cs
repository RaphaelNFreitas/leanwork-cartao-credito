using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidadorCartaoCredito.Logica;

namespace ValidadorCartaoCredito.Teste
{
    [TestClass]
    public class CartaoCreditoTeste
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Numero_Do_Cartao_Nao_Deve_Ser_Vazio_Ou_Nulo()
        {
            var cartaoDeCredito = new CartaoCredito(string.Empty);
        }

        [TestMethod]
        public void Numero_Do_Cartao_Deve_Ser_Valido_Para_Tipo_Visa()
        {
            var cartaoDeCredito = new CartaoCredito("4408 0412 3456 7893");

            var resultado = cartaoDeCredito.EhValido();

            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void Numero_Do_Cartao_Deve_Ser_Invalido_Para_Tipo_Visa()
        {
            var cartaoDeCredito = new CartaoCredito("4417 1234 5678 9112");

            var resultado = cartaoDeCredito.EhValido();

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void Tipo_Do_Cartao_Deve_Ser_Visa_Valido()
        {
            var cartaoDeCredito = new CartaoCredito("4408 0412 3456 7893");

            var resultado = cartaoDeCredito.EhValido();

            Assert.AreEqual(cartaoDeCredito.TipoCartao, EnumTipoCartao.Visa);
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Tipo_Do_Cartao_Deve_Ser_Visa_Invalido()
        {
            var cartaoDeCredito = new CartaoCredito("4408 0412 3456 1234");

            var resultado = cartaoDeCredito.EhValido();

            Assert.AreEqual(cartaoDeCredito.TipoCartao, EnumTipoCartao.Visa);
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void Tipo_Do_Cartao_Deve_Ser_Amex_Valido()
        {
            var cartaoDeCredito = new CartaoCredito("378282246310005");

            var resultado = cartaoDeCredito.EhValido();

            Assert.AreEqual(cartaoDeCredito.TipoCartao, EnumTipoCartao.Amex);
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Tipo_Do_Cartao_Deve_Ser_Amex_Invalido()
        {
            var cartaoDeCredito = new CartaoCredito("378282246310505");

            var resultado = cartaoDeCredito.EhValido();

            Assert.AreEqual(cartaoDeCredito.TipoCartao, EnumTipoCartao.Amex);
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void Tipo_Do_Cartao_Deve_Ser_Discover_Valido()
        {
            var cartaoDeCredito = new CartaoCredito("6011111111111117");

            var resultado = cartaoDeCredito.EhValido();

            Assert.AreEqual(cartaoDeCredito.TipoCartao, EnumTipoCartao.Discover);
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Tipo_Do_Cartao_Deve_Ser_Discover_Invalido()
        {
            var cartaoDeCredito = new CartaoCredito("6011111111111717");

            var resultado = cartaoDeCredito.EhValido();

            Assert.AreEqual(cartaoDeCredito.TipoCartao, EnumTipoCartao.Discover);
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void Tipo_Do_Cartao_Deve_Ser_MasterCard_Valido()
        {
            var cartaoDeCredito = new CartaoCredito("5105105105105100");

            var resultado = cartaoDeCredito.EhValido();

            Assert.AreEqual(cartaoDeCredito.TipoCartao, EnumTipoCartao.MasterCard);
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Tipo_Do_Cartao_Deve_Ser_MasterCard_Invalido()
        {
            var cartaoDeCredito = new CartaoCredito("5105105105105106");

            var resultado = cartaoDeCredito.EhValido();

            Assert.AreEqual(cartaoDeCredito.TipoCartao, EnumTipoCartao.MasterCard);
            Assert.IsFalse(resultado);
        }
    }
}
