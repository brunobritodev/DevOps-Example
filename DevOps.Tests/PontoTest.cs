using DevOps.Repository;
using FluentAssertions;
using System;
using Xunit;

namespace DevOps.Tests
{
    public class PontoTest
    {
        [Fact]
        public void DeveTerDuasHorasExtras()
        {
            var ponto = new PontoDigital { PontoEntrada = DateTime.Now.Date.AddHours(9), PontoSaida = DateTime.Now.Date.AddHours(19) };

            ponto.ObterCargaExtra().Should().Be(1);

        }

        [Fact]
        public void DeveIndicarHorasExtra()
        {
            var ponto = new PontoDigital { PontoEntrada = DateTime.Now.Date.AddHours(9), PontoSaida = DateTime.Now.Date.AddHours(19) };

            ponto.TemHoraExtra().Should().Be(true);
        }

        [Fact]
        public void DeveRetornarASoma()
        {
            var calculadora = new Calculadora();
            calculadora.Somar(8, 10).Should().Be(18);
        }

        [Fact]
        public void DeveRetornarAMultiplicacao()
        {
            var calculadora = new Calculadora();
            calculadora.Multiplicar(8, 10).Should().Be(80);
        }
    }

    public class Calculadora
    {
        public int Somar(int a, int b)
        {
            return a + b;
        }

        public int Multiplicar(int a, int b)
        {
            return a * b;
        }
    }
}
