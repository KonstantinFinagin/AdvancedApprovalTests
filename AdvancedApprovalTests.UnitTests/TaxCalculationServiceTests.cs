using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AdvancedApprovalTests.BL.Services;
using AdvancedApprovalTests.DAL.Repositories;
using AdvancedApprovalTests.DAL.UnitOfWork;
using AdvancedApprovalTests.Domain;
using AdvancedApprovalTests.UnitTests.SampleData;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace AdvancedApprovalTests.UnitTests
{
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
                new TaxRate() { Id = 150, MinAmount = null, MaxAmount = null, Rate = 0.10m }
            });

            _incomeRepositoryMock.Setup(i => i.GetFiltered(2020)).ReturnsAsync(testRecords);
            
            var response = _service.CalculateYearlyTax(new List<long>() { 1 }, 2020);

            ApprovalTests.Approvals.Verify(JsonConvert.SerializeObject(response, Formatting.Indented));
        }
    }
}
