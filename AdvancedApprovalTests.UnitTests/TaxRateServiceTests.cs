using System.Collections;
using System.Linq;
using AdvancedApprovalTests.BL.Services;
using AdvancedApprovalTests.Domain;
using Xunit;

namespace AdvancedApprovalTests.UnitTests
{
    public class TaxRateServiceTest
    {
        private readonly TaxRateService _service;

        public TaxRateServiceTest()
        {
            _service = new TaxRateService();
        }

        [Fact]
        public void ShouldProvideCorrectRates_ForFlatTaxType()
        {
            var response = _service.GetTaxRates(ETaxType.Flat).ToList();

            Assert.Single(response);

            Assert.Equal(0.13m, response[0].Rate);
            Assert.Null(response[0].MinAmount);
            Assert.Null(response[0].MaxAmount);
        }

        [Fact]
        public void ShouldProvideCorrectRates_ForProgressiveTaxType()
        {
            var response = _service.GetTaxRates(ETaxType.Progressive).ToList();

            Assert.Equal(4, response.Count);

            Assert.Equal(0.00m, response[0].Rate);
            Assert.Equal(0,     response[0].MinAmount);
            Assert.Equal(1000,  response[0].MaxAmount);

            Assert.Equal(0.05m, response[1].Rate);
            Assert.Equal(1001,  response[1].MinAmount);
            Assert.Equal(5000,  response[1].MaxAmount);

            Assert.Equal(0.10m, response[2].Rate);
            Assert.Equal(5001,  response[2].MinAmount);
            Assert.Equal(10000, response[2].MaxAmount);

            Assert.Equal(0.20m,   response[3].Rate);
            Assert.Equal(10_001,  response[3].MinAmount);
            Assert.Equal(100_000, response[3].MaxAmount);

            Assert.Equal(0.35m,   response[4].Rate);
            Assert.Equal(100_001, response[4].MinAmount);
            Assert.Null(response[4].MaxAmount);
        }
    }
}