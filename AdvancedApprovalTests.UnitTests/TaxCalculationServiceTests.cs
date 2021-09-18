using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AdvancedApprovalTests.BL.Services;
using AdvancedApprovalTests.DAL.Repositories;
using AdvancedApprovalTests.DAL.UnitOfWork;
using AdvancedApprovalTests.Domain;
using AdvancedApprovalTests.UnitTests.SampleData;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace AdvancedApprovalTests.UnitTests
{
#if DEBUG
    [UseReporter(typeof(DiffReporter))]
#else
    [UseReporter(typeof(QuietReporter))]
#endif
    [UseApprovalSubdirectory("Results")]
    public class TaxCalculationServiceTests
    {
        private readonly TaxCalculationService _service;
        private readonly Mock<ITaxRateService> _rateServiceMock;
        private readonly Mock<IIncomeRecordsRepository> _incomeRepositoryMock;
        
        public TaxCalculationServiceTests()
        {
            _incomeRepositoryMock = new Mock<IIncomeRecordsRepository>();
            _rateServiceMock = new Mock<ITaxRateService>();

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(u => u.IncomeRecordsRepository).Returns(_incomeRepositoryMock.Object);

            _service = new TaxCalculationService(_rateServiceMock.Object, uowMock.Object);
        }

        [Fact]
        public async Task ShouldCalculateFlatTaxCorrectly()
        {
            var testRecords = TestEmployeeIncomeRecordFactory.GetTestIncomeRecords();

            _rateServiceMock.Setup(r => r.GetTaxRates(ETaxType.Flat)).Returns(new List<TaxRate>()
            {
                new TaxRate() { Id = 1, MinAmount = 0, MaxAmount = decimal.MaxValue, Rate = 0.10m }
            });

            _incomeRepositoryMock.Setup(i => i.GetFiltered(2020)).ReturnsAsync(testRecords);
            
            var response = await _service.CalculateYearlyTaxAsync(new List<long>() { 1 }, 2020, ETaxType.Flat);

            ApprovalTests.Approvals.Verify(JsonConvert.SerializeObject(response, Formatting.Indented));
        }

        [Fact]
        public async Task ShouldCalculateProgressiveTaxCorrectly()
        {
            var testRecords = TestEmployeeIncomeRecordFactory.GetTestIncomeRecords();
            _rateServiceMock.Setup(r => r.GetTaxRates(ETaxType.Progressive)).Returns(new List<TaxRate>()
            {
                new TaxRate() { Id = 1, MinAmount = 0, MaxAmount = 1000, Rate = 0.0m },
                new TaxRate() { Id = 2, MinAmount = 1001, MaxAmount = 5000, Rate = 0.10m },
                new TaxRate() { Id = 3, MinAmount = 5001, MaxAmount = 20000, Rate = 0.20m },
                new TaxRate() { Id = 4, MinAmount = 20001, MaxAmount = decimal.MaxValue, Rate = 0.30m }
            });

            _incomeRepositoryMock.Setup(i => i.GetFiltered(2020)).ReturnsAsync(testRecords);

            var response = await _service.CalculateYearlyTaxAsync(new List<long>() { 1 }, 2020, ETaxType.Progressive);

            ApprovalTests.Approvals.Verify(JsonConvert.SerializeObject(response, Formatting.Indented));
        }
    }
}
