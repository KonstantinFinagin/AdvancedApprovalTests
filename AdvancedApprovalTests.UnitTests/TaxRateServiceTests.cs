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

            Assert.Single((IEnumerable)response);

            Assert.Equal(0.13m, response[0].Rate);
            Assert.Null(response[0].MinAmount);
            Assert.Null(response[0].MinAmount);
        }
    }
}