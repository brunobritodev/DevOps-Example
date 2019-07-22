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
            var ponto = new PontoDigital { PontoEntrada = DateTime.Now.Date.AddHours(9), PontoSaida = DateTime.Now.Date.AddHours(20) };

            ponto.ObterCargaExtra().Should().Be(2);
        }

        [Fact]
        public void DeveIndicarHorasExtra()
        {
            var ponto = new PontoDigital { PontoEntrada = DateTime.Now.Date.AddHours(9), PontoSaida = DateTime.Now.Date.AddHours(19) };

            ponto.TemHoraExtra().Should().Be(true);
        }
    }
}
