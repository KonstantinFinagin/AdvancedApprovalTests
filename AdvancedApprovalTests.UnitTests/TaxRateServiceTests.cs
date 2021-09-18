using System.Globalization;
using System.Linq;
using AdvancedApprovalTests.BL.Services;
using AdvancedApprovalTests.Domain;
using AdvancedApprovalTests.UnitTests.Extensions;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using Newtonsoft.Json;
using Xunit;

namespace AdvancedApprovalTests.UnitTests
{
#if DEBUG
    // DIFF REPORTER is used to approve test results on a developer's machine
    [UseReporter(typeof(DiffReporter))]
#else
    // QUIET REPORTER is used when we run tests in CI/CD pipeline 
    [UseReporter(typeof(QuietReporter))]
#endif
    [UseApprovalSubdirectory("Results")]
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
            var response = _service.GetTaxRates(ETaxType.Flat);
            var jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);

            ApprovalTests.Approvals.Verify(jsonResponse);
        }

        [Fact]
        public void ShouldProvideCorrectRates_ForProgressiveTaxType()
        {
            var response = _service.GetTaxRates(ETaxType.Progressive);
            var jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);

            ApprovalTests.Approvals.Verify(jsonResponse);
        }

        [Fact]
        public void ShouldProvideCorrectRates_ForProgressiveTaxType_TableFormatting()
        {
            var response = _service.GetTaxRates(ETaxType.Progressive);

            var tableFormattedResponse = response.ToStringTable(
                ("Id", r => r.Id),
                ("Min Amount", r => r.MinAmount.ToString(CultureInfo.InvariantCulture)),
                ("Max Amount", r => (r.MaxAmount == decimal.MaxValue ? "MAX" : r.MaxAmount.ToString(CultureInfo.InvariantCulture))),
                ("Rate", r => r.Rate.ToString(CultureInfo.InvariantCulture))
            );

            ApprovalTests.Approvals.Verify(tableFormattedResponse);
        }
    }
}